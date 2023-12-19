using BookStoreProject.Infrastructure.Mappers;
using BookStoreProject.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreProject.Infrastructure.Database
{
    public class BookRepository
    {
        public List<BookViewModel> GetList()
        {
            using (var context = new Context())
            {
                var items = context.Books.ToList();
                return BookMapper.Map(items);
            }
        }
        public BookViewModel GetById(long id)
        {
            using (var context = new Context())
            {
                var item = context.Books.FirstOrDefault(x => x.ID == id);
                return BookMapper.Map(item);
            }
        }

        public BookViewModel AddBook(BookEntity entity)
        {
            entity.AuthorId = entity.AuthorId;
            entity.PublisherId = entity.PublisherId;
            entity.GenreId = entity.GenreId;
            entity.Title = entity.Title.Trim();
            entity.Cost = entity.Cost.Trim();
            entity.Quantity = entity.Quantity.Trim();

            if(string.IsNullOrEmpty(entity.Title) || string.IsNullOrEmpty(entity.Cost) || string.IsNullOrEmpty(entity.Quantity))
            {
                throw new Exception("Заполните поля пжпжпж");
            }
            using(var context = new Context())
            {
                context.Books.Add(entity);
                context.SaveChanges();
            }

            return BookMapper.Map(entity);
        }
        public BookViewModel DeleteBook(long id)
        {
            using (var context = new Context())
            {
                var bookRemove = context.Books.FirstOrDefault(y => y.ID == id);
                if (bookRemove != null)
                {
                    context.Books.Remove(bookRemove);
                    context.SaveChanges();
                }
                return BookMapper.Map(bookRemove);
            }
        }
        public BookViewModel Update(BookEntity entity)
        {
            entity.AuthorId = entity.AuthorId;
            entity.PublisherId = entity.PublisherId;
            entity.GenreId = entity.GenreId;
            entity.Title = entity.Title.Trim();
            entity.Cost = entity.Cost.Trim();
            entity.Quantity = entity.Quantity.Trim();

            if (string.IsNullOrEmpty(entity.Title) || string.IsNullOrEmpty(entity.Cost) || string.IsNullOrEmpty(entity.Quantity))
            {
                throw new Exception("Заполните поля пжпжпж");
            }
            using(var context = new Context())
            {
                var existingBook = context.Books.Find(entity.ID);

                if (existingBook != null)
                {
                    context.Entry(existingBook).CurrentValues.SetValues(entity);
                    context.SaveChanges();
                }
            }
            return BookMapper.Map(entity);
        }
        public List<BookViewModel> Search(string search)
        {
            search = search.Trim().ToLower();

            using (var context = new Context())
            {
                var result = context.Books
                    .Where(x =>
                        x.Title.ToLower().Contains(search) && x.Title.Length == search.Length ||
                        x.Author.SurName.ToLower().Contains(search) && x.Author.SurName.Length == search.Length ||
                        x.Author.Name.ToLower().Contains(search) && x.Author.Name.Length == search.Length ||
                        x.Publisher.Title.ToLower().Contains(search) && x.Publisher.Title.Length == search.Length)
                    .ToList();

                return BookMapper.Map(result);
            }
        }
    }
}
