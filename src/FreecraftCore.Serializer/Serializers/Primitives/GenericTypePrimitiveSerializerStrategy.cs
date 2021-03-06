﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FreecraftCore.Serializer
{
	//TODO: Cannot support Char due to encoding differences.
	/// <summary>
	/// Contract for type serializer that is a primitive and generic.
	/// </summary>
	/// <typeparam name="TType"></typeparam>
	public sealed class GenericTypePrimitiveSerializerStrategy<TType> : StatelessTypeSerializerStrategy<GenericTypePrimitiveSerializerStrategy<TType>, TType>
		where TType : struct
	{
		static GenericTypePrimitiveSerializerStrategy()
		{
			if (!typeof(TType).IsPrimitive)
				throw new InvalidOperationException($"Cannot use {nameof(GenericTypePrimitiveSerializerStrategy<TType>)} for Type: {typeof(TType).Name} as it's not a primitive type.");
		}

		/// <inheritdoc />
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override TType Read(Span<byte> buffer, ref int offset)
		{
			TType value = Unsafe.ReadUnaligned<TType>(ref buffer[offset]);
			offset += MarshalSizeOf<TType>.SizeOf;
			return value;
		}

		/// <inheritdoc />
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override void Write(TType value, Span<byte> buffer, ref int offset)
		{
			Unsafe.As<byte, TType>(ref buffer[offset]) = value;
			offset += MarshalSizeOf<TType>.SizeOf;
		}
	}
}
