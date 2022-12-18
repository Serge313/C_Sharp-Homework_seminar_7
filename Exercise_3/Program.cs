uint numberOfRows;
try
{
    numberOfRows = GetNumber("Enter number of rows ");
}
catch(FormatException ex)
{
    Console.WriteLine(ex.Message);
    return;
}

uint numberOfColumns;
try
{
    numberOfColumns = GetNumber("Enter number of columns ");
}
catch(FormatException ex)
{
    Console.WriteLine(ex.Message);
    return;
}

int[,] twoDimensionalArray = new int[numberOfRows, numberOfColumns];
Fill2DArray(twoDimensionalArray);
Print2DArray(twoDimensionalArray);
FindArithmeticalMean(twoDimensionalArray, numberOfColumns, numberOfRows);


void FindArithmeticalMean(int[,] array, uint numberOfColumns, uint numberOfRows)
{
    int j = 0;
    while (j < numberOfColumns)
    {
        double sumOfNumbersInColumn = 0;
        for (int i = 0; i < array.GetLength(0); i++)
        {
            sumOfNumbersInColumn += array[i,j];
        }
        double arithmeticalMean = Math.Round((sumOfNumbersInColumn / numberOfRows), 1);
        Console.WriteLine($"Arithmetical mean of numbers in the {j+1} column is {arithmeticalMean}");
        j++;
    }
}


void Print2DArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i, j]} ");
        }
        Console.WriteLine();
    }
}


void Fill2DArray(int[,] array)
{
    Random random = new Random();
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i,j] = random.Next(1, 10);
        }
    }
}


uint GetNumber(string message)
{
    Console.Write(message);
    bool isParsed = uint.TryParse(Console.ReadLine(), out uint number);
    if (isParsed)
    {
        return number;
    }
    else
    {
        throw new FormatException("Invalid value entered!");
    }
}