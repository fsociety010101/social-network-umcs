@echo off
cd SocialNetwork.Data
dotnet restore
rem dotnet ef dbcontext scaffold "Server=localhost;Port=3306;Database=social-network;User=root;Password=root;" "Pomelo.EntityFrameworkCore.MySql" -o Model -f -v -c BaseContext
dotnet ef dbcontext scaffold name=Database "Pomelo.EntityFrameworkCore.MySql" -o Model -f -v -c BaseContext
pause