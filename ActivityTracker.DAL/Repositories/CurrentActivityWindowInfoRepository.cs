using ActivityTracker.Core.WindowActivity;
using ActivityTracker.DAL.DbModels.MappingExtension;

namespace ActivityTracker.DAL.Repositories;

public class CurrentActivityWindowInfoRepository(ApplicationDbContext context) : ICurrentActivityWindowInfoRepository
{
    private ApplicationDbContext _context = context;

    public Task Add(CurrentActivityWindowInfo info)
    {
        throw new NotImplementedException();
    }

    public Task AddBatch(List<CurrentActivityWindowInfo> infos)
    {
        throw new NotImplementedException();
    }

    public Task Delete(List<CurrentActivityWindowInfo> infos)
    {
        throw new NotImplementedException();
    }

    public Task<List<CurrentActivityWindowInfo>> GetByAppName(string appName, DateTime start)
    {
        throw new NotImplementedException();
    }

    public Task<List<CurrentActivityWindowInfo>> GetFromPeriod(DateTime start, DateTime end)
    {
        throw new NotImplementedException();
    }
}
