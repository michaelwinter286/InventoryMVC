# InventoryMVC
Inventory System MVC

Prior to running program please update database to ensure table creation. (update-database)

Features:
  * Make your application asynchronous - This was done through various interactions with Entity Framework and the SQL Database.
  * Create a dictionary or list, populate it with several values, retrieve at least one value, and use it in your program - I used the "ToListAsync()" method to call items from the Database to be displayed on the MVC web app.
  * Make a generic class and use it - When I created my Controllers for both my Livestock and Supplies models, a generic Class of "Controller" is created that both of my LivestockController and SuppliesController classes inherit from.


I will be continuing the development on a reporting aspect to pull different data out of the Database for reporting purposes.
