using DynamicArray;
namespace UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
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
                array.Add(15);
                Console.WriteLine(array);
                array.Insert(2, 100);
                Console.WriteLine(array);
                array.RemoveAt(2);
                Console.WriteLine(array);
                array.Insert(2, 1000);
                Console.WriteLine("Массив");
                foreach (var elem in array)
                {
                    Console.Write(elem + "\t");
                }
                Console.WriteLine();
                //array.RemoveAt(15);

                foreach(var elem in array.GetRange(2, 4))
                {
                    
                    Console.Write(elem + "\t");
                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }
    }
}