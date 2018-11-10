using System;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsCatamaran;
using WindowsFormsLodka;

namespace WindowsFormsCatamaran
{
    public partial class FormLodka : Form
    {
        private ITransport lodka;
        /// <summary>
        /// Конструктор
        /// </summary>
        public FormLodka()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Метод отрисовки лодки
        /// </summary>
        private void Draw()
        {
            Bitmap bmp = new Bitmap(pictureBoxCatamaran.Width, pictureBoxCatamaran.Height);
            Graphics gr = Graphics.FromImage(bmp);
            lodka.DrawCatamaran(gr);
            pictureBoxCatamaran.Image = bmp;
        }
        /// <summary>
        /// Обработка нажатия кнопки "Создать лодку"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCreate_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            lodka = new Lodka(rnd.Next(100, 300), rnd.Next(1000, 2000), Color.RosyBrown);
            lodka.SetPosition(rnd.Next(10, 100), rnd.Next(10, 100), pictureBoxCatamaran.Width,
           pictureBoxCatamaran.Height);
            Draw();
        }
        /// <summary>
        /// Обработка нажатия кнопки "Создать катамаран"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCreateCatamaran_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            lodka = new Catamaran(rnd.Next(300, 400), rnd.Next(500, 1000), Color.RosyBrown, Color.Cyan, true, true);
            lodka.SetPosition(rnd.Next(10, 100), rnd.Next(10, 100), pictureBoxCatamaran.Width,
           pictureBoxCatamaran.Height);
            Draw();
        }
        /// <summary>
        /// Обработка нажатия кнопок управления
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonMove_Click(object sender, EventArgs e)
        {
            //получаем имя кнопки
            string name = (sender as Button).Name;
            switch (name)
            {
                case "Up":
                    lodka.MoveTransport(Direction.Up);
                    break;
                case "Down":
                    lodka.MoveTransport(Direction.Down);
                    break;
                case "Left":
                    lodka.MoveTransport(Direction.Left);
                    break;
                case "Right":
                    lodka.MoveTransport(Direction.Right);
                    break;
            }
            Draw();
        }
    }
}