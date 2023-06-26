using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramTax
{
    class Program
    {
        static void Main(string[] args)
        {
            Product[] products = new Product[6];
            products[0] = new Book("B01", "The Alchemist", 10.99, "HarperCollins");
            products[1] = new Book("B02", "The Hunger Games", 6.99, "Scholastic");
            products[2] = new Book("B03", "To Kill a Mockingbird", 8.45, "J. B. Lippincott & Co.");
            products[3] = new MobilePhone("M01", "iPhone 12", 849.99, "Apple");
            products[4] = new MobilePhone("M02", "Samsung Galaxy S21", 749.99, "Samsung");
            products[5] = new MobilePhone("M03", "Google Pixel 5", 649.99, "Google");

            double totalBookTax = 0, totalPhoneTax = 0;

            foreach (Product p in products)
            {
                if (p is Book book)
                {
                    totalBookTax += book.computeTax();
                }
                else if (p is MobilePhone mobilePhone)
                {
                    totalPhoneTax += mobilePhone.computeTax();
                }
            }

            Console.WriteLine("total Book Tax is: " + totalBookTax);
            Console.WriteLine("total Mobile Phone Tax is: " + totalPhoneTax);
            double totalTax = totalBookTax + totalPhoneTax;
            Console.WriteLine("total Tax is: " + totalTax);
            Console.ReadLine();
        }
    }

    public abstract class Product
    {
        protected string productId;
        protected string name;
        protected double price;
        protected string producer;

        public Product(string productId, string name, double price, string producer)
        {
            this.productId = productId;
            this.name = name;
            this.price = price;
            this.producer = producer;
        }

        public abstract double computeTax();
    }

    public class Book : Product
    {
        public Book(string productId, string name, double price, string producer) : base(productId, name, price, producer)
        {
        }

        public override double computeTax()
        {
            return price * 0.08;
        }
    }

    public class MobilePhone : Product
    {
        public MobilePhone(string productId, string name, double price, string producer) : base(productId, name, price, producer)
        {
        }

        public override double computeTax()
        {
            return price * 0.1;
        }
    }
}