using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards.Infrastructure.Interface
{
    public interface IUnitOfWork
    {
        ICardRepository Card { get; }
        void Save();
    }
}
