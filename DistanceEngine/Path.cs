using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceEngine
{
    public class Path : IPath
    {
        public Location Destination { get; private set; }
        public int Distance { get; private set; }

        public Path(Location destination, int distance)
        {
            Destination = destination;
            Distance = distance;
        }
    }
}
