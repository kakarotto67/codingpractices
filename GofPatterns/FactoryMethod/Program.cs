using System;
using System.Collections.Generic;

namespace FactoryMethod
{
    // The Product
    abstract class Page
    {
    }

    // A ConcreteProduct
    class SkillsPage : Page
    {
    }

    // A ConcreteProduct
    class ExperiencePage : Page
    {
    }

    // A ConcreteProduct
    class IntroductionPage : Page
    {
    }

    // A ConcreteProduct
    class ResultsPage : Page
    {
    }

    // A ConcreteProduct
    class SummaryPage : Page
    {
    }

    // The Creator
    abstract class Document
    {
        private List<Page> pages = new List<Page>();

        // Constructor calls abstract Factory method
        public Document()
        {
            this.CreatePages();
        }

        public List<Page> Pages
        {
            get { return pages; }
        }

        // Factory Method
        public abstract void CreatePages();
    }

    // A ConcreteCreator
    class Resume : Document
    {
        // Factory Method implementation
        public override void CreatePages()
        {
            Pages.Add(new SkillsPage());
            Pages.Add(new ExperiencePage());
        }
    }

    // A ConcreteCreator
    class Report : Document
    {
        // Factory Method implementation
        public override void CreatePages()
        {
            Pages.Add(new IntroductionPage());
            Pages.Add(new ResultsPage());
            Pages.Add(new SummaryPage());
        }
    }

    // The Application
    public class Program
    {
        public static void Main()
        {
            var documents = new Document[2];

            // Constructors call Factory Method
            documents[0] = new Resume();
            documents[1] = new Report();

            // Display document pages
            foreach (Document doc in documents)
            {
                Console.WriteLine(doc.GetType().Name);
                foreach (Page page in doc.Pages)
                {
                    Console.WriteLine(page.GetType().Name);
                }
            }
        }
    }
}
