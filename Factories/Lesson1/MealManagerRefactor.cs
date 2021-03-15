using System;
using System.Collections.Generic;
using System.Text;

namespace Factories.Lesson1.Refactor
{
    public class MealManagerRefactor
    {
        public void Run()
        {
            while (true)
            {
                var mealToPrepare = PromptUser();

                ProcessMeal(mealToPrepare);

                // It's ok for the main thread to check for an exit condition. This
                // could be abstracted as well but we'll leave it for brevity
                Console.WriteLine();
                var exit = Console.ReadLine();
                if (exit.ToLower().Trim() == "bye")
                {
                    break;
                }
            }
        }

        // UI code pulled out of main method to reduce its responsibilities
        private string PromptUser()
        {
            Console.WriteLine("Which meal would you like (enter number below)?");
            Console.WriteLine("1 Breakfast");
            Console.WriteLine("2 Lunch");
            Console.WriteLine("3 Snack");
            Console.WriteLine("4 Dinner");
            Console.WriteLine("5 Dessert");
            Console.Write("Enter your choice: ");
            return Console.ReadLine();
        }

        // Processing of the user input is offloaded to a different method since the main shouldn't care what actually happens, just
        // that the program doesn't fail.
        private void ProcessMeal(string mealType)
        {
            Meal meal;
            switch (mealType)
            {
                case "1":
                    meal = new BreakfastMeal();
                    break;
                case "2":
                    meal = new LunchMeal();
                    break;
                case "3":
                    meal = new SnackMeal();
                    break;
                case "4":
                    meal = new DinnerMeal();
                    break;
                case "5":
                    meal = new DessertMeal();
                    break;
                default:
                    Console.WriteLine("Invalid selection. Please try again.");
                    return;
            }

            meal.Prepare();
        }
    }


    // Used abstract class over interface because we could use the default implementation
    // of Prepare in a generic enough way that we don't need to override or specify it in the base
    // class. This makes the class signatures of the child classes very simple and the cod which
    // utilizes these objects can operate on the base class since polymorphic inheritence guarantees
    // the child method will be executed.
    public abstract class Meal
    {
        public abstract string MealName { get; }

        public virtual void Prepare()
        {
            Console.WriteLine($"Preparing {MealName}");
        }
    }

    public class BreakfastMeal : Meal
    {
        public override string MealName => "Breakfast";
    }

    public class LunchMeal : Meal
    {
        public override string MealName => "Lunch";
    }

    public class SnackMeal : Meal
    {
        public override string MealName => "Snack";
    }

    public class DinnerMeal : Meal
    {
        public override string MealName => "Dinner";
    }

    public class DessertMeal : Meal
    {
        public override string MealName => "Dessert";
    }
}
