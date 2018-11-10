﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsLodka;

namespace WindowsFormsCatamaran
{
    interface ITransport
    {
        /// <summary>
        /// Установка позиции катамарана
        /// </summary>
        /// <param name="x">Координата X</param>
        /// <param name="y">Координата Y</param>
        /// <param name="width">Ширина картинки</param>
        /// <param name="height">Высота картинки</param>
        void SetPosition(int x, int y, int width, int height);
        /// <summary>
        /// Изменение направления пермещения
        /// </summary>
        /// <param name="direction">Направление</param>
        void MoveTransport(Direction direction);
        /// <summary>
        /// Отрисовка катамарана
        /// </summary>
        /// <param name="g"></param>
        void DrawCatamaran(Graphics g);
    }

}

