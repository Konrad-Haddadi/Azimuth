﻿using Azimuth;
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
			player = new AnimatedGameObject("duck", new Vector2(118, 60), 2, 1);
			image = new ImageWidget(Vector2.Zero, new Vector2(500, 1000), "KAKAROT");
			button = new Button(new Vector2(50, 245), "Konrad", normal);
			button2 = new Button(new Vector2(50, 500), new Vector2(200, 100), "Mathew", normal);
			
			GameObjectManager.Add(movSet);
			GameObjectManager.Add(player);
			UIManager.Add(button);
			UIManager.Add(button2);
			
		}
		public override void Update(float _deltaTime)
		{
			GameObjectManager.Update(_deltaTime);
			player.Update(movSet.position);
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