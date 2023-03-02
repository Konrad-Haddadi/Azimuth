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
		private Button.RenderSettings normal = new Button.RenderSettings("Konrad", 50, Color.PINK);

		private void OnClickButton()
		{
			Console.Write("Hello World");
		}
		public override void Load()
		{
			int counter = 0;
			image = new ImageWidget(Vector2.Zero, new Vector2(500, 1000), "KAKAROT");
			button = new Button(new Vector2(100,245), normal);
			UIManager.Add(button);
			button.AddListener(OnClickButton);
			button.AddListener(() =>
			{
				if(counter % 2 == 0)
				{
					UIManager.Add(image);
				}
				else
				{
					UIManager.Remove(image);
				}

				counter++;
			});
			
		}
		
		public override void Unload()
		{
			
		}
	}
}