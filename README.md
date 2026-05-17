# Hello - Person Console Application

A simple C# console application demonstrating basic object-oriented programming concepts using .NET 10.0.

## Overview

This project creates a `Person` class with basic properties and demonstrates how to instantiate objects and call methods in C#.

## Features

- **Person Class**: Represents a person with Id, FirstName, and LastName properties
- **PrintName Method**: Displays a greeting with a person's full name
- **Console Output**: Outputs formatted messages to the console

## Project Structure

```
hello/
├── Person.cs          # Person class definition
├── Program.cs         # Main entry point
├── hello.csproj       # Project configuration
└── README.md          # This file
```

## Prerequisites

- .NET 10.0 SDK or later installed
- C# compiler (included with .NET SDK)

## Building

To build the project, run:

```bash
dotnet build
```

## Running

To run the application, execute:

```bash
dotnet run
```

### Expected Output

```
Hello Umar Farooqi.
```

## Code Example

The application creates a `Person` instance with Id, FirstName, and LastName, then calls the `PrintName` method:

```csharp
var objPerson = new Person
{
    Id = 1,
    FirstName = "Umar",
    LastName = "Farooqi"
};

objPerson.PrintName(objPerson.FirstName, objPerson.LastName);
```

## Technology Stack

- **Language**: C#
- **Framework**: .NET 10.0
- **Output Type**: Console Application

## License

This project is open source and available under the MIT License.
