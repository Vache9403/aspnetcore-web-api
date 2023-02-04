namespace my_books.Data.ViewModels
{
    public class PublisherVM
    {
        public string Name { get; set; } 
    }

    public class PublisherWithBooksAndAuthorsVM 
    {
        public string Name { get; set; }
        public List<BookAndAuthorVM> BookAndAuthors { get; set; }
    }

    public class BookAndAuthorVM
    {
        public string BookName { get; set; }
        public List<string> BookAuthors { get; set; } 
    }
}
