using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace ForestGame
{
    public class CloudParticleSystem : ParticleSystem
    {
        Rectangle _source;

        public bool isCoudy { get; set; } = true;

        public CloudParticleSystem(Game game, Rectangle source) : base(game, 20)
        {
            _source = source;
        }

        protected override void InitializeConstants()
        {
            textureFilename = "cloud_layer";
            minNumParticles = 1;
            maxNumParticles = 10;
        }

        protected override void InitializeParticle(ref Particle p, Vector2 where)
        {
            p.Initialize(where, Vector2.UnitX * 5, Vector2.Zero, Color.White, scale: RandomHelper.NextFloat(1.0f, 0.5f), lifetime: 500);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (isCoudy) AddParticles(_source);
        }

    }
}
