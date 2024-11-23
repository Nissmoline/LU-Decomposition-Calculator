using System;

class Program
{
    static void Main(string[] args)
    {
        double[,] A = {
            { 4, 0.24, -0.08 },
            { 0.09, 3, 0.15 },
            { 0.04, 0.08, 4 }
        };

        int n = A.GetLength(0);
        double[,] L = new double[n, n];
        double[,] U = new double[n, n];

        // Выполнение LU-декомпозиции с инициализацией L и U
        LU_Decomposition(A, L, U, n);

        // Вывод исходной матрицы
        Console.WriteLine("Исходная матрица:");
        PrintMatrix(A, n);

        // Вывод матрицы L
        Console.WriteLine("Матрица L:");
        PrintMatrix(L, n);

        // Вывод матрицы U
        Console.WriteLine("Матрица U:");
        PrintMatrix(U, n);

        // Вычисление и вывод определителя матрицы A
        double detA = 1;
        for (int i = 0; i < n; i++) detA *= U[i, i];
        Console.WriteLine($"Определитель матрицы: {detA}");
        Console.WriteLine("\nНажмите Enter для завершения работы...");
        Console.ReadLine();
    }

    static void LU_Decomposition(double[,] A, double[,] L, double[,] U, int n)
    {
        for (int i = 0; i < n; i++)
        {
            for (int k = i; k < n; k++)
            {
                double sum = 0;
                for (int j = 0; j < i; j++) sum += L[i, j] * U[j, k];
                U[i, k] = A[i, k] - sum;
            }

            L[i, i] = 1; // Диагональ L заполняется единицами

            for (int k = i + 1; k < n; k++)
            {
                double sum = 0;
                for (int j = 0; j < i; j++) sum += L[k, j] * U[j, i];
                L[k, i] = (A[k, i] - sum) / U[i, i];
            }
        }
    }

    static void PrintMatrix(double[,] matrix, int n)
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++) Console.Write($"{matrix[i, j],8:F2} ");
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}
