using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using FreecraftCore.Serializer;
using FreecraftCore.Serializer.CustomTypes;
namespace FreecraftCore.Serializer.CustomTypes
{
	[AutoGeneratedWireMessageImplementationAttribute]
	public partial class TestCustomSerializerReferenceType : IWireMessage<TestCustomSerializerReferenceType>
	{
		public Type SerializableType => typeof(TestCustomSerializerReferenceType);
		public TestCustomSerializerReferenceType Read(Span<byte> buffer, ref int offset)
		{
			TestCustomSerializerReferenceType_AutoGeneratedTemplateSerializerStrategy.Instance.InternalRead(this, buffer, ref offset);
			return this;
		}
		public void Write(TestCustomSerializerReferenceType value, Span<byte> buffer, ref int offset)
		{
			TestCustomSerializerReferenceType_AutoGeneratedTemplateSerializerStrategy.Instance.InternalWrite(this, buffer, ref offset);
		}
	}
}

namespace FreecraftCore.Serializer
{
	//THIS CODE IS FOR AUTO-GENERATED SERIALIZERS! DO NOT MODIFY UNLESS YOU KNOW WELL!
	/// <summary>
	/// FreecraftCore.Serializer's AUTO-GENERATED (do not edit) serialization
	/// code for the Type: <see cref="TestCustomSerializerReferenceType"/>
	/// </summary>
	public sealed partial class TestCustomSerializerReferenceType_AutoGeneratedTemplateSerializerStrategy
		: BaseAutoGeneratedSerializerStrategy<TestCustomSerializerReferenceType_AutoGeneratedTemplateSerializerStrategy, TestCustomSerializerReferenceType>
	{
		/// <summary>
		/// Auto-generated deserialization/read method.
		/// Partial method implemented from shared partial definition.
		/// </summary>
		/// <param name="value">See external doc.</param>
		/// <param name="buffer">See external doc.</param>
		/// <param name="offset">See external doc.</param>
		public override void InternalRead(TestCustomSerializerReferenceType value, Span<byte> buffer, ref int offset)
		{
			//Type: TestCustomSerializerReferenceType Field: 1 Name: Value Type: Int32;
			value.Value = GenericTypePrimitiveSerializerStrategy<Int32>.Instance.Read(buffer, ref offset);
		}

		/// <summary>
		/// Auto-generated serialization/write method.
		/// Partial method implemented from shared partial definition.
		/// </summary>
		/// <param name="value">See external doc.</param>
		/// <param name="buffer">See external doc.</param>
		/// <param name="offset">See external doc.</param>
		public override void InternalWrite(TestCustomSerializerReferenceType value, Span<byte> buffer, ref int offset)
		{
			//Type: TestCustomSerializerReferenceType Field: 1 Name: Value Type: Int32;
			GenericTypePrimitiveSerializerStrategy<Int32>.Instance.Write(value.Value, buffer, ref offset);
		}
	}
}