using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using WindowsFormsCatamaran;

namespace WindowsFormsLodka
{
    /// <summary>
    /// Класс отрисовки катамарана
    /// </summary>

    public class Catamaran : Lodka
    {
        /// <summary>
        /// Ширина окна отрисовки
        /// </summary>
        private int pictureWidth;
        // Высота окна отрисовки
        private int pictureHeight;
        /// <summary>
        /// Ширина отрисовки катамарана
        /// </summary>
        protected const int LodkaWidth = 100;
        /// <summary>
        /// Ширина отрисовки катамарана
        /// </summary>
        protected const int LodkaHeight = 60;
        /// <summary>
        /// Максимальная скорость
        /// </summary>
        public new int MaxSpeed { set; get; }
        /// <summary>
        /// Вес катамарана
        /// </summary>
        public new float Weight { set; get; }
        /// <summary>
        /// Основной цвет катамарана
        /// </summary>
        public new Color MainColor { set; get; }
        public bool Corpus { set; get; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="maxSpeed">Максимальная скорость</param>
        /// <param name="weight">Вес катамарана</param>
        /// <param name="mainColor">Основной цвет катамарана</param>
        /// /// <param name="dopColor">Дополнительный цвет катамарана</param>
        public Color DopColor { set; get; }
        /// <summary>
        /// Признак наличия левого груза
        ///  </summary>
        public bool LeftGruz { private set; get; }
        /// <summary>
        /// Признак наличия правого груза
        ///  </summary>
        public bool RightGruz { private set; get; }
        protected int PictureWidth { get => pictureWidth; set => pictureWidth = value; }
        protected int PictureHeight { get => pictureHeight; set => pictureHeight = value; }

        /// 
        /// </summary>
        /// 
        ///  /// <param name="engine">Признак наличия двигателя</param>
        public Catamaran(int maxSpeed, float weight, Color mainColor, Color dopColor, bool gruzleft, bool gruzright) :
            base(maxSpeed, weight, dopColor)
        {
            MaxSpeed = maxSpeed;
            Weight = weight;
            MainColor = mainColor;
            LeftGruz = gruzleft;
            RightGruz = gruzright;
            DopColor = dopColor;
        }


        /// <summary>
        /// Отрисовка катамарана
        /// </summary>
        /// <param name="g"></param>
        public override void DrawCatamaran(Graphics g)
        {
            base.DrawCatamaran(g);
            Brush machta = new SolidBrush(Color.Black);
            g.FillRectangle(machta, _startPosX + 120, _startPosY + 20, 5, 30);
            if (LeftGruz)
            {
                Brush gruz = new SolidBrush(DopColor);
                g.FillEllipse(gruz, _startPosX + 40, _startPosY + 13, 150, 15);
            }
            if (RightGruz)
            {
                Brush gruz2 = new SolidBrush(DopColor);
                g.FillEllipse(gruz2, _startPosX + 40, _startPosY + 45, 150, 15);
            }



        }
    }
}



