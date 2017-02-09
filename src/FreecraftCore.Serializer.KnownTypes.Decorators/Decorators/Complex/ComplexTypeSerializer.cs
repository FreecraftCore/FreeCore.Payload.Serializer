﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using JetBrains.Annotations;

namespace FreecraftCore.Serializer
{
	public abstract class ComplexTypeSerializer<TType> : ITypeSerializerStrategy<TType>
	{
		/// <inheritdoc />
		public virtual Type SerializerType { get; } = typeof(TType);

		/// <inheritdoc />
		public SerializationContextRequirement ContextRequirement { get; } = SerializationContextRequirement.Contextless;

		//We use an array now for more performant iteration
		/// <summary>
		/// Ordered pairs of known serializer references and the memberinfos for wiremembers.
		/// </summary>
		[NotNull]
		protected IMemberSerializationMediator<TType>[] orderedMemberInfos { get; }

		/// <summary>
		/// General serializer provider service.
		/// </summary>
		[NotNull]
		protected IGeneralSerializerProvider serializerProviderService { get; }

		protected ComplexTypeSerializer([NotNull] IEnumerable<IMemberSerializationMediator<TType>> serializationDirections, [NotNull] IGeneralSerializerProvider serializerProvider)
		{
			//These can be empty. If there are no members on a type there won't be anything to serialize.
			if (serializationDirections == null)
				throw new ArgumentNullException(nameof(serializationDirections), $"Provided argument {nameof(serializationDirections)} is null.");

			if (serializerProvider == null)
				throw new ArgumentNullException(nameof(serializerProvider), $"Provided {nameof(serializerProvider)} service was null.");

			orderedMemberInfos = serializationDirections.ToArray();
			serializerProviderService = serializerProvider;
		}

		/// <inheritdoc />
		public abstract TType Read(IWireStreamReaderStrategy source);

		/// <inheritdoc />
		public abstract void Write(TType value, IWireStreamWriterStrategy dest);

		/// <inheritdoc />
		void ITypeSerializerStrategy.Write(object value, IWireStreamWriterStrategy dest)
		{
			Write((TType)value, dest);
		}

		/// <inheritdoc />
		object ITypeSerializerStrategy.Read(IWireStreamReaderStrategy source)
		{
			return Read(source);
		}

		protected void SetMembersFromReaderData(TType obj, [NotNull] IWireStreamReaderStrategy source)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));

			//replaced for perf
			/*foreach (IMemberSerializationMediator<TType> serializerInfo in orderedMemberInfos)
			{
				serializerInfo.SetMember(obj, source);
			}*/
			for(int i = 0; i < orderedMemberInfos.Length; i++)
				orderedMemberInfos[i].SetMember(obj, source);
		}

		protected void WriteMemberData(TType obj, [NotNull] IWireStreamWriterStrategy dest)
		{
			if (dest == null) throw new ArgumentNullException(nameof(dest));

			//replaced for perf
			/*foreach (IMemberSerializationMediator<TType> serializerInfo in orderedMemberInfos)
			{
				serializerInfo.WriteMember(obj, dest);
			}*/
			for (int i = 0; i < orderedMemberInfos.Length; i++)
				orderedMemberInfos[i].WriteMember(obj, dest);
		}

		public object ReadIntoObject(ref object obj, IWireStreamReaderStrategy source)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));

			TType castedObj = (TType) obj;

			return ReadIntoObject(ref castedObj, source);
		}

				/// <inheritdoc />
		public TType ReadIntoObject(ref TType obj, IWireStreamReaderStrategy source)
		{
			if (obj == null) throw new ArgumentNullException(nameof(obj));
			if (source == null) throw new ArgumentNullException(nameof(source));

			//Basically if someone calls this method they want us to set the members from the reader
			SetMembersFromReaderData(obj, source);

			return obj;
		}

		public void ObjectIntoWriter(object obj, IWireStreamWriterStrategy dest)
		{
			if (obj == null) throw new ArgumentNullException(nameof(obj));

			ObjectIntoWriter((TType)obj, dest);
		}

		public void ObjectIntoWriter(TType obj, IWireStreamWriterStrategy dest)
		{
			if (obj == null) throw new ArgumentNullException(nameof(obj));
			if (dest == null) throw new ArgumentNullException(nameof(dest));

			//This method is only responsible for writing the members
			//Even if we're suppose to write type data for this type we don't
			//Just members
			WriteMemberData(obj, dest);
		}
	}
}