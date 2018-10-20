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
            player.area.From.newPosX = coordinationX;
            player.area.From.oldPosX = coordinationX;
            player.area.From.newPosY = coordinationY;
            player.area.From.oldPosY = coordinationY;

            player.area.To.newPosX = coordinationX + 4;
            player.area.To.oldPosX = coordinationX + 4;
            player.area.To.newPosY = coordinationY;
            player.area.To.oldPosY = coordinationY;

            player.color = GameColors.DarkGrey;
            player.backColor = GameColors.Yellow;
            player.damage = 5;
            player.HP = 100;
            player.name = "player";
            player.speed = 10;
            player.teg = Tegs.Player;
            player.viev = "(o_o)";
                           

            return player;
        }
    }
}
