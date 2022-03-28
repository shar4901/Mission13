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

        public IQueryable<Team> Teams => _context.Teams;

        public void SaveBowler(Bowler bowler)
        {
            if (bowler.BowlerId == 0)
            {
                int maxId = _context.Bowlers.Max(x => x.BowlerId);
                bowler.BowlerId = maxId + 1;

                _context.Bowlers.Add(bowler);
                _context.SaveChanges();
            }
            _context.SaveChanges();
        }

        public void DeleteBowler(int bowlerId)
        {
            Bowler bowler = _context.Bowlers.Where(x => x.BowlerId == bowlerId).FirstOrDefault();
            _context.Remove(bowler);
            _context.SaveChanges();
        }

        public void EditBowler(Bowler bowler)
        {
            _context.Update(bowler);
        }

    }
}
