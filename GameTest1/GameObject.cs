using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTest1
{
    public struct GameObject
    {
        //меняем гем обдж - Все что касается вншнего вида - отдельно, и добавляем обджЕкшен и меняем логику соответственно
        // TODO all fields to Camel case
        public string ObjName;
        public Area ObjArea;
        public ObjUI Ui;
        public float Slowness;
        public int HP;
        public int Damage;
        public Tags ObjTag;
        public int Index;
        public UnitActions Action;


        public void Shoot (GameRoom room, Direction dir)
        {

        }

    }

}
