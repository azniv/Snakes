using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
namespace WindowsFormsApp13
{
    public class Snake
    {
        string direction = "right";
        string nextDirection = "right";
        delegate string Directions(EventArgs e);

        // В лист записываем сегменты змейкм
        List<Figure> snake = new List<Figure>() {
            new Figure(7,5),
            new Figure(6,5),
            new Figure(5,5)
        };

        Figure head = new Figure();
        Figure newHead = new Figure();
        // Создаем новую голову и добавляем ее к началу змейки, 
        // чтобы передвинуть змейку в текущем направлении
        public void Move(Fruits fruit)
        {
            head = snake[0];
            direction = nextDirection;
            if (direction == "right")
            {
                newHead = new Figure(head.Col + 1, head.Row);
            }
            else if (direction == "down")
            {
                newHead = new Figure(head.Col, head.Row + 1);
            }
            else if (direction == "left")
            {
                newHead = new Figure(head.Col - 1, head.Row);
            }
            else if (direction == "up")
            {
                newHead = new Figure(head.Col, head.Row - 1);
            }

            // Если врезались, то конец игры 
            if (CheckCollision())
            {
                GameOver();
                return;
            }
            snake.Insert(0, newHead);
            //если съели фрукт, то увеличиваем очки 
            if (newHead.Equal(fruit))
            {
                Game.score++;
                fruit.Move();
            }
            else
            {
                snake.RemoveAt(snake.Count - 1);
            }
        }
        // Задаем следующее направление движения змейки на основе нажатой клавиши
        public void SetDirection(string newDirection)
        {
            if (direction == "up" && newDirection == "down")
            {
                return;
            }
            else if (direction == "right" && newDirection == "left")
            {
                return;
            }
             else if (direction == "down" && newDirection == "up")
            {
                return;
            }
            else  if (direction == "left" && newDirection == "right")
            {
                return;
            }
            nextDirection = newDirection;
        }

        // Рисуем квадрат для каждого сегмента тела змейки
        public void DrawSnake(Graphics graphics)
        {
            foreach (var s in snake)
            {
                s.DrawSquare(graphics);
            }
        }


        public void Restart()
        {
            direction = "right";
   
            nextDirection = "right";
            snake.Clear();
            
            snake.Add(new Figure(7, 5));
            snake.Add(new Figure(6, 5));
            snake.Add(new Figure(5, 5));
           
            Game.score = 0;
            
          
        }
        // Проверяем, не столкнулась ли змейка со стеной или собственным  телом 
        public bool CheckCollision()
        {
            var leftCollision = (newHead.Col < 1);
            var topCollision = (newHead.Row < 1);
            var rightCollision = (newHead.Col == Game.widthInBlocks);
            var bottomCollision = (newHead.Row == Game.heightInBlocks);

            var wallCollision = leftCollision || topCollision || rightCollision || bottomCollision;
            var selfCollision = false;
            foreach (var s in snake)
            {
                if (newHead.Equal(s))
                    selfCollision = true;
            }
            return wallCollision || selfCollision;
        }
        //Конец игры
        public void GameOver()
        {
            var result = MessageBox.Show("Вы проиграли :( \nНажмите ОК, чтобы начать заново ", "", MessageBoxButtons.OK);
            if (result == DialogResult.OK)
            {
                Restart();
                return;
            }
        }
    }
}




//22,24,5,7,8,17


