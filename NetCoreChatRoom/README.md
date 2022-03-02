	Requirementes to run the project:

*Must have Microsoft SQL server in localhost or in cloud (must execute migrations to deploy the DB)

*Both applications are constructed in net core 6 LTS so it's necessary have the runtime installed to run the application.

*It's not ready for deployment in cloud, some adjustments must be made to be totally compatible

*I think visual studio 2022 is required, probably the vs 2019 could get some errors.


	I created two projects:

One project for the front end: https://github.com/ADSNB/NetCore6-ChatRoom

One project for the api (backend): https://github.com/ADSNB/NetCore6-ChatRoomAPI

	Configurations needed ChatRoomAPI project:

1 - The AppSettings.Json the parameter "Database.ConnectionString" must be changed to your database location

2 - Execute the migrations against the database

	How to execute the project?
1 - Open the front end in vs 2022 and run the application.

2 - Open the API, alter the connection string

3 - run the command "update-database" in the package manager console

4 - run the API project

5 - In the home page of the website is located the user and passwords of two users for testing pourposes, notice that when you log in with this users you must skip the policy from attach the MFA because my B2C have a free license only

	About the project:
	
*I constructed the applications using the last .net core version avaible.

*The project architecture is following a custom DDD pattern that i'm improving over the years, is not perfect but is a good structure without loose so much time constructing things.

*For logging i use Serilog and for small test cases i uso mocks using faker and autofixture. The Serilog generate logs in console and phisicaly by day located inside the folder "Logs" in each project. This folder is only created when the project is running / generating some logs.

*The two projects are with identity authentication (microsoft identity provider) listening to my private B2C for testing (the two users for access are listed in the home page).

*The authentication works and only the authenticated persons can send messages and create communication groups.

*The service that call the API and the project API have identity too but i disabled the authentication in methods because still need more changes to have the openid to work as expected.

	FrontEnd considerations:
*The chat and push notifications work for multiple users simultaneously. 

*Implemented the chat as components

*The command to bring the stock value for now only works if typed exacly as "/stock=aapl.us", later can be programmed to verify if is present in a message text.

	BackEnd considerations:
*This application have SignalR for notifications on the API, so all the "clients" listen to the one server.

*Because of the time to implement RabbitMQ or Azure Service Bus, i used a queue built in database called (ProcessingQueue).

*The commands that are sent to the API are stored in the ProcessingQueue table to be processed in another time by the robot.

*The robot is present in the API as background worker service, executing the analysis of the csv file located inside the application and returning the respective value.

*More "commands" can be implemented later in the current structure easily.
	
I constructed this project from scratch, first time working with .netcore 6 (i currently work with netcore 3.1), i know the unit tests are missing, but i tried to demonstrate my knowledge with architecture, good practices following clean code and DDD structures, some principal of DRY, KISS and the directives of the challenge.

If you have any questions feel free to ask.

	      