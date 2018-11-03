using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTest1
{
    public enum UnitActions : byte
    {
        None,
        MoveRight,
        MoveLeft,
        MoveDown,
        MoveTop,
        Stop,
        Shoot,
        Die,
        GetDamage,
        Attack
    }
}
