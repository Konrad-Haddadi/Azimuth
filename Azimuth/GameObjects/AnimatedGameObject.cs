using Raylib_cs;

using System.Numerics;

namespace Azimuth.GameObject
{
	public class AnimatedGameObject : GameObject
	{
		public Texture2D texture;
		public Rectangle source;
		public Rectangle dest;
		public Vector2 pos;
		public Vector2 size;
		public Vector2 srcNum;
		public float currentImage = 0;
		
		
		public AnimatedGameObject (string _image, Vector2 _size, Vector2 _srcNum)
		{
			size = _size;
			srcNum = _srcNum;
			texture = Assets.Find<Texture2D>($"Textures/{_image}");
		}

		public void Update(Vector2 _pos)
		{
			pos.X = _pos.X;
			pos.Y = _pos.Y;
			dest  = new Rectangle(pos.X, pos.Y, size.X, size.Y);
			source = new Rectangle(currentImage, 0, texture.width / srcNum.X, texture.height / srcNum.Y);
		}

		public override void Draw()
		{
			Raylib.DrawTexturePro(texture, source, dest, Vector2.Zero, 0, Color.WHITE);
		}
	}
}