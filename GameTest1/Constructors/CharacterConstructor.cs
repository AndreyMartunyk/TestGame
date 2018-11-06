using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTest1
{
    class CharacterConstructor
    {
        public GameObject CreatePlayer (int coordinationX, int coordinationY)
        {
            GameObject player;
            player = new GameObject();
            player.ObjArea.From.newPos.x = coordinationX;
            player.ObjArea.From.oldPos.x = coordinationX;
            player.ObjArea.From.newPos.y = coordinationY;
            player.ObjArea.From.oldPos.y = coordinationY;

            player.ObjArea.To.newPos.x = coordinationX + 4;
            player.ObjArea.To.oldPos.x = coordinationX + 4;
            player.ObjArea.To.newPos.y = coordinationY;
            player.ObjArea.To.oldPos.y = coordinationY;

            player.Color = GameColors.DarkGrey;
            player.BackColor = GameColors.Yellow;
            player.Damage = 3;
            player.HP = 100;
            player.ObjName = "player";
            player.Slowness = 1;
            player.ObjTag = Tags.Player;
            player.Viev = "(o_o)";
                           

            return player;
        }

        public GameObject CreateBlindBeagle(int coordinationX, int coordinationY)
        {
            GameObject bBeagle;
            bBeagle = new GameObject();
            bBeagle.ObjArea.From.newPos.x = coordinationX;
            bBeagle.ObjArea.From.oldPos.x = coordinationX;
            bBeagle.ObjArea.From.newPos.y = coordinationY;
            bBeagle.ObjArea.From.oldPos.y = coordinationY;

            bBeagle.ObjArea.To.newPos.x = coordinationX + 4;
            bBeagle.ObjArea.To.oldPos.x = coordinationX + 4;
            bBeagle.ObjArea.To.newPos.y = coordinationY;
            bBeagle.ObjArea.To.oldPos.y = coordinationY;

            bBeagle.Color = GameColors.White;
            bBeagle.BackColor = GameColors.None;
            bBeagle.Damage = 2;
            bBeagle.HP = 100;
            bBeagle.ObjName = "Blind Beagle";
            bBeagle.Slowness = 12;
            bBeagle.ObjTag = Tags.BlindBeagle;
            bBeagle.Viev = "(\\_/)";

            return bBeagle;
        }
    }
}
