using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BurdsPackTerrariaMod.Projectiles
{
    public class ScytheOfCthulhuProjectile : ModProjectile
    {
        private float rotationScale = 0.2f / 100; // Sets speed of rotation of projectile
        private float velocityScale = 0.98f; // Loses 2% of its value each frame when multiplied by this.
        private int fadeScale; // Defined in SetDefaults, states how fast the projectile fades (lower value = fade sooner).
        public override void SetDefaults()
        {
            projectile.width = 50;
            projectile.height = 50;
            projectile.penetrate = 30;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.tileCollide = false;
            projectile.light = 0.4f;
            projectile.timeLeft = 200; // frames
            fadeScale = projectile.timeLeft*15;
            projectile.ignoreWater = true;
            projectile.extraUpdates = 1;
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            //projectile.type = 274; // Sets projectile to death sickle projectiles.
        }

        public override void AI()
        {
            // Dust trail
            //Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 21, projectile.velocity.X * -0.5f, projectile.velocity.Y * -0.5f); // Create dust trail following projectile (15 is the dust, change for a different type)
            
            // Lighting (purple is 1 part red, 0 parts green, 1 part blue (1:0:1))
            Lighting.AddLight(projectile.position, 1f, 0f, 1f);

            // Speed (slowing down the closer we get to the end).
            projectile.velocity.X *= velocityScale;
            projectile.velocity.Y *= velocityScale;

            // Projectile Spin
            if (projectile.velocity.X < 0) {  // Moving left, invert direction of sprite and direction of its rotation
                projectile.spriteDirection = -1; // Invert direction of sprite (flip the sprite), which also inverts its rotation (sprite now faces and spins left instead of right.)
                //Main.NewText(projectile.rotation.ToString() + " " + projectile.spriteDirection.ToString(), 0, 0, 255, true);
            } 
            projectile.rotation += (projectile.spriteDirection * projectile.timeLeft * rotationScale);

            // Projectile fade
            projectile.alpha = fadeScale / projectile.timeLeft; 
        }

        public override void PostAI() // called after each AI() call
        {
            // maybe some velocity checks?
        }

        public override void Kill(int timeLeft) // Called on projectile kill (obviously)
        {
            // Create explosion
            // Main.PlaySound(SoundID.Item14, projectile.position);
            // Create dust
            // for (int i=0; i<10; i++) {
            //     Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 107, projectile.velocity.X * -0.5f, projectile.velocity.Y * -0.5f);
            // }
        }
    }
}