using JobRepository.Model;
using JobRepository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobRepository
{
    public class LocationRepository : ILocationRepo
    {
        private static List<Location> locations = new List<Location>();

        public void AddLocation(Location location)
        {
            locations.Add(location);
        }

        public List<Location> GetAllLocations() => locations;

        public Location GetLocationById(int id)
        {
            return locations.FirstOrDefault(l => l.LocationID == id);
        }

        public Location GetLocationByName(string name)
        {
            return locations.FirstOrDefault(l => l.LocationName == name);
        }

        public void UpdateLocation(Location location)
        {
            var existingLoc = GetLocationById(location.LocationID);
            if (existingLoc != null)
            {
                existingLoc.LocationName = location.LocationName;
            }
        }

        public void DeleteLocation(int id)
        {
            var location = GetLocationById(id);
            if (location != null)
            {
                locations.Remove(location);
            }
        }
    }


}
