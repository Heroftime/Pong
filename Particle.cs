using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;

namespace Pong;

public class Particle
{
    public Texture2D particleTexture;
    public Vector2[] particles = new Vector2[25]; // Use single array for position and velocity
    public Vector2[] velocities = new Vector2[25]; // Array for velocities
    public Color[] colors = new Color[25];

    public float[] lifetimes = new float[25]; // Array for lifetimes
    public float[] opacities = new float[25]; // Array for opacities

    public Vector2 position;
 
    // TODOS: Understand how this is working, experiment with different values

    public Particle(Vector2 _position)
    {
        particleTexture = Globals.pixel;
        position = _position;
       
        for (int i = 0; i < 25; i++)
        {
            // Initialize positions with random offsets
            var newPosition = new Vector2(position.X, position.Y);
            particles[i] = newPosition;


            var velocity = new Vector2((float)(Globals.random.NextDouble() * 2 - 1), (float)(Globals.random.NextDouble() * 2 - 1));
            velocities[i] = velocity * 100;

            // Initialize lifetimes and opacities
            lifetimes[i] = 1.0f; // Lifetime in seconds
            opacities[i] = 1.0f; // Fully opaque
            colors[i] = Globals.random.Next(0, 2) == 0 ? Color.Yellow : Color.Red;
        }
    }

    public void Update(GameTime gameTime)
    {
        float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
       
        for (int i = 0; i < particles.Length; i++)
        {
            // Update positions using stored velocities
            particles[i] += velocities[i] * deltaTime;

            // Update lifetimes and opacities
            lifetimes[i] -= deltaTime;
            if (lifetimes[i] < 0)
            {
                lifetimes[i] = 0;
                opacities[i] = 0;
            }
            else
            {
                opacities[i] = lifetimes[i]; // Fade out over time
            }
        }

     

    }

    public void Draw()
    {
        if (particleTexture != null)
        {
            for (int i = 0; i < particles.Length; i++)
            {
                if (opacities[i] > 0)
                {
                    Color color = colors[i] * opacities[i]; // Apply opacity
                    Globals.spriteBatch.Draw(particleTexture, particles[i], color);
                }
            }
        }
    }
}
