using JobRepository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobService.Service
{
    public interface ILocationService
    {
        void AddLocation(Location location);
        List<Location> GetAllLocations();
        Location GetLocationById(int id);
        void UpdateLocation(Location location);
        void DeleteLocation(int id);
    }
}
