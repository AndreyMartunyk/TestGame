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
            player.area.From.newPos.x = coordinationX;
            player.area.From.oldPos.x = coordinationX;
            player.area.From.newPos.y = coordinationY;
            player.area.From.oldPos.y = coordinationY;

            player.area.To.newPos.x = coordinationX + 4;
            player.area.To.oldPos.x = coordinationX + 4;
            player.area.To.newPos.y = coordinationY;
            player.area.To.oldPos.y = coordinationY;

            player.color = GameColors.DarkGrey;
            player.backColor = GameColors.Yellow;
            player.damage = 3;
            player.HP = 100;
            player.objName = "player";
            player.Slowness = 1;
            player.teg = Tags.Player;
            player.viev = "(o_o)";
                           

            return player;
        }

        public GameObject CreateBlindBeagle(int coordinationX, int coordinationY)
        {
            GameObject bBeagle;
            bBeagle = new GameObject();
            bBeagle.area.From.newPos.x = coordinationX;
            bBeagle.area.From.oldPos.x = coordinationX;
            bBeagle.area.From.newPos.y = coordinationY;
            bBeagle.area.From.oldPos.y = coordinationY;

            bBeagle.area.To.newPos.x = coordinationX + 4;
            bBeagle.area.To.oldPos.x = coordinationX + 4;
            bBeagle.area.To.newPos.y = coordinationY;
            bBeagle.area.To.oldPos.y = coordinationY;

            bBeagle.color = GameColors.White;
            bBeagle.backColor = GameColors.None;
            bBeagle.damage = 2;
            bBeagle.HP = 100;
            bBeagle.objName = "Blind Beagle";
            bBeagle.Slowness = 12;
            bBeagle.teg = Tags.BlindBeagle;
            bBeagle.viev = "(\\_/)";

            return bBeagle;
        }
    }
}
