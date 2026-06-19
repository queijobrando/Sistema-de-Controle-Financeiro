# API Controle de Finanças

Um sistema simples de controle de movimentações bancárias para estudo da implementação de uma API Restful em ASP.NET

**Funcionamento:** O usuário registra suas movimentações de receita e despesa por dia. O sistema consegue retornar esses dados e fazer um cálculo total do valor de despesas e de receita.

## Diagrama do DB

![diagramaDb](db.png)

## Endpoints da API

### POST /api/categoria

#### Request

```json
{
  "nome": "Alimentação"
}
```

#### Response (201 Created)

```json
{
  "id": 1,
  "nome": "Alimentação"
}
```

### GET /api/categoria

#### Response (200 OK)

```json
[
  {
    "id": 1,
    "nome": "Alimentação"
  },
  {
    "id": 2,
    "nome": "Transporte"
  }
]
```

### GET /api/categoria/{id}

#### Response (200 OK)

```json
{
  "id": 1,
  "nome": "Alimentação"
}
```

#### Response (404 Not Found)

```json
{
  "mensagem": "Categoria não encontrada"
}
```

### PATCH /api/categoria/{id}

#### Request

```json
{
  "nome": "Supermercado"
}
```

#### Response (200 OK)

```json
{
  "id": 1,
  "nome": "Supermercado"
}
```

#### Response (404 Not Found)

```json
{
  "mensagem": "Categoria não encontrada"
}
```

### DELETE /api/categoria/{id}

#### Response (204 No Content)

Sem corpo.

#### Response (404 Not Found)

```json
{
  "mensagem": "Categoria não encontrada"
}
```

# Movimentações

### POST /api/movimentacao

#### Request

```json
{
  "valor": 12.0,
  "tipo": "D",
  "categoriaId": 1,
  "data": "2026-06-19"
}
```

#### Response (201 Created)

```json
{
  "id": 1,
  "valor": 12.0,
  "tipo": "D",
  "categoriaId": 1,
  "data": "2026-06-19"
}
```

#### Response (400 Bad Request)

```json
{
  "mensagem": "Tipo informado não existe"
}
```

#### Response (400 Bad Request)

```json
{
  "mensagem": "Categoria informada não existe"
}
```

### GET /api/movimentacao

#### Response (200 OK)

```json
[
  {
    "id": 1,
    "valor": 12.0,
    "tipo": "D",
    "categoriaId": 1,
    "data": "2026-06-19"
  },
  {
    "id": 2,
    "valor": 1500.0,
    "tipo": "R",
    "categoriaId": 2,
    "data": "2026-06-20"
  }
]
```

### GET /api/movimentacao?tipo=D

```json
[
  {
    "id": 1,
    "valor": 12.0,
    "tipo": "D",
    "categoriaId": 1,
    "data": "2026-06-19"
  }
]
```

### GET /api/movimentacao?categoriaId=1

```json
[
  {
    "id": 1,
    "valor": 12.0,
    "tipo": "D",
    "categoriaId": 1,
    "data": "2026-06-19"
  }
]
```

### GET /api/movimentacao?data=2026-06-19

```json
[
  {
    "id": 1,
    "valor": 12.0,
    "tipo": "D",
    "categoriaId": 1,
    "data": "2026-06-19"
  }
]
```

### GET /api/movimentacao/{id}

#### Response (200 OK)

```json
{
  "id": 1,
  "valor": 12.0,
  "tipo": "D",
  "categoriaId": 1,
  "data": "2026-06-19"
}
```

#### Response (404 Not Found)

```json
{
  "mensagem": "Movimentação não encontrada"
}
```

### DELETE /api/movimentacao/{id}

#### Response (204 No Content)

Sem corpo.

#### Response (404 Not Found)

```json
{
  "mensagem": "Movimentação não encontrada"
}
```

# Relatórios

### GET /api/saldo

#### Response (200 OK)

```json
{
  "saldo": 1387.5
}
```

#### Regra

```text
saldo =
soma(receitas)
-
soma(despesas)
```

### GET /api/resumo

#### Response (200 OK)

```json
{
  "totalReceitas": 2000.0,
  "totalDespesas": 612.5,
  "saldo": 1387.5
}
```

### GET /api/movimentacao/por-categoria

#### Response (200 OK)

```json
[
  {
    "categoria": "Alimentação",
    "total": 320.0
  },
  {
    "categoria": "Transporte",
    "total": 150.0
  },
  {
    "categoria": "Lazer",
    "total": 80.0
  }
]
```
