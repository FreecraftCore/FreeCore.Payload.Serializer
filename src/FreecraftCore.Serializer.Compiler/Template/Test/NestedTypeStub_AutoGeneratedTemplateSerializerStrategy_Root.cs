using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace FreecraftCore.Serializer
{
    //THIS CODE IS FOR AUTO-GENERATED SERIALIZERS! DO NOT MODIFY UNLESS YOU KNOW WELL!
    /// <summary>
    /// FreecraftCore.Serializer's AUTO-GENERATED (do not edit) serialization
    /// code for the Type: <see cref="NestedTypeStub"/>
    /// </summary>
    [AutoGenerated]
    public sealed partial class NestedTypeStub_AutoGeneratedTemplateSerializerStrategy
        : BaseAutoGeneratedSerializerStrategy<NestedTypeStub_AutoGeneratedTemplateSerializerStrategy, NestedTypeStub>
    {
        /// <summary>
        /// Auto-generated deserialization method.
        /// </summary>
        /// <param name="value">Value to initialize.</param>
        /// <param name="source">The source data buffer.</param>
        /// <param name="offset">The initial offset into the source buffer.</param>
        protected override void InternalRead(NestedTypeStub value, Span<byte> source, ref int offset)
        {
            GeneratedRead(value, source, ref offset);
        }

        //Actual partial serialization auto-generated and implemented in external partial class.
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        partial void GeneratedRead(NestedTypeStub value, Span<byte> source, ref int offset);

        /// <summary>
        /// Aut-generated serialization method.
        /// </summary>
        /// <param name="value">The value to write data from.</param>
        /// <param name="destination">The destination data buffer.</param>
        /// <param name="offset">The initial offset into the destination buffer</param>
        protected override void InternalWrite(NestedTypeStub value, Span<byte> destination, ref int offset)
        {
            GeneratedWrite(value, destination, ref offset);
        }

        //Actual partial serialization auto-generated and implemented in external partial class.
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        partial void GeneratedWrite(NestedTypeStub value, Span<byte> destination, ref int offset);
    }
}