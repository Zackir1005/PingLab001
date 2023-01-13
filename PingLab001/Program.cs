using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PingLab001
{
    class CommandLine
    {
        public static int[] Numbers;
        public static int[] GetNumbers()
        {
            return Numbers;
        }

        public static void AddNumbers(int _number, int _index)
        {
            Numbers[_index] = _number;
        }
        public static void DetectNumbers(string[] _args)
        {
            try
            {
                int _length = _args.Length;
                bool IsInputNeed = true;
                for (int i = 0; i < _length; i++)
                {
                    Console.Write("Аргумент {1} = {0}", _args[i], i);
                    Converter.Convert2Int(_args[i], out int _Number, out bool _succes);
                    if (_succes)
                    {
                        Console.Write(" - это число {0}", _Number);
                    }
                    else
                    {
                        Converter.Convert2Int(_args[i], IsInputNeed, out _Number);
                        _args[i] = _Number.ToString();
                        AddNumbers(_Number, i);
                        Console.WriteLine("Получили число {0}", _Number);
                    }
                    Console.WriteLine();
                }
                foreach (var item in _args)
                {
                    Console.WriteLine("Получено число {0}", item);
                }
            }
            catch
            {
                Console.WriteLine("Программа требует ввода агрументов командной строки");

            }
        }
    }
    class Converter
    {
        public static void Convert2Int(string _input, out int result, out bool _succes)
        {
            try
            {
                result = int.Parse(_input);
                _succes = true;
            }
            catch
            {
                result = 0;
                _succes = false;
            }
        }
        public static void Convert2Int(string _input, bool IsInputNeed, out int result)
        {
            bool IsConverted = false;
            if (IsInputNeed)
            {
                try
                {
                    result = int.Parse(_input);
                }
                catch
                {
                    do
                    {
                        try
                        {
                            Console.WriteLine("Введите число");
                            result = int.Parse(Console.ReadLine());
                            IsConverted = true;
                        }
                        catch
                        {
                            Console.WriteLine("Не число, повторите ввод...");
                            result = 0;
                        }

                    } while (!IsConverted);
                }
            }
            else
            {
                Convert2Int(_input, out result, out bool _success);
            }
        }
    }
    class myArray
    {
        public void Print(int[] _Arr)
        {
            _Arr = new[] { 11, 12, 7, 1, 5, 9, 4, 8, 6, 3 };
            Console.WriteLine($"{_Arr[0]}, {_Arr[1]}, {_Arr[2]}, {_Arr[3]}, {_Arr[4]}, {_Arr[5]}, {_Arr[6]}, {_Arr[7]}, {_Arr[8]}, {_Arr[9]}");
        }
        public void Print(string[] _Arr)
        {
            _Arr = new[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            Console.WriteLine($"Дни недели: {_Arr[0]}, {_Arr[1]}, {_Arr[2]}, {_Arr[3]}, {_Arr[4]}, {_Arr[5]}, {_Arr[6]}");
        }
        public void Sort(int[] _Arr)
        {
            Console.WriteLine("Сортировка: ");
            _Arr = new[] { 11, 12, 7, 1, 5, 9, 4, 8, 6, 3 };
            for (int i = _Arr.Min(); i < _Arr.Max() + 1; i++)
            {
                if (_Arr.Contains(i))
                {
                    Console.Write(i+" ");
                }
            }
            Console.WriteLine();
        }
        public void Sort(string[] _Arr)
        {
            Console.WriteLine("Сортировка: ");
            _Arr = new[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            Array.Sort(_Arr);
            Console.WriteLine(String.Join(", ", _Arr));
        }
        public void FindEven(int[] _Arr)
        {
            Console.WriteLine("Поиск числа:");
            _Arr = new[] { 11, 12, 7, 1, 5, 9, 4, 8, 6, 3 };
            Console.WriteLine($"{_Arr[0]}, {_Arr[1]}, {_Arr[2]}, {_Arr[3]}, {_Arr[4]}, {_Arr[5]}, {_Arr[6]}, {_Arr[7]}, {_Arr[8]}, {_Arr[9]}\nВведите число:");
            bool TF;
            do
            {
                try
                {
                    int _input = Int16.Parse(Console.ReadLine());
                    int search = Array.Find(_Arr, n => n == _input);
                    if (search != _Arr[0] && search != _Arr[1] && search != _Arr[2] && search != _Arr[3] && search != _Arr[4] && 
                        search != _Arr[5] && search != _Arr[6] && search != _Arr[7] && search != _Arr[8] && search != _Arr[9])
                    {
                        Console.WriteLine("Ошибка! Такого числа нет! Попробовать ещё раз?( 1 - да, другое число - нет)");
                        int _input2 = Int16.Parse(Console.ReadLine());
                        if (_input2==1)
                        {
                            Console.WriteLine("\nВведите число:");
                            TF = true;
                        }
                        else
                        {
                            TF = false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Число найденно!");
                        Console.WriteLine(search);
                        TF = false;
                    }
                }
                catch
                {
                    Console.WriteLine("Ошибка! Это не число! Попробуйте ещё раз!\nВведите число:");
                    TF = true;
                }
            } while (TF);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var _myArr= new myArray();
            int [] _intArr= new int[10];
            string[] _stringArr = new string[7];

            try
            {
                string[] _args = new string[args.Length];
                int[] _intArgs = new int[args.Length];
                for (int i = 0; i < args.Length; i++)
                {
                    _args[i] = args[i];
                }
                CommandLine.DetectNumbers(_args);
                _intArgs = CommandLine.GetNumbers();
            }
            catch
            {
                Console.WriteLine("Программа требует ввода агрументов командной строки");
            }

            Console.WriteLine();
            _myArr.Print(_intArr);
            Console.WriteLine();
            _myArr.Sort(_intArr);
            Console.WriteLine();
            _myArr.Print(_stringArr);
            Console.WriteLine();
            _myArr.Sort(_stringArr);
            Console.WriteLine();
            _myArr.FindEven(_intArr);
            Console.WriteLine();
        }
    }
}
