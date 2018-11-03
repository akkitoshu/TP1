using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsCatamaran
{
    public partial class FormCatamaran : Form
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        private Catamaran catamaran;
        public FormCatamaran()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Метод отрисовки катамарана
        /// </summary>
        private void Draw()
        {
            Bitmap bmp = new Bitmap(pictureBoxCatamaran.Width, pictureBoxCatamaran.Height);
            Graphics gr = Graphics.FromImage(bmp);
            catamaran.DrawCatamaran(gr);
            pictureBoxCatamaran.Image = bmp;
        }
        /// <summary>
        /// Обработка нажатия кнопки "Создать"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCreate_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            catamaran = new Catamaran(rnd.Next(200, 400), rnd.Next(500, 1000), Color.Red,
           Color.DarkRed);
            catamaran.SetPosition(rnd.Next(25, 100), rnd.Next(25, 100), pictureBoxCatamaran.Width,
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
                case "buttonUp":
                    catamaran.MoveTransport(Direction.Up);
                    break;
                case "buttonDown":
                    catamaran.MoveTransport(Direction.Down);
                    break;
                case "buttonLeft":
                    catamaran.MoveTransport(Direction.Left);
                    break;
                case "buttonRight":
                    catamaran.MoveTransport(Direction.Right);
                    break;
            }
            Draw();
        }
    }
}
