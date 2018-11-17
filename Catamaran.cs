using System.Drawing;

namespace WindowsFormsBoats
{
    public class Catamaran : Boat
    {
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


        /// 
        /// </summary>
        /// 
        ///  /// <param name="engine">Признак наличия двигателя</param>
        public Catamaran(int maxSpeed, float weight, Color mainColor, Color dopColor, bool gruzleft, bool gruzright) :
            base(maxSpeed, weight, mainColor)
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
        public override void DrawBoat(Graphics g)
        {
            base.DrawBoat(g);
            Brush machta = new SolidBrush(MainColor);
            g.FillRectangle(machta, _startPosX + 55, _startPosY + 20, 5, 30);
            if (LeftGruz)
            {
                Brush gruz = new SolidBrush(DopColor);
                g.FillEllipse(gruz, _startPosX+10, _startPosY + 13, 95, 15);
            }
            if (RightGruz)
            {
                Brush gruz2 = new SolidBrush(DopColor);
                g.FillEllipse(gruz2, _startPosX+10 , _startPosY + 45, 95, 15);
            }
        }
    }
}
