uint rowLength;
try
{
    rowLength = GetNumber("Enter row length ");
}
catch(FormatException ex)
{
    Console.WriteLine(ex.Message);
    return;
}

uint columnLength;
try
{
    columnLength = GetNumber("Enter column length ");
}
catch(FormatException ex)
{
    Console.WriteLine(ex.Message);
    return;
}
double [,] twoDimensionalArray = new double[rowLength, columnLength];
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
            array[i,j] = random.NextDouble();
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