
﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsBoats
{
    public partial class FormPort : Form
    {
        /// <summary>
        /// Объект от класса многоуровневой парковки
        /// </summary>
        MultiLevelParking parking;
        /// <summary>
        /// Форма для добавления
        /// </summary>
        FormBoatConfig form;
        /// <summary>
        /// Количество уровней-парковок
        /// </summary>
        private const int countLevel = 5;
        public FormPort()
        {
            InitializeComponent();
            parking = new MultiLevelParking(countLevel, pictureBoxPort.Width,
           pictureBoxPort.Height);
            //заполнение listBox
            for (int i = 0; i < countLevel; i++)
            {
                listBoxLevels.Items.Add("Уровень " + (i + 1));
            }
            listBoxLevels.SelectedIndex = 0;
        }

        /// <summary>
        /// Метод отрисовки гавани
        /// </summary>
        private void Draw()
        {
            if (listBoxLevels.SelectedIndex > -1)
            {//если выбран один из пуктов в listBox (при старте программы ни один пункт  не будет выбран и может возникнуть ошибка, если мы попытаемся обратиться к элементу  listBox)
                Bitmap bmp = new Bitmap(pictureBoxPort.Width, pictureBoxPort.Height);
                Graphics gr = Graphics.FromImage(bmp);
                parking[listBoxLevels.SelectedIndex].Draw(gr);
                pictureBoxPort.Image = bmp;
            }
        }

        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonPortCatamaran_Click(object sender, EventArgs e)
        {
            if (listBoxLevels.SelectedIndex > -1)
            {
                ColorDialog dialog = new ColorDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var catamaran = new Boat(100, 1000, dialog.Color);
                    int place = parking[listBoxLevels.SelectedIndex] + catamaran;
                    if (place == -1)
                    {
                        MessageBox.Show("Нет свободных мест", "Ошибка",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    Draw();
                }
            }
        }


        private void buttonPortBoat_Click(object sender, EventArgs e)
        {
            if (listBoxLevels.SelectedIndex > -1)
            {
                ColorDialog dialog = new ColorDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    ColorDialog dialogDop = new ColorDialog();
                    if (dialogDop.ShowDialog() == DialogResult.OK)
                    {
                        var catamaran = new Catamaran(100, 1000, dialog.Color, dialogDop.Color, true, true); 
                        int place = parking[listBoxLevels.SelectedIndex] + catamaran;
                        if (place == -1)
                        {
                            MessageBox.Show("Нет свободных мест", "Ошибка",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        Draw();
                    }
                }
            }
        }

        private void buttonTake_Click(object sender, EventArgs e)
        {
            if (listBoxLevels.SelectedIndex > -1)
            {
                if (maskedTextBox1.Text != "")
                {
                    var boat = parking[listBoxLevels.SelectedIndex] -
                   Convert.ToInt32(maskedTextBox1.Text);
                    if (boat != null)
                    {
                        Bitmap bmp = new Bitmap(pictureBoxTakeBoat.Width,
                       pictureBoxTakeBoat.Height);
                        Graphics gr = Graphics.FromImage(bmp);
                        boat.SetPosition(5, 5, pictureBoxTakeBoat.Width,
                       pictureBoxTakeBoat.Height);
                        boat.DrawBoat(gr);
                        pictureBoxTakeBoat.Image = bmp;
                    }
                    else
                    {
                        Bitmap bmp = new Bitmap(pictureBoxTakeBoat.Width,
                       pictureBoxTakeBoat.Height);
                        pictureBoxTakeBoat.Image = bmp;
                    }
                    Draw();
                }
            }
        }
       
        /// <summary>
        /// Метод обработки выбора элемента на listBoxLevels
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBoxLevels_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            Draw();
        }

    /// <summary>
    /// Обработка нажатия кнопки "Добавить лодку"
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void buttonSetBoat_Click(object sender, EventArgs e)
    {
        form = new FormBoatConfig();
        form.AddEvent(AddBoat);
        form.Show();
    }
        /// <summary>
        /// Метод добавления судна
        /// </summary>
        /// <param name="car"></param>
        private void AddBoat(IBoat boat)
        {
            if (boat != null && listBoxLevels.SelectedIndex > -1)
            {
                int place = parking[listBoxLevels.SelectedIndex] + boat;
                if (place > -1)
                {
                    Draw();
                }
                else
                {
                    MessageBox.Show("Судно не удалось поставить");
                }
            }
        }
        /// <summary>
        /// Обработка нажатия пункта меню "Сохранить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (parking.SaveData(saveFileDialog1.FileName))
                {
                    MessageBox.Show("Сохранение прошло успешно", "Результат",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Не сохранилось", "Результат", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
        }
        /// <summary>
        /// Обработка нажатия пункта меню "Загрузить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void загрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (parking.LoadData(openFileDialog1.FileName))
                {
                    MessageBox.Show("Загрузили", "Результат", MessageBoxButtons.OK,
                   MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Не загрузили", "Результат", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
                Draw();
            }
        }
    }
}