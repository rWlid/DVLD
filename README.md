# DVLD - Driving License Management System

A desktop application for managing driving-license operations, built with C# and Windows Forms on a three-tier architecture. The system covers people, system users, license applications, and the reference data (application types, test types, license classes) needed to issue driving licenses.

This project follows the DVLD project specification from [ProgrammingAdvices.com](https://programmingadvices.com).

## Features

### Implemented

- **Authentication**
  - Username/password login with inactive-account rejection.
  - Optional "remember me" that restores the last used credentials.
  - Change password with old-password verification.

- **People management**
  - Add, edit, delete, list, and search people.
  - Validation of required fields and unique national number.
  - Nationality selection from a countries list.
  - Profile image upload (copied to a local images folder with a GUID file name).

- **User management**
  - Add, edit, delete, list, and view users.
  - Each user is linked to an existing person.
  - Activate/deactivate users.
  - Prevent duplicate users for the same person.

- **Application types**
  - List application types and update their title and fees.

- **Test types**
  - List test types and update their title, description, and fees.

- **Local driving-license applications**
  - Create a new local license application for a person and license class.
  - Prevent duplicate active applications for the same person and class.
  - List applications with applicant, class, status, date, and passed-test count.
  - View application details.
  - Cancel, delete, and update the license class of an application.

- **Reference data**
  - Countries, license classes, and test types are read from the database.

### Planned

- Test appointments and scheduling (vision, written, and practical tests).
- Recording test results and retaking failed tests.
- License issuance after all requirements are met.
- License renewal, lost/damaged replacement, detention, and release.
- International driving licenses.
- Role-based permissions.

## Architecture

The solution is split into three projects with a one-way dependency chain: **Presentation -> Business Logic -> Data Access**.

```
DVLD.sln
├── DVLD/                 Presentation layer (WinForms)
│   ├── Applications/     Application types, local license applications, shared controls
│   ├── People/           People forms and controls
│   ├── Users/            Login, user forms, and controls
│   ├── Tests/            Test type forms
│   ├── Icons/            UI images and icons
│   ├── Utils.cs          Image/file helpers
│   └── Program.cs        Application entry point (starts the login form)
├── DVLD.BL/              Business logic layer
│   ├── Person.cs, User.cs, Application.cs, LocalLicenseApplication.cs
│   ├── ApplicationType.cs, TestType.cs, LicenseClass.cs, Country.cs
│   ├── Globals.cs        Current user and remembered credentials
│   └── Mode.cs           Shared AddNew/Update state
└── DVLD.DAL/             Data access layer (ADO.NET)
    ├── PersonData.cs, UserData.cs, ApplicationData.cs
    ├── LocalLicenseApplicationData.cs, ApplicationTypeData.cs
    ├── TestTypeData.cs, LicenseClassData.cs, CountryData.cs
    └── DataAccessSettings.cs   Database connection string
```

- **Presentation** contains only form logic and UI event handling.
- **Business logic** exposes domain classes with validation, a `Save()` method driven by `Mode` (`AddNew`/`Update`), and static `Find`/`GetAll` methods.
- **Data access** uses `System.Data.SqlClient` with parameterized inline T-SQL, returning `DataTable` objects or populating values through `ref` parameters.

## Tech Stack

| Area | Technology |
| --- | --- |
| Language | C# |
| Runtime | .NET Framework 4.7.2 |
| UI | Windows Forms |
| Data access | ADO.NET (`System.Data.SqlClient`) |
| Database | SQL Server |
| IDE | Visual Studio 2022 |
| Style | `.editorconfig` (Microsoft C# conventions) |

## Prerequisites

- Windows
- Visual Studio 2022 with the **.NET desktop development** workload and the **.NET Framework 4.7.2** targeting pack
- SQL Server (Express, Developer, or LocalDB) with a database named `DVLD`

## Database Setup

The repository does **not** include a database schema or seed script. You need a `DVLD` database whose schema matches the queries in `DVLD.DAL`.

The data access layer references the following tables:

- `People`
- `Users`
- `Countries`
- `Applications`
- `ApplicationTypes`
- `LocalDrivingLicenseApplications`
- `LicenseClasses`
- `TestTypes`
- `TestAppointments`
- `Tests`

The default connection string is defined in `DVLD.DAL/DataAccessSettings.cs`:

```csharp
"Server=localhost;Database=DVLD;Trusted_Connection=True;TrustServerCertificate=True;"
```

Change the server or authentication settings there if your SQL Server instance differs. A connection string is not read from `App.config`.

To sign in, the `Users` table must contain at least one active user. Passwords are currently stored and compared as plain text.

## Build and Run

1. Clone the repository and open `DVLD.sln` in Visual Studio 2022.
2. Create or restore the `DVLD` database and update the connection string in `DVLD.DAL/DataAccessSettings.cs` if needed.
3. Build the solution (`Debug | Any CPU`).
4. Set `DVLD` (the WinForms project) as the startup project and press `F5`.
5. Sign in with an active user from the `Users` table.

People images are copied to `C:\DVLD-People-Images\`, which the application creates automatically. The folder must be writable.

## Known Limitations

- Passwords are stored in plain text in the database.
- "Remember me" writes the username and password in plain text to `D:\LastLoginUser.txt`.
- The connection string and image folder path are hardcoded.
- Data access methods swallow exceptions in some `catch` blocks, so failures can appear as empty results.
- There are no automated tests.
- Several features from the specification (tests, licensing, detention, international licenses) are not implemented yet.

## Acknowledgements

- Project specification and requirements: [ProgrammingAdvices.com](https://programmingadvices.com).
- Built as part of a learning path for C#, SQL Server, ADO.NET, and three-tier application design.

## License

No license is specified for this repository.
