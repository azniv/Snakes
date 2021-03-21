using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp13
{
    public class Figure : Block
    {
       

        public Figure() {

        }
        public Figure(int x, int y) : base (col: x, row: y)
        {
          
        }
        public void DrawCircle(Graphics graphics) 
        {
            int x = Col * BlockSize;
            int y = Row * BlockSize;
            graphics.FillEllipse(Brushes.Green, x,y, BlockSize, BlockSize);
        }
        public void DrawSquare(Graphics graphics)
        {
            int x = Col * BlockSize;
            int y = Row * BlockSize;
            graphics.FillRectangle(Brushes.Blue, x, y, BlockSize, BlockSize);
        }
    }
}
