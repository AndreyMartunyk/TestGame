using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTest1
{
    class FpsCalculator
    {
        private int fps;
        private DateTime time;

        public void CreateFpsCalculator()
        {
            //fps - колл-во кадров прошедших за одну секунду
            fps = 0;
            time = DateTime.Now;
        }

        public bool EndOfFrame(out int countOfFrames)
        {
            //show - переменная указывающая на то, есть ли готовый результат FPS
            //соответственно если нет то возвращаем false и не показываем его пока
            bool show = false;
            countOfFrames = 0;

            ++fps;
            if (DateTime.Now.Second - time.Second >= 1)
            {
                countOfFrames = fps;
                time = DateTime.Now;
                fps = 0;
                show = true;
            }
            return show;
        }
    }
}
