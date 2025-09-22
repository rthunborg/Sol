# Development Environment Setup Guide

## Prerequisites

### Required Software
1. **Visual Studio 2019 or 2022** - Primary IDE for .NET Framework 4.8 development
2. **PostgreSQL 12+** - Database server with PostGIS extension
3. **Git** - Version control
4. **.NET Framework 4.8** - Runtime and development targeting pack

### Database Setup

#### 1. Install PostgreSQL with PostGIS
```bash
# Windows - Download from postgresql.org
# Include PostGIS extension during installation
# Or install separately from postgis.net
```

#### 2. Create Development Database
```sql
-- Connect to PostgreSQL as superuser
CREATE DATABASE sunnyseat_dev;
CREATE DATABASE sunnyseat_test;

-- Enable PostGIS extension
\c sunnyseat_dev;
CREATE EXTENSION postgis;

\c sunnyseat_test;
CREATE EXTENSION postgis;
```

#### 3. Create Database User (Optional)
```sql
-- Create dedicated user for the application
CREATE USER sunnyseat_user WITH PASSWORD 'secure_password_here';
GRANT ALL PRIVILEGES ON DATABASE sunnyseat_dev TO sunnyseat_user;
GRANT ALL PRIVILEGES ON DATABASE sunnyseat_test TO sunnyseat_user;
```

### Project Setup

#### 1. Clone Repository
```bash
git clone <repository-url>
cd Sol
```

#### 2. Configure Database Connection
Update `App.config` with your PostgreSQL connection details:

```xml
<connectionStrings>
  <add name="SunnySeatConnection" 
       connectionString="Server=localhost;Port=5432;Database=sunnyseat_dev;User Id=postgres;Password=your_password;" 
       providerName="Npgsql" />
</connectionStrings>
```

#### 3. Restore NuGet Packages
```bash
# In Visual Studio
# Tools -> NuGet Package Manager -> Package Manager Console
Update-Package -Reinstall
```

Or use command line:
```bash
nuget restore Sol.sln
```

#### 4. Build Solution
```bash
# In Visual Studio: Build -> Build Solution
# Or use MSBuild command line:
msbuild Sol.sln /p:Configuration=Debug
```

#### 5. Test Database Connectivity
Run the Sol console application to test database connection:
```bash
# From bin/Debug directory
Sol.exe
```

Expected output:
```
Sunny Seat - Database Infrastructure Test
========================================
?? Testing database connection...
? Database connection successful
?? PostgreSQL Version: 14.x
???  Testing PostGIS extension...
? PostGIS extension is available
```

### Running Tests

#### Unit Tests
```bash
# In Visual Studio Test Explorer
# Test -> Run All Tests

# Or using command line with NUnit Console Runner
nunit3-console.exe src\SunnySeat.Tests\bin\Debug\SunnySeat.Tests.dll
```

#### Integration Tests
Integration tests marked as `[Explicit]` require a running PostgreSQL instance:
```bash
# Run specific explicit tests
nunit3-console.exe src\SunnySeat.Tests\bin\Debug\SunnySeat.Tests.dll --where "cat == Explicit"
```

## Project Structure

```
Sol/
??? Sol.sln                           # Main solution file
??? Sol.csproj                        # Console test application
??? App.config                        # Configuration including connection strings
??? docs/                            # Project documentation
?   ??? architecture/                # Architecture documentation
?   ??? prd/                        # Product requirements
?   ??? stories/                    # Development stories
??? src/                            # Source code
    ??? SunnySeat.Core/             # Domain entities and interfaces
    ??? SunnySeat.Data/             # Data access with Entity Framework
    ??? SunnySeat.Tests/            # Unit and integration tests
```

## Development Workflow

1. **Create Feature Branch**
   ```bash
   git checkout -b feature/your-feature-name
   ```

2. **Make Changes**
   - Follow coding standards in `docs/architecture/coding-standards.md`
   - Write unit tests for new functionality
   - Update documentation as needed

3. **Test Changes**
   ```bash
   # Build solution
   msbuild Sol.sln
   
   # Run tests
   nunit3-console.exe src\SunnySeat.Tests\bin\Debug\SunnySeat.Tests.dll
   
   # Test database connectivity
   bin\Debug\Sol.exe
   ```

4. **Commit and Push**
   ```bash
   git add .
   git commit -m "Your commit message"
   git push origin feature/your-feature-name
   ```

## Troubleshooting

### Common Issues

#### "Connection string not found"
- Verify `App.config` has correct connection string name: `SunnySeatConnection`
- Check that `App.config` is copied to output directory

#### "Could not load file or assembly 'Npgsql'"
- Restore NuGet packages: `Update-Package -Reinstall`
- Check that Npgsql version is compatible with .NET Framework 4.8

#### "PostGIS extension not found"
- Install PostGIS extension in PostgreSQL
- Verify extension is enabled: `SELECT * FROM pg_extension WHERE extname = 'postgis';`

#### Build Errors
- Clean and rebuild solution: `Build -> Clean Solution`, then `Build -> Rebuild Solution`
- Check that all project references are correct
- Verify .NET Framework 4.8 targeting pack is installed

### Database Connection Issues
1. Verify PostgreSQL service is running
2. Check firewall settings (default port 5432)
3. Verify user permissions on database
4. Test connection with pgAdmin or psql command line

## Next Steps

After successful setup:
1. Run Entity Framework migrations (when implemented)
2. Seed initial data (when seed scripts are available)
3. Start implementing business logic in SunnySeat.Services
4. Add Web API layer in SunnySeat.Web

## Support

For development questions, refer to:
- Architecture documentation in `docs/architecture/`
- Coding standards in `docs/architecture/coding-standards.md`
- Project stories in `docs/stories/`