using System.Collections;

namespace ExprBodied_Indexer_Enumerator
{
    class Stack : IEnumerable
    {
        private string[] _items;
        private int _top = -1;
        public Stack(int size) => _items = new string[size];
        public int Top
        {
            get => _top;
        }
        public int Count => _top + 1;
        public void Push(string item) => _items[++_top] = item;
        public string Pop() => _items[_top--];
        public string Peek() => _items[_top];
        public bool IsEmpty() => _top == -1;
        public string this[int index]
        {
            get
            {
                if(index < 0 || index > _top)
                    throw new IndexOutOfRangeException("Index out of range");
                return _items[index];
            }
            set
            {
                if (index < 0 || index > _top)
                    throw new IndexOutOfRangeException("Index out of range");
                _items[index] = value;
            }
        }

        /*
        public IEnumerator GetEnumerator()
        {
            return new StackEnumerator(this);
        }
        */

        public IEnumerator GetEnumerator()
        {
            for(int i=0; i<=_top; i++)
                yield return _items[i];
        }
        class StackEnumerator : IEnumerator
        {
            private Stack _stack;
            private int _pos;
            public StackEnumerator(Stack stack)
            {
                _stack = stack;
                _pos = -1;
            }
            public bool MoveNext()
            {
                if (_pos < _stack._top)
                {
                    _pos++;
                    return true;
                }
                return false;
            }
            public object Current => _stack._items[_pos];
            public void Reset() => _pos = -1;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // ClassName objName = new ClassName();
            Stack s = new(5); // Target-typed new syntax
            s.Push("A");
            s.Push("B");
            s.Push("C");
            s.Push("D");
            s.Push("E");
            Console.WriteLine("s[2] = " + s[2]);
            s[2] = "CAT";
            //IEnumerator e = s.GetEnumerator();
            //while (e.MoveNext())
            //    Console.WriteLine("Item: " + e.Current);
            foreach(object item in s)
                Console.WriteLine("Item: " + item);
            //while(!s.IsEmpty())
            //    Console.WriteLine("Popped: " + s.Pop());
        }

        static IEnumerable GetNums()
        {
            yield return 1;
            yield return 2;
            yield return 3;
        }
        static void Main2(string[] args)
        {
            foreach(int num in GetNums())
                Console.WriteLine(num);
        }
    }
}

