
## Donation
- Uma doação pode estar vinculada a uma ação ou não.
- Quando a doação supera a quantidade de itens necessários para uma ação, o doador é notificado que o excedente
será armazenado para futuras ações. 
- Status de uma doação
  - waiting_collection: Aguardando coleta
  - collected: Doação entregue
  - canceled: Doação cancelada

### Get all donations
#### Request
- Method: GET
- URL: /donations?fetch=10&offset=0&sort_by=created_at&sort_order=desc
- Query String:
  - fetch: Number of records to fetch
  - offset: Number of records to skip
  - sort_by: Field to sort by
  - sort_order: asc or desc
- Headers: 
    - Authorization: Bearer

#### Response

- Status: 200 OK
- Body:
```json
{
  "records_count": 1,
  "records": [
    {
      "id": "8f14e45f-e62b-47e1-8d5e-2d6e734a4ff3",
      "donor_id": "8f14e45f-e62b-47e1-8d5e-2d6e734a4ff3",
      "voluntary_action_id": "8f14e45f-e62b-47e1-8d5e-2d6e734a4ff3",
      "status" : "waiting_collection",
      "collected_at": null,
      "collect_point_id": "8f14e45f-e62b-47e1-8d5e-2d6e734a4ff3",
      "items": [
        {
          "item_id": "8f14e45f-e62b-47e1-8d5e-2d6e734a4ff3",
          "quantity": 123,
          "excess_quantity": 0,
          "used_quantity": 123
        }
      ],
      "created_at": "2024-07-24T14:45:30Z",
      "updated_at": "2024-07-24T14:45:30Z"
    }
  ]
}
```

### Get a donation by ID
#### Request
- Method: GET
- URL: /donations/{ID}
- Path Parameters:
  - ID: ID of the donation
- Headers: 
  - Authorization: Bearer

#### Response
- Status: 200 OK
- Body:
```json
{
  "id": "8f14e45f-e62b-47e1-8d5e-2d6e734a4ff3",
  "donor_id": "8f14e45f-e62b-47e1-8d5e-2d6e734a4ff3",
  "status" : "waiting_collection",
    "collected_at": null,
    "collect_point_id": "8f14e45f-e62b-47e1-8d5e-2d6e734a4ff3",
  "voluntary_action_id": "8f14e45f-e62b-47e1-8d5e-2d6e734a4ff3",
  "items": [
    {
      "item_id": "8f14e45f-e62b-47e1-8d5e-2d6e734a4ff3",
      "quantity": 123,
      "excess_quantity": 0,
      "used_quantity": 123
    }
  ],
  "created_at": "2024-07-24T14:45:30Z",
  "updated_at": "2024-07-24T14:45:30Z"
}
```

### Create a donation
#### Request
- Method: POST
- URL: /donations
- Headers: 
    - Authorization: Bearer {Token}
- Body:
```json
{
  "voluntary_action_id": "8f14e45f-e62b-47e1-8d5e-2d6e734a4ff3",
  "collect_point_id": "8f14e45f-e62b-47e1-8d5e-2d6e734a4ff3",
  "items": [
    {
      "item_id": "8f14e45f-e62b-47e1-8d5e-2d6e734a4ff3",
      "quantity": 200
    }
  ]
}
```

#### Response
- Status: 201 Created
- Headers:
    - Location: /donations/8f14e45f-e62b-47e1-8d5e-2d6e734a4ff3
- Body:
```json
{
  "id": "8f14e45f-e62b-47e1-8d5e-2d6e734a4ff3",
  "donor_id": "8f14e45f-e62b-47e1-8d5e-2d6e734a4ff3",
  "voluntary_action_id": "8f14e45f-e62b-47e1-8d5e-2d6e734a4ff3",
  "status" : "waiting_collection",
  "collected_at": null,
  "collect_point_id": "8f14e45f-e62b-47e1-8d5e-2d6e734a4ff3",
  "items": [
    {
      "item_id": "8f14e45f-e62b-47e1-8d5e-2d6e734a4ff3",
      "donation_quantity": 200,
      "used_quantity": 123,
      "excess_quantity": 77
    }
  ],
  "created_at": "2024-07-24T14:45:30Z",
  "updated_at": "2024-07-24T14:45:30Z"
}
```

### Update a donation
#### Request
- Method: PUT
- URL: /donations/{ID}
- Path Parameters:
  - ID: ID of the donation
- Headers: 
    - Authorization: Bearer
- Body:
```json
{
  "collect_point_id": "8f14e45f-e62b-47e1-8d5e-2d6e734a4ff3",
  "items": [
    {
      "item_id": "8f14e45f-e62b-47e1-8d5e-2d6e734a4ff3",
      "quantity": 200
    }
  ]
}
```

#### Response
- Status: 204 No Content

### Delete a donation
#### Request
- Method: DELETE
- URL: /donations/{ID}
- Path Parameters:
  - ID: ID of the donation
  - Headers: 
    - Authorization: Bearer
- Body: Empty

#### Response
- Status: 204 No Content
- Body: Empty

### Update the status of a donation
#### Request
- Method: PATCH
- URL: /donations/{ID}/cancel or /donations/{ID}/collect
- Path Parameters:
  - ID: ID of the donation
- Headers: 
    - Authorization: Bearer
- Body: empty

#### Response
- Status: 204 No Content
- Body: Empty
- Headers:
    - Location: /donations/8f14e45f-e62b-47e1-8d5e-2d6e734a4ff3
