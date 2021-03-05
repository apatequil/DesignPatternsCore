using System;
using System.Collections.Generic;
using System.Text;

namespace Factories.Lesson1.Starter
{
    public class MealManagerStarter
    {
        public void Run()
        {
            while (true)
            {
                Console.WriteLine("Which meal would you like (enter number below)?");
                Console.WriteLine("1 Breakfast");
                Console.WriteLine("2 Lunch");
                Console.WriteLine("3 Snack");
                Console.WriteLine("4 Dinner");
                Console.WriteLine("5 Dessert");
                Console.Write("Enter your choice: ");

                var mealToPrepare = Console.ReadLine();
                switch (mealToPrepare)
                {
                    case "1":
                        var breakfast = new BreakfastMeal();
                        breakfast.Prepare();
                        break;
                    case "2":
                        var lunch = new LunchMeal();
                        lunch.Prepare();
                        break;
                    case "3":
                        var snack = new SnackMeal();
                        snack.Prepare();
                        break;
                    case "4":
                        var dinner = new DinnerMeal();
                        dinner.Prepare();
                        break;
                    case "5":
                        var dessert = new DessertMeal();
                        dessert.Prepare();
                        break;
                    default:
                        Console.WriteLine("Invalid selection. Please try again.");
                        break;
                }

                
                

                Console.WriteLine();
                var exit = Console.ReadLine();
                if(exit.ToLower().Trim() == "bye")
                {
                    break;
                }
            }
        }
    }

    public class BreakfastMeal
    {
        public void Prepare()
        {
            Console.WriteLine("Preparing Breakfast");
        }
    }

    public class LunchMeal
    {
        public void Prepare()
        {
            Console.WriteLine("Preparing Lunch");
        }
    }

    public class SnackMeal
    {
        public void Prepare()
        {
            Console.WriteLine("Preparing Snack");
        }
    }

    public class DinnerMeal
    {
        public void Prepare()
        {
            Console.WriteLine("Preparing Dinner");
        }
    }

    public class DessertMeal
    {
        public void Prepare()
        {
            Console.WriteLine("Preparing Dessert");
        }
    }
}
