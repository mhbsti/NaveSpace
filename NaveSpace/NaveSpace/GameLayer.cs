using System;
using System.Collections.Generic;
using CocosSharp;
using Microsoft.Xna.Framework;
using NaveSpace.Entities;
using NaveSpace.Factories;

namespace NaveSpace
{
    public class GameLayer : CCLayerColor
    {

        // Define a label variable
        Ship ship;
        List<Bullet> bullets;

        public GameLayer() : base(CCColor4B.Blue)
        {
            ship = new Ship();
            ship.PositionX = 240;
            ship.PositionY = 50;
            AddChild(ship);

            bullets = new List<Bullet>();
            BulletFactory.Self.BulletCreated += HandleBulletCreated;
        }

        void HandleBulletCreated(Bullet newBullet)
        {
            AddChild(newBullet);
            bullets.Add(newBullet);
        }

        protected override void AddedToScene()
        {
            base.AddedToScene();

            // Use the bounds to layout the positioning of our drawable assets
            var bounds = VisibleBoundsWorldspace;

            // position the label on the center of the screen
            //label.Position = bounds.Center;

            // Register for touch events
            var touchListener = new CCEventListenerTouchAllAtOnce();
            touchListener.OnTouchesEnded = OnTouchesEnded;
            AddEventListener(touchListener, this);
        }

        void OnTouchesEnded(List<CCTouch> touches, CCEvent touchEvent)
        {
            if (touches.Count > 0)
            {
                // Perform touch handling here
            }
        }
	}
}

