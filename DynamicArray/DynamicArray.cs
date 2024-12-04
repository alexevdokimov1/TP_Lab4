using System.Collections;
using System.Text;

namespace DynamicArray
{
    public class DynamicArray<T> : IEnumerable<T>
    {
        private T[] array;

        public int Count { get; private set; }

        public int Capacity { get => array.Length; }

        public DynamicArray(int capacity = 20)
        {
            this.array = new T[capacity];
            this.Count = 0;
        }

        public void Add(T item)
        {
            if (Count == Capacity)
                IncreaseCapacity(1);
            array[Count++] = item;
        }

        public void Add(IEnumerable<T> elements)
        {
            foreach (var element in elements)
            {
                Add(element);
            }
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || index > Count)
            {
                throw new ArgumentOutOfRangeException($"Индекс {index} вне массива");
            }

            if (Count == Capacity)
                IncreaseCapacity(1);

            for (int i = Count; i > index; i--)
            {
                array[i] = array[i - 1];
            }

            array[index] = item;
            Count++;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException($"Индекс {index} вне массива");
            }

            for (int i = index; i < Count - 1; i++)
            {
                array[i] = array[i + 1];
            }
            array[--Count] = default;
        }

        public void IncreaseCapacity(int n = 1)
        {
            if (n < 0) throw new ArgumentException("Увеличение вместимости не должно приводить к уменьшению массива");
            T[] newArray = new T[Capacity + n];
            for (int i = 0; i < Count; i++)
            {
                newArray[i] = array[i];
            }
            array = newArray;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new();
            for (int i = 0; i < Count; i++)
                stringBuilder.Append(array[i] + "\t");
            stringBuilder.Append('\n');
            stringBuilder.Append("Элементов " + Count);
            stringBuilder.Append('\n');
            stringBuilder.Append("Вместимость " + Capacity);
            return stringBuilder.ToString();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return array[i];
            }
            yield break;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new CustomEnumerator<T>(array);
        }

        public DynamicArray<T> GetRange(int index, int count)
        {
            DynamicArray<T> finalArray = new DynamicArray<T>();
            if (count < 0) throw new ArgumentException("Отрицательное количество элементов");
            if (index < 0 || index >= Count) throw new ArgumentException("Индекс вне границ массива");
            if (index + count > Count) throw new ArgumentException("Индекс + количество элементов выходят за пределы массива");
            for(int i = 0; i<count; i++)
            {
                finalArray.Add(array[index+i]);
            }
            return finalArray;
        }
    }
}