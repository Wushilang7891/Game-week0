using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace MyGame;

public class Entity
{
    private Texture2D texture;
    public Vector2 position { get; protected set;} = Vector2.Zero;
    public Vector2 velocity {get; protected set;}= new Vector2(25, 0);

    public Vector2 Vel => velocity;
    public bool IsRemoved { get; private set; }

    public Rectangle Bounds => new Rectangle(
        (int)position.X,
        (int)position.Y,
        texture.Width,
        texture.Height);

    public Entity(Texture2D _texture, Vector2 _position)
    {
        texture = _texture;
        position = _position;
    }

    public Entity(Texture2D _texture)
    {
        texture = _texture;
    }

    public void SetPosition(Vector2 v)
    {
        position = v;
    }

    public void Remove()
    {
        IsRemoved = true;
    }

    public virtual void Update(GameTime gameTime)
    {
        position += velocity;
    }

    public void Draw(SpriteBatch _spriteBatch)
    {
        // TODO: Add your drawing code here
        _spriteBatch.Draw(texture, position, Color.White);
    }

    public Vector2 GetPosition()
    {
        return position;
    }
}


