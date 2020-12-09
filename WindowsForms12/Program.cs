using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


namespace WindowsForms12
{
    static class Program
    {
        public static List<company> workers = new List<company>();
        public static void AddWorker(string fullName, string gender, int salary, int incSalary, int percent, int norm, int group) 
            //Функция добавления нового работника
        {
            
            Console.Write("\nВыберите тип работника:\n" +
                "'1' - Почасовой\n'2' - Комиссионный\n" +
                "'Другой вариант' - Вернуться назад\nВВОД: ");
            group = Convert.ToInt32(Console.ReadLine());
            if (group != 1 && group != 2) return;
            Console.Write("Введите ФИО работника: ");


            fullName = Console.ReadLine();
            Console.Write("Введите пол работника: ");
            gender = Console.ReadLine();

            switch (group)
            {
                case 1:
                    Console.Write("Введите ставку за час: ");
                    salary = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Введите повышенную ставку за час: ");
                    incSalary = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Введите норму часов: ");
                    norm = Convert.ToInt32(Console.ReadLine());
                    workers.Add(new hourly(fullName, gender, salary, incSalary, norm));
                    break;
                case 2:
                    Console.Write("Введите фиксированный оклад: ");
                    salary = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Введите процент за каждую продажу: ");
                    percent = Convert.ToInt32(Console.ReadLine());
                    workers.Add(new comission(fullName, gender, salary, percent));
                    break;
            }
        }

        public static void Dismiss(int worker) //Функция увольнения
        {
            
            while (true)
            {
                Console.Write("\nВведите номер работника ('0' - Вернуться назад): ");
                worker = Convert.ToInt32(Console.ReadLine());
                if (worker == 0) return;
                workers.RemoveAt(worker - 1);
                Console.Write("Работник успешно уволен\n");
                break;
            }
        }

        public static void SimulateWork(int day)
        {

            Console.WriteLine("\nСИМУЛЯЦИЯ НАЧАЛАСЬ\n");
            for (int i = 1; i <= day; i++)
            {
                Console.WriteLine("День " + i);
                for (int j = 0; j < workers.Count; ++j)
                {
                    workers[j].Work(1 + 6);
                    if (i % 15 == 0)
                    {
                        Console.WriteLine("ДЕНЬ РАСЧЕТА ЗАРПЛАТЫ\n" + workers[j].fullName);
                        workers[j].CalculateSalary();
                        Console.WriteLine(workers[j].salary + "rub");
                    }
                    Console.WriteLine(workers[j].fullName);
                }
            }
        }

        public static void PutList() //Функция вывода вектора
        {
            for (int i = 0; i < workers.Count; ++i)
                Console.WriteLine(i + 1 + ". " + workers[i].fullName);
        }

        public static void Serialize() //сериализация
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("people.dat", FileMode.OpenOrCreate))
                formatter.Serialize(fs, workers);
        }
        public static void Deserialize() //десериализация
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("people.dat", FileMode.OpenOrCreate))
                workers = (List<company>)formatter.Deserialize(fs);
        }
        public static void ClearDocument()
        {
            workers.Clear();
        }
        static void Menu()
        {
            int ans=0;
            while (true)
            {
                

                switch (ans)
                {
                   
                    case 2:
                        PutList();
                        break;
                   
                    case 4:
                        Console.WriteLine("Введите количество дней");
                        int days;
                        days = Convert.ToInt32(Console.ReadLine());
                        SimulateWork(days);
                        break;
                    
                    case 0:
                        System.Environment.Exit(0); //Функция выхода из программы
                        break;
                    
                }
            }
        }

        [STAThread]
        static void Main()
        {
         
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Menu());
        }
    }
}
