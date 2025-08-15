## About

This **API**, developed using **.NET 8**, adopts **Domain-Driven Design (DDD)** principles to offer a structured and effective solution for personal expenses management. The main objective is to allow users to create their expenses, detailing information such as title, date and time, description, amount, and payment type, with the data stored securely in a **MySQL** database.

The **API**'s architecture is based on **REST**, utilizing standard **HTTP** methods for efficient and simplified communication. It's also complemented by **Swagger** documentation, which provides an interactive graphical interface for developers to easily explore and test endpoints.

Among the NuGet packages used, **AutoMapper** is responsible for mapping between domain objects and request/response, reducing the need for repetitive and manual code. **FluentAssertions** is used in unit tests to make verifications more readable, helping to write clear and understandable tests. For validations, **FluentValidation** is used to implement validation rules simply and intuitively in request classes, keeping the code clean and easy to maintain. Finally, **EntityFramework** acts as an ORM (Object-Relational Mapper) that simplifies database interactions, allowing the use of .NET objects to manipulate data directly, without the need for SQL queries.

### Features

- **Domain-Driven Design (DDD)**: Modular structure that facilitates understanding and maintenance of the application domain.
- **Unit Tests**: Comprehensive testing with FluentAssertions to ensure functionality and quality.
- **Reports**: Ability to export detailed reports to PDF and Excel, providing visual and effective expense analysis.
- **RESTful API with Swagger Documentation**: Documented interface that facilitates integration and testing by developers.

### Built with

![badge-dot-net]
![badge-windows]
![badge-visual-studio]
![badge-mysql]
![badge-swagger]

## Getting Started

To get a working local copy, follow these steps.

### Requirements

* Visual Studio 2022+ version or Visual Studio Code
* Windows 10+ or Linux/MacOS with [.NET SDK][dot-net-sdk] installed
* MySql Server

### How to install

1. Clone the repository:
    ```sh
    git clone https://github.com/miguelbandrade/CashFlow.git
    ```

2. Fill the file information `appsettings.Development.json`.
3. Run the API and enjoy your tests :)



<!-- Links -->
[dot-net-sdk]: https://dotnet.microsoft.com/en-us/download/dotnet/8.0

<!-- Badges -->
[badge-dot-net]: https://img.shields.io/badge/.NET-512BD4?logo=dotnet&logoColor=fff&style=for-the-badge
[badge-windows]: https://img.shields.io/badge/Windows-0078D4?logo=windows&logoColor=fff&style=for-the-badge
[badge-visual-studio]: https://img.shields.io/badge/Visual%20Studio-5C2D91?logo=visualstudio&logoColor=fff&style=for-the-badge
[badge-mysql]: https://img.shields.io/badge/MySQL-4479A1?logo=mysql&logoColor=fff&style=for-the-badge
[badge-swagger]: https://img.shields.io/badge/Swagger-85EA2D?logo=swagger&logoColor=000&style=for-the-badge

### Extra
This project was developed through C# RocketSeat Course.
