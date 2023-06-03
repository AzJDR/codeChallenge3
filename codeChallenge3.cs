using System;

class Program
{
    static void Main()
    {
        Console.Clear();
        int[] grades = new int[8];
        char choice;
        char returnC = 'Y'; // Initialize returnCh with a default value

        Random random = new Random();
        for (int i = 0; i < 8; i++) 
            grades[i] = GenerateNumbers(50, 100, random);

        while (returnC == 'Y')
        {
            DisplayGrades(grades);
            choice = Operations();
            switch (choice)
            {
                case 'A':
                    do
                    {                        
                        Console.WriteLine("\nA. Search for Specific Grade");
                        SearchGrade(grades);
                        returnC = Ask();
                        Console.Clear();
                        DisplayGrades(grades);
                        Console.WriteLine();
                    } while (returnC == 'N');
                    break;
                case 'B':
                    do
                    {
                        Console.WriteLine("\nB. Sort Grades");
                        SortingOptions(grades);
                        returnC = Ask();
                        Console.Clear();
                        DisplayGrades(grades);
                        Console.WriteLine();
                    } while (returnC == 'N');
                    break;
                case 'C':
                    do
                    {
                        Console.WriteLine("\nC. Compute the Average Grade");
                        ComputeAverage(grades);
                        returnC = Ask();
                        Console.Clear();
                        DisplayGrades(grades);
                        Console.WriteLine();
                    } while (returnC == 'N');
                    break;
                case 'D':
                    do
                    {
                        Console.WriteLine("\nD. Count Number of PASS Grades");
                        CountPass(grades);
                        returnC = Ask();
                        Console.Clear();
                        DisplayGrades(grades);
                        Console.WriteLine();
                    } while (returnC == 'N');
                    break;
                case 'E':
                    do
                    {
                        Console.WriteLine("\nE. Count Number of FAIL Grades");
                        CountFail(grades);
                        returnC = Ask();
                        Console.Clear();
                        DisplayGrades(grades);
                        Console.WriteLine();
                    } while (returnC == 'N');
                    break;
                case 'F':
                    Console.Clear();
                    ExitProgram();
                    return;
                default:
                    break;
            }
            Console.Clear();
        }
    }

    static char Operations()
    {
        char choice;

        while (true)
        {
            Console.WriteLine("\n\nOperations:");
            Console.WriteLine("A. Search for Specific Grade");
            Console.WriteLine("B. Sort Grades");
            Console.WriteLine("C. Compute the Average Grade");
            Console.WriteLine("D. Count Number of PASS Grades");
            Console.WriteLine("E. Count Number of FAIL Grades");
            Console.WriteLine("F. Exit");
            Console.Write("Enter the letter that corresponds to the operation: ");
            choice = Char.ToUpper(Console.ReadKey().KeyChar);
            Console.WriteLine();
            if (choice == 'A' || choice == 'B' || choice == 'C' || choice == 'D' || choice == 'E' || choice == 'F')
                break;
        }
        return choice;
    }

    static void DisplayGrades(int[] grades)
    {
        Console.WriteLine("List of Grades:");
        foreach (int grade in grades)
            Console.Write($"{grade}\t");
    }

    static int GenerateNumbers(int min, int max, Random random)
    {
        return random.Next(min, max + 1);
    }

    static void SearchGrade(int[] grades)
    {
        int grade, count = 0;

        Console.Write("\nEnter grade to search: ");
        if (int.TryParse(Console.ReadLine(), out grade))
        {
            foreach (int g in grades)
            {
                if (g == grade)
                    count++;
            }

            if (count > 0)
                Console.WriteLine($"Result: {count} occurrence(s)");
            else
                Console.WriteLine("Result: Not found!");
        }
        else
        {
            Console.WriteLine("Invalid input!");
        }
    }

    static void SortingOptions(int[] grades)
    {
        int[] tempGrades = new int[8];
        char c;

        while (true)
        {
            Console.WriteLine("\nSorting Operations:");
            Console.WriteLine("[1] Ascending");
            Console.WriteLine("[2] Descending");
            Console.Write("Enter operation: ");
            c = Console.ReadKey().KeyChar;
            c = char.ToUpper(c);

            if (c == '1' || c == '2')
                break;
        }

        Array.Copy(grades, tempGrades, grades.Length);

        switch (c)
        {
            case '1':
                Console.WriteLine("\n\nSort in Ascending Order:");
                Array.Sort(tempGrades);
                foreach (int grade in tempGrades) Console.Write($"{grade}\t");
                break;
            case '2':
                Console.WriteLine("\n\nSort in Descending Order:");
                Array.Sort(tempGrades);
                Array.Reverse(tempGrades);
                foreach (int grade in tempGrades) Console.Write($"{grade}\t");
                break;
            default:
                break;
        }
        Console.WriteLine();
    }

    static void ComputeAverage(int[] grades)
    {
        int sum = 0;
        foreach (int grade in grades)
            sum += grade;

        int average = sum / grades.Length;
        Console.WriteLine($"\nAverage grade: {average}%");
    }

    static void CountPass(int[] grades)
    {
        int count = 0;

        foreach (int grade in grades)
        {
            if (grade >= 75 && grade <= 100)
                count++;
        }
        Console.WriteLine($"\nCount: {count}");
    }

    static void CountFail(int[] grades)
    {
        int count = 0;

        foreach (int grade in grades)
        {
            if (grade >= 50 && grade <= 74)
                count++;
        }
        Console.WriteLine($"\nCount: {count}");
    }

    static void ExitProgram()
    {
        char c;
        bool exit = false;
        bool isValid = false;
        while (!isValid)
        {
            Console.WriteLine("Thank you! Press E to exit...");
            c = char.ToUpper(Console.ReadKey().KeyChar);
            
            if (c == 'E')
            {
                exit = true;
                break;
            }
            else
            {
                Console.WriteLine("Invalid Input");                
            }
        }                         
    }

    static char Ask()
    {
        char c;

        while (true)
        {
            Console.Write("\nPress Y to return to Operations, press N to try again: ");
            c = char.ToUpper(Console.ReadKey().KeyChar);

            if (c == 'Y' || c == 'N')
                break;
        }
        return c;
    }
}
