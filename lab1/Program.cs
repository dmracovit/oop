using System;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Please specify a task number (1, 2, etc.).");
            return;
        }

        switch (args[0])
        {
            case "1":
                RunTask1();
                break;
            case "2":
                RunTask2(args); 
                break;

            case "3":
                RunTask3();
                break;

            case "4":
                Console.WriteLine("Tasl is not done yes");
                break;

            default:
                Console.WriteLine("Invalid task number.");
                break;
        }
    }

        static void RunTask1()
        {
        Display display1 = new Display(1920, 1080, 96.0f, "Lenovo");
        Display display2 = new Display(2560, 1440, 109.0f, "LG");
        Display display3 = new Display(3840, 2160, 163.0f, "Электроника");

        Console.WriteLine("Comparing Display Lenovo with Display LG:");
            display1.CompareWithMonitor(display2);

            Console.WriteLine();

            Console.WriteLine("Comparing Display LG with Display Электроника:");
            display2.CompareWithMonitor(display3);

            Console.WriteLine();

            Console.WriteLine("Comparing Display Lenovo with Display Электроника:");
            display1.CompareWithMonitor(display3);
        }

        static void RunTask2(string[] args)
        {
        if (args.Length < 2)
        {
            Console.WriteLine("Please provide the path to the .txt file for Task 2.");
            return;
        }

        string filePath = args[1];
        FileReader fileReader = new FileReader();
        string fileContent = fileReader.ReadFileIntoString(filePath);

        if (string.IsNullOrEmpty(fileContent))
        {
            Console.WriteLine("The file is empty or could not be read.");
            return;
        }

        TextData textData = new TextData(fileContent, filePath);

        Console.WriteLine("File Name: " + textData.GetFilename());
        Console.WriteLine("Text Content: " + textData.GetText());
        Console.WriteLine("Number of Vowels: " + textData.GetNumberOfVowels());
        Console.WriteLine("Number of Consonants: " + textData.GetNumberOfConsonants());
        Console.WriteLine("Number of Letters: " + textData.GetNumberOfLetters());
        Console.WriteLine("Number of Sentences: " + textData.GetNumberOfSentences());
        Console.WriteLine("Longest Word: " + textData.GetLongestWord());
    }

    static void RunTask3()
    {
        Assistant assistant = new Assistant("Boris");

        Display display1 = new Display(1920, 1080, 92.0f, "Model A");
        Display display2 = new Display(2560, 1440, 109.0f, "Model B");
        Display display3 = new Display(3840, 2160, 110.0f, "Model C");

        assistant.AssignDisplay(display1);
        assistant.AssignDisplay(display2);
        assistant.AssignDisplay(display3);

        assistant.Assist();

        Display boughtDisplay = assistant.BuyBestDisplay();
        if (boughtDisplay != null)
        {
            Console.WriteLine($"Successfully bought: {boughtDisplay.GetModel()}");
        }
        else
        {
            Console.WriteLine("Display was not found.");
        }
    }
}
