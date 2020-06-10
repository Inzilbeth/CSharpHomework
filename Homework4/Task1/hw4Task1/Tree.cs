using System.IO;

namespace Task1
{
    /// <summary>
    /// Class with an implementation of the tree.
    /// </summary>
    public sealed class Tree
    {
        private TreeNode tree;

        /// <summary>
        /// Prints the tree.
        /// </summary>
        public void Print()
            => tree.Print();

        /// <summary>
        /// Initializes a new instance of the <see cref="Tree"/> class.
        /// </summary>
        /// <param name="fileName">Name of the file with correct string.</param>
        /// <exception cref="System.ArgumentException">Thrown when file has wrong name.</exception>
        public Tree(StreamReader stream)
        {
            var parser = new FileParser();
            tree = parser.Parse(stream);
        }

        /// <summary>
        /// Calculates the result of the expression inside the tree.
        /// </summary>
        /// <returns>Expression's result.</returns>
        public int Calculate()
            => tree.Calculate().GetNumber();

        /// <summary>
        /// Class with an implementation of file parser.
        /// </summary>
        private class FileParser
        {
            /// <summary>
            /// Parses correct string from a file.
            /// </summary>
            /// <param name="fileName">File name.</param>
            /// <returns>First tree node.</returns>
            public TreeNode Parse(StreamReader stream)
            {
                string fileString = stream.ReadToEnd();
                char[] separator = { '(', ')', ' ', '\n', '\r' };
                return ParseNode(fileString.Split(separator));
            }

            private int index = 0;

            /// <summary>
            /// Parses the node from the input string array,
            /// returning the correct type of node.
            /// </summary>
            /// <param name="splitString">Array of splitted strings.</param>
            /// <returns>Correct node type.</returns>
            private TreeNode ParseNode(string[] splitString)
            {
                if (index > splitString.Length - 1)
                {
                    throw new System.ArgumentException("Wrong string inside a file.");
                }
                string current = splitString[index];

                if (current.Length == 0)
                {
                    index++;
                    if (index > splitString.Length)
                    {
                        throw new System.ArgumentException("Wrong string inside a file.");
                    }
                    return ParseNode(splitString);
                }

                if (int.TryParse(current, out int number))
                {
                    return new Number(number);
                }
                else
                {
                    index++;
                    INode left = ParseNode(splitString);
                    index++;
                    INode right = ParseNode(splitString);
                    return current switch
                    {
                        "+" => new Addition(left, right),
                        "-" => new Substraction(left, right),
                        "*" => new Multiplication(left, right),
                        "/" => new Division(left, right),
                        _ => throw new System.ArgumentException("Wrong string inside a file."),
                    };
                }
            }
        }
    }
}