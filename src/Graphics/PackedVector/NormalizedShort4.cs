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
	public struct NormalizedShort4 : IPackedVector<ulong>, IEquatable<NormalizedShort4>
	{
		#region Public Properties

		[CLSCompliant(false)]
		public ulong PackedValue
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

		private ulong packedValue;

		#endregion

		#region Public Constructors

		public NormalizedShort4(Vector4 vector)
		{
			packedValue = Pack(vector.X, vector.Y, vector.Z, vector.W);
		}

		public NormalizedShort4(float x, float y, float z, float w)
		{
			packedValue = Pack(x, y, z, w);
		}

		#endregion

		#region Public Methods

		public Vector4 ToVector4()
		{
			const float maxVal = 0x7FFF;

			return new Vector4(
				((short) (packedValue & 0xFFFF)) / maxVal,
				((short) ((packedValue >> 0x10) & 0xFFFF)) / maxVal,
				((short) ((packedValue >> 0x20) & 0xFFFF)) / maxVal,
				((short) ((packedValue >> 0x30) & 0xFFFF)) / maxVal
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

		public static bool operator !=(NormalizedShort4 a, NormalizedShort4 b)
		{
			return !a.Equals(b);
		}

		public static bool operator ==(NormalizedShort4 a, NormalizedShort4 b)
		{
			return a.Equals(b);
		}

		public override bool Equals(object obj)
		{
			return (obj is NormalizedShort4) && Equals((NormalizedShort4) obj);
		}

		public bool Equals(NormalizedShort4 other)
		{
			return packedValue.Equals(other.packedValue);
		}

		public override int GetHashCode()
		{
			return packedValue.GetHashCode();
		}

		public override string ToString()
		{
			return packedValue.ToString("X16");
		}

		#endregion

		#region Private Static Pack Method

		private static ulong Pack(float x, float y, float z, float w)
		{
			if (x < -1f) x = -1f;
			if (x > 1f) x = 1f;
			int ix = MathHelper.Round(x * short.MaxValue);

			if (y < -1f) y = -1f;
			if (y > 1f) y = 1f;
			int iy = MathHelper.Round(y * short.MaxValue);

			if (z < -1f) z = -1f;
			if (z > 1f) z = 1f;
			int iz = MathHelper.Round(z * short.MaxValue);

			if (w < -1f) w = -1f;
			if (w > 1f) w = 1f;
			int iw = MathHelper.Round(w * short.MaxValue);

			return (
				(ulong) (uint) ((ushort) ix | iy << 16) |
				(ulong) (uint) ((ushort) iz | iw << 16) << 32
			);
		}

		#endregion
	}
}
