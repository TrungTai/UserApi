# UserApi

### GitHub Link ###


### About The Project ###
This is a project using ASP.Net Core + Web API.
This project is built from Visual Studio 2017.


### How To Install And Execute The Project ###
- Open the project (UserApi.sln file) with Visual Studio 2017.
- In Visual Studio, press Ctrl + F5 to launch the application.
Visual Studio launches a browser and navigates to http://localhost:port/api/values
, where port is a randomly chosen port number. The browser displays the following output:
["value1","value2"]


### Test API ###
- Can use Postman to test API
- Test "Create User":
   + Method: Post
   + Url: http://localhost:2797/api/users
   + Headers: 
             Content-Type: application/json
   + Body: {"Name":"Mary", "Age":30, "Address":"123 Main St. Chicago, IL 60626"}
   
- Test "Update User":
   + Method: Put
   + Url: http://localhost:2797/api/users/1
   + Headers: 
             Content-Type: application/json
   + Body: {"Id":1, "Name":"Tom", "Age":35, "Address":"456 Main St. Washington, IL 40414"}

- Test "Get User":
   + Method: Get
   + Url: http://localhost:2797/api/users/1

- Test "List User": 
   + Method: Get
   + Url: http://localhost:2797/api/users
   
   
