
Run_Back: ##funciona para correr el backend
	cd app/; dotnet run

Run_Migrations: ##corre las migraciones
	cd app/; dotnet-ef database update 

Run_Front: ##corre el front
	cd app-fe/; npm run dev
