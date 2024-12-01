using DynamicArray;
namespace UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DynamicArray<int> array = new(3)
            {
                1,
                2
            };
            Console.WriteLine(array);
            array.Add(3);
            Console.WriteLine(array);
            array.Add(2);
            Console.WriteLine(array);
            array.Add(3);
            Console.WriteLine(array);
            array.RemoveAt(0);
            Console.WriteLine(array);
            array.RemoveAt(0);
            Console.WriteLine(array);
            array.Add(2);
            Console.WriteLine(array);
            array.Insert(2, 100);
            Console.WriteLine(array);
            array.Insert(2, 1000);
            Console.WriteLine(array);

        }
    }
}