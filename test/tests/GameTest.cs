namespace Microsoft.Xna.Framework
{
	public static class GameTest
	{
		internal static Game game = new Game();
		internal static GraphicsDeviceManager gdm = new GraphicsDeviceManager(game) { GraphicsProfile = Graphics.GraphicsProfile.HiDef };
		static GameTest()
		{
			((IGraphicsDeviceManager) gdm).CreateDevice();
		}
	}
}
