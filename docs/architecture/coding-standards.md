# Coding Standards

## .NET Framework 4.8 Coding Standards

### General Principles
- Follow Microsoft's C# Coding Conventions
- Use meaningful, descriptive names for all identifiers
- Write self-documenting code with clear intent
- Prefer composition over inheritance
- Follow SOLID principles

### Naming Conventions

#### Classes and Methods
- **PascalCase** for class names, method names, and public properties
- **camelCase** for private fields and local variables
- **UPPER_CASE** for constants

```csharp
public class VenueService
{
    private readonly IPatioRepository _patioRepository;
    public const int MAX_SEARCH_RADIUS = 3000;
    
    public async Task<Venue> GetVenueByIdAsync(int venueId)
    {
        // Implementation
    }
}
```

#### Database Entities
- Use singular nouns for entity classes (e.g., `Venue`, not `Venues`)
- Match database table names with entity class names
- Use descriptive property names that match database column names

### File Organization

#### Project Structure
```
SunnySeat/
??? SunnySeat.Core/           # Domain entities and interfaces
??? SunnySeat.Data/           # Data access layer
??? SunnySeat.Services/       # Business logic services
??? SunnySeat.Web/           # Web API controllers
??? SunnySeat.Tests/         # Unit and integration tests
```

#### Namespace Conventions
- Root namespace: `SunnySeat`
- Follow folder structure: `SunnySeat.Data.Repositories`
- One class per file (with few exceptions)

### Database & Entity Framework Standards

#### Entity Configuration
- Use Fluent API configuration in separate configuration classes
- Place configurations in `SunnySeat.Data.Configurations`
- Use meaningful constraint names

```csharp
public class VenueConfiguration : EntityTypeConfiguration<Venue>
{
    public VenueConfiguration()
    {
        HasKey(v => v.Id);
        Property(v => v.Name).IsRequired().HasMaxLength(200);
        Property(v => v.Location).IsRequired();
    }
}
```

#### PostGIS Spatial Data
- Use NetTopologySuite geometry types
- Configure spatial reference systems explicitly
- Use appropriate spatial indexes (GIST)

### Error Handling

#### Exception Handling
- Use specific exception types when possible
- Log exceptions with sufficient context
- Don't catch and rethrow without adding value
- Use `using` statements for disposable resources

```csharp
public async Task<Venue> GetVenueAsync(int id)
{
    try
    {
        return await _repository.FindByIdAsync(id);
    }
    catch (EntityNotFoundException ex)
    {
        _logger.LogWarning("Venue not found: {VenueId}", id);
        throw new VenueNotFoundException($"Venue with ID {id} not found", ex);
    }
}
```

### API Standards

#### RESTful API Design
- Use HTTP verbs appropriately (GET, POST, PUT, DELETE)
- Return appropriate HTTP status codes
- Use consistent JSON response formats
- Include proper error responses

```csharp
[HttpGet("api/venues/{id}")]
public async Task<IHttpActionResult> GetVenue(int id)
{
    var venue = await _venueService.GetVenueAsync(id);
    if (venue == null)
        return NotFound();
    
    return Ok(venue);
}
```

### Testing Standards

#### Unit Test Conventions
- One test class per production class
- Descriptive test method names: `Method_Scenario_ExpectedResult`
- Use AAA pattern: Arrange, Act, Assert
- Mock external dependencies

```csharp
[Test]
public async Task GetVenue_WithValidId_ReturnsVenue()
{
    // Arrange
    var venueId = 1;
    var expectedVenue = new Venue { Id = venueId, Name = "Test Venue" };
    _mockRepository.Setup(r => r.FindByIdAsync(venueId)).ReturnsAsync(expectedVenue);
    
    // Act
    var result = await _venueService.GetVenueAsync(venueId);
    
    // Assert
    Assert.That(result, Is.EqualTo(expectedVenue));
}
```

### Configuration Management

#### Connection Strings
- Store in `app.config` or `web.config`
- Use different configurations for different environments
- Never commit sensitive credentials to source control

#### Application Settings
- Use `appSettings` section for configuration values
- Use configuration transformation for environment-specific values

### Performance Guidelines

#### Database Access
- Use async/await for database operations
- Implement proper connection pooling
- Use appropriate lazy loading strategies
- Index spatial queries properly

#### Spatial Operations
- Cache precomputed spatial results when possible
- Use appropriate spatial indexes
- Minimize geometry precision where appropriate

### Security Standards

#### Data Protection
- Sanitize all user inputs
- Use parameterized queries (Entity Framework handles this)
- Implement proper authentication and authorization
- Log security-relevant events

#### API Security
- Implement rate limiting
- Use HTTPS in production
- Validate all input parameters
- Return minimal error information to clients