using CocosSharp;

namespace NaveSpace.Entities
{
    class Bullet : CCNode
    {
        CCSprite sprite;

        public float VelocityX { get; set; }
        public float VelocityY { get; set; }
       
        public Bullet() : base()
        {
            sprite = new CCSprite("bullet.png");           
            sprite.AnchorPoint = CCPoint.AnchorMiddle;
            AddChild(sprite);
            Schedule(ApplyVelocity);
        }

        void ApplyVelocity(float time)
        {
            PositionX += VelocityX * time;
            PositionY += VelocityY * time;
        }

        
    }
}
