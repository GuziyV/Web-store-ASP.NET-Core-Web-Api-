using DAL.Contexts;
using DAL.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.DBInitilizer
{
    public static class DBInitilizer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<StoreContext>();

                if (!context.Producers.Any())
                {
                    var producer1 = new Producer("Lenovo", "Chinese multinational technology company with headquarters in Beijing, China, and Morrisville, North Carolina, United States.");
                    context.Add(producer1);

                    var category1 = new Category("Laptops", "Small, portable personal computer with a clamshell form factor", "https://library.fresnostate.edu/sites/all/assets/img/tech/laptop.jpg");
                    context.Add(category1);

                    var product1 = new Product(producer1,
                        category1,
                        "Y530",
                        "This 15.6-inch laptop gives you exactly what you need for a gaming experience that balances performance and portability. Its breathtakingly sleek design includes a three-sided narrow bezel for a more immersive gaming experience. The latest-generation specs include GTX graphics and Intel Core i7 six core processors, which guarantee you serious gaming power. Thermally optimized to run cooler and quieter with a full-sized white-backlit keyboard, the Lenovo Legion Y530 Laptop is primed for those who demand gaming wherever life takes them.",
                        799.99,
                        8
                    );
                    context.Add(product1);

                    context.SaveChanges();
                }
                
            }
        }
    }
}
