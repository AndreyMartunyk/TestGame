using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTest1
{
    class BulletConstructor
    {

        public GameObject DefaultBullet(int startX, int startY)
        {
            GameObject bullet = new GameObject();
            bullet.Ui.BackColor = GameColors.None;
            bullet.ObjArea = new Area().SetArea(startX, startY, 1, 1);
            bullet.ObjName = "Bullet";
            bullet.Ui.Viev = "*";
            bullet.Slowness = 5;

            return bullet;
        }

        public GameObject PlayerBullet(int startX, int startY, GameObject shooter)
        {
            GameObject bullet = new GameObject();
            bullet.Damage = shooter.Damage;
            bullet.HP = 999;


            return bullet;

        }
    }
}
