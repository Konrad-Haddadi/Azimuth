using System.Numerics;
using Raylib_cs;

namespace Azimuth.GameObject;

public class Movement : GameObject
{
    private KeyboardKey left;
    private KeyboardKey right;
    private KeyboardKey up;
    private KeyboardKey down;
    private KeyboardKey jump;
    public float speed;
    
    public Movement(float _speed, KeyboardKey _left, KeyboardKey _right, KeyboardKey _up, KeyboardKey _down) 
    {
        left = _left;
        right = _right;
        up = _up;
        down = _down;
        speed = _speed;
    }
    
    public Movement(float _speed, KeyboardKey _left, KeyboardKey _right, KeyboardKey _jump) 
    {
        left = _left;
        right = _right;
        jump = _jump;
        speed = _speed;
    }

    public override void Update(float _deltaTime)
    {
        position = MovementSettings(_deltaTime / 2);
    }

    public Vector2 MovementSettings(float _deltaTime)
    {
        if (Raylib.IsKeyDown(left))
            position.X-= speed;
        
        if (Raylib.IsKeyDown(right))
            position.X+= speed;
        
        if (Raylib.IsKeyDown(up))
            position.Y -= speed;
        
        if (Raylib.IsKeyDown(down))
            position.Y+= speed;
        
        return position;
    }
}