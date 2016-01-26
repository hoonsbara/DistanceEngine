using System.Collections.Generic;

namespace DistanceEngine
{
    public interface IDistanceManager
    {
        void AddPath(string pattern);

        string GetDistance(IList<string> locations);

        string GetPathNumber(string from, string to);

        string GetShortestLength(string from, string to);
    }
}