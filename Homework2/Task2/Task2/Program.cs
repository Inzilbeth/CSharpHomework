using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            var hashTable = new HashTable();
            int command = -1;
            while (command != 0)
            {
                Console.WriteLine("Select the operation: ");
                Console.WriteLine("0: Exit");
                Console.WriteLine("1: AddValue");
                Console.WriteLine("2: DeleteValue ");
                Console.WriteLine("3: HashContains");
                command = Convert.ToInt32(Console.ReadLine());
                switch (command)
                {
                    case 1:
                        {
                            Console.WriteLine("Enter the string to add: ");
                            hashTable.AddData(Console.ReadLine());
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Enter the string to remove: ");
                            hashTable.DeleteData(Console.ReadLine());
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Enter the string to check: ");
                            Console.WriteLine(hashTable.HashContains(Console.ReadLine()));
                            break;
                        }
                    default:
                        {
                            command = 0;
                            break;
                        }
                }
            }
        }
    }
}