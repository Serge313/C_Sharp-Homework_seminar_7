TestingFindArithmeticalMeanOfParticularColumn();

uint numberOfRows;
try
{
    numberOfRows = GetNumber("Enter number of rows: ");
}
catch (FormatException ex)
{
    Console.WriteLine(ex.Message);
    return;
}

uint numberOfColumns;
try
{
    numberOfColumns = GetNumber("Enter number of columns: ");
}
catch (FormatException ex)
{
    Console.WriteLine(ex.Message);
    return;
}

int[,] twoDimensionalArray = new int[numberOfRows, numberOfColumns];
Fill2DArray(twoDimensionalArray);
Print2DArray(twoDimensionalArray);

/*Выбор пользователем пути решения задачи через консоль.
Если пользователь ввел 1 - в консоль выводятся среднее арифметическое каждого столбца.
Если пользователь ввел 2 - в консоль выводится просьба ввести номер столбца для вывода
среднего арифметического чисел выбранного столбца*/
uint exerciseSolutionWay;
try
{
    exerciseSolutionWay = GetNumber("Enter 1, if you want to get arithmetical mean of each column, or enter 2, if you want to choose particular column: ");
}
catch (FormatException ex)
{
    Console.WriteLine(ex.Message);
    return;
}

ChooseExerciseSolutionWay(exerciseSolutionWay);





void TestingFindArithmeticalMeanOfParticularColumn()
{
    Console.WriteLine("Testing of the \"FindArithmeticalMeanOfParticularColumn\" method has been launched... ");
    int[,] test2DArray = {{1, 4, 7, 2}, {5, 9, 2, 3}, {8, 4, 2, 4}};
    double expected = 5.7;
    double actual = FindArithmeticalMeanOfParticularColumn(test2DArray, 3, 2);
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


void ChooseExerciseSolutionWay(uint a)
{
    if (exerciseSolutionWay == 1)
    {
        FindArithmeticalMean(twoDimensionalArray, numberOfColumns, numberOfRows);
    }
    else if (exerciseSolutionWay == 2)
    {
        Console.WriteLine();
        uint particularColumn;
        try
        {
            particularColumn = GetNumber("Enter the number of the column, which arithmetical mean should be found: ");
        }
        catch (FormatException ex)
        {
            Console.WriteLine(ex.Message);
            return;
        }
        double arithmeticalMeanOfParticularColumn = FindArithmeticalMeanOfParticularColumn(twoDimensionalArray, numberOfRows, particularColumn);
        Console.WriteLine();
        Console.WriteLine($"Arithmetical mean of the {particularColumn} column is {arithmeticalMeanOfParticularColumn}");
    }
    else
    {
        Console.WriteLine("You should enter 1 or 2 only!");
        return;
    }
}


double FindArithmeticalMeanOfParticularColumn(int[,] array, uint numberOfRows, uint particularColumn)
{
    uint j = particularColumn - 1;
    double sumOfNumbersInColumn = 0;
    for (int i = 0; i < array.GetLength(0); i++)
    {
        sumOfNumbersInColumn += array[i, j];
    }
    double arithmeticalMean = Math.Round((sumOfNumbersInColumn / numberOfRows), 1);
    return arithmeticalMean;
}


void FindArithmeticalMean(int[,] array, uint numberOfColumns, uint numberOfRows)
{
    Console.WriteLine();
    int j = 0;
    while (j < numberOfColumns)
    {
        double sumOfNumbersInColumn = 0;
        for (int i = 0; i < array.GetLength(0); i++)
        {
            sumOfNumbersInColumn += array[i, j];
        }
        double arithmeticalMean = Math.Round((sumOfNumbersInColumn / numberOfRows), 1);
        Console.WriteLine($"Arithmetical mean of numbers in the {j + 1} column is {arithmeticalMean}");
        j++;
    }
    Console.WriteLine();
}


void Print2DArray(int[,] array)
{
    Console.WriteLine();
    Console.WriteLine("Your array filled with pseudo-random numbers from 1 to 9: ");
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i, j]} ");
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}


void Fill2DArray(int[,] array)
{
    Random random = new Random();
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = random.Next(1, 10);
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