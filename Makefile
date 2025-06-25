# Configuration
PROJECT_NAME=MultiDbTenant
SQL_SCRIPT=./sql/Setup.sql
SQL_SERVER=localhost
SQLCMD=sqlcmd

# .NET targets
build:
	dotnet build

run:
	dotnet run --project ./src/MultiDbTenant.Api/MultiDbTenant.Api.csproj

test:
	dotnet test

clean:
	dotnet clean

restore:
	dotnet restore

# Setup DB (resets Tenant1 and Tenant2 using setup.sql)
setup-db:
	$(SQLCMD) -S $(SQL_SERVER) -d master -i $(SQL_SCRIPT)

# Rebuild everything and set up DB
rebuild: clean build setup-db

# Call the API for each tenant (POST sample product)
call-api:
	@echo "Posting sample to tenant1..."
	curl -X POST http://localhost:5097/api/product \
		-H "Content-Type: application/json" \
		-H "X-Tenant-ID: tenant1" \
		-d "{\"name\": \"Tenant1 Widget\", \"description\": \"From curl\"}"
	@echo
	@echo "Posting sample to tenant2..."
	curl -X POST http://localhost:5097/api/product \
		-H "Content-Type: application/json" \
		-H "X-Tenant-ID: tenant2" \
		-d "{\"name\": \"Tenant2 Widget\", \"description\": \"From curl\"}"
	@echo

# Help
help:
	@echo "Available targets:"
	@echo "  build       - Build the project"
	@echo "  run         - Run the Web API"
	@echo "  test        - Run unit tests"
	@echo "  clean       - Clean the build output"
	@echo "  restore     - Restore NuGet packages"
	@echo "  setup-db    - Run setup.sql to reset tenant databases"
	@echo "  rebuild     - Clean, build, and setup DB"
	@echo "  call-api    - Call the API for each tenant"
