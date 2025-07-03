# Changelog

## [1.0.0] - 2025-07-03

### Updates
- Migrate to .Net 7
- Semantic versioning

### Breaking Changes
- **Environment Variable Change:**  
  The environment variable for configuring the Redis connection string has changed.  
  **Old:** `REDIS_CONNECTION`  
  **New:** `Database__ConnectionString`  
  Update your deployment scripts and Docker run commands to use `--env Database__ConnectionString=your_connection_string` instead of `--env REDIS_CONNECTION=your_connection_string`

## Past Versions

All changes were pushed as [LATEST], they were simple changes like .Net Migrations and initial features like adding Redis types `String` and `SortedSet`.