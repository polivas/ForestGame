using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using tainicom.Aether.Physics2D.Dynamics;
using tainicom.Aether.Physics2D.Dynamics.Contacts;

namespace ForestGame
{
    public enum EyeballState
    {
        Idle = 0,
        Move = 1,
        Blink = 2
    }

    class EyeballSprite
    {
        Texture2D texture;
        Vector2 origin;
        float radius;
        float scale;

        private double animationTimer;
        private short animationFrame = 0;

        Body body;

        /// <summary>
        /// the direction of the monster
        /// </summary>
        public EyeballState State;

        /// <summary>
        /// position of the eyeball
        /// </summary>
        public Vector2 Position;

        /// <summary>
        /// A vector to the center of the eyeball
        /// </summary>
        public Vector2 Center { get; set; }

        /// <summary>
        /// A vector representing the velocity of the eyeball
        /// </summary>
        public Vector2 Velocity { get; set; }

        /// <summary>
        /// A boolean indicating if this monster is colliding with an object
        public bool Colliding { get; protected set; }


        public EyeballSprite(float radius, Body body)
        {
            this.body = body;
            this.radius = radius;
            scale = 1;
            origin = new Vector2(5, 5);
            //this.body.OnCollision += CollisionHandler;
        }



        /// <summary>
        /// Loads the eyeball's texture
        /// </summary>
        /// <param name="contentManager">The content manager to use</param>
        public void LoadContent(ContentManager contentManager)
        {
            texture = contentManager.Load<Texture2D>("eyeball spritesheet");
        }

        /// <summary>
        /// Updates the eyeball's sprite to fly in a pattern
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {

            Center += Velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (Center.X < radius || Center.X > Constants.GAME_MAX_WIDTH - radius) Velocity *= -Vector2.UnitX;
            if (Center.Y < radius || Center.Y > Constants.GAME_HEIGHT - radius) Velocity *= -Vector2.UnitY;
            Colliding = false;
        }


        /// <summary>
        /// Draws the animated sprite
        /// </summary>
        /// <param name="gametime">The game time</param>
        /// <param name="spriteBatch">The spritebatch to draw with</param>
        public void Draw(GameTime gametime, SpriteBatch spriteBatch)
        {


            if (Colliding == false)
            {
                //Update animation Timer
                animationTimer += gametime.ElapsedGameTime.TotalSeconds;

                //Update animation frame
                if (animationTimer > 0.3)
                {
                    animationFrame++;
                    if (animationFrame > 7) animationFrame = 0;
                    animationTimer -= 0.3;
                }

                if (this.body.LinearVelocity.X > 0)
                {
                    State = EyeballState.Move; //Right
                    
                }
                if (this.body.LinearVelocity.X < 0)
                {
                    State = EyeballState.Move; //Left
                }
                if(this.body.LinearVelocity.X == 0 && this.body.LinearVelocity.Y == 0)
                {
                    State = EyeballState.Idle;
                }

                //Draw the sprite
                var source = new Rectangle(animationFrame * 32, (int)State * 32, 32, 32);
                spriteBatch.Draw(texture, Center, source, Color.White, 0, origin, scale, SpriteEffects.None, 0);
            }
        }
        


        //Is checking if it has collided 
        public bool CollisionHandler()
        {

            return false;
        }
    }
}
