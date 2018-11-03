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
            player.damage = 5;
            player.HP = 100;
            player.name = "player";
            player.speed = 10;
            player.teg = Tags.Player;
            player.viev = "(o_o)";
                           

            return player;
        }
    }
}
