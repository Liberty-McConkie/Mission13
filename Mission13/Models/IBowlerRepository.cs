using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13.Models
{
    public interface IBowlerRepository
    {
        IQueryable<Bowler> Bowlers { get; }

        public void SaveBowler(Bowler bowler);

        public void UpdateBowler(Bowler bowler);

        public void DeleteBowler(Bowler bowler);
    }
}
