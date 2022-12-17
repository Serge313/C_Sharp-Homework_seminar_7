int[,] twoDimensionalArray = {{-4, 7, 9, -1}, {3, 5, -6, 4}, {2, 8, -3, -4}, {4, -9, -5, 6}};
Print2DArray(twoDimensionalArray);

uint chosenRowIndex;
try
{
    chosenRowIndex = GetNumber("Enter chosen two-dimensional array row index ");
}
catch(FormatException ex)
{
    Console.WriteLine(ex.Message);
    return;
}

uint chosenColumnIndex;
try
{
    chosenColumnIndex = GetNumber("Enter chosen two-dimensional array column index ");
}
catch(FormatException ex)
{
    Console.WriteLine(ex.Message);
    return;
}

int numberUnderIndexes;
try
{
    numberUnderIndexes = FindNumberUnderIndex(twoDimensionalArray, chosenRowIndex, chosenColumnIndex);
}
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
    return;
}

Console.WriteLine($"[{chosenRowIndex}], [{chosenColumnIndex}] - > {numberUnderIndexes}");

TestingFindNumberUnderIndex();






void TestingFindNumberUnderIndex()
{
    Console.WriteLine();
    Console.WriteLine("Testing of the \"FindNumberUnderIndex\" method has been launched... ");
    int[,] testArray = {{1, 4, 7, 2}, {5, 9, 2, 3}, {8, 4, 2, 4}};
    int expected = 9;
    int actual = FindNumberUnderIndex(testArray, 1, 1);
    bool isEqual = expected == actual;
    if (isEqual)
    {
        Console.WriteLine("Test completed successfully!");
    }
    else
    {
        Console.WriteLine("Error! Need to fix the method!");
    }
    Console.WriteLine();
}


int FindNumberUnderIndex(int[,] array, uint a, uint b)
{
    bool existIndexOrNot = ((a >= 0 && a < array.GetLength(0)) && (b >= 0 && b < array.GetLength(1)));
    if (existIndexOrNot)
    {
        return array[a, b];
    }
    else
    {
        throw new Exception($"[{chosenRowIndex}], [{chosenColumnIndex}] - > the number at entered indexes does not exist!");
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