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
		
		
		public AnimatedGameObject (string _image, Vector2 _size, int _sourceAmountX, int _sourceAmountY)
		{
			size = _size;
			texture = Assets.Find<Texture2D>($"Textures/{_image}");
			source = new Rectangle(0, 0, texture.width / _sourceAmountX, texture.height / _sourceAmountY);
			
		}

		public void Update(Vector2 _pos)
		{
			pos.X = _pos.X;
			pos.Y = _pos.Y;
			dest  = new Rectangle(pos.X, pos.Y, size.X, size.Y);
		}

		public override void Draw()
		{
			Raylib.DrawTexturePro(texture, source, dest, Vector2.Zero, 0, Color.WHITE);
		}
	}
}