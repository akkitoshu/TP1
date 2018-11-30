using System;
using System.Drawing;

namespace WindowsFormsBoats
{
    public class Boat : Lodka, IComparable<Boat>, IEquatable<Boat>
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

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="info">Информация по объекту</param>
        public Boat(string info)
        {
            string[] strs = info.Split(';');
            if (strs.Length == 3)
            {
                MaxSpeed = Convert.ToInt32(strs[0]);
                Weight = Convert.ToInt32(strs[1]);
                MainColor = Color.FromName(strs[2]);
            }
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
            Brush corpus = new SolidBrush(MainColor);
            g.FillRectangle(corpus, _startPosX + 30, _startPosY + 20, 75, 30);
            g.FillEllipse(corpus, _startPosX + 79, _startPosY + 20, 40, 30);
            g.FillEllipse(corpus, _startPosX, _startPosY + 20, 40, 30);
            Brush bort = new SolidBrush(Color.Brown);
            g.FillRectangle(bort, _startPosX + 10, _startPosY + 20, 95, 5);
            g.FillRectangle(bort, _startPosX + 10, _startPosY + 48, 95, 5);
        }
        public override string ToString()
        {
            return MaxSpeed + ";" + Weight + ";" + MainColor.Name;
        }
        /// <summary>
        /// Метод интерфейса IComparable для класса Boat
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(Boat other)
        {
            if (other == null)
            {
                return 1;
            }
            if (MaxSpeed != other.MaxSpeed)
            {
                return MaxSpeed.CompareTo(other.MaxSpeed);
            }
            if (Weight != other.Weight)
            {
                return Weight.CompareTo(other.Weight);
            }
            if (MainColor != other.MainColor)
            {
                MainColor.Name.CompareTo(other.MainColor.Name);
            }
            return 0;
        }
        /// <summary>
        /// Метод интерфейса IEquatable для класса Boat
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Boat other)
        {
            if (other == null)
            {
                return false;
            }
            if (MaxSpeed != other.MaxSpeed)
            {
                return false;
            }
            if (Weight != other.Weight)
            {
                return false;
            }
            if (MainColor != other.MainColor)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Перегрузка метода от object
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(Object obj)
        {
            if (obj == null)
            {
                return false;
            }
            Boat carObj = obj as Boat;
            if (carObj == null)
            {
                return false;
            }
            else
            {
                return Equals(carObj);
            }
        }
        /// <summary>
        /// Перегрузка метода от object
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}