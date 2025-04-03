namespace ActivityTracker.Core.WindowActivity;

public interface ICurrentActivityWindowInfoRepository
{
    public Task<List<CurrentActivityWindowInfo>> GetFromPeriod(
        DateTime start, DateTime end);
    public Task<List<CurrentActivityWindowInfo>> GetByAppName(
        string appName, DateTime start);

    public Task Add(CurrentActivityWindowInfo info);
    public Task AddBatch(List<CurrentActivityWindowInfo> infos);

    public Task Delete(List<CurrentActivityWindowInfo> infos);
}
