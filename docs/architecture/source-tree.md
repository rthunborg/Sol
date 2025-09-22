# Source Tree Structure

## Project Directory Structure

### Root Level Organization
```
Sol/                                    # Solution root directory
??? Sol.sln                            # Visual Studio solution file
??? README.md                          # Project documentation
??? .gitignore                         # Git ignore rules
??? docs/                              # Project documentation
?   ??? architecture/                  # Architecture documentation
?   ??? prd/                          # Product requirements (sharded)
?   ??? stories/                      # Development stories
??? src/                              # Source code directory
```

### Source Code Structure (.NET Framework 4.8)

```
src/
??? SunnySeat.Core/                    # Domain layer
?   ??? Entities/                      # Domain entities
?   ?   ??? Venue.cs
?   ?   ??? Patio.cs
?   ?   ??? Building.cs
?   ?   ??? Prediction.cs
?   ?   ??? WeatherSlice.cs
?   ?   ??? Feedback.cs
?   ??? Interfaces/                    # Domain interfaces
?   ?   ??? Repositories/
?   ?   ?   ??? IVenueRepository.cs
?   ?   ?   ??? IPatioRepository.cs
?   ?   ?   ??? IBuildingRepository.cs
?   ?   ??? Services/
?   ?       ??? IWeatherService.cs
?   ?       ??? ISolarCalculationService.cs
?   ?       ??? IGeometryService.cs
?   ??? ValueObjects/                  # Domain value objects
?   ?   ??? GeographicPoint.cs
?   ?   ??? SunWindow.cs
?   ?   ??? ConfidenceLevel.cs
?   ??? Enums/                        # Domain enumerations
?       ??? SunlightState.cs
?       ??? DistrictType.cs
?       ??? PriceLevel.cs
?
??? SunnySeat.Data/                    # Data access layer
?   ??? Context/
?   ?   ??? SunnySeatDbContext.cs     # Entity Framework context
?   ??? Configurations/               # Entity configurations
?   ?   ??? VenueConfiguration.cs
?   ?   ??? PatioConfiguration.cs
?   ?   ??? BuildingConfiguration.cs
?   ?   ??? PredictionConfiguration.cs
?   ?   ??? WeatherSliceConfiguration.cs
?   ?   ??? FeedbackConfiguration.cs
?   ??? Repositories/                 # Repository implementations
?   ?   ??? VenueRepository.cs
?   ?   ??? PatioRepository.cs
?   ?   ??? BuildingRepository.cs
?   ?   ??? PredictionRepository.cs
?   ?   ??? WeatherSliceRepository.cs
?   ?   ??? FeedbackRepository.cs
?   ??? Migrations/                   # EF migrations
?   ?   ??? [Generated migration files]
?   ??? Seeds/                        # Database seed data
?       ??? InitialDataSeed.cs
?
??? SunnySeat.Services/               # Business logic layer
?   ??? WeatherService.cs             # Weather data integration
?   ??? SolarCalculationService.cs    # Solar position calculations
?   ??? ShadowModelingService.cs      # 2.5D shadow calculations
?   ??? GeometryService.cs            # Spatial operations
?   ??? VenueService.cs               # Venue business logic
?   ??? PatioService.cs               # Patio business logic
?   ??? PredictionService.cs          # Sun window predictions
?   ??? ConfidenceService.cs          # Confidence calculations
?   ??? FeedbackService.cs            # User feedback processing
?
??? SunnySeat.Web/                    # Web API layer
?   ??? Controllers/                  # API controllers
?   ?   ??? PatiosController.cs       # /api/patios endpoints
?   ?   ??? VenuesController.cs       # /api/venues endpoints
?   ?   ??? FeedbackController.cs     # /api/feedback endpoints
?   ?   ??? AdminController.cs        # Admin API endpoints
?   ??? Models/                       # API models/DTOs
?   ?   ??? Requests/
?   ?   ?   ??? PatioSearchRequest.cs
?   ?   ?   ??? FeedbackRequest.cs
?   ?   ?   ??? VenueCreateRequest.cs
?   ?   ??? Responses/
?   ?       ??? PatioResponse.cs
?   ?       ??? VenueResponse.cs
?   ?       ??? SunWindowResponse.cs
?   ?       ??? ErrorResponse.cs
?   ??? Filters/                      # Action filters
?   ?   ??? RateLimitAttribute.cs
?   ?   ??? ValidationAttribute.cs
?   ?   ??? ExceptionHandlingAttribute.cs
?   ??? App_Start/                    # Application startup
?   ?   ??? WebApiConfig.cs
?   ?   ??? DependencyConfig.cs
?   ?   ??? AutoMapperConfig.cs
?   ??? Global.asax                   # Application entry point
?   ??? Global.asax.cs
?   ??? Web.config                    # Web configuration
?   ??? packages.config               # NuGet packages
?
??? SunnySeat.Workers/                # Background workers
?   ??? SolarPredictionWorker.cs      # Daily sun window calculations
?   ??? WeatherIngestionWorker.cs     # Weather data polling
?   ??? DataCleanupWorker.cs          # Cleanup old data
?
??? SunnySeat.Tests/                  # Test projects
    ??? SunnySeat.Core.Tests/         # Core layer tests
    ?   ??? Entities/
    ?   ??? ValueObjects/
    ?   ??? TestHelpers/
    ??? SunnySeat.Data.Tests/         # Data layer tests
    ?   ??? Repositories/
    ?   ??? Configurations/
    ?   ??? Integration/
    ??? SunnySeat.Services.Tests/     # Service layer tests
    ?   ??? WeatherServiceTests.cs
    ?   ??? SolarCalculationServiceTests.cs
    ?   ??? GeometryServiceTests.cs
    ??? SunnySeat.Web.Tests/          # Web layer tests
        ??? Controllers/
        ??? Models/
        ??? Integration/
```

### Configuration Files

#### Solution Level
- `Sol.sln` - Visual Studio solution file
- `.gitignore` - Git ignore patterns for .NET projects
- `README.md` - Project overview and setup instructions

#### Project Level
- `packages.config` - NuGet package references (.NET Framework style)
- `app.config` - Application configuration (for console apps/workers)
- `web.config` - Web application configuration (for Web API)

### File Naming Conventions

#### Entity Files
- Singular nouns: `Venue.cs`, `Patio.cs`, `Building.cs`
- Match database table names

#### Repository Files
- Interface: `IVenueRepository.cs`
- Implementation: `VenueRepository.cs`

#### Service Files
- Interface: `IWeatherService.cs`
- Implementation: `WeatherService.cs`

#### Controller Files
- Plural nouns: `VenuesController.cs`, `PatiosController.cs`
- Follow RESTful naming conventions

#### Test Files
- Test class per production class: `VenueServiceTests.cs`
- Integration tests: `VenueRepositoryIntegrationTests.cs`

### External Dependencies

#### Data Files (Local)
```
data/                                 # Local data files (not in source control)
??? building-footprints.gpkg         # Lantmäteriet building data
??? seed-venues.json                 # Initial venue data
??? test-data/                       # Test datasets
```

#### Build Artifacts
```
bin/                                 # Compiled binaries (not in source control)
obj/                                 # Build objects (not in source control)
packages/                            # NuGet packages (not in source control with packages.config)
```

### Development Environment Setup

#### Required Directories
1. Clone repository to development machine
2. Restore NuGet packages using Visual Studio or Package Manager Console
3. Create local `data/` directory for external data files
4. Configure local PostgreSQL database
5. Run initial Entity Framework migrations

#### Database Setup
- Local PostgreSQL instance with PostGIS extension
- Development database: `sunnyseat_dev`
- Test database: `sunnyseat_test`
- Connection strings in `app.config`/`web.config`