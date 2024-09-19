
## Items

### Get all items
#### Request
- Method: GET
- URL: /items?fetch=10&offset=0&sort_by=created_at&sort_order=desc
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
      "name": "Sapatos masculinos",
      "description": "Sapatos masculinos de todos os tamanhos.",
      "created_at": "2024-07-24T14:45:30Z",
      "category": "clothes",
      "updated_at": "2024-07-24T14:45:30Z"
    }
  ]
}
```

### Get an item by ID
#### Request
- Method: GET
- URL: /items/{ID}
- Path Parameters:
  - ID: ID of the item
- Headers: 
  - Authorization: Bearer {TOKEN}

#### Response
- Status: 200 OK
- Body:
```json
{
  "id": "8f14e45f-e62b-47e1-8d5e-2d6e734a4ff3",
  "name": "Roupas masculinas",
  "description": "Roupas masculinas de todos os tamanhos.",
  "created_at": "2024-07-24T14:45:30Z",
  "category": "clothes",
  "updated_at": "2024-07-24T14:45:30Z"
}
```

### Create an item
#### Request
- Method: POST
- URL: /items
- Headers: 
    - Authorization: Bearer {TOKEN}
- Body:
```json
{
    "name": "Suco caixinha 200ml",
    "description": "Suco de caixinha de 200ml de qualquer sabor.",
    "category": "food"
}
```

#### Response
- Status: 201 Created
- Headers:
    - Location: /items/8f14e45f-e62b-47e1-8d5e-2d6e734a4ff3
- Body:
```json
{
  "id": "8f14e45f-e62b-47e1-8d5e-2d6e734a4ff3",
  "name": "Suco caixinha 200ml",
  "description": "Suco de caixinha de 200ml de qualquer sabor.",
  "category": "food",
  "created_at": "2024-07-24T14:45:30Z",
  "updated_at": "2024-07-24T14:45:30Z"
}
```

### Update an item
#### Request
- Method: PUT
- URL: /items/{ID}
- Path Parameters:
  - ID: ID of the item
- Headers: 
    - Authorization: Bearer {TOKEN}
- Body:
```json
{
    "name": "Suco caixinha 200ml",
    "description": "Suco de caixinha de 200ml de qualquer sabor.",
    "category": "food"
}
```

#### Response
- Status: 204 No Content
- Body: Empty
- Headers:
    - Location: /items/8f14e45f-e62b-47e1-8d5e-2d6e734a4ff3

### Delete an item
#### Request
- Method: DELETE
- URL: /items/{ID}
- Path Parameters:
  - ID: ID of the item
- Headers: 
    - Authorization: Bearer
- Body: Empty

#### Response
- Status: 204 No Content
- Body: Empty
- Headers:
    - Location: /items/8f14e45f-e62b-47e1-8d5e-2d6e734a4ff3
- Status: 204 No Content
- Body: Empty
- Headers:
    - Location: /items/8f14e45f-e62b-47e1-8d5e-2d6e734a4ff3

**Outros exemplos de itens**
- Água mineral 500ml 
  - Categoria: food
- Bolacha Salgada
  - Categoria: food
- Escova de dente
  - Categoria: hygiene
- Sabonete
  - Categoria: hygiene
- Pix
  - Categoria: money
- Dinheiro em espécie
  - Categoria: money
