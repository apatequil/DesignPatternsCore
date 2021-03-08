using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Factories.Lesson1.Factory
{
    public class MealManagerFactory
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

            foreach(var mealtype in MealFactory.AvailableMeals)
            {
                Console.WriteLine($"{mealtype.Id}) {mealtype.Description}");
            }

            Console.Write("Enter your choice: ");
            return Console.ReadLine();
        }

        // Processing of the user input is offloaded to a different method since the main should care what actually happens, just
        // that the program doesn't fail.
        private void ProcessMeal(string selectedType)
        {
            var mealType = MealFactory.AvailableMeals.FirstOrDefault(x => x.Id.Equals(selectedType, StringComparison.OrdinalIgnoreCase)).MealType;

            if (mealType == null) 
            {
                Console.WriteLine("Invalid selection. Please try again.");
                return;
            }

            var meal = MealFactory.CreateMeal(mealType);
            meal.Prepare();

            return;
        }        
    }

    public static class MealFactory
    {
        // We're hard-coding this but it could easily be populated from a db or file or service
        public static List<(string Id, string Description, Type MealType)> AvailableMeals = new List<(string, string, Type)>
        {
            { ("1", "Breakfast", typeof(BreakfastMeal)) },
            { ("2", "Lunch", typeof(LunchMeal)) },
            { ("3", "Snack", typeof(SnackMeal)) },
            { ("4", "Dinner", typeof(DinnerMeal)) },
            { ("5", "Dessert", typeof(DessertMeal)) }
        };
        
        public static IMeal CreateMeal<T>() where T : IMeal, new()
        {
            return (T)Activator.CreateInstance(typeof(T));
        }

        public static IMeal CreateMeal(Type mealType)
        {
            return Activator.CreateInstance(mealType) as IMeal;
        }
    }
    // Create a common interface with which the factory can use as a return type.
    public interface IMeal
    {
        string MealName { get; }
        void Prepare();

    }

    // Implement the interface in the abstract base class. Now all meal objects can
    // be passed around as the interface
    public abstract class Meal : IMeal
    {
        public abstract string MealName { get; }

        public virtual void Prepare()
        {
            Console.WriteLine($"Preparing {MealName}");
        }
    }

    // Concrete classes for our different meal types.
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
