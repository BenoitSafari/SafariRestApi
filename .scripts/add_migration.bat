@echo off
IF NOT "%~2"=="" (
    cd SafariRest.Database
    dotnet ef migrations add %1 --output-dir Migrations -- %2
    cd ../..
) ELSE (
    echo Usage: %0 ^<MigrationName^> ^<ConnectionString^>
)