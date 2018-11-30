using System;
using System.Drawing;

namespace WindowsFormsBoats
{
    public class Catamaran : Boat, IComparable<Catamaran>, IEquatable<Catamaran>
    {
        /// <param name="dopColor">Дополнительный цвет катамарана</param>
        public Color DopColor { set; get; }
        /// <summary>
        /// Признак наличия левого груза
        ///  </summary>
        public bool LeftGruz { private set; get; }
        /// <summary>
        /// Признак наличия правого груза
        ///  </summary>
        public bool RightGruz { private set; get; }
        /// 
        /// </summary>
        /// 
        ///  /// <param name="engine">Признак наличия двигателя</param>
        public Catamaran(int maxSpeed, float weight, Color mainColor, Color dopColor, bool gruzleft, bool gruzright) :
            base(maxSpeed, weight, mainColor)
        {
            LeftGruz = gruzleft;
            RightGruz = gruzright;
            DopColor = dopColor;
        }

        public Catamaran(string info) : base(info)
        {
            string[] strs = info.Split(';');
            if (strs.Length == 6)
            {
                MaxSpeed = Convert.ToInt32(strs[0]);
                Weight = Convert.ToInt32(strs[1]);
                MainColor = Color.FromName(strs[2]);
                DopColor = Color.FromName(strs[3]);
                LeftGruz = Convert.ToBoolean(strs[4]);
                RightGruz = Convert.ToBoolean(strs[5]);
            }
        }
        /// <summary>
        /// Отрисовка катамарана
        /// </summary>
        /// <param name="g"></param>
        public override void DrawBoat(Graphics g)
        {
            base.DrawBoat(g);
            Brush machta = new SolidBrush(Color.Brown);
            g.FillRectangle(machta, _startPosX + 55, _startPosY + 20, 5, 30);
            if (LeftGruz)
            {
                Brush gruz = new SolidBrush(DopColor);
                g.FillEllipse(gruz, _startPosX + 10, _startPosY + 13, 95, 15);
            }
            if (RightGruz)
            {
                Brush gruz2 = new SolidBrush(DopColor);
                g.FillEllipse(gruz2, _startPosX + 10, _startPosY + 45, 95, 15);
            }
        }

        /// Смена дополнительного цвета
        /// </summary>
        /// <param name="color"></param>
        public void SetDopColor(Color color)
        {
            DopColor = color;
        }

        public override string ToString()
        {
            return base.ToString() + ";" + DopColor.Name + ";" + LeftGruz + ";" + RightGruz;
        }

        /// <summary>
        /// Метод интерфейса IComparable для класса Catamaran
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(Catamaran other)
        {
            var res = (this is Boat).CompareTo(other is Boat);
            if (res != 0)
            {
                return res;
            }
            if (DopColor != other.DopColor)
            {
                DopColor.Name.CompareTo(other.DopColor.Name);
            }
            if (LeftGruz != other.LeftGruz)
            {
                return LeftGruz.CompareTo(other.LeftGruz);
            }
            if (RightGruz != other.RightGruz)
            {
                return RightGruz.CompareTo(other.RightGruz);
            }
            return 0;
        }
        /// <summary>
        /// Метод интерфейса IEquatable для класса Catamaran
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Catamaran other)
        {
            var res = (this as Boat).Equals(other as Boat);
            if (!res)
            {
                return res;
            }
            if (DopColor != other.DopColor)
            {
                return false;
            }
            if (LeftGruz != other.LeftGruz)
            {
                return false;
            }
            if (RightGruz != other.RightGruz)
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
            Catamaran carObj = obj as Catamaran;
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

