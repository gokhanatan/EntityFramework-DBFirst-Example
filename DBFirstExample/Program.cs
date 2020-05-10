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
            //ReadExample();

            //AddExample();

            //UpdateExample();

            DeleteExample();

            Console.ReadLine();

        }

        private static void DeleteExample()
        {
            using (var context = new NorthwindEntities())
            {
                var category = context.Categories.Find(9);
                context.Categories.Remove(category);
                context.SaveChanges();

            }
        }

        private static void UpdateExample()
        {
            using (var context = new NorthwindEntities())
            {
                var category = context.Categories.Find(9);

                category.CategoryName = "Spor";
                category.Description = "Bu bir spor kategorisidir.";

                context.SaveChanges();
            }
        }

        private static void AddExample()
        {
            using (var context = new NorthwindEntities())
            {
                Category category = new Category() { CategoryName = "Bilişim", Description = "Bu bir bilişim kategorisidir." };
                context.Categories.Add(category);
                context.SaveChanges();
            }
        }

        private static void ReadExample()
        {
            NorthwindEntities context = new NorthwindEntities();
            var categories = context.Categories.ToList();
            foreach (var item in categories)
            {
                Console.WriteLine(item.CategoryName);
            }
        }
    }
}
