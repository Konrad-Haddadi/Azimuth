using Raylib_cs;
using System.Numerics;

namespace Azimuth.UI
{
    public class Button : InteractableWidget
    {
        public delegate void OnClickEvent();

        private readonly float roundednesss;
        private readonly string text;
        private readonly int fontSize;
        private readonly float fontSpacing;

        private readonly Font font;
        private readonly Color textColor;
        private readonly Vector2 textSize;

        public class RenderSettings
        {
            public ColorBlock colors = new ColorBlock()
            {
                disabled = new Color(255, 255, 255, 128),
                hovered = Color.DARKGRAY,
                normal = Color.LIGHTGRAY,
                selected = Color.BLACK
            };

            public int fontSize;
            public Color textColor;
            public float roundedness = 0.1f;
            public float fontSpacing = 1f;
            public string? fontId = null;

            public RenderSettings(int _fontSize, Color _textColor) : base()
            {
                fontSize = _fontSize;
                textColor = _textColor;
            }
        }

        private OnClickEvent? onClick;

        public Button(Vector2 _position, string _text, RenderSettings _settings)
            : base(_position, Vector2.Zero, _settings.colors)
        {
            roundednesss = _settings.roundedness;
            text = _text;
            fontSize = _settings.fontSize;
            fontSpacing = _settings.fontSpacing;

            font = string.IsNullOrEmpty(_settings.fontId)
                ? Raylib.GetFontDefault()
                : Assets.Find<Font>(_settings.fontId);
            textColor = _settings.textColor;

            //Raylib function that creates a bounding box around the font based on its size and spacing
            textSize = Raylib.MeasureTextEx(font, text, fontSize, fontSpacing);
            size = textSize;
        }

        public Button(Vector2 _position, Vector2 _buttonSize, string _text, RenderSettings _settings)
            : base(_position, _buttonSize, _settings.colors)
        {
            roundednesss = _settings.roundedness;
            text = _text;
            fontSize = _settings.fontSize;
            fontSpacing = _settings.fontSpacing;

            font = string.IsNullOrEmpty(_settings.fontId)
                ? Raylib.GetFontDefault()
                : Assets.Find<Font>(_settings.fontId);
            textColor = _settings.textColor;

            //Raylib function that creates a bounding box around the font based on its size and spacing
            textSize = Raylib.MeasureTextEx(font, text, fontSize, fontSpacing);
            size = _buttonSize;
        }

        public void AddListener(OnClickEvent _event)
        {
            if (onClick == null)
                onClick = _event;
            else
                onClick += _event;
        }

        public void RemoveListener(OnClickEvent _event)
        {
            if (onClick != null)
                onClick -= _event;
        }

        public override void Draw()
        {
            Raylib.DrawRectanglePro(Bounds, Vector2.Zero, 0, ColorFromState());
            Vector2 p = size - textSize;
            Raylib.DrawTextPro(font, text, new Vector2(position.X + p.X * 0.5f, position.Y + p.Y * 0.5f), Vector2.Zero,
                0f, fontSize, fontSpacing, textColor);
        }

        protected override void OnStateChange(InteractionState _state, InteractionState _oldstate)
        {
            if (_state != InteractionState.Selected && _oldstate == InteractionState.Selected)
            {
                // The button is no longer being clicked, so do the event
                onClick?.Invoke();
            }
        }
    }
}