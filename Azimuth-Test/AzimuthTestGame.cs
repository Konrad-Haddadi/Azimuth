using Azimuth;
using Azimuth.GameObject;
using Azimuth.UI;

using Raylib_cs;

using System.Numerics;

namespace Azimuth_Test
{
	public class AzimuthTestGame : Game
	{
		private ImageWidget image;
		private Button button;
		private Button button2;
		private Button.RenderSettings normal = new(50, Color.PINK);
		private AnimatedGameObject dino;
		private int startPoint = 0;

		private void OnClickButton()
		{
			Console.Write("Hello World");
		}

		public override void Load()
		{
			
			dino = new("duck", new Vector2(startPoint,0), new Vector2(118, 60));
			int counter = 0;
			image = new ImageWidget(Vector2.Zero, new Vector2(500, 1000), "KAKAROT");
			button = new Button(new Vector2(50, 245), "Konrad", normal);
			button2 = new Button(new Vector2(50, 500), new Vector2(200, 100), "Mathew", normal);
			
			GameObjectManager.Add(dino);
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

		public override void Update(float _deltaTime)
		{
			if(_deltaTime % 2 = 0)
			{
				startPoint += 118;
			}
			else
			{
				startPoint = 0;
			}
		}

		public override void Unload() { }
	}
}