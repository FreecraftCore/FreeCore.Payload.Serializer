using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using FreecraftCore.Serializer;
using FreecraftCore.Serializer.CustomTypes;

namespace FreecraftCore.Serializer
{
    //THIS CODE IS FOR AUTO-GENERATED SERIALIZERS! DO NOT MODIFY UNLESS YOU KNOW WELL!
    /// <summary>
    /// FreecraftCore.Serializer's AUTO-GENERATED (do not edit) serialization
    /// code for the Type: <see cref="TypeStubGenericDouble<Int32,String>"/>
    /// </summary>
    public sealed partial class TypeStubGenericDouble_Int32String_AutoGeneratedTemplateSerializerStrategy
        : BaseAutoGeneratedSerializerStrategy<TypeStubGenericDouble_Int32String_AutoGeneratedTemplateSerializerStrategy, TypeStubGenericDouble<Int32,String>>
    {
        /// <summary>
        /// Auto-generated deserialization/read method.
        /// Partial method implemented from shared partial definition.
        /// </summary>
        /// <param name="value">See external doc.</param>
        /// <param name="buffer">See external doc.</param>
        /// <param name="offset">See external doc.</param>
        public override void InternalRead(TypeStubGenericDouble<Int32,String> value, Span<byte> buffer, ref int offset)
        {
            //Type: TypeStubGenericDouble Field: 1 Name: Value Type: Int32;
            value.Value = GenericTypePrimitiveSerializerStrategy<Int32>.Instance.Read(buffer, ref offset);
            //Type: TypeStubGenericDouble Field: 2 Name: Value2 Type: String;
            value.Value2 = TerminatedStringTypeSerializerStrategy<UTF16StringTypeSerializerStrategy, UTF16StringTerminatorTypeSerializerStrategy>.Instance.Read(buffer, ref offset);
        }

        /// <summary>
        /// Auto-generated serialization/write method.
        /// Partial method implemented from shared partial definition.
        /// </summary>
        /// <param name="value">See external doc.</param>
        /// <param name="buffer">See external doc.</param>
        /// <param name="offset">See external doc.</param>
        public override void InternalWrite(TypeStubGenericDouble<Int32,String> value, Span<byte> buffer, ref int offset)
        {
            //Type: TypeStubGenericDouble Field: 1 Name: Value Type: Int32;
            GenericTypePrimitiveSerializerStrategy<Int32>.Instance.Write(value.Value, buffer, ref offset);
            //Type: TypeStubGenericDouble Field: 2 Name: Value2 Type: String;
            TerminatedStringTypeSerializerStrategy<UTF16StringTypeSerializerStrategy, UTF16StringTerminatorTypeSerializerStrategy>.Instance.Write(value.Value2, buffer, ref offset);
        }
    }
}