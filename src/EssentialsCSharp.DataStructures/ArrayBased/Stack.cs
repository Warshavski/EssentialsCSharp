namespace EssentialsCSharp.DataStructures.ArrayBased
{
    public class Stack<TValue>
    {
        private readonly TValue[] _innerArray;

        private int _currentItemIndex;

        public int Size
        {
            get { return _innerArray.Length; }
        }

        public bool IsEmpty 
        { 
            get { return _currentItemIndex == -1; } 
        }

        public bool IsFull
        {
            get { return _currentItemIndex == Size; }
        }

        public Stack(int stackSize)
        {
            _innerArray = new TValue[stackSize];
            _currentItemIndex = -1;
        }

        public void Push(TValue item)
        {
            ++_currentItemIndex;
            _innerArray[_currentItemIndex] = item;
        }

        public TValue Pop()
        {
            var value = _innerArray[_currentItemIndex];
            --_currentItemIndex;

            return value;
        }

        public TValue Peek()
        {
            return _innerArray[_currentItemIndex];
        }
    }
}
