using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace MyGame;

public class Enemy2 : Enemy
{
    public Enemy2(Texture2D _texture, Vector2 _position) : base(_texture, _position)
    {
        // position = new Vector2(100,100);
    }

    public Enemy2(Texture2D _texture) : base(_texture)
    {
    }

    public override void Update(GameTime gameTime)
    {

        base.Update(gameTime);
    }

}


