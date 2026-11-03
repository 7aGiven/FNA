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
	/// <summary>
	/// Packed vector type containing unsigned normalized values ranging from 0 to 1. 
	/// The x and z components use 5 bits, and the y component uses 6 bits.
	/// </summary>
	public struct Rgba64 : IPackedVector<ulong>, IEquatable<Rgba64>, IPackedVector
	{
		#region Public Properties

		/// <summary>
		/// Gets and sets the packed value.
		/// </summary>
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

		/// <summary>
		/// Creates a new instance of Rgba64.
		/// </summary>
		/// <param name="x">The x component</param>
		/// <param name="y">The y component</param>
		/// <param name="z">The z component</param>
		/// <param name="w">The w component</param>
		public Rgba64(float x, float y, float z, float w)
		{
			packedValue = Pack(x, y, z, w);
		}

		/// <summary>
		/// Creates a new instance of Rgba64.
		/// </summary>
		/// <param name="vector">
		/// Vector containing the components for the packed vector.
		/// </param>
		public Rgba64(Vector4 vector)
		{
			packedValue = Pack(vector.X, vector.Y, vector.Z, vector.W);
		}

		#endregion

		#region Public Methods

		/// <summary>
		/// Gets the packed vector in Vector4 format.
		/// </summary>
		/// <returns>The packed vector in Vector4 format</returns>
		public Vector4 ToVector4()
		{
			return new Vector4(
				(packedValue & 0xFFFF) / 65535.0f,
				((packedValue >> 16) & 0xFFFF) / 65535.0f,
				((packedValue >> 32) & 0xFFFF) / 65535.0f,
				(packedValue >> 48) / 65535.0f
			);
		}

		#endregion

		#region IPackedVector Methods

		/// <summary>
		/// Sets the packed vector from a Vector4.
		/// </summary>
		/// <param name="vector">Vector containing the components.</param>
		void IPackedVector.PackFromVector4(Vector4 vector)
		{
			packedValue = Pack(vector.X, vector.Y, vector.Z, vector.W);
		}

		#endregion

		#region Public Static Operators and Override Methods

		/// <summary>
		/// Compares an object with the packed vector.
		/// </summary>
		/// <param name="obj">The object to compare.</param>
		/// <returns>True if the object is equal to the packed vector.</returns>
		public override bool Equals(object obj)
		{
			return (obj is Rgba64) && Equals((Rgba64) obj);
		}

		/// <summary>
		/// Compares another Rgba64 packed vector with the packed vector.
		/// </summary>
		/// <param name="other">The Rgba64 packed vector to compare.</param>
		/// <returns>True if the packed vectors are equal.</returns>
		public bool Equals(Rgba64 other)
		{
			return packedValue == other.packedValue;
		}

		/// <summary>
		/// Gets a string representation of the packed vector.
		/// </summary>
		/// <returns>A string representation of the packed vector.</returns>
		public override string ToString()
		{
			return packedValue.ToString("X16");
		}

		/// <summary>
		/// Gets a hash code of the packed vector.
		/// </summary>
		/// <returns>The hash code for the packed vector.</returns>
		public override int GetHashCode()
		{
			return packedValue.GetHashCode();
		}

		public static bool operator ==(Rgba64 lhs, Rgba64 rhs)
		{
			return lhs.packedValue == rhs.packedValue;
		}

		public static bool operator !=(Rgba64 lhs, Rgba64 rhs)
		{
			return lhs.packedValue != rhs.packedValue;
		}

		#endregion

		#region Private Static Pack Method

		private static ulong Pack(float x, float y, float z, float w)
		{
			if (x > 1f) x = 1f;
			int ix = MathHelper.Round(x * ushort.MaxValue);
			if (ix < 0) ix = 0;

			if (y > 1f) y = 1f;
			int iy = MathHelper.Round(y * ushort.MaxValue);
			if (iy < 0) iy = 0;

			if (z > 1f) z = 1f;
			int iz = MathHelper.Round(z * ushort.MaxValue);
			if (iz < 0) iz = 0;

			if (w > 1f) w = 1f;
			int iw = MathHelper.Round(w * ushort.MaxValue);
			if (iw < 0) iw = 0;

			return (
				(ulong) (uint) (ix | iy << 16) |
				(ulong) (uint) (iz | iw << 16) << 32
			);
		}

		#endregion
	}
}
