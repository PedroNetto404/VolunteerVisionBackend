## Donation Collect Point
### Get all donation collect points
#### Request
- Method: GET
- URL: /donation-collect-points?fetch=10&offset=0&sort_by=created_at&sort_order=desc
- Query String:
  - fetch: Number of records to fetch
  - offset: Number of records to skip
  - sort_by: Field to sort by
  - sort_order: asc or desc
- Headers: 
    - Authorization: Bearer {TOKEN}
- Response
- Status: 200 OK
- Body:
```json
{
  "records_count": 1,
  "records": [
    {
      "id": "8f14e45f-e62b-47e1-8d5e-2d6e734a4ff3",
      "name": "Ponto de coleta 1",
      "description": "Ponto de coleta de doações de roupas, alimentos e itens de higiene.",
      "location": "Pça. Bandeiras S/N, Ribeirão Preto, SP, 14015-068",
      "created_at": "2024-07-24T14:45:30Z",
      "updated_at": "2024-07-24T14:45:30Z"
    }
  ]
}
```

### Get a donation collect point by ID
#### Request
- Method: GET
- URL: /donation-collect-points/{ID}
- Path Parameters:
  - ID: ID of the donation collect point
- Headers: 
    - Authorization: Bearer

#### Response
- Status: 200 OK
- Body:
```json
{
  "id": "8f14e45f-e62b-47e1-8d5e-2d6e734a4ff3",
  "name": "Ponto de coleta 1",
  "description": "Ponto de coleta de doações de roupas, alimentos e itens de higiene.",
  "location": "Pça. Bandeiras S/N, Ribeirão Preto, SP, 14015-068",
  "created_at": "2024-07-24T14:45:30Z",
  "updated_at": "2024-07-24T14:45:30Z"
}
```

### Create a donation collect point
#### Request
- Method: POST
- URL: /donation-collect-points
- Headers: 
    - Authorization: Bearer
- Body:
```json
{
  "name": "Ponto de coleta 1",
  "description": "Ponto de coleta de doações de roupas, alimentos e itens de higiene.",
  "location": "Pça. Bandeiras S/N, Ribeirão Preto, SP, 14015-068"
}
```

#### Response
- Status: 201 Created
- Headers:
    - Location: /donation-collect-points/8f14e45f-e62b-47e1-8d5e-2d6e734a4ff3
- Body:
```json
{
  "id": "8f14e45f-e62b-47e1-8d5e-2d6e734a4ff3",
  "name": "Ponto de coleta 1",
  "description": "Ponto de coleta de doações de roupas, alimentos e itens de higiene.",
  "location": "Pça. Bandeiras S/N, Ribeirão Preto, SP, 14015-068",
  "created_at": "2024-07-24T14:45:30Z",
  "updated_at": "2024-07-24T14:45:30Z"
}
```

### Update a donation collect point
#### Request
- Method: PUT
- URL: /donation-collect-points/{ID}
- Path Parameters:
  - ID: ID of the donation collect point
- Headers: 
    - Authorization: Bearer
- Body:
```json
{
  "name": "Ponto de coleta 1",
  "description": "Ponto de coleta de doações de roupas, alimentos e itens de higiene.",
  "location": "Pça. Bandeiras S/N, Ribeirão Preto, SP, 14015-068"
}
```

#### Response
- Status: 204 No Content
- Body: Empty
- Headers:
    - Location: /donation-collect-points/8f14e45f-e62b-47e1-8d5e-2d6e734a4ff3

### Delete a donation collect point
#### Request
- Method: DELETE
- URL: /donation-collect-points/{ID}
- Path Parameters:
  - ID: ID of the donation collect point
- Headers: 
    - Authorization: Bearer
- Body: Empty

#### Response
- Status: 204 No Content
- Body: Empty
- Headers:
    - Location: /donation-collect-points/8f14e45f-e62b-47e1-8d5e-2d6e734a4ff3
