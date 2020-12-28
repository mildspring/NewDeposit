using System.Collections.Generic;
using System.Linq;

namespace ContributionCalculators
{
    public class Portfolio
    {
        public IList<IPosition> Positions { get; }

        public Portfolio(
            IList<IPosition> positions)
        {
            Positions = positions;
        }

        public Portfolio(
            IList<Position> positions)
            : this(positions.Select(p => p).Cast<IPosition>().ToList())
        {
        }
    }
}