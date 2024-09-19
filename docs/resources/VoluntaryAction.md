

## Voluntary Action
### Get all voluntary actions
#### Request
- Method: GET
- URL: /voluntary-actions?fetch=10&offset=0&sort_by=created_at&sort_order=desc&occurs_at_start=2021-01-01&occurs_at_end=2021-12-31
- Query String:
  - fetch: Number of records to fetch
  - offset: Number of records to skip
  - sort_by: Field to sort by
  - sort_order: asc or desc
  - occurs_at_start: Start date of the occurrence
  - occurs_at_end: End date of the occurrence
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
      "id": "145232e2-7c34-4720-9f85-941da69e5a13",
      "name": "Ação 51 BDM",
      "description": "Ação voluntária para ajudar pessoas em situação de rua com doações de roupas, alimentos e itens de higiene.",
      "special_instructions": [
        "Voluntários devem usar roupas confortáveis e levar máscaras de proteção."
      ],
      "occurs_at": "2024-07-24T14:45:30Z",
      "created_at": "2024-07-24T14:45:30Z",
      "updated_at": "2024-07-24T14:45:30Z",
      "project_id": "145232e2-7c34-4720-9f85-941da69e5a13",
      "sequence": "51",
      "registration_url": "https://www.sympla.com.br/somando-mais-acoes-ribeirao-preto---acao-051__2555645",
      "promotional_banner_url": "https://example.picture.com",
      "status": "completed",
      "location": "Pça. Bandeiras S/N, Ribeirão Preto, SP, 14015-068",
      "required_items": [
        {
          "item_id": "8f14e45f-e62b-47e1-8d5e-2d6e734a4ff3",
          "quantity": 123
        },
        {
          "item_id": "6b0bd333-b6e4-4b1e-843d-8c7e347a4a21",
          "quantity": 136
        },
        {
          "item_id": "3c2a5c4b-1e43-4f45-8a58-6e7e848a4b32",
          "quantity": 136
        }
      ]
    }
  ]
}
```

### Get a voluntary action by ID
#### Request
- Method: GET
- URL: /voluntary-actions/{ID}
- Path Parameters:
  - ID: ID of the voluntary action
- Headers: 
    - Authorization: Bearer {TOKEN}

#### Response
- Status: 200 OK
- Body:
```json
{
  "id": "145232e2-7c34-4720-9f85-941da69e5a13",
  "name": "Ação 51 BDM",
  "description": "Ação voluntária para ajudar pessoas em situação de rua com doações de roupas, alimentos e itens de higiene.",
  "special_instructions": [
    "Voluntários devem usar roupas confortáveis e levar máscaras de proteção."
  ],
  "occurs_at": "2024-07-24T14:45:30Z",
  "created_at": "2024-07-24T14:45:30Z",
  "updated_at": "2024-07-24T14:45:30Z",
  "project_id": "145232e2-7c34-4720-9f85-941da69e5a13",
  "sequence": "51",
  "registration_url": "https://www.sympla.com.br/somando-mais-acoes-ribeirao-preto---acao-051__2555645",
  "promotional_banner_url": "https://example.picture.com",
  "status": "completed",
  "location": "Pça. Bandeiras S/N, Ribeirão Preto, SP, 14015-068",
  "required_items": [
    {
      "item_id": "8f14e45f-e62b-47e1-8d5e-2d6e734a4ff3",
      "quantity": 123
    },
    {
      "item_id": "6b0bd333-b6e4-4b1e-843d-8c7e347a4a21",
      "quantity": 136
    },
    {
      "item_id": "3c2a5c4b-1e43-4f45-8a58-6e7e848a4b32",
      "quantity": 136
    }
  ]
}
```

### Create a voluntary action
#### Request
- Method: POST
- URL: /voluntary-actions
- Headers: 
    - Authorization: Bearer {TOKEN}
    - Content-Type: application/json

- Body:
```json
{
    "name": "Ação 51 BDM",
    "description": "Ação voluntária para ajudar pessoas em situação de rua com doações de roupas, alimentos e itens de higiene.",
    "special_instructions": [
        "Voluntários devem usar roupas confortáveis e levar máscaras de proteção."
    ],
    "occurs_at": "2024-07-24T14:45:30Z",
    "registration_url": "https://www.sympla.com.br/somando-mais-acoes-ribeirao-preto---acao-051__2555645",
    "promotional_banner_url": "https://example.picture.com",
    "location": "Pça. Bandeiras S/N, Ribeirão Preto, SP, 14015-068",
    "required_items": [
        {
        "item_id": "8f14e45f-e62b-47e1-8d5e-2d6e734a4ff3",
        "quantity": 123
        },
        {
        "item_id": "6b0bd333-b6e4-4b1e-843d-8c7e347a4a21",
        "quantity": 136
        },
        {
        "item_id": "3c2a5c4b-1e43-4f45-8a58-6e7e848a4b32",
        "quantity": 136
        }
    ]
}
```

#### Response
- Status: 201 Created
- Headers:
    - Location: /voluntary-actions/145232e2-7c34-4720-9f85-941da69e5a13
- Body:
```json
{
  "id": "145232e2-7c34-4720-9f85-941da69e5a13",
  "name": "Ação 51 BDM",
  "description": "Ação voluntária para ajudar pessoas em situação de rua com doações de roupas, alimentos e itens de higiene.",
  "special_instructions": [
    "Voluntários devem usar roupas confortáveis e levar máscaras de proteção."
  ],
  "occurs_at": "2024-07-24T14:45:30Z",
  "created_at": "2024-07-24T14:45:30Z",
  "updated_at": "2024-07-24T14:45:30Z",
  "project_id": "145232e2-7c34-4720-9f85-941da69e5a13",
  "sequence": "51",
  "registration_url": "https://www.sympla.com.br/somando-mais-acoes-ribeirao-preto---acao-051__2555645",
  "promotional_banner_url": "https://example.picture.com",
  "status": "completed",
  "location": "Pça. Bandeiras S/N, Ribeirão Preto, SP, 14015-068",
  "required_items": [
    {
      "item_id": "8f14e45f-e62b-47e1-8d5e-2d6e734a4ff3",
      "quantity": 123
    },
    {
      "item_id": "6b0bd333-b6e4-4b1e-843d-8c7e347a4a21",
      "quantity": 136
    },
    {
      "item_id": "3c2a5c4b-1e43-4f45-8a58-6e7e848a4b32",
      "quantity": 136
    }
  ]
}
```

### Update a voluntary action
#### Request
- Method: PUT
- URL: /voluntary-actions/{ID}
- Path Parameters:
  - ID: ID of the voluntary action
- Headers: 
    - Authorization: Bearer {TOKEN}

- Body:
```json
{
    "name": "Ação 51 BDM",
    "description": "Ação voluntária para ajudar pessoas em situação de rua com doações de roupas, alimentos e itens de higiene.",
    "special_instructions": [
        "Voluntários devem usar roupas confortáveis e levar máscaras de proteção."
    ],
    "occurs_at": "2024-07-24T14:45:30Z",
    "registration_url": "https://www.sympla.com.br/somando-mais-acoes-ribeirao-preto---acao-051__2555645",
    "promotional_banner_url": "https://example.picture.com",
    "location": "Pça. Bandeiras S/N, Ribeirão Preto, SP, 14015-068",
    "required_items": [
        {
        "item_id": "8f14e45f-e62b-47e1-8d5e-2d6e734a4ff3",
        "quantity": 123
        },
        {
        "item_id": "6b0bd333-b6e4-4b1e-843d-8c7e347a4a21",
        "quantity": 136
        },
        {
        "item_id": "3c2a5c4b-1e43-4f45-8a58-6e7e848a4b32",
        "quantity": 136
        }
    ]
}
```

#### Response
- Status: 204 No Content
- Body: Empty
- Headers:
    - Location: /voluntary-actions/145232e2-7c34-4720-9f85-941da69e5a13
### Delete a voluntary action
#### Request
- Method: DELETE
- URL: /voluntary-actions/{ID}
- Path Parameters:
  - ID: ID of the voluntary action
- Headers: 
    - Authorization: Bearer {TOKEN}

#### Response
- Status: 204 No Content

### Update the status of a voluntary action
#### Request
- Method: PATCH
- URL: /voluntary-actions/{ID}/status
- Path Parameters:
  - ID: ID of the voluntary action
- Headers: 
    - Authorization: Bearer {TOKEN}
- Body:
```json
{
    "status": "completed"
}
```

#### Response
- Status: 204 No Content
- Body: Empty
- Headers:
    - Location: /voluntary-actions/145232e2-7c34-4720-9f85-941da69e5a13



### Update required items of a voluntary action

#### Request
- Method: PATCH
- URL: /voluntary-actions/{ID}/required-items/{REQUIRED_ITEM_ID}
- Path Parameters:
  - ID: ID of the voluntary action
- Headers: 
  - Authorization: Bearer
  - Content-Type: application/json

- Body:
```json
{
    "quantity": 123
}
```

#### Response
- Status: 204 No Content
- Body: Empty
- Headers:
    - Location: /voluntary-actions/145232e2-7c34-4720-9f85-941da69e5a13

### Delete required items of a voluntary action

#### Request
- Method: DELETE
- URL: /voluntary-actions/{ID}/required-items/{REQUIRED_ITEM_ID}
- Path Parameters:
  - ID: ID of the voluntary action
  - ITEM_ID: ID of the item
  - Headers: 
    - Authorization: Bearer {TOKEN}
- Body: Empty

#### Response
- Status: 204 No Content
- Body: Empty

### Create required items of a voluntary action

#### Request
- Method: POST
- URL: /voluntary-actions/{ID}/required-items
- Path Parameters:
  - ID: ID of the voluntary action
  - Headers: 
    - Authorization: Bearer {TOKEN}
    - Content-Type: application/json
- Body:
```json
{
    "item_id": "8f14e45f-e62b-47e1-8d5e-2d6e734a4ff3",
    "quantity": 123
}
```

#### Response
- Status: 201 Created
- Headers:
    - Location: /voluntary-actions/145232e2-7c34-4720-9f85-941da69e5a13
- Body:
```json
{
    "id": "145232e2-7c34-4720-9f85-941da69e5a13",
    "item_id": "8f14e45f-e62b-47e1-8d5e-2d6e734a4ff3",
    "quantity": 123
}
```
