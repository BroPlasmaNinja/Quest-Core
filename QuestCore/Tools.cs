using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestCore
{
    public class Tools
    {
        /// <summary>
        /// Красивый вывод с нужными цветами. при этом мы оставляем стандартные цвета не тронутыми
        /// </summary>
        /// <param name="text">Техе который выведется</param>
        /// <param name="col">Цвет вывода (формат 0-задний фон, 1-цвет строки)</param>
        /// <param name="writeLine">Нужно ли ставить символ "с новой строки" в конце вывода</param>
        static public void PO<T>(T text, ConsoleColor backgroundColor, ConsoleColor foregroundColor, bool writeLine)
        {
            ConsoleColor defb = Console.BackgroundColor;
            Console.BackgroundColor = backgroundColor;
            ConsoleColor deff = Console.ForegroundColor;
            Console.ForegroundColor = foregroundColor;
            Console.Write(text.ToString(), 0);
            Console.BackgroundColor = defb;
            Console.ForegroundColor = deff;
            if (writeLine)
                Console.Write("\n", 0);
        }
        /// <summary>
        /// Считывает данные указанного файла
        /// </summary>
        /// <param name="path">Полный путь к файлу</param>
        /// <returns></returns>
        static public string ReadData(string path)
        {
            using (FileStream file = new FileStream(path, FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(file))
                {
                    return sr.ReadToEnd();
                }
            }
        }
        /// <summary>
        /// Сохраняет файл в указанном месте
        /// </summary>
        /// <param name="path">Полный путь для сохранения, название и расширение файла</param>
        /// <param name="mode">По какому принципу записываются данные</param>
        /// <param name="text">Данные которые нужно сохранить</param>
        static public void SaveDate(string path, FileMode mode, string text)
        {
            using (FileStream file = new FileStream(path, FileMode.OpenOrCreate))
            {
                using (StreamWriter sw = new StreamWriter(file))
                {
                    sw.Write(text);
                }
            }
        }
    }
}
