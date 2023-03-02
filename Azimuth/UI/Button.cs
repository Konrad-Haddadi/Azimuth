using Raylib_cs;

using System.Numerics;

namespace Azimuth.UI
{
	public class Button : InteractableWidget
	{
		public delegate void OnClickEvent();
		
		public static  Vector2 buttonSize;
		public Vector2 _buttonSize => buttonSize;
		private static  Vector2 pos;
		
		private readonly float roundednesss;
		private readonly string text;
		private readonly int fontSize;
		private readonly float fontSpacing;

		private readonly Font font;
		private readonly Color textColor;
		private readonly Vector2 textSize;
		// Bellow is just allowing "RenderSetting sett = RenderSetting normal" in other classes
		// instead of RenderSetting sett = new RenderSetting()
		public class RenderSettings
		{
			public ColorBlock colors = new ColorBlock()
			{
				disabled = new Color(255, 255, 255, 128),
				hovered = Color.DARKGRAY,
				normal =  Color.LIGHTGRAY,
				selected = Color.BLACK
			};
			public string text;
			public int fontSize;
			public Color textColor;
			public float roundedness = 0.1f;
			public float fontSpacing = 1f;
			public string? fontId = null;
			
			public RenderSettings(string _text, int _fontSize, Color _textColor) : base()
			{
				text = _text;
				fontSize = _fontSize;
				
				textColor = _textColor;
				buttonSize = new Vector2(fontSize * text.Length, _fontSize * 2); 
			}
			
			
		}

		private OnClickEvent? onClick;
		
		public Button(Vector2 _position, RenderSettings _settings)
			: base(_position, buttonSize, _settings.colors)
		{
			roundednesss = _settings.roundedness;
			text = _settings.text;
			fontSize = _settings.fontSize;
			fontSpacing = _settings.fontSpacing;
			pos = _position + (buttonSize / 4);
			font = string.IsNullOrEmpty(_settings.fontId) ? Raylib.GetFontDefault() : Assets.Find<Font>(_settings.fontId);
			textColor = _settings.textColor;
			
			//Raylib function that creates a bounding box around the font based on its size and spacing
			textSize = Raylib.MeasureTextEx(font, text, fontSize, fontSpacing) * 0.5f;
		}

		public void AddListener(OnClickEvent _event)
		{
			if(onClick == null)
			{
				onClick = _event;
			}
			else
			{
				onClick += _event;
			}
		}

		public void RemoveListener(OnClickEvent _event)
		{
			if(onClick != null)
				onClick -= _event;
		}
		public override void Draw()
		{
			Raylib.DrawRectanglePro(Bounds, Vector2.Zero, 0, ColorFromState());
			Raylib.DrawTextPro(font, text, pos, Vector2.Zero, 0f, fontSize, fontSpacing, textColor);
		}

		protected override void OnStateChange(InteractionState _state, InteractionState _oldstate)
		{
			if(_state != InteractionState.Selected && _oldstate == InteractionState.Selected)
			{
				// The button is no longer being clicked, so do the event
				onClick?.Invoke();
			}
		}
	}
}