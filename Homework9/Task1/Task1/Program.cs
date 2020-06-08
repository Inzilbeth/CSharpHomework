namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            var intSet = new Set<int>(new CustomComparer()) { -10, 5, 19, 0 };
            var array = new int[4];
            intSet.CopyTo(array, 0);
        }
    }
}
