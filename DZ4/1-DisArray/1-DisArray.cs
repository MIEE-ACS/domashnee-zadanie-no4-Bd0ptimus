//ДЗ 3. Буй Тхе Зунг. УТС-22
// Вариант 2

//Проект Одномерные массивы
using System;
using System.Runtime.Versioning;

//Project include 
/*
 * 1. Input Number Element In Array. Data have to be number
 * 2. Setting Random Value For Each Element In Array In Range(-100 -> 100)
 * 3. Show Array After Created In Console Screen
 * 4. Find All Positive Number In Array And Calculate Sum Of All Positive Numbers
 * 5. Find Max, Min Module Element In Array and their Position
 * 6. Calculate The Multiplication Of All Element Between Max, Min Module Element
 * 7. Sorts The Elements In Descending Order
 */
namespace _1_DisArray
{
    class Program
    {
        static void Main(string[] args)
        {
        InputProcess:
            int NumberElement;
            double SumPositiveElement = 0;
            double MultiResult = 1;


            //I.
            // Input number elements of array :
            // Input have to be a number and greater than 0
            try
            {
                Console.Write("Number of Array : ");
                NumberElement = Convert.ToInt32(Console.ReadLine());
                if (NumberElement <= 1)
                {
                    Console.WriteLine("Sorry ! \nNumber Of Array Have To Be Greater Than 1");
                    goto InputProcess;
                }
            }
            catch (FormatException M)
            {
                Console.WriteLine("Sorry ! \n The Number Format Exception : {0}.\n Please enter a interger number\n", M.Message);
                goto InputProcess;
            }

            // Define the array, setting random value (-100 -> 100) for each element and show array after created
            double[] Array = new double[NumberElement]; //Declare Array
            Random R = new Random();
            for (int i = 0; i < NumberElement; i++)
            {
                Array[i] = Math.Round(R.NextDouble() * (100 + 100) - 100, 3);
            }
            Console.WriteLine("Array : "); // Show Array
            for (int i = 0; i < NumberElement; i++)
            {
                Console.Write("{0}\t", Array[i]);
            }


            //II.
            // Calculate Sum of positive elements in array and show result
            for (int i = 0; i < NumberElement; i++)
            {
                if (Array[i] > 0)
                {
                    SumPositiveElement = SumPositiveElement + Array[i];
                }
            }
            Console.WriteLine("\n*Sum All Positive Elements = {0}", SumPositiveElement);


            //III.
            //Find the max, min module element in array, their position and calculate the multiplication of elements between them
            //Find the max, min module element, their position in array 
            double Max = Math.Abs(Array[0]);
            int MaxPos=0;
            double Min = Math.Abs(Array[0]);
            int MinPos=0;
            for (int i = 0; i < NumberElement; i++)
            {
                if (Max < Math.Abs(Array[i]))
                {
                    Max = Math.Abs(Array[i]);
                    MaxPos = i;
                }

                if (Min > Math.Abs(Array[i]))
                {
                    Min = Math.Abs(Array[i]);
                    MinPos = i;
                }
            }
            Console.WriteLine("Max Module Element = {0} in Position {1} ; Min Module Element = {2} in Position {3}", Max, MaxPos, Min, MinPos);
            // Check whigh position is higher in array, then make the loop for the lower to higher
            int Bigger = MaxPos;
            int Smaller = MinPos;
            if (MaxPos < MinPos)
            {
                Bigger = MinPos;
                Smaller = MaxPos;
            }
            // Calculate the multiplication
            for (int i = Smaller+1; i < Bigger; i++)
            {
                //Console.Write("\t {0}", Array[i]);
                MultiResult = Math.Round(MultiResult * Array[i],3);
            }
            // If Position of them are next to together, so will be nothing between them
            if (MultiResult == 1)
            {
                Console.WriteLine("Between Max and Min Module Number have not element !");
            }
            else
            {
                Console.WriteLine("\n*Result Of Multiplication All Elements Between Max and Min Module Number {0}", MultiResult); // Show the result
            }


            //IV.
            //Sorts The Elements In Descending Order And Show New Array
            for (int i = 0; i < NumberElement; i++)
            {
                for(int j=i+1;j<NumberElement;j++)
                {
                    if (Array[i] < Array[j])
                    {
                        double tem = Array[i];
                        Array[i] = Array[j];
                        Array[j] = tem;
                    }
                }
            }
            Console.WriteLine("*Array, after having sorted the elements in descending order");
            for (int i = 0; i < NumberElement; i++)
            {
                Console.Write("{0}\t", Array[i]);
            }

            Console.ReadKey();
        }
    }
}
