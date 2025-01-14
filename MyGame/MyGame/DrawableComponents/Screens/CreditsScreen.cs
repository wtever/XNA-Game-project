﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Helper;
using control;

namespace MyGame
{
    /// <summary>
    /// This class represent the Credits Screen that hold the name of the persons who worked on that game
    /// </summary>
    public class CreditsScreen : Screen
    {
        // Shot variables
        //private const int keyDelay = 100;
        private float preferredtitlePosOffset = 150;
        private Color titleColor = Color.Yellow;

        private String[] menuItems = new String[] { "Amr EL-Assal" , "Housam Hassan" , "Housam Sherif", 
                                                    "Housam Mahmoud", "Mahmoud Bahaa", "Mohamed Madyan", 
                                                    "El-Mo3tasem" };

        public CreditsScreen(MyGame game)
            : base(game,500)
        {
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            if (checkSilencePeriod(gameTime))
                return;
            KeyboardState keyState = Keyboard.GetState();
            if (delayedAction.eventHappened(gameTime, keyState.IsKeyDown(Keys.Enter) 
                                                    && !keyState.IsKeyDown(Keys.RightAlt)))
            {
                myGame.mediator.fireEvent(MyEvent.G_StartScreen);
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// This method renders the current state.
        /// </summary>
        /// <param name="gameTime">The elapsed game time.</param>
        public override void Draw(GameTime gameTime)
        {
            Game.GraphicsDevice.Clear(backgroundColor);
            spriteBatch.Begin();

            String title = "Credits";
            Vector2 pos = findCenteredPos(title, bigFont);
            Vector2 nextPosOffset = new Vector2(0, Math.Min(preferredtitlePosOffset, pos.Y));
            pos -= nextPosOffset;
            spriteBatch.DrawString(bigFont, title, pos, titleColor);

            nextPosOffset = nextPosOffset - new Vector2(0, bigFont.MeasureString(title).Y);
            for (int i = 0; i < menuItems.Count(); i++)
            {
                pos = findCenteredPos(menuItems[i], mediumFont) - nextPosOffset;

                spriteBatch.DrawString(mediumFont, menuItems[i], pos, menuItemColor);
                nextPosOffset = nextPosOffset - new Vector2(0, mediumFont.MeasureString(menuItems[i]).Y);
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
