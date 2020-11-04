//ДЗ 3. Буй Тхе Зунг. УТС-22
// Вариант 2

//Проект Двумерные массивы
using System;

//Project include 
/*
 * 1. Input Number Element In Row and Column. Data have to be number
 * 2. Setting Random Value For Each Element In Matrix In Range(-50 -> 50)
 * 3. Show Matrix After Created In Console Screen
 * 4. Find Number Rows have not 0 number
 * 5. Calculate The Characsteristic of Row = Addition Of All Positive Even Number in Each Row
 * 6. Sort All Rows In Matrix According to The Increase Of Characsteristics
 */
namespace _2_DisArray
{
    class Program
    {    
        //Function Inout Data for Number of rows and columns. Check these valid data
        //Data have to be the interger number greater than 0
        static int Input(int Index)
        {
        Input:
            int result = 0;
            if (Index == 1)
            {
                Console.Write("Number of Rows : ");
            }
            else if (Index == 2)
            {
                Console.Write("Number of Columns : ");
            }
        
            try 
            {
                result = Convert.ToInt32(Console.ReadLine());
                if (result<= 1)
                {
                    Console.WriteLine("Sorry ! \nNumber Have To Be Greater Than 1");
                    goto Input;
                }
            }
            catch (FormatException M)
            {
                Console.WriteLine("Sorry ! \n The Input Format Exception : {0}.\n Please enter a interger number\n", M.Message);
                goto Input;
            }
            return result;
        }

        //Function show the matrix on console screen
        static void ShowMatrix(int[][] Matrix , int NumberRows, int NumberCols)
        {
            for (int i = 0; i < NumberRows; i++)
            {
                for (int j = 0; j < NumberCols; j++)
                {
                    Console.Write("{0}\t", Matrix[i][j]);
                }
                Console.Write("\n");
            }
        }

        //Function calculate the Characsteristics Of Rows. 
        //Stores the Characsteristic of each row in each cell in the array. The number of cells in the array corresponds to the number of rows
        //Show Array on console screen
        static int [] Cal_Find_CharacsteristicsRows(int[][] Matrix, int NumberRows, int NumberCols)
        {
            int[] CharacRows = new int[NumberRows];
            for (int i = 0; i < NumberRows; i++)
            {
                CharacRows[i] = 0;
                for (int j = 0; j < NumberCols; j++)
                {
                    if (Matrix[i][j] > 0)
                    {
                        if (Matrix[i][j] % 2 == 0)
                        {
                            CharacRows[i] = CharacRows[i] + Matrix[i][j];
                        }
                    }
                }
            }

            Console.WriteLine("Characteristic of Rows : ");
            for (int i = 0; i < NumberRows; i++)
            {
                Console.Write("{0}\t", CharacRows[i]);
            }
            return CharacRows;
        }

        static void Main(string[] args)
        {
            int NumberRows, NumberCols;
            NumberRows = Input(1);
            NumberCols = Input(2);
            Console.WriteLine("Number of Rows {0}, Number of Columns {1}", NumberRows, NumberCols);

            //Define the matrix have the size = NumberRows * NumberCols
            int[][] Matrix = new int[NumberRows][];
            for (int i = 0; i < NumberRows; i++)
            {
                Matrix[i] = new int[NumberCols];
            }

            //Setting random value in range(-50 -> 50) for each element in matrix
            for (int i = 0; i < NumberRows; i++)
            {
                for (int j = 0; j < NumberCols; j++)
                {
                    Random R = new Random();
                    Matrix[i][j] = R.Next(-50,50);
                }
            }
      
            Console.WriteLine("Matrix : ");
            ShowMatrix(Matrix, NumberRows, NumberCols);


            //Find number columns have not 0 number inside and show result
            int NumberCol_NOT_Include0 = NumberCols;
            for (int i = 0; i < NumberCols; i++)
            {
                int NumberElement0InCol = 0;
                for (int j = 0; j < NumberRows; j++)
                {
                    if (Matrix[j][i] == 0)
                    {
                        NumberElement0InCol++;
                    }
                }
                if (NumberElement0InCol != 0)
                {
                    NumberCol_NOT_Include0--;
                    Console.WriteLine("Index Column Include 0 : {0}", i);
                }
            }
            Console.WriteLine("Number Col Not Include 0 : {0}", NumberCol_NOT_Include0);


            //Find Characsteristic of each row and show result follow a array 
            int[] CharacRows = new int[NumberRows];
            CharacRows=Cal_Find_CharacsteristicsRows(Matrix, NumberRows, NumberCols);


            //Sort All Rows In Matrix According to The Increase Of Characsteristics
            int[] tem = new int[NumberCols];
            int TemCharacRows;
            for (int i = 0; i < NumberRows; i++)
            {
                for (int j = i + 1; j < NumberRows; j++)
                {
                    if (CharacRows[i] > CharacRows[j])
                    {
                        tem = Matrix[i];
                        Matrix[i] = Matrix[j];
                        Matrix[j] = tem;
                        TemCharacRows = CharacRows[i];
                        CharacRows[i] = CharacRows[j];
                        CharacRows[j] = TemCharacRows;
                    }
                }
            }
            Console.WriteLine("\nMatrix After Sorted");
            ShowMatrix(Matrix, NumberRows, NumberCols); // Show Matrix after sorted


            //Find Characsteristic of each row to check the new Matrix is exactly sorting according to requirement
            Cal_Find_CharacsteristicsRows(Matrix, NumberRows, NumberCols);


            Console.ReadKey();
        }
    }
}
