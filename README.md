Simple Blog API with ASP.NET Core Web API and MongoDB
This project provides a RESTful API for a simple blog application built with ASP.NET Core Web API and MongoDB.

Features:
CRUD operations for posts (Create, Read, Update, Delete)
CRUD operations for comments (Create, Read, Update, Delete)
User authentication and authorization
Prerequisites:
.NET Core SDK (https://dotnet.microsoft.com/en-us/download)
MongoDB (https://www.mongodb.com/)
Setup:
Clone this repository.
Restore NuGet packages:
Bash
dotnet restore
Use code with caution.
content_copy
Configure your MongoDB connection string in the appsettings.json file.

Start the application:
Bash
dotnet run
Use code with caution.
content_copy
API Endpoints:
Posts:

GET /api/posts: Get all posts.
GET /api/posts/{id}: Get a single post by its ID.
POST /api/posts: Create a new post (requires authentication).
PUT /api/posts/{id}: Update a post (requires authentication).
DELETE /api/posts/{id}: Delete a post (requires authentication).
Comments:

GET /api/posts/{postId}/comments: Get all comments for a specific post.
GET /api/comments/{id}: Get a single comment by its ID.
POST /api/posts/{postId}/comments: Create a new comment for a post (requires authentication).
PUT /api/comments/{id}: Update a comment (requires authentication).
DELETE /api/comments/{id}: Delete a comment (requires authentication).
Authentication:

POST /api/auth/register: Register a new user.
POST /api/auth/login: Login and get an authentication token.
Error Handling:

The API uses appropriate HTTP status codes to indicate success or failure.

Successful requests: 200 OK, 201 Created
Error responses: 400 BadRequest (invalid request), 401 Unauthorized (authentication required), 403 Forbidden (insufficient permissions), 404 NotFound (resource not found), 500 InternalServerError (unexpected error)
Validation:

The API validates user input to ensure data integrity.

Authorization:

Certain endpoints require user authentication and authorization to access them.
