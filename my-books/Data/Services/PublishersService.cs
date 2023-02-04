using my_books.Data.Models;
using my_books.Data.ViewModels;

namespace my_books.Data.Services
{
    public class PublishersService
    {
        AppDbContext _context;
        public PublishersService(AppDbContext context)
        {
            _context = context;
        }

        public Publisher AddPublisher(PublisherVM publisher)
        {
            var _publisher = new Publisher
            {
                Name = publisher.Name
            };
            _context.Publishers.Add(_publisher);
            _context.SaveChanges();
            return _publisher;
        }

        public Publisher GetPublisherById(int publisherId) => _context.Publishers.FirstOrDefault(x => x.Id == publisherId);

        public PublisherWithBooksAndAuthorsVM GetPublisherData(int publisherId)
        {
            var _publisherData = _context.Publishers.Where(x => x.Id == publisherId).Select(x =>
            new PublisherWithBooksAndAuthorsVM
            {
                Name = x.Name,
                BookAndAuthors = x.Books.Select(x =>
                    new BookAndAuthorVM
                    {
                        BookName = x.Title,
                        BookAuthors = x.Book_Authors.Select(x => x.Author.FullName).ToList()
                    }).ToList()
            }).FirstOrDefault();

            return _publisherData;
        }

        public void DeletePublisherData(int id)
        {
            var _publisher = _context.Publishers.FirstOrDefault(x => x.Id == id);
            if (_publisher != null)
            {
                _context.Publishers.Remove(_publisher);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception($"The publisher with id {id} does not exist.");
            }
        }
    }
}
