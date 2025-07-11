using JobRepository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobRepository.Repository
{
    public interface ILocationRepo
    {
        void AddLocation(Location location);
        List<Location> GetAllLocations();
        Location GetLocationById(int id);
        Location GetLocationByName(string name);
        void UpdateLocation(Location location);
        void DeleteLocation(int id);
    }
}
