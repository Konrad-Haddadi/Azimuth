using Raylib_cs;

using System.Numerics;

namespace Azimuth.GameObject
{
	public class AnimatedGameObject : GameObject
	{
		public Texture2D texture;
		public Rectangle source;
		public Rectangle dest;
		public Vector2 size;
		public Vector2 srcNum;
		public Vector2 imgNum = Vector2.Zero;
		private Vector2 widthHeight;

		public AnimatedGameObject (string _image, Vector2 _size, Vector2 _srcNum)
		{
			
			size = _size;
			srcNum = _srcNum;
			texture = Assets.Find<Texture2D>($"Textures/{_image}");
		}

		public void Update(Vector2 _position)
		{
			widthHeight = new Vector2(texture.width / srcNum.X, texture.height / srcNum.Y);
			dest  = new Rectangle(_position.X, _position.Y, size.X, size.Y);
			source = new Rectangle(imgNum.X, imgNum.Y, widthHeight.X, widthHeight.Y);
		}

		public override void Draw()
		{
			Raylib.DrawTexturePro(texture, source, dest, new Vector2(widthHeight.X * 0.5f, widthHeight.Y * 0.5f), 0, Color.WHITE);
		}
	}
}