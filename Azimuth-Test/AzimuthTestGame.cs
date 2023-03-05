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
		private AnimatedGameObject player;

		private Button.RenderSettings normal = new(75, Color.PINK);
		private Movement movSet = new Movement(2, KeyboardKey.KEY_A, KeyboardKey.KEY_D, KeyboardKey.KEY_W,
			KeyboardKey.KEY_S);

		public int posX;
		public int posY;
		
		private void OnClickButton()
		{
			
		}

		public override void Load()
		{
			player = new AnimatedGameObject("duck", new Vector2(118, 60), new Vector2(2,1));
			
			
			GameObjectManager.Add(movSet);
			GameObjectManager.Add(player);
		}
		public override void Update(float _deltaTime)
		{
			GameObjectManager.Update(_deltaTime);
			player.Update(movSet.position);

			if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
			{
				Console.WriteLine($"{player.currentImage}");
				player.currentImage += 118;
				if (player.currentImage > 118)
				{
					player.currentImage = 0;
				}
			}
		}

		public override void Draw()
		{
			player.Draw();
		}

		public override void Unload()
		{
		}
	}
}