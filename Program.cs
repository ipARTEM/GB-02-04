using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace GB_02_04
{



    public class User
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }

        public override bool Equals(object obj)
        {
            var user = obj as User;

            if (user == null)
                return false;

            return FirstName == user.FirstName && SecondName == user.SecondName;
        }

        public override int GetHashCode()
        {
            int firtsNameHashCode = FirstName?.GetHashCode() ?? 0;
            int secondNameHashCode = SecondName?.GetHashCode() ?? 0;
            return firtsNameHashCode ^ secondNameHashCode;
        }
    }


    






    class Program
    {
        static string[] array;

        static HashSet<string> hashSet=new HashSet<string>();

        static int newLength;

        static Stopwatch sw;

        static int RandomGenerator(int quantity, int length)
        {
            array = new string[quantity];

            

            for (int i = 0; i < quantity; i++)
            {
                var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                var stringChars = new char[length];
                var random = new Random();

                for (int j = 0; j < stringChars.Length; j++)
                {
                    stringChars[j] = chars[random.Next(chars.Length)];
                }

                var finalString = new String(stringChars);
                hashSet.Add(finalString);
                //Console.WriteLine(finalString);
                

            }
            Console.WriteLine($"Количество объектов: {hashSet.Count}");
            Console.WriteLine("Объекты инициализированны");

            return newLength = length;
        }

        static void TestSpeed(int quantityTest)
        {

            Console.WriteLine("*************************Тестирование*************************");

            Console.WriteLine(" array        hashSet    ");

            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[newLength];
            var random = new Random();

            for (int j = 0; j < stringChars.Length; j++)
            {
                stringChars[j] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);

            sw = new Stopwatch();
            sw.Start();

            for (int i = 0; i < array.Length; i++)
            {
                if (finalString==i.ToString())
                {
                    Console.WriteLine("НАШЁЛ");
                    break;

                }

            }
            sw.Stop();
            Console.Write($" {sw.ElapsedTicks}       ");

            sw.Start();

            for (int i = 0; i < hashSet.Count; i++)
            {
                if (finalString == i.ToString())
                {
                    Console.WriteLine("НАШЁЛ");
                    break;

                }

            }
            sw.Stop();
            Console.Write($" {sw.ElapsedTicks}       ");

            Console.WriteLine("НЕ НАШЁЛ");



        }







        static void Main(string[] args)
        {
            RandomGenerator(1000,1000);

            TestSpeed(100);


        }
    }
}
