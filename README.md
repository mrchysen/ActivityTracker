Чтобы добавить миграцию необходимо в корне проекта(где лежит файл README) запустить команду

`//  dotnet ef migrations add <YOUR_MIGRATION_NAME> -v --project ActivityTracker -s ./ActivityTracker -p ./ActivityTracker.DAL -o ./ActivityTracker.DAL/Migrations`

YOUR_MIGRATION_NAME - замени на миграцию с названием изменений в бд