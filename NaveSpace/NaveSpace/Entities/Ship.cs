using System.Collections.Generic;
using CocosSharp;
using NaveSpace.Factories;

namespace NaveSpace.Entities
{
    class Ship : CCNode
    {
        CCSprite sprite;

        CCEventListenerTouchAllAtOnce touchListener;

        public Ship() : base()
        {
            sprite = new CCSprite("ship.png");            
            sprite.AnchorPoint = CCPoint.AnchorMiddle;
            AddChild(sprite);

            touchListener = new CCEventListenerTouchAllAtOnce();
            touchListener.OnTouchesMoved = HandleInput;
            AddEventListener(touchListener, this);

            Schedule(FireBullet, interval: 0.5f);
        }

        private void HandleInput(List<CCTouch> touches, CCEvent touchEvent)
        {
            if (touches.Count > 0)
            {
                CCTouch firstTouch = touches[0];

                PositionX = firstTouch.Location.X;
                PositionY = firstTouch.Location.Y;
            }
        }

        void FireBullet(float unusedValue)
        {
            Bullet newBullet = BulletFactory.Self.CreateNew();
            newBullet.Position = this.Position;
            newBullet.VelocityY = 100;
        }
    }
}
