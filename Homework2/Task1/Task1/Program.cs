using System;


namespace Task1
{
    public class Program
    {
        static void Main(string[] args)
        {
            var linkedList = new LinkedList<int>();
            int command = -1;
            while (command != 0)
            {
                Console.WriteLine("Select the operation: ");
                Console.WriteLine("0: Exit");
                Console.WriteLine("1: AddByNumber");
                Console.WriteLine("2: RemoveByNumber ");
                Console.WriteLine("3: Size");
                Console.WriteLine("4: IsEmpty? ");
                Console.WriteLine("5: GetValue ");
                Console.WriteLine("6: SetValue ");
                Console.WriteLine("7: Print ");
                command = Convert.ToInt32(Console.ReadLine());
                switch (command)
                {
                    case 1:
                        {
                            Console.WriteLine("Enter the number, then value line by line:");
                            int number = Convert.ToInt32(Console.ReadLine());
                            int value = Convert.ToInt32(Console.ReadLine());
                            linkedList.AddByNumber(number, value);
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Enter the number: ");
                            int number = Convert.ToInt32(Console.ReadLine());
                            linkedList.RemoveByNumber(number);
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine(linkedList.Count);
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine(linkedList.IsEmpty);
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("Enter the number: ");
                            int number = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine(linkedList.GetValue(number));
                            break;
                        }
                    case 6:
                        {
                            Console.WriteLine("Enter the number, then value line by line:");
                            int number = Convert.ToInt32(Console.ReadLine());
                            int value = Convert.ToInt32(Console.ReadLine());
                            linkedList.SetValue(number, value);
                            break;
                        }
                    case 7:
                        {
                            Console.WriteLine("Your list is: ");
                            foreach (var item in linkedList)
                            {
                                Console.WriteLine(item);
                            }
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
