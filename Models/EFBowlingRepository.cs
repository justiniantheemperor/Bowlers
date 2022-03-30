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
    }
}
