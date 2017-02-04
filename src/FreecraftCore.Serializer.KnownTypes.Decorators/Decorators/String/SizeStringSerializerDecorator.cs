﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JetBrains.Annotations;


namespace FreecraftCore.Serializer.KnownTypes
{
	public class SizeStringSerializerDecorator : ITypeSerializerStrategy<string>
	{
		/// <inheritdoc />
		public SerializationContextRequirement ContextRequirement { get; } = SerializationContextRequirement.RequiresContext;

		/// <inheritdoc />
		public Type SerializerType { get; } = typeof(string);

		/// <summary>
		/// Provides the size of the fixed string.
		/// </summary>
		[NotNull]
		public IStringSizeStrategy sizeProvider { get; }

		/// <summary>
		/// The string serializer that is being decorated.
		/// </summary>
		[NotNull]
		private ITypeSerializerStrategy<string> decoratedSerializer { get; }

		public SizeStringSerializerDecorator([NotNull] IStringSizeStrategy size, [NotNull] ITypeSerializerStrategy<string> stringSerializer)
		{
			if (size == null) throw new ArgumentNullException(nameof(size));
			if (stringSerializer == null) throw new ArgumentNullException(nameof(stringSerializer));

			sizeProvider = size;
			decoratedSerializer = stringSerializer;
		}

		/// <inheritdoc />
		public string Read(IWireMemberReaderStrategy source)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));

			//The size must come from the strategy provided
			int size = sizeProvider.Size(source);

			byte[] bytes = source.ReadBytes(size);

			//TODO: Pointer hack for preformance
			//This is the only way to remove padding that I know of
			//There may be a more efficient way of removing the padding
			//There is actually an unsafe pointer hack to improve preformance here too.
			//profile and add later.
			return Encoding.ASCII.GetString(bytes).TrimEnd('\0'); 
		}

		/// <inheritdoc />
		public void Write([NotNull] string value, IWireMemberWriterStrategy dest)
		{
			if (value == null) throw new ArgumentNullException(nameof(value));
			if (dest == null) throw new ArgumentNullException(nameof(dest));

			int size = sizeProvider.Size(value, dest);

			//Now that we know the size, and the header will be written if it was needed, we can write it
			//Don't write the size. Leave it up to the strategy above
			decoratedSerializer.Write(value, dest);

			//the tricky part here is that the serializer just wrote the string plus the null terminator
			//So, if the length of the string was less than the expected size write some more 0s.
			//However, DO NOT write another null terminator either way because we already have one.
			if (value.Length < size)
				dest.Write(new byte[(size - value.Length)]);
		}

		/// <inheritdoc />
		public void Write(object value, IWireMemberWriterStrategy dest)
		{
			Write((string)value, dest);
		}

		/// <inheritdoc />
		object ITypeSerializerStrategy.Read(IWireMemberReaderStrategy source)
		{
			return Read(source);
		}

		public string Read(ref string obj, IWireMemberReaderStrategy source)
		{
			obj = Read(source);

			return obj;
		}
	}
}
