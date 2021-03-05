using System;
using System.Collections.Generic;
using System.Text;

namespace Factories.FactoryRefactor
{
    public class MealFactoryStarter
    {
        public void Run()
        {
            while (true)
            {
                Console.WriteLine("Which meal would you like (enter number below)?");
                Console.WriteLine("1 Beef");
                Console.WriteLine("2 Chicken");
                Console.WriteLine("3 Fish");
                Console.WriteLine("4 Vegetarian");

                var mealNumber = Console.ReadLine();
                var meal = MealFactory.CreateMeal(mealNumber);
                meal.Prepare();


                Console.WriteLine();
                var exit = Console.ReadLine();
                if (exit.ToLower().Trim() == "bye")
                {
                    break;
                }
            }
        }
    }

    public interface IMeal
    {
        string Name { get; }
        string Code { get; }
        string Number { get; }
        void Prepare();
    }

    public class VegetarianMeal : IMeal
    {
        public string Name => "Vegetarian Meal";
        public string Code => GetType().Name;
        public string Number => "4";

        public void Prepare()
        {
            Console.WriteLine($"Preparing {Name}");
            Console.ReadKey();
        }
    }

    public class BeefMeal : IMeal
    {
        public string Name => "Beef Meal";
        public string Code => GetType().Name;

        public string Number => "1";
        public void Prepare()
        {
            Console.WriteLine($"Preparing {Name}");
            Console.ReadKey();
        }
    }

    public class ChickenMeal : IMeal
    {
        public string Name => "Chicken Meal";
        public string Code => GetType().Name;
        public string Number => "2";
        public void Prepare()
        {
            Console.WriteLine($"Preparing {Name}");
            Console.ReadKey();
        }
    }

    public class FishMeal : IMeal
    {
        public string Name => "Fish Meal";
        public string Code => GetType().Name;
        public string Number => "3";
        public void Prepare()
        {
            Console.WriteLine($"Preparing {Name}");
            Console.ReadKey();
        }
    }

    public static class MealFactory
    {
        public static IMeal CreateMeal(string mealNumber)
        {
            if (mealNumber == null)
            {
                return null;
            }
            if (mealNumber == "1")
            {
                return new BeefMeal();
            }
            if (mealNumber == "2")
            {
                return new ChickenMeal();
            }
            if (mealNumber == "3")
            {
                return new FishMeal();
            }
            if (mealNumber == "4")
            {
                return new VegetarianMeal();
            }

            throw new Exception("Meal Type Does Not Exist");
        }
    }
}
