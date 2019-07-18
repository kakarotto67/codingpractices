using System;

namespace Adapter
{
    // The Target
    class Mixture
    {
        protected string chemical;
        protected float boilingPoint;
        protected string molecularFormula;

        // Constructor
        public Mixture(string chemical)
        {
            this.chemical = chemical;
        }

        public virtual void Display()
        {
            Console.WriteLine("Mixture: {0}", chemical);
        }
    }

    // The Adapter
    class MixtureAdapter : Mixture
    {
        // Adaptee that needs adapting
        private ChemicalDatabank chemicalDatabank;

        public MixtureAdapter(string name)
            : base(name)
        {
        }

        public override void Display()
        {
            // The Adaptee
            chemicalDatabank = new ChemicalDatabank();

            boilingPoint = chemicalDatabank.GetCriticalPoint(chemical);
            molecularFormula = chemicalDatabank.GetMolecularStructure(chemical);

            base.Display();
            Console.WriteLine("Formula: {0}", molecularFormula);
            Console.WriteLine("Boiling Point: {0}", boilingPoint);
        }
    }

    // The Adaptee
    class ChemicalDatabank
    {
        // The databank 'legacy API'
        public float GetCriticalPoint(string compound)
        {
            switch (compound.ToLower())
            {
                case "water": return 100.0f;
                case "benzene": return 80.1f;
                case "ethanol": return 78.3f;
                default: return 0f;
            }
        }

        public string GetMolecularStructure(string compound)
        {
            switch (compound.ToLower())
            {
                case "water": return "H20";
                case "benzene": return "C6H6";
                case "ethanol": return "C2H5OH";
                default: return "";
            }
        }
    }

    // The Application
    public class Program
    {
        public static void Main()
        {
            // Non-adapted chemical compound
            Mixture unknown = new Mixture("Unknown");
            unknown.Display();

            // Adapted chemical compounds
            Mixture water = new MixtureAdapter("Water");
            water.Display();

            Mixture benzene = new MixtureAdapter("Benzene");
            benzene.Display();

            Mixture ethanol = new MixtureAdapter("Ethanol");
            ethanol.Display();
        }
    }
}
