﻿using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Operators namespace.
/// </summary>
namespace Task1.Operators
{
    /// <summary>
    /// Class with implementation of division operator.
    /// </summary>
    public sealed class Division : Operator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Division"/> class.
        /// </summary>
        /// <param name="left">Left operand.</param>
        /// <param name="right">Right operand.</param>
        public Division(IOperand left, IOperand right)
            : base(left, right)
        {
        }

        /// <summary>
        /// Print current operator function.
        /// </summary>
        protected override void PrintSign()
        {
            System.Console.Write("/");
        }

        /// <summary>
        /// Evaluate result of operation.
        /// </summary>
        /// <param name="left">Left operand.</param>
        /// <param name="right">Right operand.</param>
        /// <returns>Operation result.</returns>
        protected override Value Evaluate(Value left, Value right)
        {
            return new Value(left.GetNumber() / right.GetNumber());
        }
    }
}