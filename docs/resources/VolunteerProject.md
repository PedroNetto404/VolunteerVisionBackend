# Volunteer Project

## Get all volunteer project
### **Request**
- Method: GET
- URL: /volunteer-projects?fetch=10&offset=0&sort_by=created_at&sort_order=desc
- Query String:
  - fetch: Number of records to fetch
  - offset: Number of records to skip
  - sort_by: Field to sort by
  - sort_order: asc or desc
- Headers: 
    - Authorization: Bearer {TOKEN}
### Response
- Status: 200 OK
- Body:
```json
{
  "records_count": 1,
  "page_index": 1, 
  "page_size": 10,
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

## Get volunteer project by id
### Request
- Method: GET
- URL: /volunteer-projects/{ID}
- Path Parameters:
  - ID: ID of the volunteer project
- Headers: 
    - Authorization: Bearer {TOKEN}
### Response
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

## Create a volunteer project
### Request
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

### Response
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

## Update a volunteer project
### Request
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

### Response
- Status: 204 No Content
- Body: Empty
- Headers:
    - Location: /volunteer-projects/8f14e45f-e62b-47e1-8d5e-2d6e734a4ff3

## Delete a volunteer project
### Request
- Method: DELETE
- URL: /volunteer-projects/{ID}
- Path Parameters:
  - ID: ID of the volunteer project
- Headers: 
    - Authorization: Bearer {TOKEN}
- Body: Empty

### Response
- Status: 204 No Content
- Body: Empty