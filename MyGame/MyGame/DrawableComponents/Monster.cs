﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Helper;
using control;
using XNAnimation;

namespace MyGame
{
    public class Monster : CDrawableComponent
    {
        public int health = 100;

        private MonsterModel monsterModel;
        public MonsterUnit monsterUnit;

        public MonsterModel.MonsterAnimations ActiveAnimation
        {
            get 
            {
                return monsterModel.activeAnimation;
            }
        }

        public int getScore()
        {
            return monsterUnit.monsterConstants.SCORE;
        }

        public Monster(MyGame game, CModel model, Unit unit)
            : base(game, unit, model)
        {
            monsterModel = ((MonsterModel)cModel);
            monsterUnit = ((MonsterUnit)unit);
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            if (!myGame.camera.BoundingVolumeIsInView(unit.BoundingBox/*BoundingSphere*/) && !monsterModel.isRunning)
                return;
            monsterModel.animationController.Update(gameTime.ElapsedGameTime, Matrix.Identity);

            if ((monsterModel.activeAnimation == MonsterModel.MonsterAnimations.TakeDamage ||
                monsterModel.activeAnimation == MonsterModel.MonsterAnimations.Bite) &&
                !monsterModel.animationController.IsPlaying)
            {
                if (monsterModel.isRunning)
                {
                    monsterUnit.moving = true;
                    monsterModel.Run();
                }
                else
                {
                    monsterUnit.moving = false;
                    monsterModel.Idle();
                }
            }

            Vector3 pos = unit.position;
            unit.position.Y = myGame.GetHeightAtPosition(pos.X, pos.Z);
            base.Update(gameTime);
        }

        /// <summary>
        /// This method renders the current state.
        /// </summary>
        /// <param name="gameTime">The elapsed game time.</param>
        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }

        public void Idle()
        {
            monsterModel.Idle();
        }

        public void Run()
        {
            monsterModel.Run();
        }

        public void Bite()
        {
            monsterModel.Bite();
        }

        public void TakeDamage()
        {
            monsterModel.TakeDamage();
        }

        public void Die()
        {
            monsterModel.Die();
        }
    }
}
