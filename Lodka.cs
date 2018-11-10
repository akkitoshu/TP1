using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsLodka;

namespace WindowsFormsCatamaran
{
    /// <summary>
    /// Класс отрисовки лодки
    /// </summary>
    public class Lodka : Vehicle
    {

        /// <summary>
        /// Ширина отрисовки судна
        /// </summary>
        protected const int lodkaWidth = 100;
        /// <summary>
        /// Ширина отрисовки судна
        /// </summary>
        protected const int lodkaHeight = 60;

        public new Color MainColor { set; get; }
        /// <summary>
        /// Конструктор
        /// </summary>
        ///  /// <param name="maxSpeed">Максимальная скорость</param>
        /// <param name="weight">Вес лодки</param>
        /// <param name="mainColor">Основной цвет лодки</param>
        ///   ///  /// <param name="parus">Признак наличия паруса</param>
        public Lodka(int maxSpeed, float weight, Color mainColor)
        {
            MaxSpeed = maxSpeed;
            Weight = weight;
            MainColor = mainColor;


        }
        public override void MoveTransport(Direction direction)
        {
            float step = MaxSpeed * 100 / Weight;
            switch (direction)
            {
                // вправо
                case Direction.Right:
                    if (_startPosX + step < _pictureWidth - lodkaWidth - 100)
                    {
                        _startPosX += step;
                    }
                    break;
                //влево
                case Direction.Left:
                    if (_startPosX - step > 0)
                    {
                        _startPosX -= step;
                    }
                    break;
                //вверх
                case Direction.Up:
                    if (_startPosY - step > 15)
                    {
                        _startPosY -= step;
                    }
                    break;
                //вниз
                case Direction.Down:
                    if (_startPosY + step < _pictureHeight - lodkaHeight)
                    {
                        _startPosY += step;
                    }
                    break;
            }
        }

        public override void DrawCatamaran(Graphics g)
        {

            Brush corpus = new SolidBrush(Color.DarkSlateGray);
            g.FillRectangle(corpus, _startPosX + 80, _startPosY + 20, 80, 30);
            g.FillEllipse(corpus, _startPosX + 119, _startPosY + 20, 80, 30);
            g.FillEllipse(corpus, _startPosX + 40, _startPosY + 20, 80, 30);
            Brush bort = new SolidBrush(MainColor);
            g.FillRectangle(bort, _startPosX + 60, _startPosY + 20, 115, 5);
            g.FillRectangle(bort, _startPosX + 60, _startPosY + 48, 115, 5);

        }
    }
}

