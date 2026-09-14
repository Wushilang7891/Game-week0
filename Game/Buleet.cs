using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace MyGame;

public class Buleet : Entity
{
    public bool IsPlayerBullet { get; }

    public Buleet(Texture2D _texture, Vector2 _position) : base(_texture, _position)
    {
        velocity = new Vector2(0, -100);
        IsPlayerBullet = true;
    }

    public Buleet(Texture2D _texture, Vector2 _position, Vector2 _velocity) : base(_texture, _position)
    {
        velocity = _velocity;
        IsPlayerBullet = _velocity.Y < 0;
    }

    public override void Update(GameTime gameTime)
    {
        if (position.X < 0 || position.X > 1920)
        {

            if (position.Y < 0 || position.Y > 1080)
            {

            }
        }

        foreach (var entity in Main.entities)
        {
            if (IsPlayerBullet && entity is Enemy enemy && !enemy.IsRemoved && Bounds.Intersects(enemy.Bounds))
            {
                Debug.WriteLine("Bullet hit enemy!");
                enemy.Remove();
                Remove();
                Main.AddEntity(new Enemy(Main._img2,  new Vector2(100, 0)));
                Main.AddEntity(new Enemy(Main._img2, new Vector2(0, 0)));
                break;
            }
        }
        base.Update(gameTime);
    }


}


