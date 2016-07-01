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
            number = number + i;
        }

        public void Multiply(int i)
        {
            number = number * i;
        }

        public void NoOperation(int i)
        {
            Console.WriteLine("NoOperation");
            number = number - i;
        }

        public void NoOperation2(int i)
        {
            Console.WriteLine("NoOperation2");
        }

    }
}
