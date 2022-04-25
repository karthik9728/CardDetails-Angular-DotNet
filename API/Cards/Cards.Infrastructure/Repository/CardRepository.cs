using Cards.Domain.Models;
using Cards.Infrastructure.Data;
using Cards.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards.Infrastructure.Repository
{
    public class CardRepository : BaseRepository<Card>, ICardRepository
    {
        ApplicationDbContext _db;
        public CardRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public bool CardExists(Guid id)
        {
            bool value = _db.Card.Any(x => x.Id == id);
            return value;
        }

        public bool CardExists(string name)
        {
            bool value = _db.Card.Any(x => x.CardHolderName.ToUpper().Trim() == name.ToUpper().Trim());
            return value;
        }

        public void Update(Card obj)
        {
            _db.Card.Update(obj);
        }
    }
}



































































