using Raylib_cs;

namespace Azimuth
{
	public sealed class Window
	{
		public int Width { get; private set; }
		public int Height { get; private set; }
		public int Fps { get; }

		public string Title { get; }

		public Color ClearColor { get; }

		public Window()
		{
			Width = Config.Get<int>("Window", "width");
			Height = Config.Get<int>("Window", "height");
			Title = Config.Get<string>("Application", "name")!;
			ClearColor = Config.Get<Color>("Window", "clearColor");
			Fps = Config.Get<int>("Window", "FPS");

			Raylib.SetExitKey((KeyboardKey) Config.Get<int>("Application", "quitKey"));

			if(Config.Get<bool>("Window", "resizableWindow"))
				Raylib.SetConfigFlags(ConfigFlags.FLAG_WINDOW_RESIZABLE);
		}

		public void Open()
		{
			Raylib.InitWindow(Width, Height, Title);
			Raylib.SetTargetFPS(Fps);
		}

		public void Clear()
		{
			Raylib.ClearBackground(ClearColor);

			Width = Raylib.GetScreenWidth();
			Height = Raylib.GetScreenHeight();
		}

		public void Close()
		{
			Raylib.CloseWindow();
		}
	}
}