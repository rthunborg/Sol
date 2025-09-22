# Epic 05: Solar & Shadow Engine

## Epic Goal
Implement the core solar position calculations and 2.5D shadow casting algorithms to determine which patios are in direct sunlight at any given time.

## Epic Description

**Algorithm Context:**
- Solar position calculations using astronomical formulas
- 2.5D shadow casting from building footprints with heights
- Polygon intersection calculations for patio sun/shade determination
- Precomputation system for performance optimization

**Technical Implementation:**
- Solar ephemeris calculations (SPA/NREL equivalent)
- Shadow polygon generation from building geometry
- Spatial geometry operations for shadow-patio intersection
- Caching and precomputation for real-time performance

## User Stories

### Story 5.1: Solar Position Calculator
**As a** developer **I want** accurate solar position calculations **so that** I can determine sun angle and direction for any timestamp in Gothenburg.

**Acceptance Criteria:**
- [ ] Solar position algorithm implemented (azimuth, elevation)
- [ ] Time zone handling for Gothenburg (Europe/Stockholm)
- [ ] Daylight Saving Time adjustments
- [ ] Solar position accuracy validated against reference sources
- [ ] Sunrise/sunset time calculations
- [ ] Solar position caching for performance
- [ ] Unit tests covering edge cases (winter/summer solstice, equinox)

### Story 5.2: 2.5D Shadow Casting Algorithm
**As a** developer **I want** to cast shadows from buildings **so that** I can determine which areas are shaded at specific times.

**Acceptance Criteria:**
- [ ] Building extrusion algorithm (2D footprint + height ? 3D volume)
- [ ] Shadow polygon calculation based on sun position
- [ ] Efficient shadow casting for multiple buildings
- [ ] Shadow polygon simplification for performance
- [ ] Shadow intersection detection with ground plane
- [ ] Shadow merging for overlapping building shadows
- [ ] Algorithm validation with test cases

### Story 5.3: Patio Sun/Shade Determination
**As a** developer **I want** to determine patio illumination status **so that** I can classify patios as sunny, partial, or shaded.

**Acceptance Criteria:**
- [ ] Patio-shadow intersection algorithm
- [ ] Sun coverage percentage calculation for patios
- [ ] Classification logic (Sunny: >80%, Partial: 20-80%, Shaded: <20%)
- [ ] Handling of complex patio shapes
- [ ] Performance optimization for multiple patio checks
- [ ] Edge case handling (sunrise/sunset transitions)
- [ ] Accuracy validation with real-world spot checks

### Story 5.4: Sun Window Precomputation
**As a** developer **I want** to precompute daily sun windows **so that** users get instant responses about when patios will be sunny.

**Acceptance Criteria:**
- [ ] Daily precomputation job for all patios
- [ ] Sun window calculation (continuous sunny periods)
- [ ] Today and tomorrow precomputation
- [ ] Minute-level granularity for accuracy
- [ ] Efficient storage of sun window data
- [ ] Incremental updates for changed building/patio data
- [ ] Precomputation monitoring and error handling

### Story 5.5: Shadow Calculation Performance Optimization
**As a** developer **I want** optimized shadow calculations **so that** the system can handle real-time requests efficiently.

**Acceptance Criteria:**
- [ ] Spatial indexing for efficient building queries
- [ ] Shadow calculation result caching
- [ ] Geometry simplification for performance
- [ ] Parallel processing for multiple calculations
- [ ] Memory management for large datasets
- [ ] Performance benchmarking and monitoring
- [ ] Response time < 200ms for typical patio queries

## Technical Dependencies
- Spatial geometry libraries (PostGIS, NetTopologySuite)
- Mathematical libraries for solar calculations
- High-precision coordinate system transformations
- Efficient polygon operations

## Algorithm Requirements
- Solar position accuracy: ±0.1 degrees
- Shadow casting accuracy: ±1 meter at ground level
- Sun window detection: ±2 minute precision
- Performance: Handle 100+ patio calculations per second

## Validation Requirements
- Cross-reference with NREL Solar Position Algorithm
- Real-world validation with sun/shade observations
- Edge case testing (polar day effects, building heights)
- Performance testing with production-scale data

## Definition of Done
- [ ] All stories completed with acceptance criteria met
- [ ] Solar calculations match reference implementations
- [ ] Shadow casting produces accurate results
- [ ] Precomputation system runs reliably
- [ ] Performance requirements are met
- [ ] Comprehensive test coverage including edge cases

## Success Metrics
- Solar position accuracy within ±0.1 degrees
- Patio classification accuracy >90% vs. real observations
- Precomputation completes in <30 minutes for all Gothenburg patios
- Real-time query response time <200ms