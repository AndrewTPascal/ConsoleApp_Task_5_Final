using System;

namespace ConsoleApp_Task_5_Final
{
    class Program
    {
        static void Main(string[] args)
        {
            // Получаем кортеж с анкетой
            var Anketa = CreateAnketa();

            // Выводим данные в консоль
            PrintAnketa(Anketa);
        }

        // Заполнение данных пользователя с клавиатуры
        static (string Name, string Surname, int Age, bool HavePet, string[] Pets, String[] Colors) CreateAnketa()
        {
            (string Name, string Surname, int Age, bool HavePet, string[] Pets, String[] Colors) Anketa;
            Console.Write("Введите ваше имя: ");
            Anketa.Name = Console.ReadLine();
            Console.Write("Введите вашу фамилию: ");
            Anketa.Surname = Console.ReadLine();
            Console.Write("Введите ваш возраст: ");
            Anketa.Age = CheckData();
            Console.Write("У вас есть питомец? да/нет: ");

            if ( CheckYesNo(Console.ReadLine()) )
            {
                Anketa.HavePet = true;
                Console.Write("Введите количество ваших питомцев: ");
                Anketa.Pets = CreatePets(CheckData());
            }
            else
            {
                Anketa.HavePet = false;
                Anketa.Pets = new string[0];
            }

            Console.Write("Введите количество ваших любимых цветов: ");
            Anketa.Colors = CreateColors(CheckData());

            return Anketa;
        }


        // Вывод данных в консоль
        static void PrintAnketa((string Name, string Surname, int Age, bool HavePet, string[] Pets, String[] Colors) Anketa)
        {
            Console.WriteLine("\nВаше имя: " + Anketa.Name);
            Console.WriteLine("Ваша фамилия: " + Anketa.Surname);
            Console.WriteLine("Ваш возраст: " + Anketa.Age);
            if (Anketa.HavePet)
            {
                if (Anketa.Pets.Length > 1)
                    Console.WriteLine("У вас есть питомцы. Имена ваших питомцев:");
                else
                    Console.Write("У вас есть питомец. Имя питомца: ");
                foreach (string pet in Anketa.Pets) Console.WriteLine(pet);
            }
            else
                Console.WriteLine("У вас нет питомцев");

            if (Anketa.Colors.Length > 1)
                Console.WriteLine("Ваши любимые цвета:");
            else
                Console.Write("Ваш любимый цвет: ");
            foreach (string color in Anketa.Colors) Console.WriteLine(color);

        }

        // Проверка корректности числовых данных
        static int CheckData()
        {
            bool iscorrect = false;
            int num = 0;

            while (!iscorrect)
            {
                iscorrect = int.TryParse(Console.ReadLine(), out num);

                if (iscorrect == false)
                {
                    Console.Write("Вы ввели некорректные данные! Повторите ввод: ");
                    continue;
                }

                if (num <= 0)
                {
                    iscorrect = false;
                    Console.Write("Вы ввели некорректные данные! Повторите ввод: ");
                }
            }
            return num;
        }


        // Проверка ответа пользователя: да/нет
        static bool CheckYesNo(string answer)
        {
 
            while (true)
            {

                if (string.Compare(answer.Trim(), "да", StringComparison.OrdinalIgnoreCase) == 0)
                    return true;
                
                if (string.Compare(answer.Trim(), "нет", StringComparison.OrdinalIgnoreCase) == 0)
                    return false;

                Console.Write("Вы ввели некорректные данные! Введите да/нет: ");
                answer = Console.ReadLine();
            }
   
        }

        // Создание массива с именами питомцев
        static string[] CreatePets(int pets)
        {
            string[] arrpets = new string[pets];
            for (int i = 0; i < arrpets.Length; i++)
            {
                if (arrpets.Length > 1)
                    Console.Write($"Введите имя питомца №{i + 1}: ");
                else
                    Console.Write("Введите имя питомца: ");
                arrpets[i] = Console.ReadLine();
            }
            return arrpets;
        }

        // Создание массива с цветами
        static string[] CreateColors(int colors)
        {
            string[] arrcolors = new string[colors];
            for (int i = 0; i < arrcolors.Length; i++)
            {
                if (arrcolors.Length > 1)
                    Console.Write($"Введите цвет №{i + 1}: ");
                else
                    Console.Write("Введите цвет: ");
                arrcolors[i] = Console.ReadLine();
            }
            return arrcolors;
        }







    }
}
