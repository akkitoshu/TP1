using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsBoats
{
    /// <summary>
    /// Класс-ошибка "Если место, на которое хотим поставить судно уже занято"
    /// </summary>
    class PortOccupiedPlaceException : Exception
    {
        public PortOccupiedPlaceException(int i) : base("На месте " + i + " уже стоит судно")
        { }
    }
}
