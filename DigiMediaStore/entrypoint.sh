#!/bin/bash
set -e

echo "Waiting for PostgreSQL to be ready..."
until pg_isready -h postgres -U postgres; do
  sleep 1
done

echo "PostgreSQL is ready!"

echo "Running database migrations..."
dotnet ef database update --project ../DigiMediaStore.DataAccess/DigiMediaStore.DataAccess.csproj --no-build || echo "Migrations may have already been applied or EF tools not available"

echo "Starting application..."
exec dotnet DigiMediaStore.dll









