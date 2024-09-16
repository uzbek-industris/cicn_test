using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp1
{
    // Класс с базовыми функциями, реализованными через разложение в ряд Тейлора
    public class TaylorSeriesFunctions
    {
        // Метод для вычисления факториала
        public static double Factorial(int n)
        {
            if (n == 0) return 1;
            return n * Factorial(n - 1);
        }

        // Метод для вычисления синуса через разложение в ряд Тейлора
        public static double SinTaylor(double x, int terms = 10)
        {
            double result = 0;
            for (int i = 0; i < terms; i++)
            {
                double coef = (i % 2 == 0) ? 1 : -1;
                double term = coef * Math.Pow(x, 2 * i + 1) / Factorial(2 * i + 1);
                result += term;
            }
            return result;
        }

        // Метод для вычисления косинуса через разложение в ряд Тейлора
        public static double CosTaylor(double x, int terms = 10)
        {
            double result = 0;
            for (int i = 0; i < terms; i++)
            {
                double coef = (i % 2 == 0) ? 1 : -1;
                double term = coef * Math.Pow(x, 2 * i) / Factorial(2 * i);
                result += term;
            }
            return result;
        }

        // Метод для вычисления натурального логарифма через разложение в ряд Тейлора
        public static double LnTaylor(double x, int terms = 10)
        {
            if (x <= 0)
            {
                throw new ArgumentException("ln(x) is undefined for x <= 0");
            }

            double result = 0;
            for (int i = 1; i <= terms; i++)
            {
                double term = Math.Pow((x - 1) / (x + 1), 2 * i - 1) / (2 * i - 1);
                result += term;
            }
            return 2 * result;
        }

    }

    public class MainFunction
    {
        // Метод для вычисления главной функции
        public static double Evaluate(double x)
        {
            if (x < 0)
            {
                double sinTerm = TaylorSeriesFunctions.SinTaylor(x);
                double cosTerm = TaylorSeriesFunctions.CosTaylor(x);
                double lnTerm = TaylorSeriesFunctions.LnTaylor(Math.Abs(sinTerm));
                return sinTerm * sinTerm + cosTerm * cosTerm + lnTerm;
            }
            else
            {
                double sinTerm = TaylorSeriesFunctions.SinTaylor(x * x);
                double cosTerm = TaylorSeriesFunctions.CosTaylor(TaylorSeriesFunctions.LnTaylor(x * x));
                return Math.Sqrt(sinTerm + cosTerm);
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}

