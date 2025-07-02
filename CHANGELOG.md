# Changelog

## [LATEST] - 2025-07-02

### Breaking Changes
- **Environment Variable Change:**  
  The environment variable for configuring the Redis connection string has changed.  
  **Old:** `REDIS_CONNECTION`  
  **New:** `Database__ConnectionString`  
  Update your deployment scripts and Docker run commands to use `--env Database__ConnectionString=your_connection_string` instead of `--env REDIS_CONNECTION=your_connection_string`