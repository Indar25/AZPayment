# 💳 Payment API

The **Payment API** is a .NET 8 Web API designed to handle payment processing in a distributed microservices system. It communicates with the Order API using RabbitMQ and participates in the **Saga Pattern (Choreography-based)**.

---

### 🔧 Tech Stack:

- .NET 8  
- Clean Architecture  
- MediatR (CQRS)  
- Entity Framework Core  
- MassTransit + RabbitMQ  

---

### 🧩 Responsibilities:

- Listens for `OrderCreatedEvent` from RabbitMQ  
- Executes payment logic via command handler  
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

