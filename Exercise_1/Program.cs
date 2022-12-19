uint numberOfRows;
try
{
    numberOfRows = GetNumber("Enter number of rows: ");
}
catch(FormatException ex)
{
    Console.WriteLine(ex.Message);
    return;
}

uint numberOfColumns;
try
{
    numberOfColumns = GetNumber("Enter number of columns: ");
}
catch(FormatException ex)
{
    Console.WriteLine(ex.Message);
    return;
}
double [,] twoDimensionalArray = new double[numberOfRows, numberOfColumns];
Fill2DArray(twoDimensionalArray);
Print2DArray(twoDimensionalArray);


void Print2DArray(double [,] array)
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


void Fill2DArray(double [,] array)
{
    Random random = new Random();
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i,j] = Convert.ToDouble(random.Next(-100, 101)) / 10;
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