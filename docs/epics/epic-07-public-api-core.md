# Epic 07: Public API & Core Frontend

## Epic Goal
Implement the public REST API endpoints and core React frontend that enable users to find sunny patios now and view venue sun windows for today/tomorrow.

## Epic Description

**API Context:**
- REST endpoints for patio search, venue details, and user feedback
- Performance optimizations with caching and response time requirements
- Error handling and rate limiting for public API
- OpenAPI documentation for API clarity

**Frontend Context:**
- React application with MapLibre GL for interactive mapping
- Responsive design for mobile and desktop users
- Core user journeys: search patios, view venue details
- Confidence display and user feedback collection

## User Stories

### Story 7.1: Public API Implementation
**As a** frontend developer **I want** REST API endpoints **so that** I can build the user interface for patio search and venue details.

**Acceptance Criteria:**
- [ ] `GET /api/patios` endpoint with location and radius parameters
- [ ] `GET /api/venues/{id}` endpoint for venue details and sun windows
- [ ] `POST /api/feedback` endpoint for user accuracy feedback
- [ ] API response time <400ms p95 (per PRD requirements)
- [ ] Rate limiting: 60 rpm/IP for patios, 120 rpm/IP for venues
- [ ] Error responses with proper HTTP status codes
- [ ] OpenAPI/Swagger documentation generated

### Story 7.2: Patio Search API Logic
**As a** user **I want** to search for sunny patios near me **so that** I can find sunny spots within my desired radius.

**Acceptance Criteria:**
- [ ] Location-based search with lat/lng parameters
- [ ] Radius filtering (default 1.5km, max 3km, 422 error if exceeded)
- [ ] Current sun state calculation (Sunny/Partial/Shaded)
- [ ] Confidence percentage for each patio
- [ ] Mini 2-hour timeline with 10-minute ticks
- [ ] Distance calculation and sorting
- [ ] Geofencing (no results >10km from query point)
- [ ] Empty state handling (<3 sunny patios)

### Story 7.3: Venue Details API Logic
**As a** user **I want** detailed venue information **so that** I can see when a specific venue will be sunny today and tomorrow.

**Acceptance Criteria:**
- [ ] Venue basic information (name, location, district, price level)
- [ ] Sun windows for today and tomorrow
- [ ] Per-window confidence percentages
- [ ] "No direct sun expected" messaging with reason badges
- [ ] Data freshness indicators
- [ ] Shareable deep links with venue and date
- [ ] Auto-refresh every 5 minutes when page is open

### Story 7.4: React Frontend Foundation
**As a** user **I want** a responsive web application **so that** I can easily find sunny patios on both mobile and desktop devices.

**Acceptance Criteria:**
- [ ] React application with modern build setup (Create React App or Vite)
- [ ] MapLibre GL integration for interactive mapping
- [ ] Responsive design (mobile-first approach)
- [ ] Component library setup and design system basics
- [ ] Routing setup for different views (map, venue details)
- [ ] State management for API data
- [ ] Loading states and error handling UI

### Story 7.5: Map-Based Patio Search
**As a** user **I want** to see patios on an interactive map **so that** I can visually explore sunny options in my area.

**Acceptance Criteria:**
- [ ] Interactive map with MapLibre GL
- [ ] Patio markers with sun state visual indicators
- [ ] Clustered markers for performance
- [ ] Map pan/zoom ?50 FPS on mobile, ?60 FPS on desktop
- [ ] Location permission request and fallback to manual pin
- [ ] Radius selector (1-3km with visual indicator)
- [ ] Map bounds synchronized with patio search results

### Story 7.6: Patio List View & Filters
**As a** user **I want** a list view of patios **so that** I can quickly scan options and apply filters.

**Acceptance Criteria:**
- [ ] List view synchronized with map bounds
- [ ] Sort by distance and confidence
- [ ] Filter by district, price level
- [ ] Search by venue name
- [ ] Result cards showing: name, distance, current state, confidence, mini timeline
- [ ] Smooth switching between map and list views
- [ ] Infinite scroll or pagination for large result sets

### Story 7.7: Venue Detail Page
**As a** user **I want** detailed venue pages **so that** I can see comprehensive sun information and plan visits.

**Acceptance Criteria:**
- [ ] Venue information display
- [ ] Patio polygon overlay on map
- [ ] Today and tomorrow sun windows
- [ ] Confidence badges with explanations
- [ ] Share link functionality
- [ ] Automatic refresh every 5 minutes
- [ ] "No sun expected" states with reason explanations

### Story 7.8: User Feedback System
**As a** user **I want** to provide feedback on accuracy **so that** the system can improve its predictions.

**Acceptance Criteria:**
- [ ] One-tap feedback (Yes/No) for "was it sunny?"
- [ ] Feedback submission via POST /api/feedback
- [ ] Feedback data collection (venue, time, predicted vs actual state)
- [ ] User feedback history and thank you messaging
- [ ] Privacy-compliant feedback collection
- [ ] Feedback analytics for system improvement

## Technical Dependencies
- .NET Framework 4.8 Web API
- React 18+ with modern tooling
- MapLibre GL JS for mapping
- HTTP client libraries for API calls

## Performance Requirements
- API endpoints: p95 <400ms at 100 RPS
- Frontend: First meaningful paint <2s on 4G
- Map performance: 50+ FPS mobile, 60+ FPS desktop
- Bundle size optimization for mobile users

## User Experience Requirements
- Mobile-first responsive design
- Accessibility compliance (WCAG AA)
- Intuitive navigation and clear information hierarchy
- Fast loading and smooth interactions

## Definition of Done
- [ ] All stories completed with acceptance criteria met
- [ ] API endpoints meet performance requirements
- [ ] Frontend provides excellent user experience
- [ ] Core user journeys work seamlessly
- [ ] Rate limiting and error handling work properly
- [ ] Comprehensive testing coverage

## Success Metrics
- API response times meet p95 <400ms requirement
- User engagement: >60% find sunny patio within 2 minutes
- Feedback collection: >10% of users provide accuracy feedback
- Performance: 95%+ of users have good loading experience