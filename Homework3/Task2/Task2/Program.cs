using System;

namespace Task2
{
    class Program
    {
        public static IHash Input()
        {
            Console.WriteLine("Enter the preferrable hash method: 0 = MD5, 1 = Custom hash");
            int choice = Convert.ToInt32(Console.ReadLine());
            if (choice == 0)
            {
                var hash = new MD5();
                return hash;
            }
            else if (choice == 1)
            {
                var hash = new MyHash();
                return hash;
            }
            else
            {
                Console.WriteLine("Wrong input.");
                return default;
            }
        }

        static void Main(string[] args)
        {
            IHash hash;
            hash = Input();
            var hashTable = new HashTable(hash);
            int command = -1;
            while (command != 0)
            {
                Console.WriteLine("Select the operation: ");
                Console.WriteLine("0: Exit");
                Console.WriteLine("1: AddValue");
                Console.WriteLine("2: DeleteValue ");
                Console.WriteLine("3: HashContains");
                Console.WriteLine("4: SwitchHash");
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
                            Console.WriteLine(hashTable.DeleteData(Console.ReadLine()));
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Enter the string to check: ");
                            Console.WriteLine(hashTable.HashContains(Console.ReadLine()));
                            break;
                        }
                    case 4:
                        {
                            hash = Input();
                            hashTable.ChangeHashFunction(hash);
                            Console.WriteLine("Done!");
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