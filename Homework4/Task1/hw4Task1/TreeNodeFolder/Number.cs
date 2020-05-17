namespace Task1
{
    /// <summary>
    /// Implementation of Number class, that represents a number
    /// in the expression.
    /// </summary>
    public class Number : TreeNode
    {
        /// <summary>
        /// Value of a number.
        /// </summary>
        private int number;

        /// <summary>
        /// Initializes a new instance of the <see cref="Number"/> class.
        /// </summary>
        /// <param name="number">Number value.</param>
        public Number(int number)
        {
            this.number = number;
        }

        /// <summary>
        /// Gets number function.
        /// </summary>
        /// <returns>Number.</returns>
        public int GetNumber()
            => number;

        /// <summary>
        /// Calculate result of the tree.
        /// </summary>
        /// <returns>Result value.</returns>
        public override Number Calculate()
            => this;

        /// <summary>
        /// Print number function.
        /// </summary>
        public override void Print()
            => System.Console.Write(number);
    }
}
