# CustomersApp
CustomersApp


The solution consists of 2 projects:
-CustomersApp.Api : The .Net Core rest Api, contains the customers controller
-CustomersApp.UnitTests: NUnit tests for the basic crud operations.

How to Run it:

1- Clone the repository (git clone https://github.com/Hazem-Rihani/CustomersApp.git)
2- Open CustomerApp.sln
3- Update MongoDBConnectionString if it is set differently on your local machine 
   I've set the mongodb connection to point to my local host (mongodb://localhost:27017)
4- Press F5 to run!

The Api provides 
  A- GET method to get the customer by id
  B- POST method to add a customer
  C- DELETE method to delete a customer by id
