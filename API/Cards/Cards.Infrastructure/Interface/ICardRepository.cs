using Cards.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards.Infrastructure.Interface
{
    public interface ICardRepository : IBaseRepository<Card>
    {
        bool CardExists(Guid id);
        bool CardExists(string name);
        void Update(Card obj);
    }
}
