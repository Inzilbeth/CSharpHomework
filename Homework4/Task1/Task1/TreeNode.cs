﻿/// <summary>
/// Global namespace.
/// </summary>
namespace Task1
{
    /// <summary>
    /// Abstract class of node of tree.
    /// </summary>
    public abstract class TreeNode : IOperand
    {
        /// <summary>
        /// Evaluate result of tree.
        /// </summary>
        /// <returns>Result value.</returns>
        public abstract Value Evaluate();

        /// <summary>
        /// Get operand value.
        /// </summary>
        /// <returns>Operand value.</returns>
        public Value GetValue()
        {
            return this.Evaluate();
        }

        /// <summary>
        /// Print tree node function.
        /// </summary>
        public abstract void Print();
    }
}
