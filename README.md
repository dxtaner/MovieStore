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

Clone or download this project.
Open the project in Visual Studio.
Press F5 to start the application.

## API Endpoints
This application uses the following API endpoints:

GET /api/movies: Gets all movies.

GET /api/movies/{id}: Gets a specific movie.

POST /api/movies: Adds a new movie.

PUT /api/movies/{id}: Updates a specific movie.

DELETE /api/movies/{id}: Deletes a specific movie.

GET /api/actors: Gets all actors.

GET /api/actors/{id}: Gets a specific actor.

POST /api/actors: Adds a new actor.

PUT /api/actors/{id}: Updates a specific actor.

DELETE /api/actors/{id}: Deletes a specific actor.

GET /api/directors: Gets all directors.

GET /api/directors/{id}: Gets a specific director.

POST /api/directors: Adds a new director.

PUT /api/directors/{id}: Updates a specific director.

DELETE /api/directors/{id}: Deletes a specific director.

GET /api/genres: Gets all genres.

GET /api/genres/{id}: Gets a specific genre.
