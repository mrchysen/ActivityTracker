using ActivityTracker.Core.WindowActivity;

namespace ActivityTracker.DAL.DbModels.MappingExtension;

internal static class CurrentActivityWindowInfoMapper
{
    internal static CurrentActivityWindowInfoDb MapToDb(this CurrentActivityWindowInfo windowInfo)
        => new()
        {
            AppName = windowInfo.AppName,
            SubInfo = windowInfo.SubInfo,
            DateTime = windowInfo.DateTime
        };

    internal static IEnumerable<CurrentActivityWindowInfoDb> MapToDb(this IEnumerable<CurrentActivityWindowInfo> windowInfos)
    {
        foreach (var windowInfo in windowInfos)
        {
            yield return windowInfo.MapToDb();
        }
    }

    internal static CurrentActivityWindowInfo MapFromDb(this CurrentActivityWindowInfoDb windowInfoDb)
        => new(windowInfoDb.AppName, windowInfoDb.SubInfo, windowInfoDb.DateTime);

    internal static IEnumerable<CurrentActivityWindowInfo> MapFromDb(this IEnumerable<CurrentActivityWindowInfoDb> windowInfoDbs)
    {
        foreach (var windowInfoDb in windowInfoDbs)
        {
            yield return windowInfoDb.MapFromDb();
        }
    }
}
