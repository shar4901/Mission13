using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13.Models
{
    public class EFBowlersRecipository : IBowlersRepository
    {
        private BowlerDbContext _context { get; set; }
        public EFBowlersRecipository(BowlerDbContext temp)
        {
            _context = temp;
        }
        public IQueryable<Bowler> Bowlers => _context.Bowlers;
    }
}
