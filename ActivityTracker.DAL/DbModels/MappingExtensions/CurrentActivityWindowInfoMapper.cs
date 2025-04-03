using ActivityTracker.Core.WindowActivity;

namespace ActivityTracker.DAL.DbModels.MappingExtension;

public static class CurrentActivityWindowInfoMapper
{
    public static CurrentActivityWindowInfoDb MapToDb(this CurrentActivityWindowInfo windowInfo)
        => new()
        {
            AppName = windowInfo.AppName,
            SubInfo = windowInfo.SubInfo,
            DateTime = windowInfo.DateTime
        };

    public static IEnumerable<CurrentActivityWindowInfoDb> MapToDb(this IEnumerable<CurrentActivityWindowInfo> windowInfos)
    {
        foreach (var windowInfo in windowInfos)
        {
            yield return windowInfo.MapToDb();
        }
    }

    public static CurrentActivityWindowInfo MapFromDb(this CurrentActivityWindowInfoDb windowInfoDb)
        => new(windowInfoDb.AppName, windowInfoDb.SubInfo, windowInfoDb.DateTime);

    public static IEnumerable<CurrentActivityWindowInfo> MapFromDb(this IEnumerable<CurrentActivityWindowInfoDb> windowInfoDbs)
    {
        foreach (var windowInfoDb in windowInfoDbs)
        {
            yield return windowInfoDb.MapFromDb();
        }
    }
}
