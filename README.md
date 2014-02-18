AmazonOrders
============

Retrieve order history for a merchant, using Amazon Orders API.

 You need to fill in your own values for seller ID, secret and access keys. 

 The project uses entity framework and to make it work with entity framework Amazon provided classes have been altered in a minor way. That is why those assemblies are attached to the project. If you want to use a newer assembly from Amazon or you want to use your own, you may run into some compile errors, but they can be easily fixed by referencing the versions of the same classes added in this project.

 Orders are retrieved and inserted into the Visual Studio 2013 local SQL Database. You can acess it using the server name (localdb)\v11.0 with SQL Server Management Studio or with VS 2013 server explorer. You can build various reporting solutions that may not have worked on Amazon against this database. Specifically, you can use Microsoft's Power BI and Power Query to do rich queries and analysis.
 
 Individual items in the orders are not retrieved, this feature may be added later.
 
 When retrieving orders, the program starts from 2010 and keeps reading new orders. It uses timestamp of the last order in the database for the beginning time of the query against AWS. However, since orders can be placed at the same time with Amazon, there is a risk of duplication. As such, the program checks against duplicates before writing into the database for every record it retrieves from AWS. Retrieval from AWS is done in 100 chunks, where the check against local database is done one by one. Not a big deal for small operations, but if your local database access is expensive, this may be a problem. 
 
 To be able to work around SQL, Microsoft Entity Framework and AWS quirks around minimum datetime values, this program assumes a minimum date of 2000-01-01. If your business needs order history before that date, than you may want to change that value.
 
 

