using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyRPG
{
    class Ninja : Character, IFighter, IGatherer
    {
        public Ninja(string name, Point position, int owner) : base(name, position, owner)
        {
            this.HitPoints = 1;
            this.DefensePoints = int.MaxValue;
            this.AttackPoints = 0;
        }

        public int AttackPoints { get; private set; }

        public int DefensePoints { get; private set; }

        public bool TryGather(IResource resource)
        {
            if (resource.Type == ResourceType.Lumber)
            {
                this.AttackPoints += resource.Quantity;
                return true;
            }
            else if (resource.Type == ResourceType.Stone)
            {
                this.AttackPoints += resource.Quantity * 2;
                return true;
            }

            return false;
        }

        public int GetTargetIndex(List<WorldObject> availableTargets)
        {
            var sortedAvailableTargets = availableTargets.OrderBy(x => x.HitPoints);
            var sortedList = sortedAvailableTargets as List<WorldObject>;

            int index = 0;

            for (int i = 0; i < sortedList.Count; i++)
            {
                if (sortedList[i].Owner != this.Owner && sortedList[i].Owner != 0)
                {
                    index = availableTargets.IndexOf(sortedList[i]);
                    return index;
                }
            }

            return -1;
        }
    }
}
