# 📚 BookWorm - Virtual 📖 Shop, 📚 Library & 📦 Renting System

## 🌎 Overview
BookWorm is a 🌐 web-based system designed to facilitate the 🛍️ purchase, 📦 rental, and 🤝 lending of 📱 digital content, including 📖 eBooks, 🎧 audiobooks. The system ensures seamless 💰 transactions while maintaining 🎯 royalty calculations for 🎭 beneficiaries. Users can access their 🎁 purchased or 📦 rented content via "📂 My Shelf," where rented items are automatically ❌ removed after their ⏳ validity period expires.

## ✨ Features
- **🛍️ Purchase, 📦 Rent, and 🤝 Lend** 📖 eBooks, 🎧 Audiobooks, and 📹 Videos
- **🖥️ User-Friendly Interface** built with ⚛️ React JS 18
- **📂 My Shelf** to access 🎁 purchased or 📦 rented content
- **⏳ Automated Expiry** of 📦 rented or 🤝 lent content
- **💰 Royalty Calculation** for each successful 💳 transaction
- **🔐 Secure Authentication** using 🛡️ JWT
- **🖥️ Microservices Architecture** for 📈 scalable performance
- **🐳 Docker Support** for 📦 containerized deployment
- **🗄️ Database-Driven System** with 🐬 MySQL 8

## 🛠️ Tech Stack
### 🎨 Frontend:
- ⚛️ React JS 18

### 🏗️ Backend:
- ☕ Spring Boot 3
- ☕ Spring 6
- 🏗️ Maven 3
- 🔗 REST API
- 🗃️ JPA
- 🛡️ JWT Authentication

### 🖥️ .NET Core Services:
- 💠 .NET 8 Web API Core
- 🏛️ Entity Framework Core 8

### 🗄️ Database:
- 🐬 MySQL 8

### 🚀 DevOps:
- 🐳 Docker

## ⚙️ Installation & Setup
### 📌 Prerequisites:
- 🟢 Node.js & npm
- ☕ Java 17+ (for Spring Boot 3)
- 💠 .NET Core 8 SDK
- 🐬 MySQL 8
- 🐳 Docker (Optional for 📦 containerized deployment)

### 🏃 Steps to Run the Project
#### 1️⃣ Clone the Repository
```sh
git clone https://github.com/yourusername/BookWorm.git
cd BookWorm
```
#### 2️⃣ Backend - ☕ Spring Boot Service
```sh
cd backend-java
mvn clean install
mvn spring-boot:run
```
#### 3️⃣ Backend - 💠 .NET Core Service
```sh
cd backend-dotnet
 dotnet build
 dotnet run
```
#### 4️⃣ Frontend - ⚛️ React JS
```sh
cd frontend
npm install
npm start
```

## 🤝 Contribution
Contributions are welcome! Please follow these steps:
1️⃣ Fork the repository 🍴
2️⃣ Create a feature branch (`git checkout -b feature-branch`)
3️⃣ Commit your changes (`git commit -m '✨ Add new feature'`)
4️⃣ Push to the branch (`git push origin feature-branch`)
5️⃣ Create a pull request 🔃
