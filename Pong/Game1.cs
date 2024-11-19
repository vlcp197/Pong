using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pong
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        Paddle paddle;
        Paddle paddle2;
        Ball ball;
        SpriteFont font;


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
            paddle = new Paddle(false);
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

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            paddle.Update(gameTime);
            paddle2.Update(gameTime);
            ball.Update(gameTime, paddle, paddle2);
            base.Update(gameTime);


        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            Globals.spriteBatch.Begin();

            paddle.Draw();
            paddle2.Draw();
            ball.Draw();

            Globals.spriteBatch.DrawString(font, Globals.player1_score.ToString(), new Vector2(100, 50), Color.White);

            Globals.spriteBatch.DrawString(font, Globals.player2_score.ToString(), new Vector2(Globals.WIDTH - 112, 50), Color.White);

            Globals.spriteBatch.End();


            base.Draw(gameTime);

        }
    }
}
