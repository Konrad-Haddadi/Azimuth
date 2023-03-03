using Raylib_cs;

using System.Numerics;

namespace Azimuth.GameObject
{
	public class AnimatedGameObject : GameObject
	{
		public Texture2D texture;
		public Rectangle location;
		public Rectangle textureSize;
		
		public AnimatedGameObject (string _image,  Vector2 _location, Vector2 _size)
		{
			texture = Assets.Find<Texture2D>($"Textures/{_image}");
			location = new Rectangle(_location.X, _location.Y, _size.X, _size.Y);
			textureSize = new Rectangle(0, 0, texture.width, texture.height * 2);
		}

		public override void Draw()
		{
			Raylib.DrawTexturePro(texture, location, textureSize , Vector2.Zero, 0f, Color.WHITE ); 
		}
	}
}