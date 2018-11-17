using System.Drawing;

namespace WindowsFormsBoats
{
    public class Boat : Lodka
    {
        protected const int boatWidth = 100;
        /// <summary>
        /// Ширина отрисовки лодки
        /// </summary>
        protected const int boatHeight = 60;
        
        /// Конструктор
        /// </summary>
        /// <param name="maxSpeed">Максимальная скорость</param>
        /// <param name="weight">Вес </param>
        /// <param name="mainColor">Основной цвет лодки</param>
        public Boat(int maxSpeed, float weight, Color mainColor)
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
                    if (_startPosX + step < _pictureWidth - boatWidth)
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
                    if (_startPosY - step > 0)
                    {
                        _startPosY -= step;
                    }
                    break;
                //вниз
                case Direction.Down:
                    if (_startPosY + step < _pictureHeight - boatHeight)
                    {
                        _startPosY += step;
                    }
                    break;
            }
        }
        public override void DrawBoat(Graphics g)
        {
            Brush corpus = new SolidBrush(Color.DarkSlateGray);
            g.FillRectangle(corpus, _startPosX + 30, _startPosY + 20, 75, 30);
            g.FillEllipse(corpus, _startPosX + 79, _startPosY + 20, 40, 30);
            g.FillEllipse(corpus, _startPosX , _startPosY + 20, 40, 30);
            Brush bort = new SolidBrush(MainColor);
            g.FillRectangle(bort, _startPosX + 10, _startPosY + 20, 95, 5);
            g.FillRectangle(bort, _startPosX + 10, _startPosY + 48, 95, 5);
        }

    }
}
