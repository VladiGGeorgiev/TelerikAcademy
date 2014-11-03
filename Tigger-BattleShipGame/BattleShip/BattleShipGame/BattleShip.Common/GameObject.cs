using System;
namespace BattleShip.Common
{
    public abstract class GameObject : IRenderable, IHittable
    {
        public abstract Array GetBody();
        public abstract bool RespondToHit(Position position);
    }
}
