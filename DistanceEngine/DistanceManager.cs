using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DistanceEngine
{
    public class DistanceManager : IDistanceManager
    {
        private readonly IDictionary<string, Location>  _locations ;

        public DistanceManager(IDictionary<string, Location> locations)
        {
            _locations = locations;
        }

        public void AddPath(string pattern)
        {
            
        }

        public string GetDistance(IList<string> locations)
        {
            return "";
        }

        public string GetPathNumber(string from, string to)
        {
            return "";
        }

        public string GetShortestLength(string from, string to)
        {
            return "";
        }
    }
    
}
