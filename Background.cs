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
        public Texture2D texture;
        public Rectangle rectangle;

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



        /// <summary>
        /// Loads sprites into the game
        /// </summary>
        /// <param name="content">The content that is to be loaded fro monogame</param>
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

        /// <summary>
        /// Updates background
        /// </summary>
        /// <param name="gameTime">An object representing time in the game</param>
        public void Update(GameTime gameTime)
        { 
            

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gameTime">An object representing time in the game</param>
        /// <param name="spriteBatch">The SpriteBatch to draw the player with</param>
        /// <param name="player">Player in the world</param>
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch, Player player)
        {
            float playerX = MathHelper.Clamp(player.Position.X, 300, Constants.GAME_MAX_WIDTH);

            float offsetX = 300 - playerX;

            Matrix transform;
          
            // Background Sky

            spriteBatch.Begin(samplerState: SamplerState.LinearWrap);

            for (int i = 0; i < 3; i++)
            {
                spriteBatch.Draw(_sky,
                  new Rectangle(i * Constants.GAME_WIDTH, 0, Constants.GAME_WIDTH, Constants.GAME_HEIGHT),
                  new Rectangle(0, 0, 272, 160),
                 Color.White);
            }

            spriteBatch.End();

            //Mountain Layer
            transform = Matrix.CreateTranslation(offsetX * 0.250f, 0, 0);
            spriteBatch.Begin(transformMatrix: transform);

            for (int i = 0; i < 3; i++)
            {
                spriteBatch.Draw(_mountain,
                  new Rectangle(i * Constants.GAME_WIDTH, 0, Constants.GAME_WIDTH, Constants.GAME_HEIGHT),
                  new Rectangle(0, 0, 272, 160),
                 Color.White);
            }

            spriteBatch.End();

            //Hill Layer
            transform = Matrix.CreateTranslation(offsetX * 0.666f, 0, 0);
            spriteBatch.Begin(transformMatrix: transform, samplerState: SamplerState.LinearWrap);

            for(int i = 0; i < 4; i++)
            {
                spriteBatch.Draw(_hill,
                  new Rectangle(i * Constants.GAME_WIDTH, 0, Constants.GAME_WIDTH, Constants.GAME_HEIGHT),
                  new Rectangle(0, 0, 272, 160),
                 Color.White);
            }


            spriteBatch.End();


            //Ground Layer
            transform = Matrix.CreateTranslation(offsetX, 0, 0);

            spriteBatch.Begin(transformMatrix: transform);

            for (int i = 0; i < 5; i++)
            {
                spriteBatch.Draw(_ground,
                  new Rectangle(i * Constants.GAME_WIDTH, 0, Constants.GAME_WIDTH, Constants.GAME_HEIGHT),
                  new Rectangle(0, 0, 272, 160),
                 Color.White);
            }

            player.Draw(gameTime, spriteBatch);

            spriteBatch.End();

            //Grass layer
            transform = Matrix.CreateTranslation(offsetX * 1.25f, 0, 0);

            spriteBatch.Begin(transformMatrix: transform, samplerState: SamplerState.LinearWrap);
            // _spriteBatch.Draw(_grass, Vector2.Zero, Color.White);

            for (int i = 0; i < 6; i++)
            {
                spriteBatch.Draw(_grass,
                  new Rectangle(i * Constants.GAME_WIDTH, 0, Constants.GAME_WIDTH, Constants.GAME_HEIGHT),
                  new Rectangle(0, 0, 272, 160),
                 Color.White);
            }



            spriteBatch.End();


        }

    }
}
