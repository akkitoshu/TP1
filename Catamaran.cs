using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace WindowsFormsCatamaran
{
    /// <summary>
    /// Класс отрисовки катамарана
    /// </summary>

    public class Catamaran
    {

        /// <summary>
        /// Левая координата отрисовки катамарана
        /// </summary>
        private float _startPosX;
        /// <summary>
        /// Правая кооридната отрисовки катамарана
        /// </summary>
        private float _startPosY;
        /// <summary>
        /// Ширина окна отрисовки
        /// </summary>
        private int _pictureWidth;
        // Высота окна отрисовки
        private int _pictureHeight;
        /// <summary>
        /// Ширина отрисовки катамарана
        /// </summary>
        private const int catamaranWidth = 100;
        /// <summary>
        /// Ширина отрисовки катамарана
        /// </summary>
        private const int catamaranHeight = 60;
        /// <summary>
        /// Максимальная скорость
        /// </summary>
        public int MaxSpeed { private set; get; }
        /// <summary>
        /// Вес катамарана
        /// </summary>
        public float Weight { private set; get; }
        /// <summary>
        /// Основной цвет катамарана
        /// </summary>
        public Color MainColor { private set; get; }
        public bool Corpus { private set; get; }
        public Color DopColor { set; get; }

        /// <summary>
        /// Признак наличия двигателя
        /// </summary>
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="maxSpeed">Максимальная скорость</param>
        /// <param name="weight">Вес катамарана</param>
        /// <param name="mainColor">Основной цвет катамарана</param>
        /// <param name="dopColor">Дополнительный цвет</param
        public Catamaran(int maxSpeed, float weight, Color mainColor, Color dopColor)
        {
            MaxSpeed = maxSpeed;
            Weight = weight;
            MainColor = mainColor;
            DopColor = dopColor;
        }
        /// <summary>
        /// Установка позиции катамарана
        /// </summary>
        /// <param name="x">Координата X</param>
        /// <param name="y">Координата Y</param>
        /// <param name="width">Ширина картинки</param>
        /// <param name="height">Высота картинки</param>
        public void SetPosition(int x, int y, int width, int height)
        {
            _startPosX = x;
            _startPosY = y;
            _pictureWidth = width;
            _pictureHeight = height;
        }
        /// <summary>
        /// Изменение направления перемещения
        /// </summary>
        /// <param name="direction">Направление</param>
        public void MoveTransport(Direction direction)
        {
            float step = MaxSpeed * 120 / Weight;
            switch (direction)
            {
                // вправо
                case Direction.Right:
                    if (_startPosX + step < _pictureWidth - catamaranWidth - 120)
                    {
                        _startPosX += step;
                    }
                    break;
                //влево
                case Direction.Left:
                    if (_startPosX - step > -35)
                    {
                        _startPosX -= step;
                    }
                    break;
                //вверх
                case Direction.Up:
                    if (_startPosY - step > 25)
                    {
                        _startPosY -= step;
                    }
                    break;
                //вниз
                case Direction.Down:
                    if (_startPosY + step < _pictureHeight - catamaranHeight)
                    {
                        _startPosY += step;
                    }
                    break;
            }
        }
        /// <summary>
        /// Отрисовка катамарана
        /// </summary>
        /// <param name="g"></param>
        public void DrawCatamaran(Graphics g)
        {
            Pen pen = new Pen(Color.Black);
            Brush corpus = new SolidBrush(Color.DarkKhaki);
            g.FillRectangle(corpus, _startPosX + 30, _startPosY + 20, 75, 30);
            g.FillEllipse(corpus, _startPosX + 79, _startPosY + 20, 40, 30);
            g.FillEllipse(corpus, _startPosX, _startPosY + 20, 40, 30);
            Brush machta = new SolidBrush(MainColor);
            g.FillRectangle(machta, _startPosX + 60, _startPosY + 20, 5, 30);
            Brush gruz = new SolidBrush(DopColor);
            g.FillEllipse(gruz, _startPosX + 10, _startPosY + 11, 105, 19);
            Brush gruz2 = new SolidBrush(DopColor);
            g.FillEllipse(gruz2, _startPosX + 10, _startPosY + 45, 105, 19);

        }
    }
}

