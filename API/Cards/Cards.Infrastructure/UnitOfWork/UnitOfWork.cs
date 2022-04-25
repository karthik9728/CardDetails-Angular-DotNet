using Cards.Infrastructure.Data;
using Cards.Infrastructure.Interface;
using Cards.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICardRepository Card {get; private set;}
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Card = new CardRepository(_db); 
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
