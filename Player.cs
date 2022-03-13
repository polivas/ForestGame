using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;



namespace ForestGame
{
    class Player
    {
        // The texture atlas for Mage Character
        private Texture2D _texture;

        // The bounds of hte helicopter within the texture atlas
        private Rectangle _playerBounds = new Rectangle(0,192,32,32);

        // The position of the player
        private Vector2 _position;

        /// <summary>
        /// The current position of the player
        /// </summary>
        public Vector2 Position => _position;

        /// <summary>
        /// Loads the player texture atlas
        /// </summary>
        /// <param name="content">The ContentManager to use to load the content</param>
        public void LoadContent(ContentManager content)
        {
            _texture = content.Load<Texture2D>("wizard spritesheet calciumtrice");
        }

        /// <summary>
        /// Updates the player
        /// </summary>
        /// <param name="gameTime">An object representing time in the game</param>
        public void Update(GameTime gameTime)
        {
            var keyboardState = Keyboard.GetState();
            float t = (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (keyboardState.IsKeyDown(Keys.Left)) _position -= Vector2.UnitX * 100 * t;
            if (keyboardState.IsKeyDown(Keys.Right)) _position += Vector2.UnitX * 100 * t;
            //if (keyboardState.IsKeyDown(Keys.Up)) _position -= Vector2.UnitY * 60 * t;
           // if (keyboardState.IsKeyDown(Keys.Down)) _position += Vector2.UnitY * 120 * t;

        }

        /// <summary>
        /// Draws the player sprite
        /// </summary>
        /// <param name="gameTime">An object representing time in the game</param>
        /// <param name="spriteBatch">The SpriteBatch to draw the player with</param>
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            _position.Y = 200;
            spriteBatch.Draw(_texture, _position, _playerBounds, Color.White);
        }
    }
}
