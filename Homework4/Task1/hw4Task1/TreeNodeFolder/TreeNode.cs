namespace Task1
{
    /// <summary>
    /// Tree node class.
    /// </summary>
    public abstract class TreeNode : INode
    {
        /// <summary>
        /// Calculates an expression.
        /// </summary>
        /// <returns>Result.</returns>
        public abstract Number Calculate();

        /// <summary>
        /// Prints the node.
        /// </summary>
        public abstract void Print();

        /// <summary>
        /// Gets value of a node.
        /// </summary>
        /// <returns>Value.</returns>
        public Number GetValue()
            => Calculate();
    }
}
