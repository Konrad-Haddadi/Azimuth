using Raylib_cs;

using System.Numerics;

namespace Azimuth.UI
{
	public abstract class InteractableWidget : Widget
	{
		public InteractionState State { get; private set; }

		public bool Interactable { get; set; } = true;

		private ColorBlock colors;

		protected InteractableWidget(Vector2 _position, Vector2 _size, ColorBlock _colors)
			: base(_position, _size)
		{
			colors = _colors;
			State = InteractionState.Normal;
		}

		public override void Update(Vector2 _mousePos)
		{
			base.Update(_mousePos);

			bool clicked = Raylib.IsMouseButtonDown(MouseButton.MOUSE_BUTTON_LEFT);

			InteractionState oldState = State;
			
			// If selected and not clicked
			if(State == InteractionState.Selected && !clicked)
			{
				State = focused ? InteractionState.Hovered : InteractionState.Normal;
			}
			// If clicked and mouse is hovered over
			else if(clicked && focused)
			{
				State = InteractionState.Selected;
			}
			// if the mouse is hovered over
			else if(focused)
			{
				State = InteractionState.Hovered;
			}
			// if none of the above happen
			else
			{
				State = InteractionState.Normal;
			}
			
			// if not interactable
			if(!Interactable)
				State = InteractionState.Disabled;
			
			if(State != oldState)
				OnStateChange(State, oldState);
		}

		protected abstract void OnStateChange(InteractionState _state, InteractionState _oldstate);

		protected Color ColorFromState()
		{
			switch(State)
			{
				// If button is has changed change color accordingly
				case InteractionState.Normal :
					return colors.normal;
				case InteractionState.Hovered:
					return colors.hovered;
				case InteractionState.Selected:
					return colors.selected;
				case InteractionState.Disabled:
					return colors.disabled;
				default:
					return Color.BLACK;
			}
		}
		
	}
}