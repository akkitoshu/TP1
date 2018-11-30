using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsBoats
{
    /// <summary>
    /// Класс-ошибка "Если на парковке уже есть автомобиль с такими же характеристиками"
    /// </summary>
    public class PortAlreadyHaveException : Exception
    {
        public PortAlreadyHaveException() : base("В порту уже существует такое судно")
        { }
    }
}
