using Microsoft.EntityFrameworkCore;

namespace EcommerceApp
{
    internal class Program
    {
        static  EcommerceContext context = new EcommerceContext();

        static async Task Main(string[] args)
        {
            await MainMenuAsync();
               var context = new EcommerceContext();

               var electronics = new Category
               {
                   Name = "Electronics",
                   Description = "Electronic Devices"
               };

               var clothes = new Category
               {
                   Name = "Clothes",
                   Description = "Fashion Products"
               };

               context.categories.AddRange(electronics, clothes);
               context.SaveChanges();

               var p1 = new Product
               {
                   Name = "Laptop",
                   Price = 25000,
                   CategoryId = 1
               };

               var p2 = new Product
               {
                   Name = "Mouse",
                   Price = 500,
                   CategoryId = 1
               };

               var p3 = new Product
               {
                   Name = "Keyboard",
                   Price = 800,
                   CategoryId = 1
               };

               var p4 = new Product
               {
                   Name = "T-Shirt",
                   Price = 350,
                   CategoryId = 2
               };

               var p5 = new Product
               {
                   Name = "Jeans",
                   Price = 700,
                   CategoryId = 2
               };

               context.products.AddRange(p1, p2, p3, p4, p5);
               context.SaveChanges();


               var c1 = new Customer
               {
                   Name = "Ahmed",
                   Email = "ahmed@gmail.com"
               };

               var c2 = new Customer
               {
                   Name = "Sara",
                   Email = "sara@gmail.com"
               };

               context.customers.AddRange(c1, c2);
               context.SaveChanges();


               var o1 = new Order
               {
                   TotalAmount = 25500,
                   Date = DateTime.Now,
                   CustomerId = 1
               };

               var o2 = new Order
               {
                   TotalAmount = 1300,
                   Date = DateTime.Now,
                   CustomerId = 1
               };

               var o3 = new Order
               {
                   TotalAmount = 700,
                   Date = DateTime.Now,
                   CustomerId = 2
               };

               context.orders.AddRange(o1, o2, o3);
               context.SaveChanges();


               var d1 = new OrderDetails
               {
                   OrderId = 1,
                   ProductId = 1,
                   Quantity = 1
               };

               var d2 = new OrderDetails
               {
                   OrderId = 1,
                   ProductId = 2,
                   Quantity = 1
               };

               var d3 = new OrderDetails
               {
                   OrderId = 2,
                   ProductId = 3,
                   Quantity = 1
               };

               var d4 = new OrderDetails
               {
                   OrderId = 2,
                   ProductId = 4,
                   Quantity = 2
               };

               var d5 = new OrderDetails
               {
                   OrderId = 3,
                   ProductId = 5,
                   Quantity = 1
               };

               context.orderDetails.AddRange(d1, d2, d3, d4, d5);
               context.SaveChanges();


               Console.WriteLine("=========== Categories ===========");

               var categoryResult = context.categories.ToList();

               foreach (var item in categoryResult)
               {
                   Console.WriteLine(item);
               }


               Console.WriteLine("=========== Products ===========");

               var productResult = context.products.ToList();

               foreach (var item in productResult)
               {
                   Console.WriteLine(item);
               }


               Console.WriteLine("=========== Customers ===========");

               var customerResult = context.customers.ToList();

               foreach (var item in customerResult)
               {
                   Console.WriteLine(item);
               }


               Console.WriteLine("=========== Orders ===========");

               var orderResult = context.orders.ToList();

               foreach (var item in orderResult)
               {
                   Console.WriteLine(item);
               }


               Console.WriteLine("=========== Order Details ===========");

               var detailsResult = context.orderDetails.ToList();

               foreach (var item in detailsResult)
               {
                   Console.WriteLine(item);
               }
        }

        static async Task MainMenuAsync()
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();

                Console.WriteLine("===== E-Commerce =====");
                Console.WriteLine("1. Category");
                Console.WriteLine("2. Product");
                Console.WriteLine("3. Exit");
                Console.Write("Choose: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        await CategoryMenuAsync();
                        break;

                    case "2":
                        await ProductMenuAsync();
                        break;

                    case "3":
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid Choice");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static async Task CategoryMenuAsync()
        {
            bool flag = false;

            while (!flag)
            {
                Console.Clear();

                Console.WriteLine("===== Category Menu =====");
                Console.WriteLine("1. Add Category");
                Console.WriteLine("2. View Categories");
                Console.WriteLine("3. Update Category");
                Console.WriteLine("4. Delete Category");
                Console.WriteLine("5. Back");

                Console.Write("Choose: ");

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        await AddCategoryAsync();
                        break;

                    case "2":
                        await ViewAllCategoriesAsync();
                        break;

                    case "3":
                        await UpdateCategoryAsync();
                        break;

                    case "4":
                        await RemoveCategoryAsync();
                        break;

                    case "5":
                        flag = true;
                        break;

                    default:
                        Console.WriteLine("Invalid Choice");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static async Task ProductMenuAsync()
        {
            bool flag = false;

            while (!flag)
            {
                Console.Clear();

                Console.WriteLine("===== Product Menu =====");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. View Products");
                Console.WriteLine("3. Update Product");
                Console.WriteLine("4. Delete Product");
                Console.WriteLine("5. Back");

                Console.Write("Choose: ");

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        await AddProductAsync();
                        break;

                    case "2":
                        await ViewAllProductsAsync();
                        break;

                    case "3":
                        await UpdateProductAsync();
                        break;

                    case "4":
                        await RemoveProductAsync();
                        break;

                    case "5":
                        flag = true;
                        break;

                    default:
                        Console.WriteLine("Invalid Choice");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static async Task AddCategoryAsync() {
            Console.Clear();

            Category category = new Category();

            Console.Write("Enter Category Name: ");
            category.Name = Console.ReadLine();

            Console.Write("Enter Description: ");
            category.Description = Console.ReadLine();

            await context.categories.AddAsync(category);
            await context.SaveChangesAsync();

            Console.WriteLine("Category Added Successfully.");

            Console.WriteLine("\nPress any key...");
            Console.ReadKey();
        }

        static async Task ViewAllCategoriesAsync() {
            Console.Clear();

            IEnumerable<Category> categories = await context.categories.ToListAsync();

            foreach (var item in categories)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\nPress any key...");
            Console.ReadKey();
        }

        static async Task UpdateCategoryAsync() {
            Console.Clear();

            Console.Write("Enter Category Id: ");
            int id = int.Parse(Console.ReadLine());

            Category category = await context.categories.FindAsync(id);

            if (category != null)
            {
                Console.Write("New Name: ");
                category.Name = Console.ReadLine();

                Console.Write("New Description: ");
                category.Description = Console.ReadLine();

                await context.SaveChangesAsync();

                Console.WriteLine("Category Updated Successfully.");
            }
            else
            {
                Console.WriteLine("Category Not Found.");
            }

            Console.WriteLine("\nPress any key...");
            Console.ReadKey();
        }

        static async Task RemoveCategoryAsync() {
            Console.Clear();

            Console.Write("Enter Category Id: ");
            int id = int.Parse(Console.ReadLine());

            Category category = await context.categories.FindAsync(id);

            if (category != null)
            {
                context.categories.Remove(category);

                await context.SaveChangesAsync();

                Console.WriteLine("Category Deleted Successfully.");
            }
            else
            {
                Console.WriteLine("Category Not Found.");
            }

            Console.WriteLine("\nPress any key...");
            Console.ReadKey();
        }

        static async Task AddProductAsync() {
            Console.Clear();

            Product product = new Product();

            Console.Write("Enter Product Name: ");
            product.Name = Console.ReadLine();

            Console.Write("Enter Price: ");
            product.Price = decimal.Parse(Console.ReadLine());

            Console.Write("Enter Category Id: ");
            product.CategoryId = int.Parse(Console.ReadLine());

            await context.products.AddAsync(product);

            await context.SaveChangesAsync();

            Console.WriteLine("Product Added Successfully.");

            Console.WriteLine("\nPress any key...");
            Console.ReadKey();
        }

        static async Task ViewAllProductsAsync() {
            Console.Clear();

            IQueryable<Product> products = context.products;

            foreach (var item in await products.ToListAsync())
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\nPress any key...");
            Console.ReadKey();
        }

        static async Task UpdateProductAsync() {
            Console.Clear();

            Console.Write("Enter Product Id: ");
            int id = int.Parse(Console.ReadLine());

            Product product = await context.products.FindAsync(id);

            if (product != null)
            {
                Console.Write("New Name: ");
                product.Name = Console.ReadLine();

                Console.Write("New Price: ");
                product.Price = decimal.Parse(Console.ReadLine());

                Console.Write("New Category Id: ");
                product.CategoryId = int.Parse(Console.ReadLine());

                await context.SaveChangesAsync();

                Console.WriteLine("Product Updated Successfully.");
            }
            else
            {
                Console.WriteLine("Product Not Found.");
            }

            Console.WriteLine("\nPress any key...");
            Console.ReadKey();
        }

        static async Task RemoveProductAsync() {
            Console.Clear();

            Console.Write("Enter Product Id: ");
            int id = int.Parse(Console.ReadLine());

            Product product = await context.products.FindAsync(id);

            if (product != null)
            {
                context.products.Remove(product);

                await context.SaveChangesAsync();

                Console.WriteLine("Product Deleted Successfully.");
            }
            else
            {
                Console.WriteLine("Product Not Found.");
            }

            Console.WriteLine("\nPress any key...");
            Console.ReadKey();
        }
    }
}
