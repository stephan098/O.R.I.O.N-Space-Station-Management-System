# O.R.I.O.N Space Station Management System

## Project Overview

The O.R.I.O.N Space Station Management System is a console-based C# application developed for the PRG2781 project.

The application allows users to manage space station modules using a menu-driven interface. Users can generate random modules, display all active modules, remove modules, and save or load data.

---

## Features

- Menu-driven console interface
- Generate random station modules
- Display all active modules
- Remove modules by Module ID
- Save data to a text file
- Load data from a text file

---

## Object-Oriented Programming

The project demonstrates the following OOP principles:

### Encapsulation
Data is stored inside classes and accessed through methods and properties.

### Inheritance
The following classes inherit from the `StationModule` base class:

- LifeSupportModule
- ResearchLab
- SolarArray

### Polymorphism
Each module overrides the `RunDiagnostics()` method to display its own diagnostic information.

### Abstraction
The `StationModule` class acts as the base class for all station modules.

---

## Interfaces

The project implements the following interfaces:

- `iPowerConsumer`
- `iMaintainable`

These interfaces define behaviour for power management and maintenance.

---

## Exception Handling

The application uses `try-catch-finally` blocks when removing modules.

A custom exception (`CriticalSystemFailureException`) is thrown when an attempt is made to remove a Life Support module.

---

## File I/O

The application includes file handling functionality.

Users can:
- Save data to a text file.
- Load data from a text file.

---

## How to Run the Application

1. Open the project in Visual Studio.
2. Build the solution.
3. Run the application.
4. Use the menu options to interact with the system.

Menu Options:

1. Generate Random Module
2. Display Modules
3. Remove Module
4. Save
5. Load
6. Exit

---

## Design Decisions

- A base class (`StationModule`) is used for common module functionality.
- Different station modules inherit from the base class.
- A separate `RandomModuleGenerator` class generates random modules.
- A separate `FileManager` class handles saving and loading data.
- `StationManager` manages the active modules in the system.

---

## Technologies Used

- C#
- .NET
- Visual Studio
- GitHub
- Git