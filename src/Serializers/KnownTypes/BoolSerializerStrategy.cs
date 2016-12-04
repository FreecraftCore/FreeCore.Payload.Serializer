﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreecraftCore.Payload.Serializer
{
	/// <summary>
	/// Known-type serializer for the <see cref="bool"/> value-type.
	/// </summary>
	[KnownTypeSerializer]
	public class BoolSerializerStrategy : ITypeSerializerStrategy<bool>
	{
		public Type SerializerType { get { return typeof(bool); } }

		/*ByteBuffer &operator>>(bool &value)
		{
			value = read<char>() > 0 ? true : false;
			return *this;
		}*/
		public bool Read(IWireMemberReaderStrategy source)
		{
			//Trinitycore could potentially send non-one bytes for a bool
			//See above
			return source.ReadByte() > 0;
		}

		public void Write(bool value, IWireMemberWriterStrategy dest)
		{
			dest.Write((byte)(value ? 1 : 0));
		}
	}
}
