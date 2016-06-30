using CSharpInterceptors;
using CSharpInterceptors.Delegation;
using System;
using System.Reflection;
using System.Reflection.Emit;

namespace InterceptorsTests
{
    public class TestClass
    {
        public int number;
        public void Add(int i)
        {
            Console.WriteLine("Add");
            number = number + i;
        }

        public void Multiply(int i)
        {
            Console.WriteLine("Multiply");
            number *= i;
        }

        public void NoOperation(int i)
        {
            Console.WriteLine("NoOperation");
        }

        public void NoOperation2(int i)
        {
            Console.WriteLine("NoOperation2");
        }

    }
}
