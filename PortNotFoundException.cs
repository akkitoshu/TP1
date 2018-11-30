using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsBoats
{
    /// <summary>
    /// Класс-ошибка "Если не найдено судно по определенному месту"
    /// </summary>
    class PortNotFoundException : Exception
    {
        public PortNotFoundException(int i) : base("Не найдено судно по месту " + i)
        { }
    }
}
