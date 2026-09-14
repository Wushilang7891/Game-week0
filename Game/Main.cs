using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace MyGame;

public class Main
{
    public static Texture2D _img;
    public static Texture2D _img2;
    public static Texture2D bulletTexture;
    public static List<Entity> entities;
    private static readonly List<Entity> pendingEntities = new();
    private Player player;
    private Enemy2 enemy2;
    private Enemy enemy;

    private Vector2 yyyposition = new Vector2(0, 0); 
    
    float timer = 0f;
    float timed = 0f;
    float timeq = 0f;

    bool isPlayerAlive = true; // Flag to track if the player is currently respawning

    public Main(ContentManager content)
    {
        Debug.WriteLine("Main initialized");
        LoadContent(content);
        entities = new List<Entity>();
        player = new Player(_img, new Vector2(20, 1000));
        entities.Add(player);


        enemy = new Enemy(_img2, new Vector2(150, 190));
        entities.Add(enemy);
        enemy2 = new Enemy2(_img2, new Vector2(500, 500));
        entities.Add(enemy2);
    }

    public void LoadContent(ContentManager content)
    {
        _img = content.Load<Texture2D>("uio");
        _img2 = content.Load<Texture2D>("qwer");
        bulletTexture = content.Load<Texture2D>("bu");

    }

    public void Update(GameTime gameTime)
    {
        // Debug.WriteLine("Update called");
        foreach (var entity in entities)
        {
            entity.Update(gameTime);
        }
        entities.RemoveAll(entity => entity.IsRemoved);

        if (pendingEntities.Count > 0)
        {
            entities.AddRange(pendingEntities);
            pendingEntities.Clear();
        }
        KeyboardState keyboardState = Keyboard.GetState();

        if (isPlayerAlive)
        {

            if (keyboardState.IsKeyDown(Keys.Space))
            {
                if (timer <= (float)gameTime.TotalGameTime.TotalSeconds)
                {
                    Vector2 weizhi = player.GetPosition() + new Vector2(60, 0); // Adjust the bullet's position to be slightly above the player
                    AddEntity(new Buleet(bulletTexture, weizhi));
                    timer = (float)gameTime.TotalGameTime.TotalSeconds + 0.3F;
                }
                // AddBuleet is an instance method; invoke it through a Main instance.
            }
        }
        else
        {
            RespawnPlayer(gameTime); // Call the respawn method if the player is not alive
        }

        foreach (var entity in entities)
        {
            if (!player.IsRemoved && entity is Buleet bullet && !bullet.IsRemoved && !bullet.IsPlayerBullet && bullet.Bounds.Intersects(player.Bounds))
            {
                yyyposition = player.GetPosition();
                bullet.Remove();
                player.SetPosition(new Vector2(676767676767, 0)); // Move the player off-screen
                isPlayerAlive = false;
                timeq = (float)gameTime.TotalGameTime.TotalSeconds + 5.0f;
                //RespawnPlayer(gameTime); // Call the respawn method
                break; // Exit the loop after handling the collision

            }
        }

        entities.RemoveAll(entity => entity.IsRemoved);

        if (timed <= (float)gameTime.TotalGameTime.TotalSeconds)
        {
            foreach (var entity in entities)
            {
                if (entity is Enemy enemy && !enemy.IsRemoved)
                {
                    Vector2 bulletPosition = enemy.GetPosition() + new Vector2(30, 100);
                    AddEntity(new Buleet(bulletTexture, bulletPosition, new Vector2(0, 20)));
                }
            }
            timed = (float)gameTime.TotalGameTime.TotalSeconds + 0.5F;
        }

        // if(turtle.position.X > 60)
        // {*
        //     turtle.SetPosition(Vector2.Zero);
        // }


    }

    public void Draw(SpriteBatch _spriteBatch)
    {
        // TODO: Add your drawing code here
        _spriteBatch.Begin();
        foreach (var entity in entities)
        {
            entity.Draw(_spriteBatch);
        }
        _spriteBatch.End();

    }


    private void RespawnPlayer(GameTime gameTime)
    {
        Debug.WriteLine("Respawning player...");
        // Set a delay before respawning the player

        // Check if the delay has passed
        if ((float)gameTime.TotalGameTime.TotalSeconds >= timeq)
        {
            player.SetPosition(yyyposition); // Respawn the player at the initial position
            isPlayerAlive = true; // Mark the player as alive again
            timeq = (float)gameTime.TotalGameTime.TotalSeconds + 5.0f; // 5 seconds delay
        }
    }

    public static void AddEntity(Entity entity)
    {
        pendingEntities.Add(entity);
    }
}