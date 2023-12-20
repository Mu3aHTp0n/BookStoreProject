using BookStoreProject.Infrastructure.Mappers;
using BookStoreProject.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreProject.Infrastructure.Database
{
    public class OrderingRepository
    {
        public List<OrderingViewModel> GetList()
        {
            using (var context = new Context())
            {
                var items = context.Orderings.ToList();
                return OrderingMapper.Map(items);
            }
        }
        public OrderingViewModel GetById(long id)
        {
            using (var context = new Context())
            {
                var item = context.Orderings.FirstOrDefault(x => x.ID == id);
                return OrderingMapper.Map(item);
            }
        }

        #region Методы: удалить, добавить, обновить
        public OrderingViewModel Delete(long id)
        {
            using(var context = new Context())
            {
                var orderRemove = context.Orderings.FirstOrDefault(y => y.ID == id);
                if (orderRemove != null)
                {
                    context.Orderings.Remove(orderRemove);
                    context.SaveChanges();
                }
                return OrderingMapper.Map(orderRemove);
            }
        }
        public OrderingViewModel AddOrder(OrderingEntity entity)
        {
            entity.PeopleId = entity.PeopleId;
            entity.BookId = entity.BookId;
            entity.Count = entity.Count.Trim();
            entity.Date = entity.Date.Trim();

            if (string.IsNullOrEmpty(entity.Count) || string.IsNullOrEmpty(entity.Date))
            {
                throw new Exception("Не все поля заполнены");
            }
            using (var context = new Context())
            {
                context.Orderings.Add(entity);
                context.SaveChanges();
            }
            return OrderingMapper.Map(entity);
        }
        public List<OrderingViewModel> Search(string search)
        {
            search = search.Trim().ToLower();

            using (var context = new Context())
            {
                var result = context.Orderings
                    .Where(x =>
                        x.Count.ToLower().Contains(search) && x.Count.Length == search.Length ||
                        x.Date.ToLower().Contains(search) && x.Date.Length == search.Length)
                    .ToList();

                return OrderingMapper.Map(result);
            }
        }
        public OrderingViewModel Update(OrderingEntity entity)
        {
            entity.PeopleId = entity.PeopleId;
            entity.BookId = entity.BookId;
            entity.Count = entity.Count.Trim();
            entity.Date = entity.Date.Trim();

            if (string.IsNullOrEmpty(entity.Count) || string.IsNullOrEmpty(entity.Date))
            {
                throw new Exception("Не все поля заполнены");
            }
            using (var context = new Context())
            {
                var existingClient = context.Orderings.Find(entity.ID);

                if (existingClient != null)
                {
                    context.Entry(existingClient).CurrentValues.SetValues(entity);
                    context.SaveChanges();
                }
            }
            return OrderingMapper.Map(entity);
        }
        #endregion
    }
}
