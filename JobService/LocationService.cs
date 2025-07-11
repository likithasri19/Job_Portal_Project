using JobRepository.Model;
using JobRepository.Repository;
using JobService.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobService
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepo _locationRepo;

        public LocationService(ILocationRepo locationRepo)
        {
            _locationRepo = locationRepo;
        }

        public void AddLocation(Location location)
        {
            _locationRepo.AddLocation(location);
        }

        public List<Location> GetAllLocations()
        {
            return _locationRepo.GetAllLocations();
        }

        public Location GetLocationById(int id)
        {
            return _locationRepo.GetLocationById(id);
        }

        public void UpdateLocation(Location location)
        {
            _locationRepo.UpdateLocation(location);
        }

        public void DeleteLocation(int id)
        {
            _locationRepo.DeleteLocation(id);
        }
    }

}
