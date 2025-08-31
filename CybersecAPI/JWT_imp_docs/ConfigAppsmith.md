Create a login form that calls your /api/auth/login endpoint
Store the JWT token (in AppSmith's store or local storage)
Add the token to API headers for all subsequent requests:

// In AppSmith API settings, add header:
Authorization: "Bearer " + appsmith.store.authToken