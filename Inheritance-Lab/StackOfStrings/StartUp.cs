using System;
using System.Collections.Generic;

namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            StackOfStrings<string> stringStack = new StackOfStrings<string>();
            stringStack.Push("Gosho");
            stringStack.Push("Pesho");
            Console.WriteLine(stringStack.IsEmpty());
            Stack<string> stringStackForAdd = new Stack<string>();
            stringStackForAdd.Push("Elena");
            stringStackForAdd.Push("Ana");
            stringStack.AddRange(stringStackForAdd);
            Console.WriteLine(string.Join(" ",stringStack));
            Console.WriteLine(stringStack.IsEmpty());

            StackOfStrings<int> intStack = new StackOfStrings<int>();
            intStack.Push(1);
            intStack.Push(2);
            Stack<int> intStackForAdd = new Stack<int>();
            intStackForAdd.Push(3);
            intStackForAdd.Push(4);
            intStack.AddRange(intStackForAdd);
            Console.WriteLine(string.Join(" ", intStack));
            Console.WriteLine(intStack.IsEmpty());
        }
    }
}
