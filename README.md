
# Volunteer Vision

![Licença](https://img.shields.io/badge/licença-MIT-blue.svg)
![Versão](https://img.shields.io/badge/versão-1.0.0-green.svg)

**Volunteer Vision** é um projeto dedicado a conectar voluntários com instituições de caridade e organizações sem fins lucrativos. A plataforma permite que os administradores de projetos sociais gerenciem voluntários, doadores e doações, além de organizarem e acompanharem ações de voluntariado.

Este projeto é uma iniciativa da comunidade de programação Koppler Labs, denominada "Koppler Labs Solidário". A Koppler Labs é composta por desenvolvedores e engenheiros de software de Ribeirão Preto e região, que se reúnem para ensinar, aprender e discutir temas relacionados ao mundo da ciência da computação.

O objetivo secundário do projeto é capacitar desenvolvedores iniciantes e intermediários a praticarem suas habilidades de programação, trabalhando em um projeto real, com um time de desenvolvedores experientes.
## Índice

- [Sobre](#sobre)
- [Instalação](#instalação)
- [Uso](#uso)
- [Documentação](#documentação)
- [Contribuição](#contribuição)
- [Licença](#licença)
- [Autores](#autores)
- [Agradecimentos](#agradecimentos)

## Sobre
### Tecnologias
Estamos trabalhando com as seguintes tecnologias:
- [.NET Core 8.0 (C#)](https://learn.microsoft.com/en-us/dotnet/fundamentals/)
- [ASP.NET Core 8.0](https://learn.microsoft.com/en-us/aspnet/core/?view=aspnetcore-8.0)
- [PostgreSQL](https://www.postgresql.org/)
- [EF Core](https://learn.microsoft.com/en-us/ef/core/)
- [Docker](https://www.docker.com/)
- [Docker Compose](https://docs.docker.com/compose/)

### Padrões e design
- Clean Architecture
- Clean Code
- Mediator Pattern
- Repository Pattern
- Unit of Work Pattern

### Funcionalidades
- Gestão de:
    - Voluntários
    - Doadores
    - Doações
    - Projetos sociais
    - Ações de voluntariado
- Dashboard e relatórios para os administradores de projetos sociais
- Notificações automáticas de doações e ações de voluntariado

### Arquitetura
- API RESTful 
  - [Roy Fielding](https://ics.uci.edu/~fielding/pubs/dissertation/fielding_dissertation.pdf) descreveu a arquitetura REST em sua tese de doutorado em 2000. REST é um estilo de arquitetura de software que define um conjunto de restrições para projetar serviços web. REST é um acrônimo para Representational State Transfer.
  - Nesse trabalho Roy definiu as seguintes características para uma arquitetura REST:
    - Cliente-servidor
    - Stateless
    - Cache
    - Interface uniforme
  - [Modelo de maturição de Richardson](https://rivaildojunior.medium.com/modelo-de-maturidade-de-richardson-para-apis-rest-8845f93b288): Leonard Richardson propôs um modelo de maturidade para APIs RESTful, que é composto por quatro níveis:
    - Uso de métodos HTTP
    - Uso de URIs
    - Uso de representações
    - Uso de links
- Arquitetura em camadas ao estilo [Clean Architecture](https://betterprogramming.pub/the-clean-architecture-beginners-guide-e4b7058c1165)
  - Presentation: camada de apresentação em que expomos os endpoints da API
    - Controllers
    - Actions
    - ViewModels
    - Filters
    - Middleware
  - Application: camada de aplicação em que implementamos os casos de uso da aplicação. Essa camada é responsável por orquestrar as operações de negócio e delegar a execução para os serviços de aplicação ou serviços de domínio.
    - Services
    - Commands
    - Queries
    - Handlers
    - Mappers
  - Domain: camada de domínio em que implementamos as regras de negócio da aplicação. Essa camada é composta por entidades, objetos de valor, agregados, eventos de domínio, interfaces e serviços de domínio.
    - Entities
    - Value Objects
    - Aggregates
    - Domain Events
    - Interfaces
    - Services
  - Infrastructure: camada de infraestrutura em que implementamos os detalhes técnicos da aplicação. Essa camada é responsável por implementar os serviços de infraestrutura, como acesso a dados, envio de e-mails, notificações, logging, etc.
    - Data
    - Repositories
    - Unit of Work
    - Services
    - Notifications
    - Logging
    - Caching
    - Identity
    - Security
    - Configuration
    - External Services

## Instalação
### Pré-requisitos
- [.NET Core 8.0](https://dotnet.microsoft.com/download/dotnet/8.0)
  - SDK, Runtime e Runtime Hosting Bundle
- [Docker](https://www.docker.com/)
- [Docker Compose](https://docs.docker.com/compose/)


### Subir containers
```bash
docker-compose up -d
```

### Parar containers
```bash
docker-compose down
```

## Uso
### Acessar a aplicação
- https://localhost:5459

## Documentação
### Endpoints
- [Swagger](https://localhost:5459/swagger)

## Contribuição
### Como contribuir
0. Entre no nosso grupo do WhatsApp: [Koppler Labs Solidário](https://chat.whatsapp.com/BA9PPLOIrDdKZdiPbSDLAy)

1. Faça um fork do projeto
2. Crie uma branch para sua feature (`git checkout -b feature/MinhaFeature`)
3. Faça commit das suas alterações (`git commit -am 'Adicionando uma nova feature'`)
4. Faça push para a branch (`git push origin feature/MinhaFeature`)
5. Crie um novo Pull Request
6. Aguarde a revisão dos mantenedores

## Licença
Este projeto está licenciado sob a Licença MIT - veja o arquivo [LICENSE.md](LICENSE.md) para detalhes

## Autores
### Backend
- [Pedro Netto (Lider backend)](https://github.com/PedroNetto404);
- [Arthur Galanti]();
- [Arthur Prado]()
- [Leonardo Testa]
### Frontend
- [Italo Covas (Lider frontend)](https://github.com/ItaloCovas)

## Agradecimentos
- Agradecemos ao projeto Bem da Madrugada por nos inspirar a criar o Volunteer Vision. O Bem da Madrugada é uma iniciativa de voluntariado que atua na cidade de Ribeirão Preto, SP, Brasil, e que tem como objetivo distribuir alimentos e roupas para pessoas em situação de rua.
Ficamos muito felizes em poder praticar a inclusão digital e a solidariedade, contribuindo com a comunidade de Ribeirão Preto e região.
- Nossa comunidade de programação Koppler Labs, que nos apoia e incentiva a aprender e ensinar, compartilhando conhecimento e experiências, exergando sempre o trabalho de engenharia de software como um trabalho humano e colaborativo.

| Viva o Open Source! 