﻿using my_books.Data.Models;
using my_books.Data.ViewModels;

namespace my_books.Data.Services
{
    public class AuthorsService
    {
        AppDbContext _context;
        public AuthorsService(AppDbContext context) 
        {
            _context = context;
        }

        public void AddAuthor(AuthorVM author)  
        {
            var _author = new Author
            {
                FullName = author.FullName
            };
            _context.Authors.Add(_author);
            _context.SaveChanges();
        }

        public AuthorWithBooksVM GetAuthorWithBooks(int authorId)
        {
            var _author = _context.Authors.Where(x=>x.Id== authorId).Select(x =>new AuthorWithBooksVM
            {
                FullName= x.FullName,
                BookTitles =x.Book_Authors.Select(x=>x.Book.Title).ToList()
            }).FirstOrDefault();
            return _author;
        }
    }
}
