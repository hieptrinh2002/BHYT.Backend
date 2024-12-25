# Insurance Web Application

## Overview
The **Insurance Web App** is a  web application designed to simplify the management of insurance policies, claims, and payments. The system features distinct modules for both users and administrators, ensuring a streamlined and efficient experience for all stakeholders.

## Technologies Used
- **Backend:** ASP.NET Web API
- **Frontend:** React.js with MUI (Material-UI) for styling
- **Programming Language:** TypeScript
- **Database:** Microsoft SQL Server

## Key Features

### 1. Admin Module
- Manage insurance policies, including creation, updates, and removal.
- Process user payments for policy purchases and premium renewals.
- Handle and approve insurance policy applications.

### 2. User Module
- Register for insurance policies.
- View and manage purchased policies.
- File and track insurance claims.

### 3. Claims Management
- Enable users to submit claims directly through the platform.
- Allow administrators to review and approve submitted claims.

### 4. Payment Integration
- Seamlessly handle payment processes for policy purchases.
- Enable premium renewals with secure payment methods.

## Installation

### Prerequisites
- .NET 7 SDK
- Node.js and npm
- Microsoft SQL Server

### Backend Setup

3. Update the `appsettings.json` file with your SQL Server connection string:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=YOUR_SERVER;Database=InsuranceDB;User Id=YOUR_USER;Password=YOUR_PASSWORD;"
     }
   }

## Contribution

We welcome contributions! To get started:
1. Fork the repository.
2. Create a new branch (`git checkout -b feature-name`).
3. Make your changes and commit them (`git commit -m 'Add some feature'`).
4. Push to the branch (`git push origin feature-name`).
5. Open a Pull Request.

## Contact
For questions or feedback, please contact me at hieptrinh2002@gmail.com].

