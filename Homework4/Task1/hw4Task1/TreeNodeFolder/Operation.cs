namespace Task1
{
    /// <summary>
    /// Operation class.
    /// </summary>
    public abstract class Operation : TreeNode
    {
        /// <summary>
        /// Left node.
        /// </summary>
        private INode left;

        /// <summary>
        /// Right node.
        /// </summary>
        private INode right;

        /// <summary>
        /// Initializes a new instance of the <see cref="Operation"/> class.
        /// </summary>
        /// <param name="left">Left node.</param>
        /// <param name="right">Right node.</param>
        public Operation(INode left, INode right)
        {
            this.left = left;
            this.right = right;
        }

        /// <summary>
        /// Calculates the expression.
        /// </summary>
        /// <returns>Result.</returns>
        public override Number Calculate()
            => Calculate(left.GetValue(), right.GetValue());

        /// <summary>
        /// Prints an expression.
        /// </summary>
        public override void Print()
        {
            System.Console.Write("( ");
            System.Console.Write(GetSign());
            System.Console.Write(" ");
            left.Print();
            System.Console.Write(" ");
            right.Print();
            System.Console.Write(" )");
        }

        /// <summary>
        /// Prints the right sign.
        /// </summary>
        protected abstract char GetSign();

        /// <summary>
        /// Calculates the expression.
        /// </summary>
        /// <param name="left">Left node.</param>
        /// <param name="right">Right node.</param>
        /// <returns>Result.</returns>
        protected abstract Number Calculate(Number left, Number right);
    }
}
