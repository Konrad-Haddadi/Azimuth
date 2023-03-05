using Raylib_cs;

using System.Numerics;

namespace Azimuth.GameObject
{
	public class AnimatedGameObject : GameObject
	{
		public Texture2D texture;
		public Rectangle source;
		public Rectangle dest;
		
		public AnimatedGameObject (string _image, Vector2 _size, int _sourceAmountX, int _sourceAmountY, Vector2 _position)
		{
			texture = Assets.Find<Texture2D>($"Textures/{_image}");
			dest  = new Rectangle(_position.X, _position.Y, _size.X, _size.Y);
			source = new Rectangle(0, 0, texture.width / _sourceAmountX, texture.height / _sourceAmountY);
		}

		public override void Update(float _deltaTime)
		{
			
		}

		public override void Draw()
		{
			Raylib.DrawTexturePro(texture, source, dest, Vector2.Zero, 0, Color.WHITE);
		}
	}
}