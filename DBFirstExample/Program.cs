using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFirstExample
{
    class Program
    {
        static void Main(string[] args)
        {
            NorthwindEntities context = new NorthwindEntities();
            var categories = context.Categories.ToList();
            foreach (var item in categories)
            {
                Console.WriteLine(item.CategoryName);
            }

            Console.ReadLine();

        }

    }
}
