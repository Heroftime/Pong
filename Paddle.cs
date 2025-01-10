using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace Pong;

public class Paddle
{
    public Rectangle rect;
    public float moveSpeed = 500f;
    public bool isSecondPlayer;
  
    public Paddle(bool isSecondPlayer = false)
    {
        this.isSecondPlayer = isSecondPlayer;

        int startingX = isSecondPlayer ? Globals.WIDTH - 20 : 0;

        rect = new Rectangle(startingX, 140, 20, 200);
    }
    public void Update(GameTime gameTime)
    {
        KeyboardState kState = Keyboard.GetState();

        int deltaSpeed = (int)(moveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds);

        if ((this.isSecondPlayer ? kState.IsKeyDown(Keys.Up) : kState.IsKeyDown(Keys.W)) && rect.Y > 0)
        {
            rect.Y -= deltaSpeed;
        }

        if ((this.isSecondPlayer ? kState.IsKeyDown(Keys.Down) : kState.IsKeyDown(Keys.S)) && rect.Y < (Globals.HEIGHT - rect.Height))
        {
            rect.Y += deltaSpeed;
        }

    }
    public void Draw()
    {
        Globals.spriteBatch.Draw(Globals.pixel, rect, Color.White);
    }
}
