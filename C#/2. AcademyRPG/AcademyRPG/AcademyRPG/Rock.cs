using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyRPG
{
    class Rock : StaticObject, IResource
    {
        public int Quantity
        { 
            get 
            { 
                return this.HitPoints / 2; 
            } 
        }

        public ResourceType Type 
        {
            get 
            { 
                return ResourceType.Stone;
            } 
        }

        public Rock(Point position, int hitPoints) : base(position, 0)
        {
            this.HitPoints = hitPoints;
        }
    }
}
