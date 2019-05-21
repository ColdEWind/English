using System;
using System.IO;
using System.Speech.Synthesis;
using System.Text;

namespace EnglishPrR1
{
    class Stream
    {
        FileStream openStream;  //поток для чтения
        string streamHelp;      //поле для чтения справочной информации
        string streamTasks;     //поле для вывода тренажера

        /*создаем объект для озвучивания речи*/
        SpeechSynthesizer synth = new SpeechSynthesizer();

        #region Работа со справкой;
        public void StreamFirst(string link)
        {
            /*открываем поток*/
            try
            {
                openStream = new FileStream(link, FileMode.Open);
            }
            catch (FileNotFoundException exc)
            {
                Console.WriteLine(exc.Message + "Не удается открыть фаил.");
                Console.ReadKey();
                return;
            }

            /*закрывем поток*/
            StreamReader fileStreamFirst = new StreamReader(openStream, Encoding.GetEncoding(1251));

            while ((streamHelp = fileStreamFirst.ReadLine()) != null)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(streamHelp);
            }
            fileStreamFirst.Close();
        }
        #endregion

        #region Работа с тренажером;
        public void StreamSecond(string link)
        {
            /*открываем поток*/
            try
            {
                openStream = new FileStream(link, FileMode.Open);
            }
            catch (FileNotFoundException exc)
            {
                Console.WriteLine(exc.Message + "Не удается открыть фаил.");
                Console.ReadKey();
                return;
            }

            /*закрывем поток*/
            StreamReader fileStreamSecond = new StreamReader(openStream, Encoding.GetEncoding(1251));

            while ((streamTasks = fileStreamSecond.ReadLine()) != null)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(streamTasks);
                synth.Speak(streamTasks);
                Console.ReadKey();
            }
            fileStreamSecond.Close();
        }
        #endregion
    }
}
