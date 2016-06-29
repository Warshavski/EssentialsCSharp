using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssentialsCSharp.DataStructures.ArrayBased
{
    public class Queue<TValue>
    {
        private readonly TValue[] _innerArray;

        private int _frontItemIndex;
        private int _rearItemIndex;
        private int _maxSize;

        public int Size
        {
            get 
            {
                if (_rearItemIndex >= _frontItemIndex)
                {
                    return _rearItemIndex - _frontItemIndex + 1;
                }
                else
                {
                    return (_maxSize - _frontItemIndex) + (_rearItemIndex + 1);
                }
            }
        }

        public bool IsEmpty
        {
            get 
            {
                return (_rearItemIndex + 1 == _frontItemIndex ||
                    (_frontItemIndex + _maxSize - 1 == _rearItemIndex));
            }
        }

        public bool IsFull
        {
            get 
            {
                return (_rearItemIndex + 2 == _frontItemIndex ||
                    (_frontItemIndex + _maxSize - 2 == _rearItemIndex));
            }
        }

        public Queue(int queueSize)
        {
            _maxSize = queueSize + 1;
            _innerArray = new TValue[_maxSize];
            _frontItemIndex = 0;
            _rearItemIndex = -1;
        }

        public void Insert(TValue item)
        {
            if (_rearItemIndex == _maxSize - 1)
            {
                _rearItemIndex = -1;
                _innerArray[++_rearItemIndex] = item;
            }
        }

        public TValue Remove()
        {
            var value = _innerArray[_frontItemIndex++];
            if (_frontItemIndex == _maxSize)
            {
                _frontItemIndex = 0;
            }

            return value;
        }

        public TValue Peek()
        {
            return _innerArray[_frontItemIndex];
        }
    }
}
