// BigCats.cs — SINGLE FILE with all classes + .Main


using System;

namespace BigCatHierarchy
{
    // ---------------- Base class ----------------
    public class Animal
    {
        // auto-properties (public get/set)
        public string Name { get; set; } = "";
        public int Age { get; set; }

        // virtual = child classes can override this to customize the sound
        public virtual string Sound() => "(animal sound)";
    }

    // ------------- Intermediate class -------------
    // BigCat "is an" Animal (inherits from Animal)
    public class BigCat : Animal
    {
        // Anyone can read Species; only this class or children can set it
        public string Species { get; protected set; } = "Big Cat";

        public override string Sound() => "Roar!";
    }

    // ---------------- Specific big cats ----------------
    public class Lion : BigCat
    {
        public Lion() { Species = "Lion"; }
        public override string Sound() => "ROAR (lion)!";
    }

    public class AfricanLion : Lion
    {
        public AfricanLion() { Species = "African Lion"; }
        // Optional: override again if you want a variant
        // public override string Sound() => "ROAR (African lion)!";
    }

    public class Tiger : BigCat
    {
        public Tiger() { Species = "Tiger"; }
        public override string Sound() => "ROAR (tiger)!";
    }

    public class BengalTiger : Tiger
    {
        public BengalTiger() { Species = "Bengal Tiger"; }
    }

    public class Leopard : BigCat
    {
        public Leopard() { Species = "Leopard"; }
        public override string Sound() => "Growl (leopard)!";
    }

    public class SnowLeopard : Leopard
    {
        public SnowLeopard() { Species = "Snow Leopard"; }
        // public override string Sound() => "Chuff (snow leopard)!";
    }

    // ---------------- Entry point ----------------
    // Standard Main method so the Console app has an entry point.
    internal class Program
    {
        static void Main(string[] args)
        {
            // (Optional) tiny test so you see output runs:
            var cat = new AfricanLion { Name = "Simba", Age = 5 };
            Console.WriteLine($"{cat.Species} named {cat.Name} (Age {cat.Age}) says: {cat.Sound()}");

          
        }
    }
}

