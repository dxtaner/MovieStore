# Film Store Application
This application is a film store developed using C# .NET Web API. The application allows users to search, review, and purchase movies. Additionally, it allows application administrators to manage data such as movies, directors, actors, genres, customers, and purchased movies.

## Models
This application uses six different models:

Movie: Holds movie data.
Actor: Holds actor data.
Director: Holds director data.
Genre: Holds genre data.
Customer: Holds customer data.
BoughtMovie: Holds purchased movie data.

## Requirements
To run this application, you need:

.NET Framework 6 or above
Visual Studio 2017 or above

## Installation
To use this application, you can follow these steps:

1.  Clone or download this repository.
2.  Open the project in Visual Studio Code.
3.  Update the database connection information in the \`appsettings.json\` file.
4.  Run the command \`dotnet ef database update\` in the console to create the database.
5.  Install any necessary dependencies required by the project.

Usage
-----

*   Each model has a separate controller located in the \`Controllers\` folder. You can use the respective controller to perform CRUD operations.
*   Test the API requests using tools like Postman.

Models
------

### Actor Model:

*   `Id` (int): Actor ID
*   `Name` (string): Actor name
*   `BirthDate` (DateTime): Actor's birth date

### Movie Model:

*   `Id` (int): Movie ID
*   `Title` (string): Movie title
*   `DirectorId` (int): Director ID
*   `GenreId` (int): Genre ID
*   `ReleaseDate` (DateTime): Movie release date

### Director Model:

*   `Id` (int): Director ID
*   `Name` (string): Director name
*   `BirthDate` (DateTime): Director's birth date

### Genre Model:

*   `Id` (int): Genre ID
*   `Name` (string): Genre name

### Customer Model:

*   `Id` (int): Customer ID
*   `Name` (string): Customer name
*   `Email` (string): Customer email address

### BoughtMovie Model:

*   `Id` (int): BoughtMovie ID
*   `CustomerId` (int): Customer ID
*   `MovieId` (int): Movie ID
*   `Price` (decimal): Price of the bought movie

API Routes
----------

### Actors:

*   `GET /api/actors`: Get all actors
*   `GET /api/actors/{id}`: Get a specific actor by ID
*   `POST /api/actors`: Add a new actor
*   `PUT /api/actors/{id}`: Update a specific actor
*   `DELETE /api/actors/{id}`: Delete a specific actor

### Movies:

*   `GET /api/movies`: Get all movies
*   `GET /api/movies/{id}`: Get a specific movie by ID
*   `POST /api/movies`: Add a new movie
*   `PUT /api/movies/{id}`: Update a specific movie
*   `DELETE /api/movies/{id}`: Delete a specific movie

### Directors:

*   `GET /api/directors`: Get all directors
*   `GET /api/directors/{id}`: Get a specific director by ID
*   `POST /api/directors`: Add a new director
*   `PUT /api/directors/{id}`: Update a specific director
*   `DELETE /api/directors/{id}`: Delete a specific director

### Genres:

*   `GET /api/genres`: Get all genres
*   `GET /api/genres/{id}`: Get a specific genre by ID
*   `POST /api/genres`: Add a new genre
*   `PUT /api/genres/{id}`: Update a specific genre
*   `DELETE /api/genres/{id}`: Delete a specific genre

### Customers:

*   `GET /api/customers`: Get all customers
*   `GET /api/customers/{id}`: Get a specific customer by ID
*   `POST /api/customers`: Add a new customer
*   `PUT /api/customers/{id}`: Update a specific customer
*   `DELETE /api/customers/{id}`: Delete a specific customer

### BoughtMovies:

*   `GET /api/boughtmovies`: Get all bought movies
*   `GET /api/boughtmovies/{id}`: Get a specific bought movie by ID
*   `POST /api/boughtmovies`: Add a new bought movie
*   `PUT /api/boughtmovies/{id}`: Update a specific bought movie
*   `DELETE /api/boughtmovies/{id}`: Delete a specific bought movie

Contributing
------------

Contributions are welcome! If you'd like to contribute to this project, please fork the repository and create a new branch. Then submit a pull request with your proposed changes.

License
-------

This project is licensed under the MIT License. For more information, please see the [LICENSE](LICENSE) file.
