﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_6_Bulygina_Delegates
{
    class Program
    {
        delegate String Operation(String name, double number);
        private static void RegisterDelegate(Operation op, String name, double number)
        {
            Console.WriteLine(op(name, number));
        }
        private static void RegisterFunc(Func<String, double, String> func, String name, double number)
        {
            Console.WriteLine(func(name, number));
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Лабораторная работа №6");
            Console.Title = "Булыгина Светлана, ИУ5Ц-51Б";

            Operation op = SqrtExp;
            Console.WriteLine(op("sqrt", 63.4));
            RegisterDelegate(op, "exp", -15); // делегат как параметр
            RegisterDelegate((name, number) => name.Equals("sqrt") ?
                "Корень из " + number + " = " + Math.Sqrt(number) :
                (name.Equals("exp") ? "e в степени " + number + " = " + Math.Exp(number) : ""), "sqrt", 6.66); //лямбда-выражение как параметр
            Func<String, double, String> func = SqrtExp;
            RegisterFunc(func, "pow", 3.333); // использование Funct<>

            Console.ReadKey();
        }
        private static String SqrtExp(String name, double number)
        {
            if (name.Equals("sqrt"))
            {
                return "Корень из " + number + " = " + Math.Sqrt(number);
            }
            else if (name.Equals("exp"))
            {
                return "e в степени " + number + " = " + Math.Exp(number);
            }
            else
            {
                return "Нет такой операции.";
            }
        }
    }
}
