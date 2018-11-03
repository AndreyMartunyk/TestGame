using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTest1
{
    public struct Brain
    {
        private UnitActions playerAction;


        

        public void SetPlayerAction(UnitActions action)
        {
            playerAction = action;
        }

        public UnitActions MakeDecision(GameObject gameObject)
        {
            UnitActions action = UnitActions.None;

            switch (gameObject.teg)
            {

                case Tags.Player:
                    action = playerAction;
                    break;
                case Tags.DamageToucher:
                case Tags.Stone:
                    action = UnitActions.None;                
                    break;
                case Tags.Zone:
                    break;
                default:
                case Tags.None:
                    //TODO: Add log about error
                    break;
            }



            return action;
        }
    }
}
