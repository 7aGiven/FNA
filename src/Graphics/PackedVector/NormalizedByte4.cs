#region License
/* FNA - XNA4 Reimplementation for Desktop Platforms
 * Copyright 2009-2024 Ethan Lee and the MonoGame Team
 *
 * Released under the Microsoft Public License.
 * See LICENSE for details.
 */
#endregion

#region Using Statements
using System;
#endregion

namespace Microsoft.Xna.Framework.Graphics.PackedVector
{
	public struct NormalizedByte4 : IPackedVector<uint>, IEquatable<NormalizedByte4>
	{
		#region Public Properties

		[CLSCompliant(false)]
		public uint PackedValue
		{
			get
			{
				return packedValue;
			}
			set
			{
				packedValue = value;
			}
		}

		#endregion

		#region Private Variables

		private uint packedValue;

		#endregion

		#region Public Constructors

		public NormalizedByte4(Vector4 vector)
		{
			packedValue = Pack(vector.X, vector.Y, vector.Z, vector.W);
		}

		public NormalizedByte4(float x, float y, float z, float w)
		{
			packedValue = Pack(x, y, z, w);
		}

		#endregion

		#region Public Methods

		public Vector4 ToVector4()
		{
			return new Vector4(
				((sbyte) (packedValue & 0xFF)) / 127.0f,
				((sbyte) ((packedValue >> 8) & 0xFF)) / 127.0f,
				((sbyte) ((packedValue >> 16) & 0xFF)) / 127.0f,
				((sbyte) ((packedValue >> 24) & 0xFF)) / 127.0f
			);
		}

		#endregion

		#region IPackedVector Methods

		void IPackedVector.PackFromVector4(Vector4 vector)
		{
			packedValue = Pack(vector.X, vector.Y, vector.Z, vector.W);
		}

		#endregion

		#region Public Static Operators and Override Methods

		public static bool operator !=(NormalizedByte4 a, NormalizedByte4 b)
		{
			return a.packedValue != b.packedValue;
		}

		public static bool operator ==(NormalizedByte4 a, NormalizedByte4 b)
		{
			return a.packedValue == b.packedValue;
		}

		public override bool Equals(object obj)
		{
			return (obj is NormalizedByte4) && Equals((NormalizedByte4) obj);
		}

		public bool Equals(NormalizedByte4 other)
		{
			return packedValue == other.packedValue;
		}

		public override int GetHashCode()
		{
			return packedValue.GetHashCode();
		}

		public override string ToString()
		{
			return packedValue.ToString("X8");
		}

		#endregion

		#region Private Static Pack Method

		private static uint Pack(float x, float y, float z, float w)
		{
			if (x < -1f) x = -1f;
			if (x > 1f) x = 1f;
			int ix = MathHelper.Round(x * sbyte.MaxValue);

			if (y < -1f) y = -1f;
			if (y > 1f) y = 1f;
			int iy = MathHelper.Round(y * sbyte.MaxValue);

			if (z < -1f) z = -1f;
			if (z > 1f) z = 1f;
			int iz = MathHelper.Round(z * sbyte.MaxValue);

			if (w < -1f) w = -1f;
			if (w > 1f) w = 1f;
			int iw = MathHelper.Round(w * sbyte.MaxValue);

			return (uint) ((ushort) ix | iy << 8 | iz << 16 | iw << 24);
		}

		#endregion
	}
}
