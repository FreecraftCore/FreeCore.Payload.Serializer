using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace FreecraftCore.Serializer
{
    //THIS CODE IS FOR AUTO-GENERATED SERIALIZERS! DO NOT MODIFY UNLESS YOU KNOW WELL!
    /// <summary>
    /// FreecraftCore.Serializer's AUTO-GENERATED (do not edit) serialization
    /// code for the Type: <see cref="TypeStub"/>
    /// </summary>
    public sealed partial class TypeStub_AutoGeneratedTemplateSerializerStrategy
        : BaseAutoGeneratedSerializerStrategy<TypeStub_AutoGeneratedTemplateSerializerStrategy, TypeStub>
    {
        /// <summary>
        /// Auto-generated deserialization/read method.
        /// Partial method implemented from shared partial definition.
        /// </summary>
        /// <param name="value">See external doc.</param>
        /// <param name="source">See external doc.</param>
        /// <param name="offset">See external doc.</param>
        partial void GeneratedRead(TypeStub value, Span<byte> source, ref int offset)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Auto-generated serialization/write method.
        /// Partial method implemented from shared partial definition.
        /// </summary>
        /// <param name="value">See external doc.</param>
        /// <param name="destination">See external doc.</param>
        /// <param name="offset">See external doc.</param>
        partial void GeneratedWrite(TypeStub value, Span<byte> destination, ref int offset)
        {
            //Field: 1 Name: Hello Type: Int32;
            GenericTypePrimitiveSerializerStrategy<Int32>.Instance.Write(value.Hello, destination, ref offset);
            //Field: 2 Name: TestString Type: String;
            LengthPrefixedStringTypeSerializerStrategy<UTF32StringTypeSerializerStrategy, UTF32StringTerminatorTypeSerializerStrategy, UInt16>.Instance.Write(value.TestString, destination, ref offset);
            //Field: 3 Name: HelloAgain Type: UInt16;
            GenericTypePrimitiveSerializerStrategy<UInt16>.Instance.Write(value.HelloAgain, destination, ref offset);
            //Field: 4 Name: TestStringTwo Type: String;
            DontTerminateLengthPrefixedStringTypeSerializerStrategy<ASCIIStringTypeSerializerStrategy, Int16>.Instance.Write(value.TestStringTwo, destination, ref offset);
            //Field: 5 Name: KnownSizeStringTest Type: String;
            KnownSizeStringSerializerHelper.Write(value.KnownSizeStringTest, destination, ref offset, 1337, EncodingType.UTF16, false);
            //Field: 6 Name: DefaultStringTest Type: String;
            DefaultStringSerializerHelper.Write(value.DefaultStringTest, destination, ref offset, EncodingType.UTF16, true);
            //Field: 6 Name: LongArrayTest Type: Int64[];
            PrimitiveArraySerializerHelper.Write(value.LongArrayTest, destination, ref offset, (Int16)(value.LongArrayTest.Length), true);
            //Field: 7 Name: KnownSizeArrayTest Type: UInt16[];
            PrimitiveArraySerializerHelper.Write(value.KnownSizeArrayTest, destination, ref offset, (Int32)(1337), false);
            //Field: 8 Name: EnumTestValue Type: TestEnum;
            GenericPrimitiveEnumTypeSerializerStrategy<TestEnum, UInt64>.Instance.Write(value.EnumTestValue, destination, ref offset);
            //Field: 9 Name: LongArrayTestAddedSize Type: Int64[];
            PrimitiveArraySerializerHelper.Write(value.LongArrayTestAddedSize, destination, ref offset, (Int16)(value.LongArrayTestAddedSize.Length - 3), true);
            //Field: 10 Name: EnumTestValueSized Type: TestEnum;
            GenericPrimitiveEnumTypeSerializerStrategy<TestEnum, Byte>.Instance.Write(value.EnumTestValueSized, destination, ref offset);
            //Field: 11 Name: ComplexTypeTest Type: NestedTypeStub;
            NestedTypeStub_AutoGeneratedTemplateSerializerStrategy.Instance.Write(value.ComplexTypeTest, destination, ref offset);
        }
    }
}