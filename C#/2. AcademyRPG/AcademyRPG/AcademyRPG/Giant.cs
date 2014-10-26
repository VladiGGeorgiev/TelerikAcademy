using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyRPG
{
    class Giant : Character, IFighter, IGatherer
    {
        public int AttackPoints { get; private set; }

        public int DefensePoints { get; private set; }

        public Giant(string name, Point position) : base(name, position, 0)
        {
            this.AttackPoints = 150;
            this.DefensePoints = 80;
            this.HitPoints = 200;
        }


        public bool TryGather(IResource resource)
        {
            if (resource.Type == ResourceType.Stone)
            {
                this.AttackPoints = 250;
                return true;
            }

            return false;
        }

        public int GetTargetIndex(List<WorldObject> availableTargets)
        {
            for (int i = 0; i < availableTargets.Count; i++)
            {
                if (availableTargets[i].Owner != 0)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
