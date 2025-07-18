using JobRepository.Model;
using JobRepository.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace JobRepository
{
    public class LocationRepository : ILocationRepo
    {
        private readonly JobPortalContext _context;

        public LocationRepository(JobPortalContext context)
        {
            _context = context;
        }

        public void AddLocation(Location location)
        {
            _context.Locations.Add(location);
            _context.SaveChanges();
        }

        public List<Location> GetAllLocations()
        {
            return _context.Locations.ToList();
        }

        public Location GetLocationById(int id)
        {
            return _context.Locations.FirstOrDefault(l => l.LocationID == id);
        }

        public Location GetLocationByName(string name)
        {
            return _context.Locations.FirstOrDefault(l => l.LocationName == name);
        }

        public void UpdateLocation(Location location)
        {
            _context.Locations.Update(location);
            _context.SaveChanges();
        }

        public void DeleteLocation(int id)
        {
            var location = GetLocationById(id);
            if (location != null)
            {
                _context.Locations.Remove(location);
                _context.SaveChanges();
            }
        }
    }
}
