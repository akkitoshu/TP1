using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WindowsFormsBoats
{
    /// <summary>
    /// Класс-хранилище гаваней
    /// </summary>
    public class MultiLevelParking
    {
        /// <summary>
        /// Список с уровнями парковки
        /// </summary>
        List<Port<IBoat>> parkingStages;
        /// <summary>
        /// Сколько мест на каждом уровне
        /// </summary>
        private const int countPlaces = 20;
        /// <summary>
        /// Ширина окна отрисовки
        /// </summary>
        private int pictureWidth;
        /// <summary>
        /// Высота окна отрисовки
        /// </summary>
        private int pictureHeight;
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="countStages">Количество уровенй парковки</param>
        /// <param name="pictureWidth"></param>
        /// <param name="pictureHeight"></param>
        public MultiLevelParking(int countStages, int pictureWidth, int pictureHeight)
        {
            parkingStages = new List<Port<IBoat>>();
            this.pictureWidth = pictureWidth;
            this.pictureHeight = pictureHeight;
            for (int i = 0; i < countStages; ++i)
            {
                parkingStages.Add(new Port<IBoat>(countPlaces, pictureWidth,
               pictureHeight));
            }
        }
        /// <summary>
        /// Индексатор
        /// </summary>
        /// <param name="ind"></param>
        /// <returns></returns>
        public Port<IBoat> this[int ind]
        {
            get
            {
                if (ind > -1 && ind < parkingStages.Count)
                {
                    return parkingStages[ind];
                }
                return null;
            }
        }
        /// <summary>
        /// Сохранение информации по суднам на парковках в файл
        /// </summary>
        /// <param name="filename">Путь и имя файла</param>
        public void SaveData(string filename)
        {
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }
            using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
                using (BufferedStream bs = new BufferedStream(fs))
                {

                    //Записываем количество уровней
                    WriteToFile("CountLeveles:" + parkingStages.Count +
                   Environment.NewLine, fs);
                    foreach (var level in parkingStages)
                    {
                        //Начинаем уровень
                        WriteToFile("Level" + Environment.NewLine, fs);
                        for (int i = 0; i < countPlaces; i++)
                        {
                            var boat = level[i];
                            try
                            {
                                //если место не пустое
                                //Записываем тип судна
                                if (boat.GetType().Name == "Boat")
                                {
                                    WriteToFile(i + ":Boat:", fs);
                                }
                                if (boat.GetType().Name == "Catamaran")
                                {
                                    WriteToFile(i + ":Catamaran:", fs);
                                }
                                //Записываемые параметры
                                WriteToFile(boat + Environment.NewLine, fs);
                            }
                               
                            finally { }
                        }
                    }
                }

            }
        }
            /// <summary>
            /// Метод записи информации в файл
            /// </summary>
            /// <param name="text">Строка, которую следует записать</param>
            /// <param name="stream">Поток для записи</param>
            private void WriteToFile(string text, FileStream stream)
            {
                byte[] info = new UTF8Encoding(true).GetBytes(text);
                stream.Write(info, 0, info.Length);
            }
            /// <summary>
            /// Загрузка нформации по автомобилям на парковках из файла
            /// </summary>
            /// <param name="filename"></param>
            public void LoadData(string filename)
            {
                if (!File.Exists(filename))
                {
                    throw new FileNotFoundException();
                }
                string bufferTextFromFile = "";
                using (FileStream fs = new FileStream(filename, FileMode.Open))
                {
                    using (BufferedStream bs = new BufferedStream(fs))
                    {
                        byte[] b = new byte[fs.Length];
                        UTF8Encoding temp = new UTF8Encoding(true);
                        while (bs.Read(b, 0, b.Length) > 0)
                        {
                            bufferTextFromFile += temp.GetString(b);
                        }
                    }
                }
                bufferTextFromFile = bufferTextFromFile.Replace("\r", "");
                var strs = bufferTextFromFile.Split('\n');
                if (strs[0].Contains("CountLeveles"))
                {
                    //считываем количество уровней
                    int count = Convert.ToInt32(strs[0].Split(':')[1]);
                    if (parkingStages != null)
                    {
                        parkingStages.Clear();
                    }
                    parkingStages = new List<Port<IBoat>>(count);
                }
                else
                {
                    //если нет такой записи, то это не те данные
                    throw new Exception("Неверный формат файла");
                }
                int counter = -1;
                IBoat boat = null;
                for (int i = 1; i < strs.Length; ++i)
                {
                    //идем по считанным записям
                    if (strs[i] == "Level")
                    {
                        //начинаем новый уровень
                        counter++;
                        parkingStages.Add(new Port<IBoat>(countPlaces, pictureWidth,
                        pictureHeight));
                        continue;
                    }
                    if (string.IsNullOrEmpty(strs[i]))
                    {
                        continue;
                    }
                    if (strs[i].Split(':')[1] == "Boat")
                    {
                        boat = new Boat(strs[i].Split(':')[2]);
                    }
                    else if (strs[i].Split(':')[1] == "Catamaran")
                    {
                        boat = new Catamaran(strs[i].Split(':')[2]);
                    }
                    parkingStages[counter][Convert.ToInt32(strs[i].Split(':')[0])] = boat;
                }
            }
        }
    }