using System;
using System.Collections.Generic;

namespace lab4
{
    internal class Storage<T>
    {
        private T _item;

        public Storage(T item)
        {
            _item = item;
        }

        public T Item
        {
            get { return _item; }
            set { _item = value; }
        }
    }

    internal class Pair<T1, T2>
    {
        public T1 First { get; set; }
        public T2 Second { get; set; }

        public Pair(T1 first, T2 second)
        {
            First = first;
            Second = second;
        }

        public void PrintPair()
        {
            Console.WriteLine($"First: {First}, Second: {Second}");
        }
    }

    internal class Calculator<T>
    {
        public dynamic Add(dynamic a, dynamic b) => a + b;
        public dynamic Subtract(dynamic a, dynamic b) => a - b;
        public dynamic Multiply(dynamic a, dynamic b) => a * b;

        public dynamic Divide(dynamic a, dynamic b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException("Division by zero is not allowed.");
            }
            return a / b;
        }
    }
    internal class Stack<T>
    {
        private List<T> _elements = new List<T>();
        public void Push(T item)
        {
            _elements.Add(item);
        }

        public T Pop()
        {
            if (_elements.Count == 0)
            {
                throw new InvalidOperationException("Stack is empty.");
            }
            T top = _elements[_elements.Count - 1];
            _elements.RemoveAt(_elements.Count - 1);
            return top;
        }
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= _elements.Count)
                {
                    throw new IndexOutOfRangeException("Invalid index.");
                }
                return _elements[index];
            }
        }
        public int Count
        {
            get { return _elements.Count; }
        }
    }
    internal class Queue<T>
    {
        private List<T> _elements = new List<T>();

        public void Enqueue(T item)
        {
            _elements.Add(item);
        }

        public T Dequeue()
        {
            if (_elements.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty.");
            }
            T first = _elements[0];
            _elements.RemoveAt(0);
            return first;
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= _elements.Count)
                {
                    throw new IndexOutOfRangeException("Invalid index.");
                }
                return _elements[index];
            }
        }

        public int Count
        {
            get { return _elements.Count; }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Storage<int> intStorage = new Storage<int>(42);
            Console.WriteLine("Integer value: " + intStorage.Item);

            Storage<string> stringStorage = new Storage<string>("Hello World");
            Console.WriteLine("String value: " + stringStorage.Item);

            Storage<double> doubleStorage = new Storage<double>(3.14);
            Console.WriteLine("Double value: " + doubleStorage.Item);

            Pair<int, string> pair1 = new Pair<int, string>(42, "Hello");
            pair1.PrintPair();

            Pair<string, double> pair2 = new Pair<string, double>("Pi", 3.14);
            pair2.PrintPair();

            Pair<bool, char> pair3 = new Pair<bool, char>(true, 'A');
            pair3.PrintPair();

            Calculator<int> intCalculator = new Calculator<int>();
            Console.WriteLine("Integer Operations:");
            Console.WriteLine($"Addition: {intCalculator.Add(10, 5)}");
            Console.WriteLine($"Subtraction: {intCalculator.Subtract(10, 5)}");
            Console.WriteLine($"Multiplication: {intCalculator.Multiply(10, 5)}");
            Console.WriteLine($"Division: {intCalculator.Divide(10, 5)}");

            Calculator<double> doubleCalculator = new Calculator<double>();
            Console.WriteLine("\nDouble Operations:");
            Console.WriteLine($"Addition: {doubleCalculator.Add(10.5, 5.2)}");
            Console.WriteLine($"Subtraction: {doubleCalculator.Subtract(10.5, 5.2)}");
            Console.WriteLine($"Multiplication: {doubleCalculator.Multiply(10.5, 5.2)}");
            Console.WriteLine($"Division: {doubleCalculator.Divide(10.5, 5.2)}");

            Stack<int> intStack = new Stack<int>();

            intStack.Push(10);
            intStack.Push(20);
            intStack.Push(30);

            Console.WriteLine("Stack elements:");
            for (int i = 0; i < intStack.Count; i++)
            {
                Console.WriteLine($"Element at index {i}: {intStack[i]}");
            }

            Console.WriteLine($"\nPopped: {intStack.Pop()}"); 
            Console.WriteLine($"\nPopped: {intStack.Pop()}"); 

            Console.WriteLine("\nStack elements after popping:");
            for (int i = 0; i < intStack.Count; i++)
            {
                Console.WriteLine($"Element at index {i}: {intStack[i]}");
            }

            try
            {
                Console.WriteLine($"\nAccessing invalid index: {intStack[5]}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Queue<int> intQueue = new Queue<int>();

            intQueue.Enqueue(10);
            intQueue.Enqueue(20);
            intQueue.Enqueue(30);

            Console.WriteLine("Queue elements:");
            for (int i = 0; i < intQueue.Count; i++)
            {
                Console.WriteLine($"Element at index {i}: {intQueue[i]}");
            }

            Console.WriteLine($"\nDequeued: {intQueue.Dequeue()}");  
            Console.WriteLine($"\nDequeued: {intQueue.Dequeue()}"); 

            Console.WriteLine("\nQueue elements after dequeuing:");
            for (int i = 0; i < intQueue.Count; i++)
            {
                Console.WriteLine($"Element at index {i}: {intQueue[i]}");
            }

            try
            {
                Console.WriteLine($"\nAccessing invalid index: {intQueue[5]}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.ReadLine();
        }
    }
}
