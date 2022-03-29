using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13.Models
{
    public class EFBowlerRepository : IBowlerRepository
    {

        private BowlersDbContext context { get; set; }

        public EFBowlerRepository (BowlersDbContext temp)
        {
            context = temp;
        }
        public IQueryable<Bowler> Bowlers => context.Bowlers;

        public void SaveBowler(Bowler bowler)
        {
            if (bowler.BowlerID == 0)
            {
                context.Bowlers.Add(bowler);
                
            }
            context.SaveChanges();

        }
        public void UpdateBowler(Bowler bowler)
        {
            context.Bowlers.Update(bowler);
            context.SaveChanges();
        }

        public void DeleteBowler (Bowler bowler)
        {
            context.Bowlers.Remove(bowler);
            context.SaveChanges();
        }

    }
}
