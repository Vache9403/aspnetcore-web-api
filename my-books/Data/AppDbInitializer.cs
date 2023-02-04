using my_books.Data.Models;

namespace my_books.Data
{
    public class AppDbInitializer 
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                if (context != null && !context.Books.Any())
                {
                    context.Books.AddRange(
                        new Book
                        {
                            Title = " 1st Title",
                            Description = "1st Description",
                            IsRead = true,
                            DateRead = DateTime.Now.AddDays(-10),
                            Rate = 4,
                            Genre = "Biography",
                            CoverUrl = "https....",
                            DateAdded = DateTime.Now
                        },
                        new Book
                        {
                            Title = " 2nd Title",
                            Description = "2nd Description",
                            IsRead = false,
                            Genre = "Biography",
                            CoverUrl = "https....",
                            DateAdded = DateTime.Now
                        });

                    context.SaveChanges();
                }
            }
        }
    }
}
