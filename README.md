// --------------------------------------------------
// README - Payment API (Markdown for GitHub)
// --------------------------------------------------

# 💳 Payment API

The **Payment API** is a .NET 8 Web API designed to handle payment processing in a distributed microservices system. It communicates with the Order API using RabbitMQ and participates in the **Saga Pattern (Choreography-based)**.

---

### 🔧 Tech Stack:

- .NET 8  
- Clean Architecture  
- MediatR (CQRS)  
- Entity Framework Core  
- PostgreSQL  
- MassTransit + RabbitMQ  

---

### 🧩 Responsibilities:

- Listens for `OrderCreatedEvent` from RabbitMQ  
- Executes payment logic via command handler  
- Persists payment data to PostgreSQL  
- Publishes either:  
  - `PaymentSucceededEvent` (if payment is successful)  
  - `PaymentFailedEvent` (if something goes wrong)  

---

### 🔄 Saga Integration:

This service participates in a **Saga Choreography** flow by reacting to events instead of relying on a central orchestrator. It operates autonomously but contributes to a larger business transaction flow.

---

### 🚀 Event Flow:

1. `OrderCreatedEvent` is published by Order API  
2. Payment API consumes the event and processes the payment  
3. Payment API publishes either:  
   - `PaymentSucceededEvent` → triggers Order confirmation  
   - `PaymentFailedEvent` → triggers Order cancellation  

---

### 🐇 Running RabbitMQ Locally (Docker)

Use the following command to spin up RabbitMQ locally with the management UI:

```bash
docker run -d \
  --hostname rabbit-local \
  --name rabbitmq \
  -p 5672:5672 \
  -p 15672:15672 \
  -e RABBITMQ_DEFAULT_USER=guest \
  -e RABBITMQ_DEFAULT_PASS=guest \
  rabbitmq:3-management
```

- Visit the UI at: [http://localhost:15672](http://localhost:15672)  
- Login: `guest` / `guest`

---
