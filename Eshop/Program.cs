using System;
using System.Collections.Generic;
using System.Text;

namespace Eshop
{
    class Program
    {
        static void Main(string[] args)
        {
            Product product1 = new Sweets(10, 5);
            Product product2 = new Book(2, 7);
            Product product3 = new Cup(3, 8);

            Catalog catalog1 = new Catalog();
            catalog1.UploadProducts(product1);
            catalog1.UploadProducts(product2);
            catalog1.UploadProducts(product3);
            

            ConsoleKeyInfo cki;
            ConsoleKeyInfo cki2;

            Console.WriteLine("Welcome to Eshop\n\nCustomers press - 1\nOwner     press - 2");
            Console.WriteLine("Press L - for the available products list");
            Console.WriteLine("Press ESC to End\n");
            do
            {
                cki = Console.ReadKey();
                switch (cki.Key)
                {
                    case ConsoleKey.L:
                        Console.WriteLine($"Here is the Eshop products list: ");
                        Console.WriteLine(catalog1.ToString());
                        break;
                    case (ConsoleKey)User.Customer:
                        //Console.WriteLine("Customer");
                        Console.WriteLine("Please Choose the Product:\nS for Sweets\nB for Book\nC for Cup\n");
                        cki2 = Console.ReadKey();
                        switch (cki2.Key)
                        {
                            case (ConsoleKey)ProductEnum.Sweets:
                                Console.WriteLine($"Enter Sweets quantity (available: {product1._quantity}):");
                                product1._inputQuantity = Convert.ToInt32(Console.ReadLine());
                                if (product1._quantity >= product1._inputQuantity)
                                {
                                    product1.Buy();
                                }
                                else
                                {
                                    Console.WriteLine("Not available quantity");
                                    break;
                                }
                                Console.WriteLine($"Available: {product1._quantity}");
                                break;
                            case (ConsoleKey)ProductEnum.Book:
                                Console.WriteLine($"Enter Book quantity (available: {product2._quantity}):");
                                product2._inputQuantity = Convert.ToInt32(Console.ReadLine());
                                if (product2._quantity >= product2._inputQuantity)
                                {
                                    product2.Buy();
                                }
                                else
                                {
                                    Console.WriteLine("Not available quantity");
                                    break;
                                }
                                Console.WriteLine($"Available: {product2._quantity}");
                                break;
                            case (ConsoleKey)ProductEnum.Cup:
                                Console.WriteLine($"Enter Cup quantity (available: {product3._quantity}):");
                                product3._inputQuantity = Convert.ToInt32(Console.ReadLine());
                                if (product3._quantity >= product3._inputQuantity)
                                {
                                    product3.Buy();
                                }
                                else
                                {
                                    Console.WriteLine("Not available quantity");
                                    break;
                                }
                                Console.WriteLine($"Available: {product3._quantity}");
                                break;
                            //default:
                            //    Console.WriteLine("Unknown Product");
                            //    break;
                        }
                        break;
                    case (ConsoleKey)User.Owner:
                        //Console.WriteLine("Owner");
                        Console.WriteLine("Please Add the Product:\nS for Sweets\nB for Book\nC for Cup\n");
                        cki2 = Console.ReadKey();
                        switch (cki2.Key)
                        {
                            case (ConsoleKey)ProductEnum.Sweets:
                                Console.WriteLine("Add Sweets quantity: ");
                                product1._inputQuantity = Convert.ToInt32(Console.ReadLine());
                                product1.Add();
                                Console.WriteLine($"Available: {product1._quantity}");
                                break;
                            case (ConsoleKey)ProductEnum.Book:
                                Console.WriteLine("Add Book quantity: ");
                                product2._inputQuantity = Convert.ToInt32(Console.ReadLine());
                                product2.Add();
                                Console.WriteLine($"Available: {product2._quantity}");
                                break;
                            case (ConsoleKey)ProductEnum.Cup:
                                Console.WriteLine("Add Cup quantity: ");
                                product3._inputQuantity = Convert.ToInt32(Console.ReadLine());
                                product3.Add();
                                Console.WriteLine($"Available: {product3._quantity}");
                                break;
                            //default:
                            //    Console.WriteLine("Unknown Product");
                            //    break;
                        }
                        break;
                    //default:
                    //    Console.WriteLine("Unknown User");
                    //    break;
                }
            } while (cki.Key != ConsoleKey.Escape);
            Console.WriteLine("Thank you for shoping");
        }
    }
    public class IShop
    {
        //private readonly IShop product1 = new Sweets(10, 5);
        //readonly Product product2 = new Book(2, 7);
        //Product product3 = new Cup(3, 8);
        //void Add();
        //void Buy();
    }

    public abstract class Product
    {
        public int _quantity;
        public int _price;
        public int _inputQuantity;

        

        public Product(int quantity, int price)
        {
            _quantity = quantity;
            _price = price;
        }

        public void Add()
        {
            _quantity += _inputQuantity;
        }

        public void Buy()
        {
            _quantity -= _inputQuantity;
        }
    }

    public class Sweets : Product
    {
        public Sweets(int quantity, int price) : base(quantity, price)
        {
        }
    }

    public class Book : Product
    {
        public Book(int quantity, int price) : base(quantity, price)
        {
        }
    }

    public class Cup : Product
    {
        public Cup(int quantity, int price) : base(quantity, price)
        {
        }
    }

    public class Catalog
    {
        public List<Product> _catalog;

        public Catalog()
        {
            _catalog = new List<Product>();
        }

        public void UploadProducts(Product product)
        {
            _catalog.Add(product);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var item in _catalog)
            {
                sb.AppendLine(item + "  quantity: " + item._quantity + ", price: " + item._price.ToString());
            }
            sb.AppendLine("Total diferent products: " + _catalog.Count.ToString());
            return sb.ToString();
        }
    }

    //public class PriceList
    //{

    //}

    //public class Quantities
    //{

    //}
}
