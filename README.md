# ASP.NET Core Blazor: Customer and Invoice Management System

## Features

- Create, Read, Update and Delete Customers
- Create, Read, Update and Delete Invoices

## Installation Instructions

### 1. Install .NET 6.0 SDK

### 2. Update Connection String Inside `appsettings.development.json` File

#### SQL Server :-

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=<SQL Server Name>;Database=BlazorInvoiceApp;User=<Username>;Password=<Password>;Trusted_Connection=True;"
  },
}
```

#### SQL Server Express LocalDB :-

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=BlazorInvoiceApp;Trusted_Connection=True;"
  },
}
```

### 3. Build and Run Project

```bash
dotnet run --project src\BlazorInvoiceApp
```