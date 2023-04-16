using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train
{
    internal class Modules
    {
        public static string OpenDialog() // открытие диалогового окна
        {
            string path = null; // переменная пути
            OpenFileDialog openFileDialog = new OpenFileDialog(); // инициализация Диалогового окна
            Nullable<bool> result = openFileDialog.ShowDialog(); // Открытие Диалогового окна
            if (result != null) // если Диалоговое окно что-то возвращает, условие выполняется
             path = openFileDialog.FileName; // приравниваем к переменной путь который был выбран в Диалоговом окне
            return path;
        }
        public static List<Children> ReadChildrens(string path)// если понадобится считывание. Параметры - путь, с которого нужно считать
        {
            List<Children> childrens = new List<Children>(); // создаем список, в который будем считывать
            try
            {
                using (StreamReader reader = new StreamReader(path)) // инициализируем StreamReader, в который передаем путь, откуда будем считывать данные
                {
                    string line; // переменная, в которую построчно будет считывать файл
                    while ((line = reader.ReadLine()) != null) // цикл, который будет повторяться, пока строки в файле не закончатся
                    {
                        string[] strings = line.Split(","); // создаем массив стрингов, в который передаем строку, считанную из файла, и делим ее через специальные знаки (,)
                        try
                        {
                            childrens.Add(new Children { Name = strings[0].Replace("\"", ""), Birthday = strings[1].Replace("\"", ""), Gender = strings[2].Replace("\"", "") }); // добавляем в созданный список, инициализируя экземпляр класса Children данные из массива стрингов
                        }
                        catch { break; }
                    }
                }
            }
            catch { }
            return childrens; // возвращаем итоговый список
        }
        public static void WriteChildrens(List<Children> childrens, string path) // ззапись в файл. Параметры - лист, который нужно записать, путь к файлу, в который нужно записать
        {
            try 
            {
                using (StreamWriter writer = new StreamWriter(path)) // инициализируем StreamWriter, в который передаем путь, куда будем записывать List
                {
                    foreach (Children item in childrens) // проходимся по всему списку, переданному в метод
                    {
                        string line = $"{item.Name},{item.Birthday},{item.Gender}"; // создаем строковую переменную, приравнивая ее к строке, которую формируем
                        writer.WriteLine(line); // записываем строку в файл
                    }
                }
            }
            catch { }
        }
    }
}
