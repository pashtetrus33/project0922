/*Написать программу, которая из имеющегося массива строк формирует массив из строк, длина которых меньше или равна 3 символа. 
Первоначальный массив можно ввести с клавиатуры, либо задать на старте выполнения алгоритма*/


//флаг для выхода из основного цикла программы
bool repeat = true;

// основной цикл программы
while (repeat)
{
    Console.Clear();
    Console.WriteLine("Программа из имеющегося массива строк формирует массив из строк, длина которых меньше или равна 3 символа");
    Console.WriteLine();
    Console.Write("Введите размер строкового массива (целое число больше нуля): ");
    int size = PositiveInt();
    int choice = ChooseArrayFilling();
    string[] array = new string[size];
    if (choice == 1)
    {
        Console.WriteLine("Поздравляем! Вы выбрали ручное заполнение массива.");
        array = ManualFilling(size);
    }
    else
    {
        Console.WriteLine("Поздравляем! Вы выбрали автоматическое заполнение массива.");
        Console.Write("Введите максимальное количество символов в элементе: ");
        int elementLength = PositiveInt();
        array = AutoFilling(size, elementLength);
    }
    string[] resultArray = CreateResultArray(array);
    Console.WriteLine("*******************************************************************************************************************");
    Console.WriteLine($"Исходный строковый массив из {size} элементов: \"{String.Join("\" \"", array)}\"");
    Console.WriteLine("*******************************************************************************************************************");
    Console.WriteLine($"Результирующий строковый массив из {resultArray.Length} элементов: \"{String.Join("\" \"", resultArray)}\"");
    Console.WriteLine("*******************************************************************************************************************");

    Console.WriteLine("Для продолжения нажмите 'ENTER', для выхода 'Q' затем 'ENTER'");
    string? decision = Console.ReadLine();
    if ((decision?.ToLower() == "q") || (decision?.ToLower() == "й"))
        repeat = false;
}
//Метод проверки на ввод целого числа больше нуля
int PositiveInt()
{
    int positiveInt = 0;

    while (positiveInt <= 0)
    {
        //проверка на ввод целого числа
        while (!int.TryParse(Console.ReadLine(), out positiveInt))
            Console.Write("Ошибка ввода! Введите целое число больше нуля!: ");
        if (positiveInt <= 0)
            Console.Write("Ошибка ввода! Введите целое число больше нуля!: ");
    }
    return positiveInt;
}
// Метод выбора способа заполнения массива
int ChooseArrayFilling()
{
    int choice = 0;
    //проверка на ввод целого числа больше нуля
    while ((choice != 1) && (choice != 2))
    {
        Console.Write("Введите 1 для ручного заполнения строкового массива 2 - для автоматического: ");
        //проверка на ввод целого числа
        while (!int.TryParse(Console.ReadLine(), out choice))
            Console.Write("Ошибка ввода! Введите 1 (ручное) 2 автоматическое: ");
    }
    return choice;
}
// Метод ручного заполнения массива
string[] ManualFilling(int size)
{
    int i = 0;
    string[] array = new string[size];
    while (i < size)
    {
        Console.Write($"Введите {i + 1} элемент строкового массива: ");
        array[i] = Console.ReadLine();
        i++;
    }
    return array;
}
// Метод автоматического заполнения массива
string[] AutoFilling(int size, int elementLength)
{
    int next = 0;
    int length = 0;
    char symbol;
    string[] array = new string[size];
    for (int i = 0; i < size; i++)
    {
        //Определение длины i-го элемента рандомного массива
        length = new Random().Next(1, elementLength + 1);
        for (int j = 0; j < length; j++)
        {
            //Определение символа для i-uj элемента рандомного массива
            next = new Random().Next(32, 128);
            symbol = (char)next;
            array[i] += symbol;
        }
    }
    return array;
}
// Метод создания результирющего массива
string[] CreateResultArray(string[] arr)
{
    string[] tempArray = new string[arr.Length];
    int j = 0;
    for (int i = 0; i < arr.Length; i++)
    {
        if (arr[i].Length <= 3)
        {
            tempArray[j] = arr[i];
            j++;
        }
    }
    string[] resultArray = new string[j];
    for (int i = 0; i < j; i++)
        resultArray[i] = tempArray[i];
    return resultArray;
}