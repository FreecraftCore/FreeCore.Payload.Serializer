﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Fasterflect;
using JetBrains.Annotations;

namespace FreecraftCore.Serializer.KnownTypes
{
	public class SubComplexTypeWithFlagsSerializerDecorator<TBaseType> : SubComplexTypeSerializer<TBaseType>
	{
		private class ChildKeyPair
		{
			/// <summary>
			/// Flags to check for to verify type information.
			/// </summary>
			public int Flags { get; }

			/// <summary>
			/// Child type.
			/// </summary>
			[NotNull]
			public ITypeSerializerStrategy Serializer { get; }

			public ChildKeyPair(int flags, [NotNull] ITypeSerializerStrategy serializer)
			{
				if (serializer == null) throw new ArgumentNullException(nameof(serializer));

				Flags = flags;
				Serializer = serializer;
			}
		}

		/// <summary>
		/// Provides read and write stragey for child keys.
		/// </summary>
		[NotNull]
		private IChildKeyStrategy keyStrategy { get; }

		//use array for performance
		private ChildKeyPair[] serializers { get; }

		//TODO: Reimplement default type handling cleanly
		[CanBeNull]
		public ITypeSerializerStrategy DefaultSerializer { get; }

		public SubComplexTypeWithFlagsSerializerDecorator([NotNull] IDeserializationPrototypeFactory<TBaseType> prototypeGenerator, [NotNull] IEnumerable<IMemberSerializationMediator<TBaseType>> serializationDirections, 
			[NotNull] IGeneralSerializerProvider serializerProvider, [NotNull] IChildKeyStrategy childKeyStrategy)
			: base(prototypeGenerator, serializationDirections, serializerProvider)
		{

			if (childKeyStrategy == null)
				throw new ArgumentNullException(nameof(childKeyStrategy), $"Provided {nameof(IChildKeyStrategy)} used for key read and write is null.");

			keyStrategy = childKeyStrategy;

			DefaultSerializer = typeof(TBaseType).Attribute<DefaultChildAttribute>() != null
				? serializerProviderService.Get(typeof(TBaseType).Attribute<DefaultChildAttribute>().ChildType) : null;

			//We no longer reserve 0. Sometimes type information of a child is sent as a 0 in WoW protocol. We can opt for mostly metadata market style interfaces.

			List<ChildKeyPair> pairs = new List<ChildKeyPair>();

			foreach (WireDataContractBaseTypeByFlagsAttribute waf in typeof(TBaseType).Attributes<WireDataContractBaseTypeByFlagsAttribute>())
			{
				if (!typeof(TBaseType).IsAssignableFrom(waf.ChildType))
					throw new InvalidOperationException($"Failed to register Type: {typeof(TBaseType).GetType().FullName} because a provided ChildType: {waf.ChildType.FullName} was not actually a child.");

				//TODO: Maybe add a priority system for flags that may override others?
				pairs.Add(new ChildKeyPair(waf.Flag, serializerProviderService.Get(waf.ChildType)));
			}

			serializers = pairs.ToArray();
		}

		/// <summary>
		/// Perform the steps necessary to serialize this data.
		/// </summary>
		/// <param name="value">The value to be serialized.</param>
		/// <param name="dest">The writer entity that is accumulating the output data.</param>
		public override void Write(TBaseType value, IWireStreamWriterStrategy dest)
		{
			if (dest == null) throw new ArgumentNullException(nameof(dest));

			//TODO: Test perf
			//Defer key writing to the key writing strategy
			foreach (ChildKeyPair childKey in serializers)
				if(childKey.Serializer.SerializerType == value.GetType())
				{

					//Well, what do we do? Do we just write the flag?
					//It's the best we can do I think. Otherwise they should use NoConsume
					//to better define the flag written themselves
					keyStrategy.Write(childKey.Flags, dest);

					//Now write
					childKey.Serializer.Write(value, dest);
					return;
				}

			//We can't write default types.
			throw new InvalidOperationException($"Failed to serialize Type: {value.GetType().FullName}. No prepared serializer could be found. Make sure to properly setup child mapping.");
		}

		/// <inheritdoc />
		public override TBaseType Read(IWireStreamReaderStrategy source)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));

			//TODO: Handle 0 flags
			//Ask the key strategy for what flags are present
			int flags = keyStrategy.Read(source); //defer to key reader (could be int, byte or something else)

			//TODO: Test perf
			foreach (ChildKeyPair childKey in serializers)
			{
				if ((childKey.Flags & flags) != 0)
					return (TBaseType)childKey.Serializer.Read(source);
			}

			//If we didn't find a flags for it then try the default
			if (DefaultSerializer != null)
				return (TBaseType)DefaultSerializer.Read(source);
			else
				throw new InvalidOperationException($"{this.GetType()} attempted to deserialize to a child type with Flags: {flags} but no valid type matches and there is no default type.");
		}
	}
}