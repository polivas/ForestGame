using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ForestGame
{
    public class ForestGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Player _player;

        // Layer textures
        private Texture2D _sky;
        private Texture2D _clouds;
        private Texture2D _mountain;
        private Texture2D _hill;
        private Texture2D _ground;
        private Texture2D _grass;


        public ForestGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = Constants.GAME_WIDTH;
            _graphics.PreferredBackBufferHeight = Constants.GAME_HEIGHT;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            _graphics.GraphicsProfile = GraphicsProfile.HiDef;
        }

        protected override void Initialize()
        {
            _player = new Player();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _player.LoadContent(Content);

            //Load background texture.
            _sky = Content.Load<Texture2D>("sky_layer");
            _clouds = Content.Load<Texture2D>("cloud_layer");
            _mountain = Content.Load<Texture2D>("mountain_layer");
            _hill = Content.Load<Texture2D>("hill_layer");
            _ground = Content.Load<Texture2D>("ground_layer");
            _grass = Content.Load<Texture2D>("grass_layer");
        }

        /// <summary>
        /// Updates the game
        /// </summary>
        /// <param name="gameTime">An object representing time in-game</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            _player.Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gameTime"></param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            float playerX = MathHelper.Clamp(_player.Position.X, 300, 13600);

            float offsetX = 300 - playerX;

            Matrix transform;

            // Background Sky
            transform = Matrix.CreateTranslation(offsetX * 0.333f, 0, 0);
            _spriteBatch.Begin(transformMatrix: transform);
            //_spriteBatch.Draw(_sky, Vector2.Zero, Color.White);
            _spriteBatch.Draw(_sky,
               new Rectangle(0, 0, Constants.GAME_WIDTH, Constants.GAME_HEIGHT),
               new Rectangle(0, 0, 272, 160),
               Color.White);
            _spriteBatch.End();




            //Mountain Layer
            transform = Matrix.CreateTranslation(offsetX * 0.555f, 0, 0);
            _spriteBatch.Begin(transformMatrix: transform);
            // _spriteBatch.Draw(_mountain, Vector2.Zero, Color.White);
            _spriteBatch.Draw(_mountain,
               new Rectangle(0, 0, Constants.GAME_WIDTH, Constants.GAME_HEIGHT),
               new Rectangle(0, 0, 272, 160),
               Color.White);
            _spriteBatch.End();

            //Hill Layer
            transform = Matrix.CreateTranslation(offsetX * 0.666f, 0, 0);
            _spriteBatch.Begin(transformMatrix: transform);
            //_spriteBatch.Draw(_hill, Vector2.Zero, Color.White);
            _spriteBatch.Draw(_hill,
              new Rectangle(0, 0, Constants.GAME_WIDTH, Constants.GAME_HEIGHT),
              new Rectangle(0, 0, 272, 160),
             Color.White);
            _spriteBatch.End();


            //Ground Layer
            transform = Matrix.CreateTranslation(offsetX, 0, 0);

            _spriteBatch.Begin(transformMatrix: transform);
            // _spriteBatch.Draw(_ground, Vector2.Zero, Color.White);
            _spriteBatch.Draw(_ground,
                new Rectangle(0, 0, Constants.GAME_WIDTH, Constants.GAME_HEIGHT),
                 new Rectangle(0, 0, 272, 160),
                 Color.White);
            _player.Draw(gameTime, _spriteBatch);

            _spriteBatch.End();

            //Grass layer
            transform = Matrix.CreateTranslation(offsetX, 0, 0);

            _spriteBatch.Begin(transformMatrix: transform);
            // _spriteBatch.Draw(_grass, Vector2.Zero, Color.White);
            _spriteBatch.Draw(_grass,
                  new Rectangle(0, 0, Constants.GAME_WIDTH, Constants.GAME_HEIGHT),
                  new Rectangle(0, 0, 272, 160),
               Color.White);
            _spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
