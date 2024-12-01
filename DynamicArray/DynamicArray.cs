using System.Collections;
using System.Text;

namespace DynamicArray
{
    public class DynamicArray<T> : IEnumerable<T>
    {
        private int count;
        private int capacity;
        private T[] array;

        public int Count => count;

        public int Capacity => capacity;

        public DynamicArray(int capacity = 20)
        {
            this.capacity = capacity;
            this.array = new T[capacity];
            this.count = 0;
        }

        public void Add(T item)
        {
            if (count == capacity)
                IncreaseCapacity(1);
            array[count++] = item;
        }

        public void Add(IEnumerable<T> elements)
        {
            foreach (var element in elements)
            {
                Add(element);
            }
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new ArgumentOutOfRangeException($"Индекс {index} вне массива");
            }

            for (int i = index; i < count - 1; i++)
            {
                array[i] = array[i + 1];
            }
            array[--count] = default;
        }

        public void IncreaseCapacity(int n)
        {
            capacity = capacity + n;
            T[] newArray = new T[capacity];
            array.CopyTo(newArray, 0);
            array = newArray;
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || index > count)
            {
                throw new ArgumentOutOfRangeException($"Индекс {index} вне массива");
            }

            if (count == capacity)
                IncreaseCapacity(1);

            // Shift elements to the right
            for (int i = count; i > index; i--)
            {
                array[i] = array[i - 1];
            }

            array[index] = item;
            count++;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new();
            for (int i = 0; i < count; i++)
                stringBuilder.Append(array[i] + "\t");
            stringBuilder.Append('\n');
            stringBuilder.Append("Count " + count);
            stringBuilder.Append('\n');
            stringBuilder.Append("Capacity " + capacity);
            return stringBuilder.ToString();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                yield return array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new CustomEnumerator<T>(array);
        }

    }
}