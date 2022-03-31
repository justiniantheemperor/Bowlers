using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bowlers.Models
{
    public class EFBowlingRepository : IBowlingRepository
    {
        private BowlingDbContext _context { get; set; }

        public EFBowlingRepository(BowlingDbContext temp)
        {
            _context = temp;
        }

        public IQueryable<Bowler> Bowlers => _context.Bowlers;

        public IQueryable<Team> Teams => _context.Teams;

        
        public void Update(Bowler b)
        {
            _context.SaveChanges();
        }

        public void Create(Bowler b)
        {
            _context.Add(b);
            _context.SaveChanges();
        }

        public void Delete(Bowler b)
        {
            _context.Remove(b);
            _context.SaveChanges();
        }

    }
}
