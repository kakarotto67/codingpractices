using System;

namespace AbstractFactory
{
    // The AbstractFactory
    abstract class ContinentFactory
    {
        public abstract Herbivore CreateHerbivore();
        public abstract Carnivore CreateCarnivore();
    }

    // The ConcreteFactory1
    class AfricaFactory : ContinentFactory
    {
        public override Herbivore CreateHerbivore()
        {
            return new Wildebeest();
        }

        public override Carnivore CreateCarnivore()
        {
            return new Lion();
        }
    }

    // The ConcreteFactory2
    class AmericaFactory : ContinentFactory
    {
        public override Herbivore CreateHerbivore()
        {
            return new Bison();
        }
        public override Carnivore CreateCarnivore()
        {
            return new Wolf();
        }
    }

    // The AbstractProductA
    abstract class Herbivore
    {
    }

    // The AbstractProductB
    abstract class Carnivore
    {
        public abstract void Eat(Herbivore h);
    }

    // The ProductA1
    class Wildebeest : Herbivore
    {
    }

    // The 'ProductB1
    class Lion : Carnivore
    {
        public override void Eat(Herbivore h)
        {
            // Eat Wildebeest
            Console.WriteLine(String.Format("{0} eats {1}",
                                            this.GetType().Name,
                                            h.GetType().Name));
        }
    }

    // The ProductA2
    class Bison : Herbivore
    {
    }

    // The ProductB2
    class Wolf : Carnivore
    {
        public override void Eat(Herbivore h)
        {
            // Eat Bison
            Console.WriteLine(String.Format("{0} eats {1}",
                                            this.GetType().Name,
                                            h.GetType().Name));
        }
    }

    // The Client
    class AnimalWorld
    {
        private Herbivore herbivore;
        private Carnivore carnivore;

        public AnimalWorld(ContinentFactory factory)
        {
            carnivore = factory.CreateCarnivore();
            herbivore = factory.CreateHerbivore();
        }

        public void RunFoodChain()
        {
            carnivore.Eat(herbivore);
        }
    }

    // The Application
    public class Program
    {
        public static void Main()
        {
            // Create and run the African animal world
            ContinentFactory africa = new AfricaFactory();
            AnimalWorld world = new AnimalWorld(africa);
            world.RunFoodChain();

            // Create and run the American animal world
            ContinentFactory america = new AmericaFactory();
            world = new AnimalWorld(america);
            world.RunFoodChain();
        }
    }
}
