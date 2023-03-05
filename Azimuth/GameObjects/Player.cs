using System.Numerics;
using Raylib_cs;

namespace Azimuth.GameObject;

public class Player : AnimatedGameObject
{
    private Movement movement;
    public Player(string _image, Vector2 _size, int _sourceAmountX, int _sourceAmountY, Vector2 _position) 
        : base(_image, _size, _sourceAmountX, _sourceAmountY, _position) { }
    
}