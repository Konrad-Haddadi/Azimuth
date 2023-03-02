using Raylib_cs;

using System.Numerics;

namespace Azimuth.UI
{
	public class Button : InteractableWidget
	{
		// Bellow is just allowing "RenderSetting sett = RenderSetting normal" in other classes
		// instead of RenderSetting sett = new RenderSetting()
		public class RenderSettings
		{
			public static RenderSettings normal = new RenderSettings();
			public ColorBlock colors = new ColorBlock()
			{
				disabled = new Color(255, 255, 255, 128),
				hovered = Color.DARKGRAY,
				normal =  Color.LIGHTGRAY,
				selected = Color.BLACK
			};
			public string text = "Button";
			public float roundedness = 0.1f;
			public int fontSize = 20;
			public float fontSpacing = 1f;
			public string? fontId = null;
			public Color textColor;
			
		}

		private readonly float roundednesss;

		private readonly string text;
		private readonly int fontSize;
		private readonly float fontSpacing;

		private readonly Font font;
		private readonly Color textColor;
		private readonly Vector2 textSize;
		
		public Button(Vector2 _position, Vector2 _size, RenderSettings _settings)
			: base(_position, _size, _settings.colors)
		{
			roundednesss = _settings.roundedness;
			text = _settings.text;
			fontSize = _settings.fontSize;
			fontSpacing = _settings.fontSpacing;

			font = string.IsNullOrEmpty(_settings.fontId) ? Raylib.GetFontDefault() : Assets.Find<Font>(_settings.fontId);
			textColor = _settings.textColor;
			
			//Raylib function that creates a bounding box around the font based on its size and spacing
			textSize = Raylib.MeasureTextEx(font, text, fontSize, fontSpacing) * 0.5f;
		}

		public override void Draw()
		{
			Raylib.DrawRectangleRounded(Bounds, roundednesss, 5, ColorFromState());
			Raylib.DrawTextPro(font, text, position + (textSize - size * 0.5f), Vector2.Zero, 0f, fontSize, fontSpacing, textColor);
		}
	}
}