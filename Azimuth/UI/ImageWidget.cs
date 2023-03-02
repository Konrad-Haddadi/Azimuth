using Raylib_cs;

using System.Numerics;

namespace Azimuth.UI
{
	public class ImageWidget : Widget
	{
		private Texture2D image;
		
		public ImageWidget(Vector2 _position, Vector2 _size, string _imageID) : base(_position, _size)
		{
			image = Assets.Find<Texture2D>($"Textures/{_imageID}");
		}

		public override void Draw()
		{
			Raylib.DrawTexturePro(image, new Rectangle(0, 0, image.width, image.height), Bounds, Vector2.Zero, 0, Color.WHITE);
		}
	}
}