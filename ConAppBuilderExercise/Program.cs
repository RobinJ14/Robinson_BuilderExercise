using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConAppBuilderExercise
{
    public class MainApp
    {
        static void Main(string[] args)
        {
            MealBuilder builder;

            shop shop = new shop();

            builder = new ChildMeal();

            shop.Construct(builder);

            builder.Meal.show();


        }
    }

    class shop
    {
        public void Construct(MealBuilder mealBuilder)
        {
            mealBuilder.Burger();
            mealBuilder.Drink();
            mealBuilder.Desert();
            mealBuilder.Toy();
        }
    }

    abstract class MealBuilder
    {
        protected Meal meal;

        public Meal Meal
        {
            get { return meal; }
        }
        public abstract void Burger();
        public abstract void Drink();
        public abstract void Desert();

        public abstract void Toy();
    }

    class ChildMeal : MealBuilder
    {
        public ChildMeal()
        {
            meal = new Meal("Child Meal");
        }

        public override void Burger()
        {
            meal["burger"] = "chicken";
        }

        public override void Desert()
        {
            meal["drink"] = "cola";
           
        }

        public override void Drink()
        {
            meal["desert"] = "icecream";
        }

        public override void Toy()
        {
            meal["toy"] = "car";
        }
    }

    class Meal
    {
        protected string _mealType;
        public Meal(string mealType)
        {
            _mealType = mealType;
        }

        private Dictionary<string, string> _details = new Dictionary<string, string>();

        public string this[string key]
        {
            get { return _details[key]; }
            set { _details[key] = value; }
        }

        public void show()
        {
            Console.WriteLine("\n-----------------------");
            Console.WriteLine("Meal Type: {0}", _mealType);
            Console.WriteLine("Burger: {0}", _details["burger"]);
            Console.WriteLine("Drink: {0}", _details["drink"]);
            Console.WriteLine("Desert: {0}", _details["desert"]);
            Console.WriteLine("Toy: {0}", _details["toy"]);

        }
    }
}
