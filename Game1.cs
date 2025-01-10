using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


/**
 * TODOS FOR COMPLETION:
 * 1. Add a particle effect when the ball hits the paddle (Yellow & Red particles) - DONE
 * 2. Add a sound effect when the ball hits the paddle
 * 3. Add a particle trail effect to the ball (and the intensity increases with ball speed) (Blue particles)
 * 4. Add a background music (some dance music)
 * 5. Add random power-ups that spawn in the middle of the screen (Red particles)
 * 6. Power-ups can be of three types (Power-up disappears on ball hit and only one can spawn at a time and they spawn randomly): 
 *      Green - Increase paddle size for the next hit.
 *      Red - Decrease paddle size for the next hit.
 *      Yellow - Player gets an extra point.
 *      Brown - Player loses a point.
 * 7. Add a Background image / effect which increases in intensity with ball movespeed.
 * 8. First Ball flow should be random and not fixed.
 * 
 **/

namespace Pong
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteFont font;
        private SpriteFont titleFont;
        private Paddle paddle;
        private Paddle paddle2;
        private Ball ball;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = Globals.WIDTH;
            _graphics.PreferredBackBufferHeight = Globals.HEIGHT;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            paddle = new Paddle();
            paddle2 = new Paddle(true);
            ball = new Ball();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            Globals.spriteBatch = new SpriteBatch(GraphicsDevice);

            Globals.pixel = new Texture2D(GraphicsDevice, 1, 1);
            Globals.pixel.SetData<Color>(new Color[] { Color.White });
            font = Content.Load<SpriteFont>("Score");
            titleFont = Content.Load<SpriteFont>("Title");
            
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            paddle.Update(gameTime);
            paddle2.Update(gameTime);
            ball.Update(gameTime, paddle, paddle2);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            Globals.spriteBatch.Begin();

            Globals.spriteBatch.DrawString(font, Globals.playerOneScore.ToString(), new Vector2(100, 50), Color.White);
            Globals.spriteBatch.DrawString(font, Globals.playerTwoScore.ToString(), new Vector2(Globals.WIDTH - 112, 50), Color.White);

            ball.Draw();
            paddle.Draw();
            paddle2.Draw();


            Globals.spriteBatch.DrawString(
                titleFont, 
                "Created By \n Noman", 
                new Vector2((Globals.WIDTH / 2) - 30, 50), 
                Color.White);


            Globals.spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
