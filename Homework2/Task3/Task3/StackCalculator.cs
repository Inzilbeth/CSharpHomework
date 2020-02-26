using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{

    public static class StackCalculator
    {
        public enum StorageType { Array, List };

        private static IStack<float> stack;

        public static (bool, float) Calculate(string Expression, StorageType choice)
        {
            if (choice == StorageType.List)
            {
                stack = new StackAsList<float>();
            }
            else
            {
                stack = new StackAsArray<float>();
            }

            var number = string.Empty;

            foreach (char symbol in Expression)
            {
                if (char.IsDigit(symbol))
                {
                    number = string.Concat(number, char.ToString(symbol));
                    continue;
                }

                if (number.Length > 0)
                {
                    stack.Push(float.Parse(number));
                    number = string.Empty;
                    continue;
                }

                if (symbol == ' ')
                {
                    continue;
                }

                switch (symbol)
                {
                    case '+':
                    case '-':
                    case '*':
                    case '/':
                        {
                            if (stack.IsEmpty())
                            {
                                return (false, 0);
                            }

                            var topValue = stack.Pop();

                            if (stack.IsEmpty() || (symbol == '/' && topValue == 0))
                            {
                                Console.WriteLine("Division by zero occurred in the expression.");
                                return (false, 0);
                            }

                            stack.Push(topValue);
                            PerformOperation(symbol);
                            break;
                        }
                    default:
                        {
                            return (false, 0);
                        }
                }
            }

            if (stack.IsEmpty())
            {
                return (false, 0);
            }

            var result = stack.Pop();
            if (stack.IsEmpty())
            {
                return (true, result);
            }

            stack.Clear();
            return (false, 0);
        }

        private static void PerformOperation(char operation)
        {
            var secondOperand = stack.Pop();
            var firstOperand = stack.Pop();
            if (operation == '+')
            {
                stack.Push(firstOperand + secondOperand);
            }
            else if (operation == '-')
            {
                stack.Push(firstOperand - secondOperand);
            }
            else if (operation == '/')
            {
                stack.Push(firstOperand / secondOperand);
            }
            else
            {
                stack.Push(firstOperand * secondOperand);
            }
        }
    }
}