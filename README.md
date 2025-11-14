**Databse**: microsoft sq server
**Migrations**: automatic on API startup (no manual commands needed)
**Logs**: checkk `Logs/` folder for detailed error information

## Quick Reference Card

| Endpoint | Method | Purpose |
|----------|--------|---------|
| `/api/client-session` | POST | Create session |
| `/api/client-session` | GET | Get all sessions |
| `/api/client-session/{id}` | GET | Get session by ID |
| `/api/client-session/client/{name}` | GET | Get sessions by client |
| `/api/client-session/{id}` | PUT | Update session |
| `/api/client-session/{id}` | DELETE | Delete session |

# API Endpoint Testing Guide

### Testing Methods

#### **Swagger UI**
1. Go to http://localhost:5249/swagger
2. Expand `POST /api/client-session`
3. Click **Try it out**
4. Paste the request JSON
5. Click **Execute**

---

## 2. Get All Sessions (GET)

**Endpoint**: `GET /api/client-session`

**Description**: Retrieves all client sessions, ordered by session date (most recent first).

#### **Browser**
Simply navigate to:
```
http://localhost:5249/api/client-session
```

---

## 3. Get Session by ID (GET)

### Testing Methods

#### **Swagger UI**
1. Go to http://localhost:5249/swagger
2. Expand `GET /api/client-session/{id}`
3. Click **Try it out**
4. Enter session ID (e.g., `1`)
5. Click **Execute**

#### **Browser**
```
http://localhost:5249/api/client-session/1
```

---

## 4. Get Sessions by Client Name (GET)

### Testing Methods

#### **Swagger UI**
1. Go to http://localhost:5249/swagger
2. Expand `GET /api/client-session/client/{clientName}`
3. Click **Try it out**
4. Enter client name (e.g., `John Doe` or just `John`)
5. Click **Execute**

#### **Browser**
```
http://localhost:5249/api/client-session/client/John%20Doe
```

---

## 5. Update Session (PUT)

### Testing Methods

#### **Swagger UI**
1. Go to http://localhost:5249/swagger
2. Expand `PUT /api/client-session/{id}`
3. Click **Try it out**
4. Enter session ID (e.g., `1`)
5. Paste the request JSON
6. Click **Execute**
   
---

## 6. Delete Session (DELETE)

### Testing Methods

#### **Swagger UI**
1. Go to http://localhost:5249/swagger
2. Expand `DELETE /api/client-session/{id}`
3. Click **Try it out**
4. Enter session ID (e.g., `1`)
5. Click **Execute**
   
