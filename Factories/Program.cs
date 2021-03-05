using System;
using Factories.Lesson1.Factory;

namespace Factories
{
    class Program
    {
        static void Main(string[] args)
        {
            new MealManagerFactory().Run();
        }
    }
}
