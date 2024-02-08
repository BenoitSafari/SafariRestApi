#!/usr/bin

if [ $# -ne 2 ]; then
    echo "Usage: $0 <MigrationName> <ConnectionString>"
    exit 1
fi
cd SafariRest.Database
dotnet ef migrations add $1 --output-dir Migrations -- $2
cd ../..
