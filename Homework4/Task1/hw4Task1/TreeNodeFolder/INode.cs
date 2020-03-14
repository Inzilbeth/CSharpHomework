/// <summary>
/// Gloobal namespace.
/// </summary>
namespace hw4Task1
{
    /// <summary>
    /// Interface for tree nodes.
    /// </summary>
    public interface INode
    {
        /// <summary>
        /// Gets Value.
        /// </summary>
        /// <returns>Number.</returns>
        public Number GetValue();

        /// <summary>
        /// Print function.
        /// </summary>
        public void Print();
    }
}
