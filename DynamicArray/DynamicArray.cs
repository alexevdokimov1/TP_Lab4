using System.Text;

namespace DynamicArray
{
    public class DynamicArray<T>
    {
        private int count = 0;
        private int capacity;
        private T[] array;

        public int Count {
            get { return count; }
        }

        public int Capacity
        {
            get { return capacity; }
        }

        public DynamicArray (int capacity=20) {
            this.capacity = capacity;
            this.array = new T[capacity];
            this.count = 0;
        }

        public void Add(T item) {
            if (capacity < count+1)
            {
                T[] newArray = new T[count+1];
                array.CopyTo(newArray, 0);
                array = newArray;
                array[count] = item;
                count++;
                capacity = count;
            }
            else
            {
                array[count] = item;
                count++;
            }
        }

        public void Add(IEnumerable<T> elements)
        {
            throw new NotImplementedException();
        }

        public void Insert(T element, int position)
        {
            if (position > count) { 
                count = position+1;
                capacity = count;
                T[] newArray = new T[count];
                array.CopyTo(newArray, 0);
                array = newArray;
                array[count] = element;
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            for( int i = 0; i<count; i++)
            {
                stringBuilder.Append(array[i] + "\t");
            }
            stringBuilder.Append('\n');
            stringBuilder.Append("Count " + count);
            stringBuilder.Append('\n');
            stringBuilder.Append("Capacity " + capacity);
            return stringBuilder.ToString();
        }
    }
}