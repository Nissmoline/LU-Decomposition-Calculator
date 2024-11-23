# LU Decomposition and Determinant Calculation

This repository contains a program for calculating the determinant of a square matrix using the **LU Decomposition Method**. The program also outputs the intermediate matrices $( L \)$ (lower triangular) and $( U \)$ (upper triangular) for better visualization of the decomposition process.

## Problem Statement

The determinant of a matrix is a scalar value that can be computed for square matrices and has numerous applications in mathematics and engineering. This program implements $LU$ decomposition to express a square matrix $( A \)$ as the product of two matrices:

$[
A = L \cdot U
\]$

Where:
- $( L \)$ is a lower triangular matrix.
- $( U \)$ is an upper triangular matrix.

The determinant of $( A \)$ is then calculated as:

$$
\text{det}(A) = u_{11} \cdot u_{22} \cdot \ldots \cdot u_{nn}
\$$

### Input:
- A square matrix \( A \).
- The order of the matrix \( n \).

### Output:
- Original matrix $( A \)$.
- Lower triangular matrix $( L \)$.
- Upper triangular matrix $( U \)$.
- Determinant of the matrix $( \text{det}(A) \)$.

---

## Implementation Details

### Algorithm Description: LU Decomposition
LU decomposition splits the matrix $( A \)$ into two matrices, $( L \)$ and $( U \)$, using the following formulas:

$$
u_{ik} = a_{ik} - \sum_{j=0}^{i-1} l_{ij} u_{jk}
\$$

$$
l_{ki} = \frac{a_{ki} - \sum_{j=0}^{i-1} l_{kj} u_{ji}}{u_{ii}}
\$$

**Steps:**
1. **Initialize Matrices $( L \)$ and $( U \)$:** 
   - $( L \)$ starts as an identity matrix.
   - $( U \)$ is initialized as a copy of $( A \)$.

2. **Perform Decomposition:**
   - Compute elements of $( U \)$ and $( L \)$ row by row.

3. **Calculate Determinant:** Multiply the diagonal elements of $( U \)$.

4. **Output Results:** Display matrices $( A \)$, $( L \)$, $( U \)$, and the determinant.

---

## Example

Given the matrix:

$$
A =
\begin{bmatrix}
4 & 0.24 & -0.08 \\
0.09 & 3 & 0.15 \\
0.04 & 0.08 & 4
\end{bmatrix}
$$

The program produces:
- **Matrix $( L \)$:**

$$
\begin{bmatrix}
1 & 0 & 0 \\
0.0225 & 1 & 0 \\
0.01 & 0.0266 & 1
\end{bmatrix}
$$

- **Matrix $( U \)$:**

$$
\begin{bmatrix}
4 & 0.24 & -0.08 \\
0 & 2.9946 & 0.1518 \\
0 & 0 & 3.9968
\end{bmatrix}
$$

- **Determinant:**

$$
\text{det}(A) = 4 \cdot 2.9946 \cdot 3.9968 \approx 47.876
$$

---

## Code Structure

### Main Function
Handles matrix initialization and calls other functions for LU decomposition and determinant calculation:
```csharp
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

    LU_Decomposition(A, L, U, n);

    Console.WriteLine("Original Matrix:");
    PrintMatrix(A, n);

    Console.WriteLine("Lower Triangular Matrix (L):");
    PrintMatrix(L, n);

    Console.WriteLine("Upper Triangular Matrix (U):");
    PrintMatrix(U, n);

    double detA = 1;
    for (int i = 0; i < n; i++) detA *= U[i, i];
    Console.WriteLine($"Determinant of Matrix: {detA}");
}
```

### LU Decomposition
Performs the decomposition:
```csharp
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

        L[i, i] = 1; // Diagonal of L is 1

        for (int k = i + 1; k < n; k++)
        {
            double sum = 0;
            for (int j = 0; j < i; j++) sum += L[k, j] * U[j, i];
            L[k, i] = (A[k, i] - sum) / U[i, i];
        }
    }
}
```

### Matrix Output
Prints any given matrix:
```csharp
static void PrintMatrix(double[,] matrix, int n)
{
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < n; j++) Console.Write($"{matrix[i, j],8:F2} ");
        Console.WriteLine();
    }
    Console.WriteLine();
}
```

---

## Requirements
- **Language:** C#
- **Environment:** .NET Framework or .NET Core
- **Libraries:** `System`

---

## Usage
Clone the repository and execute the program:
```bash
git clone https://github.com/Nissmoline/LU-Decomposition-Calculator.git
cd your-repo-name
dotnet run
```

---

## License
This project is open-source and available under the MIT License.
