# Epic 03: Admin Tooling

## Epic Goal
Create web-based administrative interface for mapping patio polygons, managing venue data, and importing geographic data to support manual patio definition workflow.

## Epic Description

**Functional Context:**
- Admin users need to draw/edit patio polygons for venues
- Support for importing GeoPackage (.gpkg) and GeoJSON files
- Quality flags and metadata management per patio
- Batch operations for efficient venue management

**Technical Implementation:**
- Web-based polygon editing interface
- Integration with mapping library (MapLibre GL or similar)
- File upload and processing capabilities
- Basic authentication for admin access

## User Stories

### Story 3.1: Admin Authentication & Access
**As an** admin user **I want** secure access to administrative functions **so that** only authorized users can modify venue and patio data.

**Acceptance Criteria:**
- [ ] Basic authentication system implemented
- [ ] Admin login page with username/password
- [ ] Session management for admin users
- [ ] Role-based access control (admin role)
- [ ] Logout functionality
- [ ] Password security best practices
- [ ] Admin access logging for audit trail

### Story 3.2: Venue Management Interface
**As an** admin **I want** to create and manage venue records **so that** I can maintain accurate venue information.

**Acceptance Criteria:**
- [ ] Venue list view with search and filtering
- [ ] Venue creation form with required fields (name, location, district, price_level)
- [ ] Venue editing capabilities
- [ ] Venue deletion with confirmation
- [ ] Bulk venue import from CSV/spreadsheet
- [ ] Data validation and error handling
- [ ] Audit trail for venue changes

### Story 3.3: Interactive Patio Polygon Editor
**As an** admin **I want** to draw and edit patio polygons on a map **so that** I can accurately define patio boundaries for sun calculations.

**Acceptance Criteria:**
- [ ] Interactive map interface using MapLibre GL
- [ ] Polygon drawing tools (click to create vertices)
- [ ] Polygon editing capabilities (move vertices, add/remove points)
- [ ] Snap-to functionality for precise drawing
- [ ] Undo/redo operations for polygon editing
- [ ] Visual feedback during drawing/editing
- [ ] Save polygon with associated venue
- [ ] Validation for minimum polygon requirements

### Story 3.4: Patio Metadata Management
**As an** admin **I want** to set quality flags and metadata for patios **so that** the system can track data quality and adjust calculations.

**Acceptance Criteria:**
- [ ] Patio metadata form (orientation, height overrides, notes)
- [ ] Quality flags: `height_source`, `polygon_quality`, `review_needed`
- [ ] Height override capability for specific patios
- [ ] Quality scoring (0-1 scale) for polygon accuracy
- [ ] Review workflow for flagged patios
- [ ] Bulk metadata operations
- [ ] Data quality reporting dashboard

### Story 3.5: GeoData Import Capabilities
**As an** admin **I want** to import geographic data files **so that** I can efficiently bulk-load patio and building data.

**Acceptance Criteria:**
- [ ] File upload interface for .gpkg and GeoJSON files
- [ ] File validation and format checking
- [ ] Preview import data before processing
- [ ] Batch import processing with progress indication
- [ ] Error handling and validation reporting
- [ ] Import history and rollback capabilities
- [ ] Mapping between file fields and database schema

## Technical Dependencies
- Web framework for admin interface (.NET MVC or Web API + SPA)
- MapLibre GL JS for interactive mapping
- File upload and processing libraries
- Authentication framework

## User Experience Requirements
- Responsive design for desktop/tablet use
- Intuitive polygon drawing interface
- Clear visual feedback for all operations
- Error messages and validation guidance

## Definition of Done
- [ ] All stories completed with acceptance criteria met
- [ ] Admin interface is fully functional and secure
- [ ] Polygon editing supports all required operations
- [ ] Import capabilities handle expected file formats
- [ ] Data quality tracking is comprehensive
- [ ] User experience meets usability standards

## Success Metrics
- Admin users can map 5 patios in < 10 minutes
- Polygon accuracy meets quality standards (>0.8 quality score)
- Import success rate > 95% for valid files
- Zero security vulnerabilities in admin interface