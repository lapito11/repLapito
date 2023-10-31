using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace lab2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Считаем квадратное уравнение по заданным значениям\n");
            Console.ResetColor();
            bool one = true;
            double a, b, c;

            try
            {
                StreamReader str = new StreamReader("file1.txt");
                if (!double.TryParse(str.ReadLine(), out a) || !double.TryParse(str.ReadLine(), out b) || !double.TryParse(str.ReadLine(), out c))
                    throw new IncorrectDataException();
                double D = b * b - 4 * a * c;
                if (D < 0)
                    throw new NegativeDiscriminantException();
                switch (D)
                {
                    case 0:
                        Console.WriteLine("X=" + (-b/(2*a)));
                        break;
                    default:
                        Console.WriteLine("X1= " + ((-b-Math.Sqrt(D))/(2*a)));
                        Console.WriteLine("X2= " + ((-b+Math.Sqrt(D))/(2*a)));
                        break;
                }
            }
            catch (DefaultEquationException ex)
            {
                Console.WriteLine(ex.Message);
                one = false;
            }
            catch(NegativeDiscriminantException ex)
            {
                Console.WriteLine(ex.Message);
                one = false;
            }
            catch(FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                one = false;
            }
            catch(IncorrectDataException ex)
            {
                Console.WriteLine(ex.Message);
                one = false;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                one = false;
            }
            finally
            {
                if(one)
                    Console.WriteLine("Готово");
                else
                    Console.WriteLine("Ошибка");
                Console.ReadLine();
            }
        }
    }
}
