# ShoppingBasketKantar

To set up the project first, you will need to follow these steps:

1. Clone this repository
2. Validate if you have SQL Server installed; if not, download here (https://www.microsoft.com/en-us/sql-server/sql-server-downloads) the free specialized edition, Express
3. Open ShoppingBasketKanterAPI on Visual Studio
4. Open Package Manager Console and execute the command "update-database"
   - Since there are already configurations on app.settings for a local database and the project already has migrations, this will create the database locally with some values in tables.
5. If this command doesn't give any error, run the api
6. Open another visual studio with the shopping-basket-app
7. Open a terminal cmd window and execute the command "ng serve"
   - This command will compile the app and when done will prompt you with a localhost url, ctrl + click on mouse or copy paste the link in the browser to open the app
   - If "ng serve" doesn't work, check your path, or you need to do the basic node, npm and angular installations
8. You should be able to freely use the web app
