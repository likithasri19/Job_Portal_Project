using JobRepository;
using JobRepository.Model;
using JobRepository.Repository;

public class ManagerRepository : IManagerRepo
{
    private readonly JobPortalContext _context;
    public ManagerRepository(JobPortalContext context)
    {
        _context = context;
    }

    public void AddManager(Manager manager)
    {
        _context.Managers.Add(manager);
        _context.SaveChanges();
    }

    public List<Manager> GetAllManagers() => _context.Managers.ToList();

    public Manager GetManagerById(int id)
    {
        return _context.Managers.FirstOrDefault(m => m.ManagerID == id);
    }

    public Manager GetManagerByEmail(string email)
    {
        return _context.Managers.FirstOrDefault(m => m.Email == email);
    }

    public void UpdateManager(Manager manager)
    {
        var existing = _context.Managers.FirstOrDefault(m => m.ManagerID == manager.ManagerID);
        if (existing != null)
        {
            existing.ManagerName = manager.ManagerName;
            existing.Email = manager.Email;
            _context.SaveChanges();
        }
    }

    public void DeleteManager(int id)
    {
        var manager = _context.Managers.FirstOrDefault(m => m.ManagerID == id);
        if (manager != null)
        {
            _context.Managers.Remove(manager);
            _context.SaveChanges();
        }
    }
}
