# API Contract

| BASE URL -> https://{HOST}:{PORT}/api/v1 

## Volunteer Project
### Get all volunteer projects
#### Request
- Method: GET
- URL: /volunteer-projects?fetch=10&offset=0&sort_by=created_at&sort_order=desc
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
      "name": "Bem da Madrugada",
      "categories": [
        "homeless",
          "vulnerable_children",
            "elderly",
        "environment_care"
      ],
        "description": "Projeto de voluntariado que visa ajudar pessoas em situação de rua, crianças carentes e idosos.",
      "instagram_url": "https://www.instagram.com/bemdamadrugada",
      "linkedin_url": "https://www.linkedin.com/company/bemdamadrugada",
      "banner_url": "https://example.picture.com",
      "profile_picture_url": "https://example.picture.com",
      "created_at": "2024-07-24T14:45:30Z",
      "updated_at": "2024-07-24T14:45:30Z"
    }
  ]
}
```

### Get volunteer project by id
#### Request
- Method: GET
- URL: /volunteer-projects/{ID}
- Path Parameters:
  - ID: ID of the volunteer project
- Headers: 
    - Authorization: Bearer {TOKEN}
#### Response
- Status: 200 OK
- Body:
```json
{
  "id": "8f14e45f-e62b-47e1-8d5e-2d6e734a4ff3",
  "name": "Bem da Madrugada",
  "categories": [
    "homeless",
    "vulnerable_children",
    "elderly",
    "environment_care"
  ],
  "description": "Projeto de voluntariado que visa ajudar pessoas em situação de rua, crianças carentes e idosos.",
  "instagram_url": "https://www.instagram.com/bemdamadrugada",
  "linkedin_url": "https://www.linkedin.com/company/bemdamadrugada",
  "banner_url": "https://example.picture.com",
  "profile_picture_url": "https://example.picture.com",
  "created_at": "2024-07-24T14:45:30Z",
  "updated_at": "2024-07-24T14:45:30Z"
}
```

### Create a volunteer project
#### Request
- Method: POST
- URL: /volunteer-projects
- Headers: 
    - Authorization: Bearer {TOKEN}
- Body:
```json
{
  "name": "Bem da Madrugada",
  "categories": [
    "homeless",
    "vulnerable_children",
    "elderly",
    "environment_care"
  ],
  "description": "Projeto de voluntariado que visa ajudar pessoas em situação de rua, crianças carentes e idosos.",
  "instagram_url": "https://www.instagram.com/bemdamadrugada",
  "linkedin_url": "https://www.linkedin.com/company/bemdamadrugada",
  "banner_url": "https://example.picture.com",
  "profile_picture_url": "https://example.picture.com"
}
```

#### Response
- Status: 201 Created
- Headers:
    - Location: /volunteer-projects/8f14e45f-e62b-47e1-8d5e-2d6e734a4ff3
- Body:
```json
{
  "id": "8f14e45f-e62b-47e1-8d5e-2d6e734a4ff3",
  "name": "Bem da Madrugada",
  "categories": [
    "homeless",
    "vulnerable_children",
    "elderly",
    "environment_care"
  ],
  "description": "Projeto de voluntariado que visa ajudar pessoas em situação de rua, crianças carentes e idosos.",
  "instagram_url": "https://www.instagram.com/bemdamadrugada",
  "linkedin_url": "https://www.linkedin.com/company/bemdamadrugada",
  "banner_url": "https://example.picture.com",
  "profile_picture_url": "https://example.picture.com",
  "created_at": "2024-07-24T14:45:30Z",
  "updated_at": "2024-07-24T14:45:30Z"
}
```

### Update a volunteer project
#### Request
- Method: PUT
- URL: /volunteer-projects/{ID}
- Path Parameters:
  - ID: ID of the volunteer project
  - Headers: 
    - Authorization: Bearer
    - Content-Type: application/json
- Body:
```json
{
  "name": "Bem da Madrugada",
  "categories": [
    "homeless",
    "vulnerable_children",
    "elderly",
    "environment_care"
  ],
  "description": "Projeto de voluntariado que visa ajudar pessoas em situação de rua, crianças carentes e idosos.",
  "instagram_url": "https://www.instagram.com/bemdamadrugada",
  "linkedin_url": "https://www.linkedin.com/company/bemdamadrugada",
  "banner_url": "https://example.picture.com",
  "profile_picture_url": "https://example.picture.com"
}
```

#### Response
- Status: 204 No Content
- Body: Empty
- Headers:
    - Location: /volunteer-projects/8f14e45f-e62b-47e1-8d5e-2d6e734a4ff3

### Delete a volunteer project
#### Request
- Method: DELETE
- URL: /volunteer-projects/{ID}
- Path Parameters:
  - ID: ID of the volunteer project
- Headers: 
    - Authorization: Bearer {TOKEN}
- Body: Empty

#### Response
- Status: 204 No Content
- Body: Empty

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
    - Authorization: Bearer
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