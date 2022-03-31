using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bowlers.Models
{
    public interface IBowlingRepository
    {
        IQueryable<Bowler> Bowlers { get; }
        IQueryable<Team> Teams { get; }

        public void Create(Bowler b);
        public void Update(Bowler b);
        public void Delete(Bowler b);
        void SaveChanges();
        void Remove(Bowler bowler);
    }
}
