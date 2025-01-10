using Microsoft.Xna.Framework;
using System;

namespace Pong;

public class Ball
{
    Rectangle ballRect;
    int right = 1, top = 1, moveSpeed = 250;
    public Particle particleSystem;

    public Ball()
    {
        ballRect = new Rectangle(Globals.WIDTH / 2 - 20, Globals.HEIGHT / 2 - 20, 20, 20);
        particleSystem = new Particle(new Vector2(ballRect.X, ballRect.Y));
    }

    public void Update(GameTime gameTime, Paddle player1, Paddle player2)
    {
        int deltaSpeed = (int)(moveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds);

        ballRect.X += right * deltaSpeed;
        ballRect.Y += top * deltaSpeed;

        if (player1.rect.Right > ballRect.Left && ballRect.Top > player1.rect.Top && ballRect.Bottom < player1.rect.Bottom)
        {
            right = 1;
            increaseMoveSpeed();

            particleSystem = new Particle(new Vector2(ballRect.X, ballRect.Y));
        }

        if (player2.rect.Left < ballRect.Right && ballRect.Top > player2.rect.Top && ballRect.Bottom < player2.rect.Bottom)
        {
            right = -1;
            increaseMoveSpeed();
            particleSystem = new Particle(new Vector2(ballRect.X, ballRect.Y));

        }

        if (ballRect.Y < 0)
        {
            top *= -1;
        }

        if (ballRect.Y > Globals.HEIGHT - ballRect.Height)
        {
            top *= -1;
        }

        if (ballRect.X < 0)
        {
            Globals.playerTwoScore += 1;
            resetGame();
        }

        if (ballRect.X > Globals.WIDTH - ballRect.Width)
        {
            Globals.playerOneScore += 1;
            resetGame();
        }

        // Update particle system continuously
        particleSystem.Update(gameTime);
    }

    public void Draw()
    {
        Globals.spriteBatch.Draw(Globals.pixel, ballRect, Color.White);
        if (particleSystem != null)
        {
            particleSystem.Draw();
        }
    }

    public void increaseMoveSpeed()
    {
        moveSpeed += 5;
    }

    public void resetGame()
    {
        moveSpeed = 250;
        ballRect.X = Globals.WIDTH / 2 - 20;
        ballRect.Y = Globals.HEIGHT / 2 - 20;
        particleSystem = new Particle(new Vector2(ballRect.X, ballRect.Y)); // Reset particle system
    }
}
