using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTest1
{
    public struct GameObject
    {
        //меняем гейм обдж - Все что касается вншнего вида - отдельно, и добавляем обджЕкшен и меняем логику соответственно
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


        public void Shoot (ref GameRoom level, Direction dir)
        {

            GameObject bullet = CreateBullet(dir);
            level.AddGameObject(bullet);
            new CollisionChecker().RespondToCollision(ref level, ref bullet);


            //проверить где появилась пуля, если на месте  другого обьекта, то уничтожиться нанести урон 

        }

        private Coordinate FindPosBullet(Direction dir)
        {
            Coordinate coord = new Coordinate();

            int xCenter = ((ObjArea.To.newPos.x - ObjArea.From.newPos.x) / 2) + ObjArea.From.newPos.x;
            int yCenter = ((ObjArea.To.newPos.y - ObjArea.From.newPos.y) / 2) + ObjArea.From.newPos.y;

            switch (dir)
            {   
                case Direction.None:
                    break;
                case Direction.Top:
                    coord.x = xCenter;
                    coord.y = ObjArea.From.newPos.y - MyConst.STEP_Y;
                    break;
                case Direction.Down:
                    coord.x = xCenter;
                    coord.y = ObjArea.To.newPos.y + MyConst.STEP_Y;
                    break;
                case Direction.Left:
                    coord.y = yCenter;
                    coord.x = ObjArea.From.newPos.x - MyConst.STEP_X;
                    break;
                case Direction.Right:
                    coord.y = yCenter;
                    coord.x = ObjArea.To.newPos.x + MyConst.STEP_X;
                    break;
                default:
                    break;
            }

            return coord;
        }

        private UnitActions ShootDirAction(Direction dir)
        {
            UnitActions action = UnitActions.None;

            switch (dir)
            {
                case Direction.None:
                    break;
                case Direction.Top:
                    action = UnitActions.MoveTop;
                    break;
                case Direction.Down:
                    action = UnitActions.MoveDown;
                    break;
                case Direction.Left:
                    action = UnitActions.MoveLeft;
                    break;
                case Direction.Right:
                    action = UnitActions.MoveRight;
                    break;
                default:
                    break;
            }

            return action;
        }

        private GameObject CreateBullet(Direction dir)
        {
            GameObject bullet = new GameObject();

            switch (ObjTag)
            {
                case Tags.None:
                    break;
                case Tags.Player:
                    bullet = new BulletConstructor().PlayerBullet(FindPosBullet(dir), Damage, ShootDirAction(dir));
                    break;
                case Tags.DamageToucher:
                    break;
                case Tags.Stone:
                    break;
                case Tags.BlindBeagle:
                    break;
                case Tags.Bullet:
                    break;
                case Tags.Zone:
                    break;
                default:
                    break;
            }

            return bullet;
        }
    }

}
