using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace ForestGame
{
    public class ForestGame : Game, IParticleEmitter
    {
        MouseState _priorMouse;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public Player _player;
        private Background _background;

        private List<EyeballSprite> enemys;

        SpellParticleSystem _spells;
        CloudParticleSystem _clouds;

        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }

        /// <summary>
        /// Constructs a new game
        /// </summary>
        public ForestGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = Constants.GAME_WIDTH;
            _graphics.PreferredBackBufferHeight = Constants.GAME_HEIGHT;
            
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            _graphics.GraphicsProfile = GraphicsProfile.HiDef;
        }


        /// <summary>
        /// Initializes the game
        /// </summary>
        protected override void Initialize()
        {
            _player = new Player();
            _background = new Background();


            _clouds = new CloudParticleSystem(this, new Rectangle(-10, 115, 1500, 20));
            Components.Add(_clouds);

            _spells = new SpellParticleSystem(this, 10);
            Components.Add(_spells);

            base.Initialize();
        }


        /// <summary>
        /// Loads game content
        /// </summary>
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

            MouseState currentMouse = Mouse.GetState();
            Vector2 mousePosition = new Vector2(currentMouse.X, currentMouse.Y);

            _player.Update(gameTime);
            _background.Update(gameTime);

            if (currentMouse.LeftButton == ButtonState.Pressed && _priorMouse.LeftButton == ButtonState.Released)
            {
                _spells.PlaceExplosion(mousePosition);

            }

            Velocity = mousePosition - Position;
            Position = mousePosition;

            base.Update(gameTime);
        }

        /// <summary>
        /// Draws the game
        /// </summary>
        /// <param name="gameTime">An object representing time in the game</param>
        protected override void Draw(GameTime gameTime)
        {         
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _background.Draw(gameTime, _spriteBatch, _player);


            base.Draw(gameTime);
        }
    }
}
