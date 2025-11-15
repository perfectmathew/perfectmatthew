# PerfectMatthew Portfolio

Professional portfolio website showcasing my skills, projects, and experience as a Full Stack Developer.

## 🚀 Tech Stack

### Frontend
- **Angular 20** - Modern web framework
- **TypeScript 5.8** - Type-safe development
- **Tailwind CSS 4** - Utility-first CSS framework
- **Signals** - Reactive state management

### Backend
- **.NET 9** - Cross-platform framework
- **ASP.NET Core Web API** - RESTful API
- **Entity Framework Core 10** - ORM
- **PostgreSQL 16** - Relational database

### DevOps
- **Docker & Docker Compose** - Containerization
- **Nginx** - Web server for frontend
- **GitHub Actions** - CI/CD (planned)

## 📦 Features

- ✅ Responsive design with Tailwind CSS
- ✅ Modern Angular 20 with standalone components
- ✅ RESTful API with Swagger documentation
- ✅ PostgreSQL database with seed data
- ✅ Lazy loading with @defer blocks
- ✅ Contact form with email notifications
- ✅ Project and skills filtering
- ✅ Fully containerized with Docker

## 🛠️ Prerequisites

- Docker Desktop
- Docker Compose
- Git

## 🚀 Quick Start

1. **Clone the repository**
   ```bash
   git clone https://github.com/perfectmathew/perfectmatthew.git
   cd perfectmatthew
   ```

2. **Start the application**
   ```bash
   docker-compose up -d --build
   ```

3. **Access the application**
   - Frontend: http://localhost
   - Backend API: http://localhost:8081
   - Swagger UI: http://localhost:8081/swagger

## 📁 Project Structure

```
perfectmatthew/
├── frontend/
│   └── perfectmatthew-ui/          # Angular 20 application
│       ├── src/
│       │   ├── app/
│       │   │   ├── components/     # UI components
│       │   │   ├── models/         # TypeScript interfaces
│       │   │   └── services/       # API services
│       │   └── styles.scss         # Global styles
│       ├── Dockerfile
│       └── nginx.conf
├── backend/
│   └── PerfectMatthew.Api/         # .NET 9 Web API
│       ├── Controllers/            # API endpoints
│       ├── Models/                 # Domain models
│       ├── Database/               # EF Core context
│       ├── Data/                   # Database seeding
│       ├── Services/               # Business logic
│       └── Dockerfile
├── docker-compose.yml
└── .gitignore
```

## 🔧 Development

### Frontend Development
```bash
cd frontend/perfectmatthew-ui
npm install
npm start
```

### Backend Development
```bash
cd backend/PerfectMatthew.Api
dotnet restore
dotnet run
```

## 🗄️ Database

The application uses PostgreSQL with automatic seeding:
- **20 Skills** across 5 categories
- **6 Projects** with details
- **Contact messages** storage

## 📝 API Endpoints

### Skills
- `GET /api/skills` - Get all skills
- `GET /api/skills/{id}` - Get skill by ID
- `GET /api/skills/category/{category}` - Get skills by category

### Projects
- `GET /api/projects` - Get all projects
- `GET /api/projects/{id}` - Get project by ID
- `GET /api/projects/category/{category}` - Get projects by category

### Contact
- `POST /api/contact` - Send contact message

## 🐳 Docker Commands

```bash
# Build and start all services
docker-compose up -d --build

# Stop all services
docker-compose down

# View logs
docker-compose logs -f

# Restart specific service
docker-compose restart backend
docker-compose restart frontend

# Remove volumes (reset database)
docker volume rm perfectmatthew_postgres_data
```

## 🌐 Environment Variables

Backend configuration in `docker-compose.yml`:
- `ConnectionStrings__DefaultConnection` - PostgreSQL connection
- `ASPNETCORE_URLS` - API listening port

## 📄 License

This project is private and not licensed for public use.

## 👤 Author

**Matthew**
- Website: https://perfectmatthew.pl
- GitHub: [@perfectmathew](https://github.com/perfectmathew)
- Email: contact@perfectmatthew.pl

## 🎯 Future Enhancements

- [ ] Kubernetes deployment
- [ ] Cloud Run deployment (GCP)
- [ ] CI/CD with GitHub Actions
- [ ] Unit and integration tests
- [ ] Performance monitoring
- [ ] Analytics integration
- [ ] Blog section
- [ ] Multi-language support
