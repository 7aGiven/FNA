using System.IO;

namespace Microsoft.Xna.Framework.Audio
{
	public static class SoundEffectTest
	{
		[TestException]
		public static void SoundEffectCtor()
		{
			//Assert.Throw(() => { new SoundEffect(null, 0, (AudioChannels) (-1)).Dispose(); });
			//Assert.Throw(() => { new SoundEffect(null, 0, 0, 0, (AudioChannels) (-1), 0, 0).Dispose(); });
		}

		[TestException]
		public static void FromStream()
		{
			Assert.Throw(() => { SoundEffect.FromStream(null); });
			Assert.Throw(() => { SoundEffect.FromStream(new MemoryStream()); });
			using (BinaryWriter writer = new BinaryWriter(new MemoryStream()))
			{
				writer.Write(new char[] { 'R', 'I', 'F' });
				writer.BaseStream.Position = 0;
				Assert.Throw(() => { SoundEffect.FromStream(writer.BaseStream).Dispose(); });
			}
			using (BinaryWriter writer = new BinaryWriter(new MemoryStream()))
			{
				writer.Write(new char[] { 'R', 'I', 'F', 'G' });
				writer.BaseStream.Position = 0;
				Assert.Throw(() => { SoundEffect.FromStream(writer.BaseStream).Dispose(); });
			}
			using (BinaryWriter writer = new BinaryWriter(new MemoryStream()))
			{
				writer.Write(new char[] { 'R', 'I', 'F', 'F' });
				writer.BaseStream.Position = 0;
				Assert.Throw(() => { SoundEffect.FromStream(writer.BaseStream).Dispose(); });
			}
			using (BinaryWriter writer = new BinaryWriter(new MemoryStream()))
			{
				writer.Write(new char[] { 'R', 'I', 'F', 'F', 'G' });
				writer.BaseStream.Position = 0;
				Assert.Throw(() => { SoundEffect.FromStream(writer.BaseStream).Dispose(); });
			}
			using (BinaryWriter writer = new BinaryWriter(new MemoryStream()))
			{
				writer.Write(new char[] { 'R', 'I', 'F', 'G' });
				writer.Write(32);
				writer.Write(new char[] { 'W', 'A', 'V', 'G' });
				writer.BaseStream.Position = 0;
				Assert.Throw(() => { SoundEffect.FromStream(writer.BaseStream).Dispose(); });
			}
			using (BinaryWriter writer = new BinaryWriter(new MemoryStream()))
			{
				writer.Write(new char[] { 'R', 'I', 'F', 'F' });
				writer.Write(32);
				writer.Write(new char[] { 'W', 'A', 'V', 'G' });
				writer.BaseStream.Position = 0;
				Assert.Throw(() => { SoundEffect.FromStream(writer.BaseStream).Dispose(); });
			}
			using (BinaryWriter writer = new BinaryWriter(new MemoryStream()))
			{
				writer.Write(new char[] { 'R', 'I', 'F', 'F' });
				writer.Write(4);
				writer.Write(new char[] { 'W', 'A', 'V', 'G' });
				writer.BaseStream.Position = 0;
				Assert.Throw(() => { SoundEffect.FromStream(writer.BaseStream).Dispose(); });
			}
			using (BinaryWriter writer = new BinaryWriter(new MemoryStream()))
			{
				writer.Write(new char[] { 'R', 'I', 'F', 'F' });
				writer.Write(4);
				writer.Write(new char[] { 'W', 'A', 'V', 'E' });
				writer.BaseStream.Position = 0;
				Assert.Throw(() => { SoundEffect.FromStream(writer.BaseStream).Dispose(); });
			}
		}
	}
}
