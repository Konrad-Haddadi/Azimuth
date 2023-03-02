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
		private Button.RenderSettings normal = new Button.RenderSettings("big", 5, 1f, Color.BLUE);

		private void OnClickButton()
		{
			Console.Write("Hello World");
		}
		public override void Load()
		{
			image = new ImageWidget(Vector2.Zero, new Vector2(Window.Width, Window.Height), "KAKAROT");
			button = new Button(new Vector2(100,245), normal);
			UIManager.Add(button);
			button.AddListener(OnClickButton);
			button.AddListener(() =>
			{
				UIManager.Add(image);
			});
			
		}
		
		public override void Unload()
		{
			
		}
	}
}