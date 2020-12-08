using System;

namespace DesignPatterns.Command
{
    public class Chef
    {
        public void CookSoup()
        {
            Console.WriteLine("Cooking soup");
        }

        public void CookPasta()
        {
            Console.WriteLine("Cooking pasta");
        }

        public void CookSteak()
        {
            Console.WriteLine("Cooking steak");
        }
    }
}
