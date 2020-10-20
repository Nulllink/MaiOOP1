using System;
using Unit1;
using System.Windows.Forms;
using System.IO;
namespace OOP1
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            //создание объекта для открытия меню выбора файла
            OpenFileDialog opd = new OpenFileDialog();
            opd.ShowDialog();
            //проверка выбора файла данных
            if (opd.FileName.Length > 0)
            {
                
                //task1(opd);
                //запуск функции выполнения 2 задачи
                task2(opd);
            }
            else
            {
                Console.WriteLine("Не выбран файл входных данных");
            }
            Console.Read();
            
        }

        static void task1(OpenFileDialog opd)
        {
            //получение 3 массивов данных из файла
            float[] a = Class1.Vv('a', opd.FileName, 0);
            float[] b = Class1.Vv('b', opd.FileName, 1);
            float[] c = Class1.Vv('c', opd.FileName, 2);
            //проверка правильности данных
            if (a.Length > 0 && b.Length > 0)
            {
                //расчет и вывод результата функции
                float y = 3 * (Class1.MAX(a) + Class1.MIN(b) + Class1.MAX(a));
                Console.WriteLine($"y= {y}");
                //Сохранение результата в выбранном пользователем файле
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.ShowDialog();
                StreamWriter sw = new StreamWriter(sfd.FileName);
                sw.WriteLine("Результат в файле:");
                sw.WriteLine($"y= {y}");
                sw.Close();
            }
            else
            {
                Console.WriteLine("Неправильные входные данные");
            }
        }
        static void task2(OpenFileDialog opd)
        {
            //вызов диалога выбора файла для сохранения
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.ShowDialog();
            //создание потоков записи и чтения
            StreamWriter sw = new StreamWriter(sfd.FileName);
            StreamReader sr = new StreamReader(opd.FileName);
            //считывание данных из файла
            try
            {
                string line;
                if ((line = sr.ReadLine()) != null)
                {
                    string[] mass = line.Split(' ');
                    double a = double.Parse(mass[0]);
                    double b = double.Parse(mass[1]);
                    double n = double.Parse(sr.ReadLine());
                    //проверка n
                    if (n == 0)
                    {
                        Console.WriteLine("n не может быть нулем");
                    }
                    else if (n < 0 && a < b)
                    {
                        Console.WriteLine("n должно быть положительно при а < b"); 
                    }                    
                    else
                    {
                        double x = a;
                        //вывод шапки первой таблицы
                        sw.WriteLine("Таблица значений функции F1");
                        Console.WriteLine("Таблица значений функции F1");
                        sw.WriteLine("    X        F1");
                        Console.WriteLine("    X        F1");
                        sw.WriteLine("--------------------");
                        Console.WriteLine("--------------------");
                        //вывод результата первой функции
                        while (x <= b)
                        {
                            double f1 = Class2.Fun1(x);
                            sw.WriteLine($"{x:f2}          {f1:f2}");
                            Console.WriteLine($"{x:f2}          {f1:f2}");
                            x += n;
                        }
                        Console.WriteLine();
                        sw.WriteLine();
                        x = a;
                        //вывод шапки второй таблицы
                        sw.WriteLine("Таблица значений функции F2");
                        Console.WriteLine("Таблица значений функции F2");
                        sw.WriteLine("    X        F2");
                        Console.WriteLine("    X        F2");
                        sw.WriteLine("--------------------");
                        Console.WriteLine("--------------------");
                        //вывод результата второй функции
                        while (x <= b)
                        {
                            double f2 = Class2.Fun2(x);
                            sw.WriteLine($"{x:f2}          {f2:f2}");
                            Console.WriteLine($"{x:f2}          {f2:f2}");
                            x += n;
                        }
                        Console.WriteLine();
                        sw.WriteLine();
                        x = a;
                        //вывод шапки третьей таблицы
                        sw.WriteLine("Таблица значений функций F1 и F2");
                        Console.WriteLine("Таблица значений функций F1 и F2");
                        sw.WriteLine("    X        F1        F2");
                        Console.WriteLine("    X        F1        F2");
                        sw.WriteLine("-------------------------------");
                        Console.WriteLine("-------------------------------");
                        //вывод результата третьей функции
                        while (x <= b)
                        {
                            double f2 = Class2.Fun2(x);
                            double f1 = Class2.Fun1(x);
                            sw.WriteLine($"{x:f2}      {f1:f2}          {f2:f2}");
                            Console.WriteLine($"{x:f2}      {f1:f2}          {f2:f2}");
                            x += n;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Файл пуст");
                }
            }
            catch
            {
                Console.WriteLine("Данные не верны");
            }
            //закрытие потоков
            sw.Close();
            sr.Close();
        }
    }
}
