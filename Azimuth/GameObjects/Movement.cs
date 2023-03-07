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
    public float groundHeight;
    private const float GRAVITY = -1.1f;
    public float yVelocity = 0;
    public int jumpHeight;
    public bool onGround = true;
    public float speed;
    public float deltaTime;
    
    public Movement(float _speed, Vector2 _position, KeyboardKey _left, KeyboardKey _right, KeyboardKey _up, KeyboardKey _down)
    {
        position = _position;
        left = _left;
        right = _right;
        up = _up;
        down = _down;
        speed = _speed;
    }
    
    public Movement(float _speed, Vector2 _position, int _jumpHeight, KeyboardKey _left, KeyboardKey _right, KeyboardKey _jump) 
    {
        position = _position;
        left = _left;
        right = _right;
        jump = _jump;
        speed = _speed;
        jumpHeight = _jumpHeight;
        onGround = false;
        position.Y += OnGroundCheck();
    }

    public override void Update(float _deltaTime)
    {
        position = MovementSettings(_deltaTime);
        
    }

    public Vector2 MovementSettings(float _deltaTime)
    {
        if (Raylib.IsKeyPressed(jump))
            position.Y -= jumpHeight * _deltaTime ;
        
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

    public float OnGroundCheck()
    {
        if (Raylib.IsKeyPressed(jump))
        {
            yVelocity = 0;
        }
        else if (position.Y == groundHeight)
        {
            yVelocity = 0;
        }
        else if (position.Y != groundHeight)
        {
            yVelocity -= GRAVITY;
        }
        return yVelocity;
    }
}