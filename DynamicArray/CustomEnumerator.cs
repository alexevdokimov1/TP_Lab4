using System.Collections;

namespace DynamicArray
{
    public class CustomEnumerator<T> : IEnumerator
    {
        private readonly T[] list;
        private int position;

        public CustomEnumerator(T[] list) => this.list = list;

        public T Current
        {
            get
            {
                if (position == -1 || position >= list.Length)
                    throw new ArgumentException();
                return list[position];
            }
        }

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (position < list.Length - 1)
            {
                position++;
                return true;
            }
            else
                return false;
        }

        public void Reset() => position = -1;
    }
}