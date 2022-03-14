using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ForestGame
{
    public class ForestGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public Player _player;
        private Background _background;



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
            _background = new Background();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _player.LoadContent(Content);
            _background.LoadContent(Content);
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

            _background.Update(gameTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gameTime"></param>
        protected override void Draw(GameTime gameTime)
        {
           // _spriteBatch.Begin();
            GraphicsDevice.Clear(Color.CornflowerBlue);
            //_player.Draw(gameTime, _spriteBatch);
             _background.Draw(gameTime, _spriteBatch, _player);
           //_spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
