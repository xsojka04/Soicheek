Simple blog web application with which I wanted to explore Blazot in .NET 8, Docker and CD/CI with Gitlab.
[Check it out](https://soicheek.cz/)

Database is PostgreSQL, because I wanted to try it out, because it is free. Database is created with Entity Framework Core code-first approach. PostgreSQL is running in Docker container on my home server. 
Data layer and business logic are each in separate project and each have another separete project for testing each layer. Tests are run automatically in Docker container with Gitlab CI/CD.
I came to a conclusion that Blazor is not something I am looking for in web development (at least not without someone who will teach me). I will try to explore some JavaScript framework next.
