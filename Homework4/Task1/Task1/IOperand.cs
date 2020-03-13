/// <summary>
/// Global namespace.
/// </summary>
namespace Task1
{
    /// <summary>
    /// Operand interface.
    /// </summary>
    public interface IOperand
    {
        /// <summary>
        /// Get operand value.
        /// </summary>
        /// <returns>Operand value.</returns>
        public Value GetValue();

        /// <summary>
        /// Print operand function.
        /// </summary>
        public void Print();
    }
}