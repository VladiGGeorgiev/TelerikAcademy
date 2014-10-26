using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyRPG
{
    class Knight : Character, IFighter
    {
        public int AttackPoints { get { return 100; } }

        public int DefensePoints { get { return 100; } }

        public Knight(string name, Point position, int owner) : base(name, position, owner)
        {
            this.HitPoints = 100;
        }

        public int GetTargetIndex(List<WorldObject> availableTargets)
        {
            for (int i = 0; i < availableTargets.Count; i++)
            {
                if (availableTargets[i].Owner != this.Owner && availableTargets[i].Owner != 0)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
