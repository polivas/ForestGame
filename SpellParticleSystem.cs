using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ForestGame
{
    public class SpellParticleSystem : ParticleSystem
    {
        public SpellParticleSystem(Game game, int maxExplosions) : base(game, maxExplosions * 15) { }

        protected override void InitializeConstants()
        {
            textureFilename = "12_nebula_spritesheet";

            minNumParticles = 1;
            maxNumParticles = 5;

            blendState = BlendState.Additive;
            DrawOrder = AdditiveBlendDrawOrder;
        }

        protected override void InitializeParticle(ref Particle p, Vector2 where)
        {
            var velocity = RandomHelper.NextDirection() * RandomHelper.NextFloat(20, 80);
            var lifetime = RandomHelper.NextFloat(0.5f, .80f);

            var acceleration = -velocity / lifetime;

            var rotation = RandomHelper.NextFloat(0, MathHelper.PiOver2);

            var angularVelocity = RandomHelper.NextFloat(-MathHelper.PiOver4, MathHelper.PiOver4);

           // var scale = RandomHelper.NextFloat(2, 5);

            p.Initialize(where, velocity, acceleration, lifetime: lifetime, rotation: rotation, angularVelocity: angularVelocity);
        }

        protected override void UpdateParticle(ref Particle particle, float dt)
        {
            base.UpdateParticle(ref particle, dt);

            float normalizedLifetime = particle.TimeSinceStart / particle.Lifetime;

            float alpha = 4 * normalizedLifetime * (1 - normalizedLifetime);
            particle.Color = Color.CornflowerBlue * alpha;

            particle.Scale = .5f + .80f * normalizedLifetime;
        }

        public void PlaceExplosion(Vector2 where) => AddParticles(where);

    }
}

