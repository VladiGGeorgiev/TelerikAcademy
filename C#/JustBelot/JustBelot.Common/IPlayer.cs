using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustBelot.Common
{
    public interface IPlayer
    {
        string Name { get; }

        void PlayCard();
    }
}
