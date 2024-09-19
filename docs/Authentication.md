## Authentication

## Authentication
### Register a new user
#### Request
- Method: POST
- URL: /auth/sign-up
- Headers: 
    - Content-Type: application/json

- Body:
- Body:
```json
{
  "name": "João da Silva",
  "email": "john.doe@emai.com",
  "phone": "16999999999",
  "password": "123456"
}
```

#### Response
- Status: 201 Created
- body:
```json
{
  "id": "8f14e45f-e62b-47e1-8d5e-2d6e734a4ff3",
  "name": "João da Silva",
  "email": "john.doe@emai.com",
    "phone": "16999999999",
    "created_at": "2024-07-24T14:45:30Z",
    "updated_at": "2024-07-24T14:45:30Z"
}
```

### Login
#### Request
- Method: POST
- URL: /auth/sign-in
- Headers: 
    - Content-Type: application/json
- Body:
```json
{
  "email": "joh@gmail.coM",
  "password": "xpto"
}
```

#### Response
- Status: 200 OK
- Body:
```json
{
  "access_token": "DANSDNANDAN",
    "token_type": "Bearer",
    "expires_in": 3600,
    "refresh_token": "DANSDNANDAN",
    "refresh_token_expires_in": 3600
}
```

### Refresh token
#### Request
- Method: POST
- URL: /auth/refresh-token
- Headers: 
    - Content-Type: application/json
- Body:
```json
{
  "refresh_token": "DANSDNANDAN"
}
```

#### Response
- Status: 200 OK
- Body:
```json
{
  "access_token": "dasdas",
    "token_type": "Bearer",
    "expires_in": 3600,
    "refresh_token": "DANSDNANDAN",
    "refresh_token_expires_in": 3600
}
```

### Logout
#### Request
- Method: POST
- URL: /auth/logout
- Headers: 
    - Authorization: Bearer
- Body: Empty

#### Response
- Status: 204 No Content