/// <summary>
/// Gloobal namespace.
/// </summary>
namespace hw4Task1
{
    public sealed class Substraction : Operation
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Substraction"/> class.
        /// </summary>
        /// <param name="left">Left node.</param>
        /// <param name="right">Right node.</param>
        public Substraction(INode left, INode right)
            : base(left, right)
        {
        }

        /// <summary>
        /// Prints an operation sign.
        /// </summary>
        protected override void PrintSign()
        {
            System.Console.Write("-");
        }

        /// <summary>
        /// Calculates expression.
        /// </summary>
        /// <param name="left">Left number.</param>
        /// <param name="right">Right number.</param>
        /// <returns>Result.</returns>
        protected override Number Calculate(Number left, Number right)
        {
            return new Number(left.GetNumber() - right.GetNumber());
        }
    }
}
