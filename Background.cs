using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using ForestGame;

namespace ForestGame
{
    public class Background
    {

        // Layer textures
        private Texture2D _sky;
        private Texture2D _clouds;
        private Texture2D _mountain;
        private Texture2D _hill;
        private Texture2D _ground;
        private Texture2D _grass;

        // The position of the sprite?
        private Vector2 _position;

        /// <summary>
        /// The current position
        /// </summary>
        public Vector2 Position => _position;

        public void LoadContent(ContentManager content)
        {

            //Load background texture.
            _sky = content.Load<Texture2D>("sky_layer");
            _clouds = content.Load<Texture2D>("cloud_layer");
            _mountain = content.Load<Texture2D>("mountain_layer");
            _hill = content.Load<Texture2D>("hill_layer");
            _ground = content.Load<Texture2D>("ground_layer");
            _grass = content.Load<Texture2D>("grass_layer");
        }

        public void Update(GameTime gameTime)
        { 
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch, Player player)
        {
            float playerX = MathHelper.Clamp(player.Position.X, 300, 13600);

            float offsetX = 300 - playerX;

            Matrix transform;

            // Background Sky
            transform = Matrix.CreateTranslation(offsetX * 0.333f, 0, 0);
            spriteBatch.Begin(transformMatrix: transform);
            spriteBatch.Draw(_sky,
               new Rectangle(0, 0, Constants.GAME_WIDTH, Constants.GAME_HEIGHT),
               new Rectangle(0, 0, 272, 160),
               Color.White);
            spriteBatch.End();


            //Mountain Layer
            transform = Matrix.CreateTranslation(offsetX * 0.555f, 0, 0);
            spriteBatch.Begin(transformMatrix: transform);
            spriteBatch.Draw(_mountain,
               new Rectangle(0, 0, Constants.GAME_WIDTH, Constants.GAME_HEIGHT),
               new Rectangle(0, 0, 272, 160),
               Color.White);
            spriteBatch.End();

            //Hill Layer
            transform = Matrix.CreateTranslation(offsetX * 0.666f, 0, 0);
            spriteBatch.Begin(transformMatrix: transform);
            spriteBatch.Draw(_hill,
              new Rectangle(0, 0, Constants.GAME_WIDTH, Constants.GAME_HEIGHT),
              new Rectangle(0, 0, 272, 160),
             Color.White);
            spriteBatch.End();


            //Ground Layer
            transform = Matrix.CreateTranslation(offsetX, 0, 0);

            spriteBatch.Begin(transformMatrix: transform);
            spriteBatch.Draw(_ground,
                new Rectangle(0, 0, Constants.GAME_WIDTH, Constants.GAME_HEIGHT),
                 new Rectangle(0, 0, 272, 160),
                 Color.White);
            player.Draw(gameTime, spriteBatch);

            spriteBatch.End();

            //Grass layer
            transform = Matrix.CreateTranslation(offsetX * 1.25f, 0, 0);

            spriteBatch.Begin(transformMatrix: transform);
            // _spriteBatch.Draw(_grass, Vector2.Zero, Color.White);
            spriteBatch.Draw(_grass,
                  new Rectangle(0, 0, Constants.GAME_WIDTH, Constants.GAME_HEIGHT),
                  new Rectangle(0, 0, 272, 160),
               Color.White);
            spriteBatch.End();


        }

    }
}
