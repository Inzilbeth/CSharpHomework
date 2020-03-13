using Task1.Operators;

/// <summary>
/// Global namespace.
/// </summary>
namespace Task1
{
    /// <summary>
    /// Class with the implementation of the tree.
    /// </summary>
    public sealed class Tree
    {
        private TreeNode tree;

        /// <summary>
        /// Initializes a new instance of the <see cref="Tree"/> class.
        /// </summary>
        /// <param name="fileName">Name of the file with an expression.</param>
        /// <exception cref="System.ArgumentException">Thrown when file has inappropriate name.</exception>
        public Tree(string fileName)
        {
            var parser = new FileParser();
            tree = parser.Parse(fileName);
        }

        /// <summary>
        /// Evaluates the result of expression in tree.
        /// </summary>
        /// <returns>Expression result.</returns>
        public int Evaluate()
        {
            return this.tree.Evaluate().GetNumber();
        }

        /// <summary>
        /// Class with implementation file parser.
        /// </summary>
        private class FileParser
        {
            /// <summary>
            /// Parse correct file function.
            /// </summary>
            /// <param name="fileName">File name.</param>
            /// <returns>First tree node.</returns>
            /// <exception cref="System.ArgumentException">Throwing when wrong file name.</exception>
            public TreeNode Parse(string fileName)
            {
                if (!System.IO.File.Exists(fileName))
                {
                    throw new System.ArgumentException("Wrong file name.");
                }

                using (System.IO.StreamReader reader = System.IO.File.OpenText(fileName))
                {
                    string fileString = reader.ReadToEnd();
                    return this.ParseNode(fileString.Split('(', ')', ' ', '\n', '\r'));
                }
            }

            private TreeNode ParseNode(string[] splited, int index = 0)
            {
                string current = splited[index];

                if (current.Length == 0)
                {
                    return this.ParseNode(splited, index + 1);
                }

                if (int.TryParse(current, out int number))
                {
                    return new Value(number);
                }
                else
                {
                    IOperand left = this.ParseNode(splited, index + 1);
                    IOperand right = this.ParseNode(splited, index + 2);
                    return current switch
                    {
                        "+" => new Addition(left, right),
                        "-" => new Substraction(left, right),
                        "*" => new Multiplication(left, right),
                        "/" => new Division(left, right),
                        _ => throw new System.ArgumentException("Wrong file (file name)."),
                    };
                }
            }
        }
    }
}