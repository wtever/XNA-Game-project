﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MyGame
{
    public class BulletUnit : Unit
    {
        Vector3 Direction { get; set; }
        float bulletSpeed = 3f;

        public BulletUnit(Game1 game,Vector3 Position, Vector3 Rotation, Vector3 Scale,Vector3 Direction)
            : base(game,Position, Rotation, Scale)
        {
            this.Direction = Direction;            
        }

        public override void update(GameTime gameTime)
        {
            // Move bullet
            baseWorld *= Matrix.CreateTranslation(Direction* bulletSpeed);
        }


        public bool isInRange(float x,float z,float range){
            return true;
                //baseWorld.Translation.Z > z-range && baseWorld.Translation.X > x-range &&
                //baseWorld.Translation.Z < z + range && baseWorld.Translation.X < x + range;
        }
    }
}