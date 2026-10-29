using System.IO;

namespace Microsoft.Xna.Framework.Graphics
{
	public static class Texture2DTest
	{
		class SeekStream : Stream
		{
			readonly bool canSeek;
			internal SeekStream(bool canSeek)
			{
				this.canSeek = canSeek;
			}
			public override bool CanRead => throw new System.NotImplementedException();
			public override bool CanSeek => canSeek;
			public override bool CanWrite => throw new System.NotImplementedException();
			public override long Length => throw new System.NotImplementedException();
			public override long Position { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
			public override void Flush()
			{
				throw new System.NotImplementedException();
			}
			public override int Read(byte[] buffer, int offset, int count)
			{
				throw new System.NotImplementedException();
			}
			public override long Seek(long offset, SeekOrigin origin)
			{
				throw new System.NotImplementedException();
			}
			public override void SetLength(long value)
			{
				throw new System.NotImplementedException();
			}
			public override void Write(byte[] buffer, int offset, int count)
			{
				throw new System.NotImplementedException();
			}
		}

		[TestException]
		public static void Texture2Dctor()
		{
			GraphicsDevice gd = GameTest.gdm.GraphicsDevice;
			Assert.Throw(() => { new Texture2D(null, 1, 1).Dispose(); });
			Assert.Throw(() => { new Texture2D(gd, 0, 1).Dispose(); });
			Assert.Throw(() => { new Texture2D(gd, 1, 0).Dispose(); });

			Assert.Throw(() => { new Texture2D(null, 1, 1, false, SurfaceFormat.Color).Dispose(); });
			Assert.Throw(() => { new Texture2D(gd, 0, 1, false, SurfaceFormat.Color).Dispose(); });
			Assert.Throw(() => { new Texture2D(gd, 1, 0, false, SurfaceFormat.Color).Dispose(); });
			Assert.Throw(() => { new Texture2D(gd, 1, 1, false, SurfaceFormat.Dxt1).Dispose(); });
		}

		[TestException]
		public static void FromStream()
		{
			GraphicsDevice gd = GameTest.gdm.GraphicsDevice;
			Assert.Throw(() => { Texture2D.FromStream(null, new SeekStream(true)).Dispose(); });
			Assert.Throw(() => { Texture2D.FromStream(gd, null).Dispose(); });
			Assert.Throw(() => { Texture2D.FromStream(gd, new SeekStream(false)).Dispose(); });

			Assert.Throw(() => { Texture2D.FromStream(null, new SeekStream(true), 1, 1, false).Dispose(); });
			Assert.Throw(() => { Texture2D.FromStream(gd, null, 1, 1, false).Dispose(); });
			Assert.Throw(() => { Texture2D.FromStream(gd, new SeekStream(false), 1, 1, false).Dispose(); });
			Assert.Throw(() => { Texture2D.FromStream(gd, new SeekStream(true), 0, 1, false).Dispose(); });
			Assert.Throw(() => { Texture2D.FromStream(gd, new SeekStream(true), 1, 0, false).Dispose(); });
		}
	}
}
