using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp13
{
    public partial class Game : Form
    {


        
        Graphics graphics;
        Snake snake;
        Fruits apple;
       
        static int width = 0;   // ширина рамки
        static int height = 0;  // высота рамки
        public static int score = 0;    //количество набранных очков  
        public static int widthInBlocks = 0;  //ширина холста в блоках
        public static int heightInBlocks = 0;  // высота холста в блоках

        public Game()
        {
            InitializeComponent();
            this.KeyPreview = true;
            width = this.ClientSize.Width;  //ширина окна 
            height = this.ClientSize.Height; //высота окна 
            widthInBlocks = width / Block.BlockSize;  //количество блоков по ширине 
            heightInBlocks = height -30/ Block.BlockSize; //количество блоков по высоте 
             

            btnStart.Location = new Point(
                 width / 2 - btnStart.Width / 2,
                 height / 2 - btnStart.Height / 2
                );

            graphics = CreateGraphics();
           
          
        }



        private void btnStart_Click(object sender, EventArgs e)
        {
            BtnStartCode();
            
            timer1.Enabled = true;  //включим в работу наш таймер,
            // то есть теперь будет происходить событие Tick и его будет обрабатывать функция On_Tick (по умолчанию
        }

        private string newDirection;
        public string NewDirection(string s)
        {
            
            return newDirection;
        }
        
        private void Game_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (btnStart.Visible) return;   //Если кнопка скрыта,то начинаем игру
 
            //выбираем новое направление движения 
            switch (e.KeyCode)
            {
                case Keys.D:
                    newDirection = "right";
                    break;
                case Keys.A:
                    newDirection = "left";
                    break;
                case Keys.W:
                    newDirection = "up";
                    break;
                case Keys.S:
                    newDirection = "down";
                    break;
                case Keys.X:
                    Application.Exit();
                    break;
                default:
                    break;

            }



            UpdateForm();
        }

      
        //Рисуем рамку 
        public void DrawBorder()
        {
            Pen pen = new Pen(Color.Gray, 20);
            graphics.DrawRectangle(pen,  0, 0, this.ClientSize.Width,this.ClientSize.Height);
         
        }

        public void UpdateForm()
        {
            graphics.Clear(this.BackColor);
            DrawBorder();
            label3.Text = score.ToString();
            snake.SetDirection(NewDirection(newDirection));
            snake.Move(apple);
            snake.DrawSnake(graphics);
            apple.Draw(graphics);
        }
        public void BtnStartCode()
        {
            if (tbName1.Text != "")
            {   // Если ввели имя 
                btnStart.Visible = false;    //скрываем кнопку, надпись и текстбокс
                tbName1.Visible = false;
                label1.Visible = false;
                btnRestart.Visible = true;
                btnExit.Visible = true;
                label2.Text = tbName1.Text + ":";    // выводим имя 
                label3.Text = score.ToString();    // и очки 
                apple = new Fruits();
                snake = new Snake();
                //apple.DrawCircle(graphics);

                apple.Draw(graphics);
                snake.DrawSnake(graphics);
                DrawBorder();
            }
        }

       
        private void Game_Load(object sender, EventArgs e)
        {
            this.ActiveControl = tbName1;
            tbName1.Focus();
            btnExit.Visible = false;
            btnRestart.Visible = false;
           
        }

        private void tbName1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    BtnStartCode();
                    break;
              

            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Хотите начать заново?", "", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                snake.Restart();
                UpdateForm();

            }
           
           
        }




        public Label getLabel()
        {
            return label2;
        }

        //private void timer1_Tick(object sender, EventArgs e)
        //{
        //    graphics.Clear(this.BackColor);
        //    snake.SetDirection(NewDirection(newDirection));
        //    snake.Move(apple);
        //    snake.DrawSnake(graphics);
        //    apple.Draw(graphics);
        //}
    }
}
