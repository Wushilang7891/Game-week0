using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace MyGame;

public class Player : Entity
{
    public Player(Texture2D _texture, Vector2 _position) : base(_texture, _position)
    {
    }

    public Player(Texture2D _texture) : base(_texture)
    {
    }

    public override void Update(GameTime gameTime)
    {
        KeyboardState keyboardState = Keyboard.GetState();
        if (keyboardState.IsKeyDown(Keys.Left)|| keyboardState.IsKeyDown(Keys.A))
        {
            velocity = new Vector2(-50, 0);
        }
        else if (keyboardState.IsKeyDown(Keys.Right) || keyboardState.IsKeyDown(Keys.D))
        {
            velocity = new Vector2(50, 0);
        }
        else if (keyboardState.IsKeyDown(Keys.Up) || keyboardState.IsKeyDown(Keys.W))
        {
            velocity = new Vector2(0, -50);
        }
        else if (keyboardState.IsKeyDown(Keys.Down) || keyboardState.IsKeyDown(Keys.S))
        {
            velocity = new Vector2(0, 50);
        }
        else
        {
            velocity = Vector2.Zero;
        }
       
       
        base.Update(gameTime); 
        // HandleInput(keyboardState);

    }  
}