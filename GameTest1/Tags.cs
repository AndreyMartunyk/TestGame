using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTest1
{
    public enum Tags
    {
        None,
        Player,         // тег указывающий непосредсвенно на игрока 
        DamageToucher,  // при прикосновении игроку наносится урон
        Stone,      // предмет к которому невозможно прикоснутся, т.е. обычная преграда

        Zone
    }
}
