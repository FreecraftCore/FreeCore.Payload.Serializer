using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using FreecraftCore.Serializer;
using FreecraftCore.Serializer.CustomTypes;
namespace FreecraftCore.Serializer.CustomTypes
{
    [AutoGeneratedWireMessageImplementationAttribute]
    public partial class TypeStub
    {
        public override Type SerializableType => typeof(TypeStub);
        public override BaseTypeStub Read(Span<byte> buffer, ref int offset)
        {
            TypeStub_AutoGeneratedTemplateSerializerStrategy.Instance.InternalRead(this, buffer, ref offset);
            return this;
        }
        public override void Write(BaseTypeStub value, Span<byte> buffer, ref int offset)
        {
            TypeStub_AutoGeneratedTemplateSerializerStrategy.Instance.InternalWrite(this, buffer, ref offset);
        }
    }
}

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
        /// <param name="buffer">See external doc.</param>
        /// <param name="offset">See external doc.</param>
        public override void InternalRead(TypeStub value, Span<byte> buffer, ref int offset)
        {
            //Type: BaseTypeStub Field: 1 Name: BaseIntField Type: Int32;
            value.BaseIntField = GenericTypePrimitiveSerializerStrategy<Int32>.Instance.Read(buffer, ref offset);
            //Type: BaseTypeStub Field: 2 Name: BaseIntFieldArray Type: Int32[];
            value.BaseIntFieldArray = FixedSizePrimitiveArrayTypeSerializerStrategy<int, StaticTypedNumeric_Int32_2>.Instance.Read(buffer, ref offset);
            //Type: TypeStub Field: 1 Name: Hello Type: Int32;
            value.Hello = GenericTypePrimitiveSerializerStrategy<Int32>.Instance.Read(buffer, ref offset);
            //Type: TypeStub Field: 2 Name: TestString Type: String;
            value.TestString = LengthPrefixedStringTypeSerializerStrategy<UTF32StringTypeSerializerStrategy, UTF32StringTerminatorTypeSerializerStrategy, UInt16>.Instance.Read(buffer, ref offset);
            //Type: TypeStub Field: 3 Name: HelloAgain Type: UInt16;
            value.HelloAgain = GenericTypePrimitiveSerializerStrategy<UInt16>.Instance.Read(buffer, ref offset);
            //Type: TypeStub Field: 4 Name: TestStringTwo Type: String;
            value.TestStringTwo = DontTerminateLengthPrefixedStringTypeSerializerStrategy<ASCIIStringTypeSerializerStrategy, Int16>.Instance.Read(buffer, ref offset);
            //Type: TypeStub Field: 5 Name: KnownSizeStringTest Type: String;
            value.KnownSizeStringTest = FixedSizeStringTypeSerializerStrategy<UTF16StringTypeSerializerStrategy, StaticTypedNumeric_Int32_1337>.Instance.Read(buffer, ref offset);
            //Type: TypeStub Field: 6 Name: DefaultStringTest Type: String;
            value.DefaultStringTest = TerminatedStringTypeSerializerStrategy<UTF16StringTypeSerializerStrategy, UTF16StringTerminatorTypeSerializerStrategy>.Instance.Read(buffer, ref offset);
            //Type: TypeStub Field: 6 Name: DefaultStringTestNotTerminated Type: String;
            value.DefaultStringTestNotTerminated = UTF16StringTypeSerializerStrategy.Instance.Read(buffer, ref offset);
            //Type: TypeStub Field: 8 Name: EnumTestValue Type: TestEnum;
            value.EnumTestValue = GenericPrimitiveEnumTypeSerializerStrategy<TestEnum, UInt64>.Instance.Read(buffer, ref offset);
            //Type: TypeStub Field: 9 Name: LongArrayTestAddedSize Type: Int64[];
            value.LongArrayTestAddedSize = SendSizePrimitiveArrayTypeSerializerStrategy<long, Int16>.Instance.Read(buffer, ref offset);
            //Type: TypeStub Field: 10 Name: EnumTestValueSized Type: TestEnum;
            value.EnumTestValueSized = GenericPrimitiveEnumTypeSerializerStrategy<TestEnum, Byte>.Instance.Read(buffer, ref offset);
            //Type: TypeStub Field: 11 Name: ComplexTypeTest Type: NestedTypeStub;
            value.ComplexTypeTest = NestedTypeStub_AutoGeneratedTemplateSerializerStrategy.Instance.Read(buffer, ref offset);
            //Type: TypeStub Field: 12 Name: ComplexArrayTest Type: NestedTypeStub[];
            value.ComplexArrayTest = FixedSizeComplexArrayTypeSerializerStrategy<NestedTypeStub_AutoGeneratedTemplateSerializerStrategy, NestedTypeStub, StaticTypedNumeric_Int32_1776>.Instance.Read(buffer, ref offset);
            //Type: TypeStub Field: 13 Name: OptionalValue Type: Int32;
            if (value.OptionalBoolCheck)value.OptionalValue = GenericTypePrimitiveSerializerStrategy<Int32>.Instance.Read(buffer, ref offset);
            //Type: TypeStub Field: 14 Name: TestCustomSerializerInt Type: Int32;
            value.TestCustomSerializerInt = FreecraftCore.Serializer.CustomTypes.TestCustomSerializer.Instance.Read(buffer, ref offset);
            //Type: TypeStub Field: 15 Name: EnumStringTestValue Type: TestEnum;
            value.EnumStringTestValue = InternalEnumExtensions.Parse<TestEnum>(TerminatedStringTypeSerializerStrategy<ASCIIStringTypeSerializerStrategy, ASCIIStringTerminatorTypeSerializerStrategy>.Instance.Read(buffer, ref offset), true);
            //Type: TypeStub Field: 16 Name: NestedPolymorphicTypeValue Type: BaseTypeStub;
            value.NestedPolymorphicTypeValue = BaseTypeStub_AutoGeneratedTemplateSerializerStrategy.Instance.Read(buffer, ref offset);
            //Type: TypeStub Field: 17 Name: BigEndianIntTestValue Type: Int32;
            value.BigEndianIntTestValue = BigEndianGenericTypePrimitiveSerializerStrategy<Int32>.Instance.Read(buffer, ref offset);
            //Type: TypeStub Field: 18 Name: EnumStringTestValueReversed Type: TestEnum;
            value.EnumStringTestValueReversed = InternalEnumExtensions.Parse<TestEnum>(TerminatedStringTypeSerializerStrategy<ReversedASCIIStringTypeSerializerStrategy, ASCIIStringTerminatorTypeSerializerStrategy>.Instance.Read(buffer, ref offset), true);
            //Type: TypeStub Field: 19 Name: CustomTypeSerializerTest Type: TestCustomSerializerReferenceType;
            value.CustomTypeSerializerTest = MyNamespace.TestCustomSerializerReferenceTypeSerializer.Instance.Read(buffer, ref offset);
            //Type: TypeStub Field: 20 Name: FieldTest Type: Int32;
            value.FieldTest = GenericTypePrimitiveSerializerStrategy<Int32>.Instance.Read(buffer, ref offset);
            //Type: TypeStub Field: 21 Name: OpenGenericTest1 Type: OpenGenericVector;
            value.OpenGenericTest1 = OpenGenericVector_Int32_AutoGeneratedTemplateSerializerStrategy.Instance.Read(buffer, ref offset);
            //Type: TypeStub Field: 22 Name: OpenGenericTest2 Type: OpenGenericVector;
            value.OpenGenericTest2 = OpenGenericVector_Int64_AutoGeneratedTemplateSerializerStrategy.Instance.Read(buffer, ref offset);
            //Type: TypeStub Field: 22 Name: OpenGenericTest3 Type: OpenGenericVector;
            value.OpenGenericTest3 = OpenGenericVector_Byte_AutoGeneratedTemplateSerializerStrategy.Instance.Read(buffer, ref offset);
            //Type: TypeStub Field: 23 Name: OpenGenericArray Type: OpenGenericVector[];
            value.OpenGenericArray = ComplexArrayTypeSerializerStrategy<OpenGenericVector_Byte_AutoGeneratedTemplateSerializerStrategy, OpenGenericVector<byte>>.Instance.Read(buffer, ref offset);
            //Type: TypeStub Field: 24 Name: CustomTypeSerializerTestArray Type: TestCustomSerializerReferenceType[];
            value.CustomTypeSerializerTestArray = ComplexArrayTypeSerializerStrategy<MyNamespace.TestCustomSerializerReferenceTypeSerializer, TestCustomSerializerReferenceType>.Instance.Read(buffer, ref offset);
            //Type: TypeStub Field: 25 Name: CustomTypeSerializerPropertyAttri Type: TestCustomSerializerReferenceType;
            value.CustomTypeSerializerPropertyAttri = MyNamespace.TestCustomSerializerReferenceTypeSerializerForPropertyTest.Instance.Read(buffer, ref offset);
            //Type: TypeStub Field: 26 Name: StringArrayTest Type: String[];
            value.StringArrayTest = SendSizeComplexArrayTypeSerializerStrategy<TerminatedStringTypeSerializerStrategy<ASCIIStringTypeSerializerStrategy, ASCIIStringTerminatorTypeSerializerStrategy>, string, Int32>.Instance.Read(buffer, ref offset);
            //Type: TypeStub Field: 27 Name: EnumArrayTest Type: TestEnum[];
            value.EnumArrayTest = SendSizeComplexArrayTypeSerializerStrategy<GenericPrimitiveEnumTypeSerializerStrategy<TestEnum, UInt64>, TestEnum, Int64>.Instance.Read(buffer, ref offset);
            //Type: TypeStub Field: 28 Name: NestedEnumTest Type: TestEnumNested;
            value.NestedEnumTest = GenericPrimitiveEnumTypeSerializerStrategy<FreecraftCore.Serializer.CustomTypes.NestedTestType.TestEnumNested, UInt64>.Instance.Read(buffer, ref offset);
            //Type: TypeStub Field: 29 Name: CustomTypeSerializerTestArrayCompressed Type: TestCustomSerializerReferenceType[];
            value.CustomTypeSerializerTestArrayCompressed = WoWZLibCompressionTypeSerializerDecorator<SendSizeComplexArrayTypeSerializerStrategy<MyNamespace.TestCustomSerializerReferenceTypeSerializer,TestCustomSerializerReferenceType,Int16>, TestCustomSerializerReferenceType[]>.Instance.Read(buffer, ref offset);
            //Type: TypeStub Field: 97 Name: LongArrayTest Type: Int64[];
            value.LongArrayTest = SendSizePrimitiveArrayTypeSerializerStrategy<long, Int16>.Instance.Read(buffer, ref offset);
            //Type: TypeStub Field: 98 Name: KnownSizeArrayTest Type: UInt16[];
            value.KnownSizeArrayTest = FixedSizePrimitiveArrayTypeSerializerStrategy<ushort, StaticTypedNumeric_Int32_1337>.Instance.Read(buffer, ref offset);
            //Type: TypeStub Field: 99 Name: FinalArrayMemberWriteToEnd Type: Int32[];
            value.FinalArrayMemberWriteToEnd = PrimitiveArrayTypeSerializerStrategy<int>.Instance.Read(buffer, ref offset);
            value.OnAfterDeserialization();
        }

        /// <summary>
        /// Auto-generated serialization/write method.
        /// Partial method implemented from shared partial definition.
        /// </summary>
        /// <param name="value">See external doc.</param>
        /// <param name="buffer">See external doc.</param>
        /// <param name="offset">See external doc.</param>
        public override void InternalWrite(TypeStub value, Span<byte> buffer, ref int offset)
        {
            value.OnBeforeSerialization();
            //Type: BaseTypeStub Field: 1 Name: BaseIntField Type: Int32;
            GenericTypePrimitiveSerializerStrategy<Int32>.Instance.Write(value.BaseIntField, buffer, ref offset);
            //Type: BaseTypeStub Field: 2 Name: BaseIntFieldArray Type: Int32[];
            FixedSizePrimitiveArrayTypeSerializerStrategy<int, StaticTypedNumeric_Int32_2>.Instance.Write(value.BaseIntFieldArray, buffer, ref offset);
            //Type: TypeStub Field: 1 Name: Hello Type: Int32;
            GenericTypePrimitiveSerializerStrategy<Int32>.Instance.Write(value.Hello, buffer, ref offset);
            //Type: TypeStub Field: 2 Name: TestString Type: String;
            LengthPrefixedStringTypeSerializerStrategy<UTF32StringTypeSerializerStrategy, UTF32StringTerminatorTypeSerializerStrategy, UInt16>.Instance.Write(value.TestString, buffer, ref offset);
            //Type: TypeStub Field: 3 Name: HelloAgain Type: UInt16;
            GenericTypePrimitiveSerializerStrategy<UInt16>.Instance.Write(value.HelloAgain, buffer, ref offset);
            //Type: TypeStub Field: 4 Name: TestStringTwo Type: String;
            DontTerminateLengthPrefixedStringTypeSerializerStrategy<ASCIIStringTypeSerializerStrategy, Int16>.Instance.Write(value.TestStringTwo, buffer, ref offset);
            //Type: TypeStub Field: 5 Name: KnownSizeStringTest Type: String;
            FixedSizeStringTypeSerializerStrategy<UTF16StringTypeSerializerStrategy, StaticTypedNumeric_Int32_1337>.Instance.Write(value.KnownSizeStringTest, buffer, ref offset);
            //Type: TypeStub Field: 6 Name: DefaultStringTest Type: String;
            TerminatedStringTypeSerializerStrategy<UTF16StringTypeSerializerStrategy, UTF16StringTerminatorTypeSerializerStrategy>.Instance.Write(value.DefaultStringTest, buffer, ref offset);
            //Type: TypeStub Field: 6 Name: DefaultStringTestNotTerminated Type: String;
            UTF16StringTypeSerializerStrategy.Instance.Write(value.DefaultStringTestNotTerminated, buffer, ref offset);
            //Type: TypeStub Field: 8 Name: EnumTestValue Type: TestEnum;
            GenericPrimitiveEnumTypeSerializerStrategy<TestEnum, UInt64>.Instance.Write(value.EnumTestValue, buffer, ref offset);
            //Type: TypeStub Field: 9 Name: LongArrayTestAddedSize Type: Int64[];
            SendSizePrimitiveArrayTypeSerializerStrategy<long, Int16>.Instance.Write(value.LongArrayTestAddedSize, buffer, ref offset);
            //Type: TypeStub Field: 10 Name: EnumTestValueSized Type: TestEnum;
            GenericPrimitiveEnumTypeSerializerStrategy<TestEnum, Byte>.Instance.Write(value.EnumTestValueSized, buffer, ref offset);
            //Type: TypeStub Field: 11 Name: ComplexTypeTest Type: NestedTypeStub;
            NestedTypeStub_AutoGeneratedTemplateSerializerStrategy.Instance.Write(value.ComplexTypeTest, buffer, ref offset);
            //Type: TypeStub Field: 12 Name: ComplexArrayTest Type: NestedTypeStub[];
            FixedSizeComplexArrayTypeSerializerStrategy<NestedTypeStub_AutoGeneratedTemplateSerializerStrategy, NestedTypeStub, StaticTypedNumeric_Int32_1776>.Instance.Write(value.ComplexArrayTest, buffer, ref offset);
            //Type: TypeStub Field: 13 Name: OptionalValue Type: Int32;
            if (value.OptionalBoolCheck)GenericTypePrimitiveSerializerStrategy<Int32>.Instance.Write(value.OptionalValue, buffer, ref offset);
            //Type: TypeStub Field: 14 Name: TestCustomSerializerInt Type: Int32;
            FreecraftCore.Serializer.CustomTypes.TestCustomSerializer.Instance.Write(value.TestCustomSerializerInt, buffer, ref offset);
            //Type: TypeStub Field: 15 Name: EnumStringTestValue Type: TestEnum;
            TerminatedStringTypeSerializerStrategy<ASCIIStringTypeSerializerStrategy, ASCIIStringTerminatorTypeSerializerStrategy>.Instance.Write(value.EnumStringTestValue, buffer, ref offset);
            //Type: TypeStub Field: 16 Name: NestedPolymorphicTypeValue Type: BaseTypeStub;
            BaseTypeStub_AutoGeneratedTemplateSerializerStrategy.Instance.Write(value.NestedPolymorphicTypeValue, buffer, ref offset);
            //Type: TypeStub Field: 17 Name: BigEndianIntTestValue Type: Int32;
            BigEndianGenericTypePrimitiveSerializerStrategy<Int32>.Instance.Write(value.BigEndianIntTestValue, buffer, ref offset);
            //Type: TypeStub Field: 18 Name: EnumStringTestValueReversed Type: TestEnum;
            TerminatedStringTypeSerializerStrategy<ReversedASCIIStringTypeSerializerStrategy, ASCIIStringTerminatorTypeSerializerStrategy>.Instance.Write(value.EnumStringTestValueReversed, buffer, ref offset);
            //Type: TypeStub Field: 19 Name: CustomTypeSerializerTest Type: TestCustomSerializerReferenceType;
            MyNamespace.TestCustomSerializerReferenceTypeSerializer.Instance.Write(value.CustomTypeSerializerTest, buffer, ref offset);
            //Type: TypeStub Field: 20 Name: FieldTest Type: Int32;
            GenericTypePrimitiveSerializerStrategy<Int32>.Instance.Write(value.FieldTest, buffer, ref offset);
            //Type: TypeStub Field: 21 Name: OpenGenericTest1 Type: OpenGenericVector;
            OpenGenericVector_Int32_AutoGeneratedTemplateSerializerStrategy.Instance.Write(value.OpenGenericTest1, buffer, ref offset);
            //Type: TypeStub Field: 22 Name: OpenGenericTest2 Type: OpenGenericVector;
            OpenGenericVector_Int64_AutoGeneratedTemplateSerializerStrategy.Instance.Write(value.OpenGenericTest2, buffer, ref offset);
            //Type: TypeStub Field: 22 Name: OpenGenericTest3 Type: OpenGenericVector;
            OpenGenericVector_Byte_AutoGeneratedTemplateSerializerStrategy.Instance.Write(value.OpenGenericTest3, buffer, ref offset);
            //Type: TypeStub Field: 23 Name: OpenGenericArray Type: OpenGenericVector[];
            ComplexArrayTypeSerializerStrategy<OpenGenericVector_Byte_AutoGeneratedTemplateSerializerStrategy, OpenGenericVector<byte>>.Instance.Write(value.OpenGenericArray, buffer, ref offset);
            //Type: TypeStub Field: 24 Name: CustomTypeSerializerTestArray Type: TestCustomSerializerReferenceType[];
            ComplexArrayTypeSerializerStrategy<MyNamespace.TestCustomSerializerReferenceTypeSerializer, TestCustomSerializerReferenceType>.Instance.Write(value.CustomTypeSerializerTestArray, buffer, ref offset);
            //Type: TypeStub Field: 25 Name: CustomTypeSerializerPropertyAttri Type: TestCustomSerializerReferenceType;
            MyNamespace.TestCustomSerializerReferenceTypeSerializerForPropertyTest.Instance.Write(value.CustomTypeSerializerPropertyAttri, buffer, ref offset);
            //Type: TypeStub Field: 26 Name: StringArrayTest Type: String[];
            SendSizeComplexArrayTypeSerializerStrategy<TerminatedStringTypeSerializerStrategy<ASCIIStringTypeSerializerStrategy, ASCIIStringTerminatorTypeSerializerStrategy>, string, Int32>.Instance.Write(value.StringArrayTest, buffer, ref offset);
            //Type: TypeStub Field: 27 Name: EnumArrayTest Type: TestEnum[];
            SendSizeComplexArrayTypeSerializerStrategy<GenericPrimitiveEnumTypeSerializerStrategy<TestEnum, UInt64>, TestEnum, Int64>.Instance.Write(value.EnumArrayTest, buffer, ref offset);
            //Type: TypeStub Field: 28 Name: NestedEnumTest Type: TestEnumNested;
            GenericPrimitiveEnumTypeSerializerStrategy<FreecraftCore.Serializer.CustomTypes.NestedTestType.TestEnumNested, UInt64>.Instance.Write(value.NestedEnumTest, buffer, ref offset);
            //Type: TypeStub Field: 29 Name: CustomTypeSerializerTestArrayCompressed Type: TestCustomSerializerReferenceType[];
            WoWZLibCompressionTypeSerializerDecorator<SendSizeComplexArrayTypeSerializerStrategy<MyNamespace.TestCustomSerializerReferenceTypeSerializer,TestCustomSerializerReferenceType,Int16>, TestCustomSerializerReferenceType[]>.Instance.Write(value.CustomTypeSerializerTestArrayCompressed, buffer, ref offset);
            //Type: TypeStub Field: 97 Name: LongArrayTest Type: Int64[];
            SendSizePrimitiveArrayTypeSerializerStrategy<long, Int16>.Instance.Write(value.LongArrayTest, buffer, ref offset);
            //Type: TypeStub Field: 98 Name: KnownSizeArrayTest Type: UInt16[];
            FixedSizePrimitiveArrayTypeSerializerStrategy<ushort, StaticTypedNumeric_Int32_1337>.Instance.Write(value.KnownSizeArrayTest, buffer, ref offset);
            //Type: TypeStub Field: 99 Name: FinalArrayMemberWriteToEnd Type: Int32[];
            PrimitiveArrayTypeSerializerStrategy<int>.Instance.Write(value.FinalArrayMemberWriteToEnd, buffer, ref offset);
        }
        private sealed class StaticTypedNumeric_Int32_1337 : StaticTypedNumeric<Int32> { public sealed override Int32 Value => 1337; }
        private sealed class StaticTypedNumeric_Int32_69 : StaticTypedNumeric<Int32> { public sealed override Int32 Value => 69; }
        private sealed class StaticTypedNumeric_Int32_1776 : StaticTypedNumeric<Int32> { public sealed override Int32 Value => 1776; }
        private sealed class StaticTypedNumeric_Int32_2 : StaticTypedNumeric<Int32> { public sealed override Int32 Value => 2; }
    }
}