using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTest1
{
    class BulletConstructor
    {

        public GameObject DefaultBullet(Coordinate coord)
        {
            GameObject bullet = new GameObject();

   
            
            bullet.Ui.BackColor = GameColors.None;          
            bullet.ObjName = "Bullet";
            bullet.Ui.Viev = "*";
            bullet.Slowness = 5;
            bullet.ObjTag = Tags.Bullet;

            bullet.ObjArea = new Area().SetArea(coord.x, coord.y, 1, 1);


            //bullet.ObjArea.From.oldPos.x = bullet.ObjArea.From.newPos.x;
            //bullet.ObjArea.From.oldPos.y = bullet.ObjArea.From.newPos.y;
            //bullet.ObjArea.To.oldPos.x = bullet.ObjArea.To.newPos.x;
            //bullet.ObjArea.To.oldPos.y = bullet.ObjArea.To.newPos.y;

            //switch (dir)
            //{
            //    case Direction.None:
            //        break;
            //    case Direction.Top:
            //        bullet.ObjArea.From.oldPos.y += MyConst.STEP_Y;
            //        bullet.ObjArea.To.oldPos.y += MyConst.STEP_Y;
            //        break;
            //    case Direction.Down:
            //        bullet.ObjArea.From.oldPos.y -= MyConst.STEP_Y;
            //        bullet.ObjArea.To.oldPos.y -= MyConst.STEP_Y;
            //        break;
            //    case Direction.Left:
            //        bullet.ObjArea.From.oldPos.x -= MyConst.STEP_X;
            //        bullet.ObjArea.To.oldPos.x -= MyConst.STEP_X;
            //        break;
            //    case Direction.Right:
            //        bullet.ObjArea.From.oldPos.x += MyConst.STEP_X;
            //        bullet.ObjArea.To.oldPos.x += MyConst.STEP_X;
            //        break;
            //    default:
            //        break;
            //}

            return bullet;
        }

        public GameObject PlayerBullet(Coordinate coord, int shooterDamage, UnitActions action)
        {
            GameObject bullet = DefaultBullet(coord);
            bullet.Damage = shooterDamage;
            bullet.HP = 999;
            bullet.Ui.Color = GameColors.Cyan;
            bullet.Action = action;

            return bullet;

        }
    }
}
