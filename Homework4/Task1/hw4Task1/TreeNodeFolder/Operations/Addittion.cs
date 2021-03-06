﻿namespace Task1
{
    /// <summary>
    /// Addition class.
    /// </summary>
    public sealed class Addition : Operation
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Addition"/> class.
        /// </summary>
        /// <param name="left">Left node.</param>
        /// <param name="right">Right node.</param>
        public Addition(INode left, INode right)
            : base(left, right)
        {
        }

        /// <summary>
        /// Returns an addittion sign.
        /// </summary>
        protected override char GetSign()
            => '+';

        /// <summary>
        /// Calculates expression.
        /// </summary>
        /// <param name="left">Left number.</param>
        /// <param name="right">Right number.</param>
        /// <returns>Result.</returns>
        protected override Number Calculate(Number left, Number right)
        {
            return new Number(left.GetNumber() + right.GetNumber());
        }
    }
}
