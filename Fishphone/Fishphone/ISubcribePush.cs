using System;
using System.Collections.Generic;
using System.Text;

namespace Fishphone
{
    public interface ISubcribePush
    {
        void Subcribe(string name);
        void UnSubcribe(string name);
    }
}
