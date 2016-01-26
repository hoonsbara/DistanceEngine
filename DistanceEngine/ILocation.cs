using System.Collections.Generic;

namespace DistanceEngine
{
    public interface ILocation
    {
        string Name { get; }
        IList<Path> Paths { get; }

        void AddPath(Location destination, int distance);
    }
}