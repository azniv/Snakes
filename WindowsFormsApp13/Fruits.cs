using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp13
{
    public class Fruits : Figure
    {
        public Random random = new Random();
     
        
        public Fruits()
        {

            this.Col = random.Next(2, Game.widthInBlocks - 2);
            this.Row = random.Next(2, Game.widthInBlocks - 2);



        }

        // Перемещаем яблоко в случайную позицию 
        public void Move()
        {
            this.Col = random.Next(2, Game.widthInBlocks-2);
            this.Row = random.Next(2, Game.widthInBlocks - 2);
           
        }

        //Рисуем яблоко
        public void Draw(Graphics graphics)
        {
            this.DrawCircle(graphics);

        }
       

    }
}
