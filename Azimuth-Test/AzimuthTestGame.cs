using Azimuth;
using Azimuth.UI;

using Raylib_cs;

using System.Numerics;

namespace Azimuth_Test
{
	public class AzimuthTestGame : Game
	{
		
		private ImageWidget image;
		private Button button;
		public override void Load()
		{
			image = new ImageWidget(Vector2.Zero, new Vector2(Window.Width, Window.Height), "KAKAROT");
			button = new Button(new Vector2(310,245), new Vector2(30, 20), Button.RenderSettings.normal);
			UIManager.Add(image);
			UIManager.Add(button);
		}
		
		public override void Unload()
		{
			
		}
	}
}