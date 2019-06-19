# AxwayMovieCatalogue

Movie Catalogue


Entities

Movies
Title

Release date

Rating

Summary

Poster

 

Genre
Name

 

Actors
First Name

Last Name

Born

Died

Biography

Picture

 

1 Movie could be in 1 Genres

1 Actor could participate in many Movies

 

Functional Requirements

As a Movie Catalogues user I should be able to

add/delete/edit/list/search movies.

As a Movie Catalogues user I should be able to view all movies, order by Release date (reverse) by default.

As a Movie Catalogues user I should be able to order movies by Rating, by Title.

As a Movie Catalogues user I want to view the movie details when click on a movie. The details should contain all movie information plus actors participated in it. When you click on an actor you can view his details.

As a Movie Catalogues user I want to be able to search movies by Title (partial match).

 

*It's not necessary to implement add/delete/edit/list/search actors and genres.

 

Technical Requirements

Entities should be stored in a database (MSSQL).

Actors and Genres are pre-seeded in the DB.

Database should be called by Web API.

WPF client should consume the Web API.

Web API should persist the data in the DB.

No authentication/authorization is required.

Repository pattern and Dependency injection should be demonstrated (both for Web API and WPF).

Unit tests should be provided for the WPF view models.

Integration tests should be provided for Web API calls.

Use .NET Framework (latest).

 

 
