# Epic 02: Database Foundation

## Epic Goal
Establish the PostgreSQL + PostGIS database schema, migration system, and basic data access layer to support venue, patio, and building data operations.

## Epic Description

**Technical Context:**
- PostgreSQL 12+ with PostGIS for spatial data operations
- Entity Framework or direct SQL approach for data access
- Support for geometric data types and spatial queries
- Migration-based schema management

**Database Requirements:**
- Complete schema implementation for core entities
- Spatial indexing for performance
- Data migration and seeding capabilities
- Connection pooling and performance optimization

## User Stories

### Story 2.1: Database Schema Implementation
**As a** developer **I want** a complete database schema **so that** I can store and query venue, patio, building, and related spatial data.

**Acceptance Criteria:**
- [ ] Database schema created matching PRD data model specification
- [ ] Core tables: `venue`, `patio`, `building`, `sun_window`, `weather_slice`, `feedback`
- [ ] PostGIS geometry columns properly configured for spatial data
- [ ] Primary keys, foreign keys, and constraints implemented
- [ ] Spatial indexes (GIST) created for geography columns
- [ ] Database creation scripts provided for all environments
- [ ] Schema documentation generated

### Story 2.2: Data Migration System
**As a** developer **I want** a migration system **so that** I can evolve the database schema safely across environments.

**Acceptance Criteria:**
- [ ] Migration framework implemented (Entity Framework or custom)
- [ ] Initial migration creates complete schema
- [ ] Migration scripts are reversible where possible
- [ ] Environment-specific migration execution procedures
- [ ] Migration status tracking and validation
- [ ] Backup procedures before migrations
- [ ] Documentation for migration workflow

### Story 2.3: Data Access Layer
**As a** developer **I want** a data access layer **so that** I can perform CRUD operations and spatial queries efficiently.

**Acceptance Criteria:**
- [ ] Repository pattern or equivalent data access implementation
- [ ] Basic CRUD operations for all core entities
- [ ] Spatial query capabilities (point-in-polygon, distance calculations)
- [ ] Connection string management and connection pooling
- [ ] Error handling and transaction management
- [ ] Unit tests for data access operations
- [ ] Performance logging for database operations

### Story 2.4: Initial Data Seeding
**As a** developer **I want** seed data capabilities **so that** I can populate the database with test data for development.

**Acceptance Criteria:**
- [ ] Data seeding framework implemented
- [ ] Sample venue data for Gothenburg (5-10 test venues)
- [ ] Sample building footprint data
- [ ] Test patio polygon data
- [ ] Seed data scripts for different environments
- [ ] Data validation after seeding
- [ ] Clear separation between test and production seed data

## Technical Dependencies
- PostgreSQL 12+ server
- PostGIS extension
- .NET Framework 4.8 data access libraries
- Connection to Lantmäteriet building data (for reference)

## Performance Requirements
- Database query response time < 100ms for simple operations
- Spatial queries optimized with proper indexing
- Support for concurrent connections (development: 10+, production: 100+)

## Definition of Done
- [ ] All stories completed with acceptance criteria met
- [ ] Database schema matches PRD specification exactly
- [ ] Migration system tested across environments
- [ ] Data access layer supports all planned operations
- [ ] Performance requirements met
- [ ] Comprehensive test coverage for data operations

## Success Metrics
- Zero data corruption during migrations
- Spatial query performance < 200ms for typical operations
- 100% test coverage for data access layer critical paths