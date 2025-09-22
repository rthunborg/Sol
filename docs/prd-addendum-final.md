# PRD v0.2 — Addendum (Final)

## A1) API Rate Limits & 429
- Defaults: 60 rpm/IP (`/api/patios`), 120 rpm/IP (`/api/venues/{id}`), 30 rpm/IP (`/api/feedback`).
- 429 JSON: `{ "error": "rate_limited", "retry_after": <seconds> }` + `Retry‑After` header; backoff with jitter (max 3 retries).

## A2) Data Retention & Backups
- Weather slices 14 days; feedback 1 year; daily backups; PITR ≥7 days.

## A3) SLO & Error Budget
- 99% during 06:00–22:00 local; 1%/month budget; SLIs: p95 <400 ms, edge cache hit >50%, accuracy ≥85%.
