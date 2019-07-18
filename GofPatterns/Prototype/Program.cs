using System;
using System.Collections.Generic;

namespace Prototype
{
    // The Prototype
    abstract class ColorPrototype
    {
        public abstract ColorPrototype Clone();
    }

    // The ConcretePrototype
    class Color : ColorPrototype
    {
        private int red;
        private int green;
        private int blue;

        // Constructor
        public Color(int red, int green, int blue)
        {
            this.red = red;
            this.green = green;
            this.blue = blue;
        }

        // Create a shallow copy
        public override ColorPrototype Clone()
        {
            return this.MemberwiseClone() as ColorPrototype;
        }
    }

    // Prototype manager
    class ColorManager
    {
        private Dictionary<string, ColorPrototype> colors =
            new Dictionary<string, ColorPrototype>();

        // Indexer
        public ColorPrototype this[string key]
        {
            get { return colors[key]; }
            set { colors.Add(key, value); }
        }
    }

    // The Application
    public class Program
    {
        public static void Main()
        {
            var colorManager = new ColorManager();

            // Initialize with standard colors
            colorManager["red"] = new Color(255, 0, 0);
            colorManager["green"] = new Color(0, 255, 0);
            colorManager["blue"] = new Color(0, 0, 255);

            // User adds personalized colors
            colorManager["angry"] = new Color(255, 54, 0);
            colorManager["peace"] = new Color(128, 211, 128);
            colorManager["flame"] = new Color(211, 34, 20);

            // User clones selected colors
            Color color1 = colorManager["red"].Clone() as Color;
            Color color2 = colorManager["peace"].Clone() as Color;
            Color color3 = colorManager["flame"].Clone() as Color;
        }
    }
}
