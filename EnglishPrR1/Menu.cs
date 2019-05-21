using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnglishPrR1
{
    public class Menu
    {
        #region Обяевление и иницилизация 
        ConsoleKeyInfo mainKey;
        ConsoleKeyInfo inKey;

        int calculaterMainMenu;
        int allMenuNumber;

        private string header = "Выберите пункт меню: ";
        private string footer = "Нажмите <ESC> для выхода";

        /*содержание главного меню*/
        private String[] menuItem = new String[]
        {
            "Present Simple(работа со временем)",
            "Качества",
            "Профессиии",
            "Качества + профессии",
            "Местоимения",
            "Связки со словом can",
            "Связки со словом have",
            "Present Continuous(работа со временем)",
            "Повелительное наклонение",
            "Рresent Perfect(работа со временем)",
            "Past Simple"
        };        

        /*Преобразование и подсчёт элементов, создание конструктора*/
        public Menu()
        {            
            calculaterMainMenu = 0;
            allMenuNumber = Convert.ToInt16(menuItem.Length);
        }
        #endregion        

        #region Логика работы главного меню
        public void TopMenu()
        {
            ShowMenu();
            mainKey = Console.ReadKey();

            switch (mainKey.Key)
            {
                case ConsoleKey.Escape:
                    return;

                case ConsoleKey.Enter:
                    SelectionPoint();
                    break;

                    /*обработчик для нижней стрелочки*/
                case ConsoleKey.DownArrow:
                    if(calculaterMainMenu < allMenuNumber - 1)
                    {
                        calculaterMainMenu++;
                    }
                    else
                    {
                        calculaterMainMenu = 0;
                    }
                    TopMenu();
                    break;

                    /*обработчик для верхней стрелочки*/
                case ConsoleKey.UpArrow:
                    if(calculaterMainMenu > 0)
                    {
                        calculaterMainMenu--;
                    }
                    else
                    {
                        calculaterMainMenu = Convert.ToInt16(allMenuNumber - 1);
                    }
                    TopMenu();
                    break;
                default:
                    {
                        TopMenu();
                        break;
                    }                
            }
        }        
        #endregion

        #region Отображение главного меню
        private void ShowMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(header + "\n");

            Console.ForegroundColor = ConsoleColor.Gray;

            /*если поз. значения массива меньше*/
            for (int i = 0; i< allMenuNumber; i++)
            {
                if (i == calculaterMainMenu)
                    Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("{0}. {1}", i + 1, menuItem[i]);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n" + footer + "\n");
        }
        #endregion

        #region Переход на пункт меню
        private void SelectionPoint()
        {
            switch (calculaterMainMenu)
            {
                #region Present Simple
                case 0:
                    Console.Clear();

                    LesPrSimple obPrS = new LesPrSimple();
                    obPrS.StreamFirst("LesPrSimpleHelp.txt");
                    obPrS.StreamSecond("LesPrSimple.txt");

                    ShowMenu();                    
                    break;
                #endregion
                case 1:
                    Console.Clear();

                    Stream obLess2 = new Stream();
                    obLess2.StreamFirst("Less2Help.txt");
                    obLess2.StreamSecond("Less2.txt");

                    ShowMenu();
                    break;
            }
        }
        #endregion
    }
}