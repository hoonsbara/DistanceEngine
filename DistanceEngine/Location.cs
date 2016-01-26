using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DistanceEngine
{
    public class Location : ILocation
    {
        public string Name { get; private set; }
        public IList<Path> Paths { get; private set; }

        public Location(string name)
        {
            Name = name;
        }

        public void AddPath(Location destination, int distance)
        {
            Paths.Add(new Path(destination, distance));
        }
    }
}
