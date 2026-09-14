using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace MyGame;

public class Enemy : Entity
{
    public Enemy(Texture2D _texture, Vector2 _position) : base(_texture, _position)
    {
    }

    public Enemy(Texture2D _texture) : base(_texture)
    {
    }

    public override void Update(GameTime gameTime)
    {
        // Implement enemy-specific update logic here
        if(position.X > 1920 || position.X < 0)
        {
        velocity = velocity*-1;
        position = new Vector2(position.X, position.Y + 20);
        }

        base.Update(gameTime);
        
    }
}


