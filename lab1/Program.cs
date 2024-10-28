using System;

namespace TaskManager
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Choose a task to execute (1-4): ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                RunTask1();
            }
            else if (choice == "2")
            {
                Console.WriteLine("Task 2 is not yet implemented.");
            }
            else if (choice == "3")
            {
                Console.WriteLine("Task 3 is not yet implemented.");
            }
            else if (choice == "4")
            {
                Console.WriteLine("Task 4 is not yet implemented.");
            }
            else
            {
                Console.WriteLine("Invalid choice. Please enter a number from 1 to 4.");
            }
        }

        static void RunTask1()
        {
            Display display1 = new Display(1920, 1080, 92.0f, "Lenovo");
            Display display2 = new Display(2560, 1440, 109.0f, "LG");
            Display display3 = new Display(1920, 1080, 100.0f, "Электроника");

            Console.WriteLine("Comparing Display Lenovo with Display LG:");
            display1.CompareWithMonitor(display2);
            
            Console.WriteLine();

            Console.WriteLine("Comparing Display 2 with Display 3:");
            display2.CompareWithMonitor(display3);

            Console.WriteLine();

            Console.WriteLine("Comparing Display 1 with Display 3:");
            display1.CompareWithMonitor(display3);
        }
    }
}
