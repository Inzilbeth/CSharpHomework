namespace Task1
{
    /// <summary>
    /// Multiplication class.
    /// </summary>
    public sealed class Multiplication : Operation
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Multiplication"/> class.
        /// </summary>
        /// <param name="left">Left node.</param>
        /// <param name="right">Right node.</param>
        public Multiplication(INode left, INode right)
            : base(left, right)
        {
        }

        /// <summary>
        /// Returns a multiplication sign.
        /// </summary>
        protected override char GetSign()
            => '*';

        /// <summary>
        /// Calculates expression.
        /// </summary>
        /// <param name="left">Left number.</param>
        /// <param name="right">Right number.</param>
        /// <returns>Result.</returns>
        protected override Number Calculate(Number left, Number right)
        {
            return new Number(left.GetNumber() * right.GetNumber());
        }
    }
}
