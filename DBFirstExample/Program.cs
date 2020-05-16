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


            using (var context = new NorthwindEntities())
            {
                var result = from prod in context.Products
                             join cat in context.Categories
                                on prod.CategoryID equals cat.CategoryID
                             group new { prod, cat }
                                by new { cat.CategoryName, prod.Discontinued }
                             into g
                             select new
                             {
                                 KategoriAdi = g.Key.CategoryName,
                                 İndirimlimi = g.Key.Discontinued,
                                 ToplamFiyat = g.Sum(x => x.prod.UnitPrice)
                             };

                foreach (var item in result)
                {
                    Console.WriteLine(" KategoriAdi: " + item.KategoriAdi +
                        " İndirimli mi: " + item.İndirimlimi +
                        " ToplamFiyat: " + item.ToplamFiyat);
                }
            }


            //using (var context = new NorthwindEntities())
            //{
            //    var result = from prod in context.Products
            //                 group prod by prod.CategoryID into g
            //                 select new
            //                 {
            //                     KategoriID = g.Key,
            //                     UrunAdedi = g.Count()
            //                 };

            //    foreach (var item in result)
            //    {
            //        Console.WriteLine(" KategoriID: " + item.KategoriID + 
            //            " UrunAdedi: "+item.UrunAdedi);
            //    }
            //}


            //LinqJoinOperasyonu();

            //LinqSimpleQuery5();

            //LinqSimpleQuery4();

            //LinqSimpleQuery3();

            //LinqSimpleQuery2();

            //LinqSimpleQuery1();


            //ReadExample();

            //AddExample();

            //UpdateExample();

            //DeleteExample();

            Console.ReadLine();

        }

        private static void LinqJoinOperasyonu()
        {
            using (var context = new NorthwindEntities())
            {
                var result = from prod in context.Products
                             join cat in context.Categories
                                on prod.CategoryID equals cat.CategoryID
                             where prod.UnitPrice > 75
                             select new
                             {
                                 KategoriAdi = cat.CategoryName,
                                 UrunID = prod.ProductID,
                                 UrunAdi = prod.ProductName,
                                 UrunFiyati = prod.UnitPrice
                             };

                foreach (var item in result)
                {
                    Console.WriteLine("KategoriAdi: " + item.KategoriAdi +
                        " UrunID: " + item.UrunID +
                        " UrunAdi: " + item.UrunAdi +
                        " UrunFiyati: " + item.UrunFiyati);
                }

            }
        }

        private static void LinqSimpleQuery5()
        {
            using (var context = new NorthwindEntities())
            {
                var products = context.Products.Where(p => p.UnitPrice > 100 ||
                p.SupplierID == 3);

                foreach (var product in products)
                {
                    Console.WriteLine("ÜrünAdı: " + product.ProductName +
                        " Fiyatı: " + product.UnitPrice +
                        " SuplierID: " + product.SupplierID);
                }
            }
        }

        private static void LinqSimpleQuery4()
        {
            using (var context = new NorthwindEntities())
            {
                var products = context.Products.Where(p => p.ProductName.Contains("Chef") ||
                    p.Discontinued != false);

                foreach (var product in products)
                {
                    Console.WriteLine("ProductName: " + product.ProductName +
                        " İndirimDurumu: " + product.Discontinued);
                }

            }
        }

        private static void LinqSimpleQuery3()
        {
            using (var context = new NorthwindEntities())
            {
                var products = context.Products.Where(p => p.UnitsInStock > 100 &&
                p.QuantityPerUnit.Contains("bottles"));

                foreach (var product in products)
                {
                    Console.WriteLine("QuantityPerUnit: " + product.QuantityPerUnit +
                        " StokMiktarı: " + product.UnitsInStock);
                }

            }
        }

        private static void LinqSimpleQuery2()
        {
            using (var context = new NorthwindEntities())
            {
                //var products = context.Products.Select(p => new
                //{
                //    UrunAdi = p.ProductName,
                //    Fiyati = p.UnitPrice
                //});

                var products = from prod in context.Products
                               select new
                               {
                                   UrunAdi = prod.ProductName,
                                   Fiyati = prod.UnitPrice
                               };

                foreach (var item in products)
                {
                    Console.WriteLine("UrunAdi: " + item.UrunAdi +
                        " Fiyatı: " + item.Fiyati);
                }

            }
        }

        private static void LinqSimpleQuery1()
        {
            using (var context = new NorthwindEntities())
            {
                //var products = context.Products;
                var products = context.Products.ToList();

                foreach (var product in products)
                {
                    Console.WriteLine("ProductID: " + product.ProductID +
                        "ProductName: " + product.ProductName);
                }
            }
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
