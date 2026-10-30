namespace Microsoft.Xna.Framework
{
	public static class MathHelperTest
	{
		[Argument(2f, 1f, 3f)]
		[Argument(2f, 3f, 1f)]
		[Argument(2f, float.NaN, float.NaN)]
		public static float Clamp(float value, float min, float max)
		{
			return MathHelper.Clamp(value, min, max);
		}

		[Argument(0f, 0f, 1f, 0f, 1f / (1L << 42))]
		public static float Hermite(float value1, float tangent1, float value2, float tangent2, float amount)
		{
			return MathHelper.Hermite(value1, tangent1, value2, tangent2, amount);
		}

		[Argument(1f, 2f)]
		[Argument(float.NaN, 1f)]
		[Argument(1f, float.NaN)]
		public static float Max(float value1, float value2)
		{
			return MathHelper.Max(value1, value2);
		}

		[Argument(1f, 2f)]
		[Argument(float.NaN, 1f)]
		[Argument(1f, float.NaN)]
		public static float Min(float value1, float value2)
		{
			return MathHelper.Min(value1, value2);
		}

		[Argument(0f, 1f, 1f / (1L << 42))]
		public static float SmoothStep(float value1, float value2, float amount)
		{
			return MathHelper.SmoothStep(value1, value2, amount);
		}

		[Argument(float.NaN)]
		[Argument(180f)]
		public static float ToDegrees(float radians)
		{
			return MathHelper.ToDegrees(radians);
		}

		[Argument(float.NaN)]
		[Argument(180f)]
		public static float ToRadians(float degrees)
		{
			return MathHelper.ToRadians(degrees);
		}

		[Argument(float.NaN)]
		[Argument(float.MinValue)]
		[Argument(float.MaxValue)]
		[Argument(MathHelper.Pi)]
		[Argument(-MathHelper.Pi)]
		public static float WrapAngle(float angle)
		{
			return MathHelper.WrapAngle(angle);
		}
	}
}
