
## Donor
### Get all donors
#### Request
- Method: GET
- URL: /donors?fetch=10&offset=0&sort_by=created_at&sort_order=desc
- Query String:
  - fetch: Number of records to fetch
  - offset: Number of records to skip
  - sort_by: Field to sort by
  - sort_order: asc or desc
- Headers: 
    - Authorization: Bearer {TOKEN}

#### Response
- Status: 200 OK
- Body:
```json
{
  "records_count": 1,
  "records": [
    {
      "id": "8f14e45f-e62b-47e1-8d5e-2d6e734a4ff3",
      "name": "João da Silva",
      "email": "john.doe@email.com",
      "phone": "+5511999999999",
      "created_at": "2024-07-24T14:45:30Z",
      "updated_at": "2024-07-24T14:45:30Z"
    } 
  ] 
}
```

### Get a donor by ID
#### Request
- Method: GET
- URL: /donors/{ID}
- Path Parameters:
  - ID: ID of the donor
- Headers: 
    - Authorization: Bearer {TOKEN}

#### Response
- Status: 200 OK
- Body:
```json
 {
      "id": "8f14e45f-e62b-47e1-8d5e-2d6e734a4ff3",
      "name": "João da Silva",
      "email": "john.doe@email.com",
      "phone": "+5511999999999",
      "created_at": "2024-07-24T14:45:30Z",
      "updated_at": "2024-07-24T14:45:30Z"
    } 
```

### Create a donor
#### Request
- Method: POST
- URL: /donors
- Headers: 
    - Authorization: Bearer {TOKEN}
- Body:
```json
{
   "name": "João da Silva",
      "email": "john.doe@email.com",
      "phone": "+5511999999999"
}
```

#### Response
- Status: 201 Created
- Headers:
    - Location: /donors/8f14e45f-e62b-47e1-8d5e-2d6e734a4ff3
- Body:
```json
 {
      "id": "8f14e45f-e62b-47e1-8d5e-2d6e734a4ff3",
      "name": "João da Silva",
      "email": "john.doe@email.com",
      "phone": "+5511999999999",
      "created_at": "2024-07-24T14:45:30Z",
      "updated_at": "2024-07-24T14:45:30Z"
    } 
```

### Update a donor
#### Request
- Method: PUT
- URL: /donors/{ID}
- Path Parameters:
  - ID: ID of the donor
- Headers: 
  - Authorization: Bearer
  - Content-Type: application/json

- Body:
```json
{
  "name": "João da Silva",
  "email": "john.doe@email.com",
  "phone": "+5511999999999"
}
```

#### Response
- Status: 204 No Content
- Body: Empty
- Headers:
    - Location: /donors/8f14e45f-e62b-47e1-8d5e-2d6e734a4ff3

### Delete a donor
#### Request
- Method: DELETE
- URL: /donors/{ID}
- Path Parameters:
  - ID: ID of the donor
- Headers: 
  - Authorization: Bearer
- Body: Empty

#### Response
- Status: 204 No Content
- Body: Empty
