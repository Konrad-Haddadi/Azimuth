using Azimuth;
using Azimuth.GameObject;
using Azimuth.UI;

using Raylib_cs;

using System.Numerics;

namespace Azimuth_Test
{
	public class AzimuthTestGame : Game
	{
		private AnimatedGameObject player1;
		private AnimatedGameObject player2;
		
		private Movement movSet1;
		private Movement movSet2;

		public int groundHeight = 500;
		public override void Load()
		{
			movSet1 = new Movement(2, new Vector2(200, 200), KeyboardKey.KEY_A, KeyboardKey.KEY_D, KeyboardKey.KEY_W, KeyboardKey.KEY_S);
			movSet2 = new Movement(2, new Vector2(200, 400), 100, KeyboardKey.KEY_LEFT, KeyboardKey.KEY_RIGHT, KeyboardKey.KEY_SPACE);
			
			player1 = new AnimatedGameObject("Vegeta", new Vector2(125, 200), new Vector2(12,4.5f));
			player2 = new AnimatedGameObject("Kirby", new Vector2(100, 100),new Vector2(16, 16));
			
			GameObjectManager.Add(movSet2);
			GameObjectManager.Add(movSet1);
			GameObjectManager.Add(player2);
			GameObjectManager.Add(player1);
		}
		public override void Update(float _deltaTime)
		{
			GameObjectManager.Update(_deltaTime);
			player1.Update(movSet1.position);
			player2.Update(movSet2.position);
			
			Move();
			
			movSet1.groundHeight = groundHeight;
			movSet2.groundHeight = groundHeight;
		}

		public override void Draw()
		{
			player1.Draw();
			player2.Draw();
			
			Raylib.DrawRectangle(100, groundHeight, 400, 50, Color.RED);
		}

		public override void Unload()
		{
		}

		public void Move()
		{
			player1.imgNum.X = 0;
			if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
			{
				player1.imgNum.X = 75;
			}
			if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
			{
				player1.imgNum.X = 115;
			}
			if (Raylib.IsKeyDown(KeyboardKey.KEY_W))
			{
				player1.imgNum.X = 200;
			}
			if (Raylib.IsKeyDown(KeyboardKey.KEY_S))
			{
				player1.imgNum.X = 200;
			}
		}
	}
}