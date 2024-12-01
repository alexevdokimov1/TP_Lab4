using DynamicArray;
namespace UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DynamicArray<int> array = new DynamicArray<int>(3);
            array.Add(1);
            array.Add(2);
            Console.WriteLine(array);
            array.Add(3);
            Console.WriteLine(array);
            array.Add(2);
            Console.WriteLine(array);
            array.Add(3);
            Console.WriteLine(array);
        }
    }
}