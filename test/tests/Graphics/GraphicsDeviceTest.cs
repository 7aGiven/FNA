namespace Microsoft.Xna.Framework.Graphics
{
	public static class GraphicsDeviceTest
	{
		[Test]
		public static Color GetBackBufferData()
		{
			GraphicsDevice gd = GameTest.gdm.GraphicsDevice;

			Texture2D white = new Texture2D(gd, 1, 1);
			white.SetData(new[] { Color.White });

			int width = gd.PresentationParameters.BackBufferWidth;
			int height = gd.PresentationParameters.BackBufferHeight;

			SpriteBatch sb = new SpriteBatch(gd);
			sb.Begin();
			sb.Draw(white, new Rectangle(0, 0, width, height >> 1), Color.Red);
			sb.Draw(white, new Rectangle(0, height >> 1, width, height), Color.Blue);
			sb.End();

			Color[] backBuffer = new Color[1];
			gd.GetBackBufferData(new Rectangle(0, 0, 1, 1), backBuffer, 0, 1);
			return backBuffer[0];
		}
	}
}
