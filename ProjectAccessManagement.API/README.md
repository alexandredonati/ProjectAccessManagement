# Project Access Management API

This API provides endpoints for managing project access and credentials in the Project Access Management system.

## Features

- Credential Management
  - Create new credentials
  - Update credential properties
  - Add/Remove modules from credentials
  - Delete credentials
  - List all credentials
  - Get credential by ID

- Application Management
  - Create new applications
  - Update application properties
  - Delete applications
  - List all applications
  - Get application by ID

- Module Management
  - Create new modules
  - Update module properties
  - Delete modules
  - List all modules
  - Get module by ID

- Automation Management
  - Create new automations
  - Add/Remove modules and credentials to/from automations
  - Delete automations
  - List all automations
  - Get automation by ID

- Business Area Management
  - Create new business areas
  - List all business areas
  - Get business area by ID

## Getting Started

### Prerequisites

- .NET 8.0 SDK
- SQL Server (LocalDB or full instance)
- Visual Studio 2022 or later (recommended)

### Installation

1. Clone the repository
2. Navigate to the API project directory
3. Update the connection string in `appsettings.json` if needed
4. Run the following commands:
   ```bash
   dotnet restore
   dotnet build
   dotnet run
   ```

### API Documentation

Once the API is running, you can access the Swagger documentation at:
```
https://localhost:7001/swagger
```

## Endpoints

### Credentials

#### Create Credential
```
POST /api/credentials
```

#### Add Modules to Credential
```
POST /api/credentials/{credentialId}/modules
```

#### Remove Modules from Credential
```
DELETE /api/credentials/{credentialId}/modules
```

#### Update Credential
```
PUT /api/credentials/{credentialId}
```

#### Get All Credentials
```
GET /api/credentials
```

#### Get Credential by ID
```
GET /api/credentials/{id}
```

#### Delete Credential
```
DELETE /api/credentials/{id}
```

### Applications

#### Create Application
```
POST /api/applications
```

#### Get All Applications
```
GET /api/applications
```

#### Get Application by ID
```
GET /api/applications/{id}
```

#### Update Application
```
PUT /api/applications/{id}
```

#### Delete Application
```
DELETE /api/applications/{id}
```

### Modules

#### Create Module
```
POST /api/modules
```

#### Get All Modules
```
GET /api/modules
```

#### Get Module by ID
```
GET /api/modules/{id}
```

#### Update Module
```
PUT /api/modules/{id}
```

#### Delete Module
```
DELETE /api/modules/{id}
```

### Automations

#### Create Automation
```
POST /api/automations
```

#### Get All Automations
```
GET /api/automations
```

#### Add Modules and Credentials to Automation
```
POST /api/automations/{id}/modules-and-credentials
```

#### Remove Modules and Credentials from Automation
```
DELETE /api/automations/{id}/modules-and-credentials
```

#### Delete Automation
```
DELETE /api/automations/{id}
```

### Business Areas

#### Create Business Area
```
POST /api/business-areas
```

#### Get All Business Areas
```
GET /api/business-areas
```

#### Get Business Area by ID
```
GET /api/business-areas/{id}
```

## Development

### Project Structure

```
ProjectAccessManagement.API/
├── Configuration/         # API configuration classes
├── Controllers/          # API controllers
├── Middleware/          # Custom middleware
└── Program.cs          # Application entry point

ProjectAccessManagement.Application/
├── DTOs/               # Data Transfer Objects
├── Mappings/          # AutoMapper profiles
└── Services/          # Application services
```

### Adding New Features

1. Create necessary DTOs in the Application layer
2. Add service methods in the Application layer
3. Create controller endpoints in the API layer
4. Add appropriate documentation
5. Add unit tests

## Security

The API uses JWT authentication. To use protected endpoints:

1. Include the JWT token in the Authorization header:
   ```
   Authorization: Bearer <your-token>
   ```

2. Configure the JWT settings in `appsettings.json`

## Contributing

1. Fork the repository
2. Create your feature branch
3. Commit your changes
4. Push to the branch
5. Create a new Pull Request 