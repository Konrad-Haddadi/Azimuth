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
		private Button.RenderSettings normal = new("MATT", 50, Color.PINK);
		private Button button2;
		private Button.RenderSettings normal2 = new("Konrad", 50, Color.BLUE);

		private void OnClickButton()
		{
			Console.Write("Hello World");
		}
		public override void Load()
		{
			int counter = 0;
			image = new ImageWidget(Vector2.Zero, new Vector2(500, 1000), "KAKAROT");
			button = new Button(new Vector2(50, 245), normal);
			button2 = new Button(new Vector2(50,500), new Vector2(200, 100), normal2);
			UIManager.Add(button);
			UIManager.Add(button2);
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