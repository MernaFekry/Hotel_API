# Hotel_API

# Overview
The Hotel API is a RESTful service that allows users to manage hotel information, including adding, updating, retrieving, and deleting hotel records. The data is stored in a JSON file, making it easy to maintain and manipulate.

# Features
CRUD Operations: Create, Read, Update, and Delete hotel records.
Data Storage: Hotels are stored in a JSON file (hotels.json).
ASP.NET Core MVC: Built using ASP.NET Core for a robust and scalable architecture.

# Getting Started
Prerequisites
.NET SDK (version 6.0 or later)
A code editor (e.g., Visual Studio, Visual Studio Code)

# Installation
* Clone the repository: git clone https://github.com/MernaFekry/Hotel_API
* Restore the dependencies: dotnet restore
* Run the application: dotnet run

# API Endpoints
| Method | Endpoint | Description |
|     :---:    |     :---:         |     :---:                          |
|      GET     | /api/hotels/{id}  | all hotels                         |
|      POST    | /api/hotels       | Create a new hotel                 |
|      PUT     | /api/hotels/{id}  | Update an existing hotel           |
|      PATCH   | /api/hotels/{id}  | Partially update an existing hotel |
|      DELETE  | /api/hotels/{id}  | Delete a hotel by ID               |

# Models
* Hotel: Represents a hotel with properties such as Id, Name, Location, Rating, ImageUrl, DatesOfTravel, BoardBasis, and a list of Rooms.
* Room: Represents a room in a hotel with properties such as RoomType and Amount.

# Error Handling
The API returns appropriate HTTP status codes for different scenarios:
* 404 Not Found: When a hotel with the specified ID does not exist.
* 204 No Content: When an update or delete operation is successful.
