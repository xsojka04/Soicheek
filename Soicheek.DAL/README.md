cd Soicheek.DAL

dotnet tool update --global dotnet-ef

tvorba migrace
pro debug
dotnet ef migrations add nazev_migrace

pro produkci
dotnet ef migrations add nazev_migrace -- --environment Production

odstraneni posledni migrace
dotnet ef migrations remove

nasazeni -takto se nasadi vzdy vsechny migrace co jsou k dispozici
-- aby postgres fungoval jak ma, tak je treba: GRANT USAGE, CREATE ON SCHEMA public TO userxxx;

nasazeni dev
dotnet ef database update
nebo produkce
dotnet ef database update -- --environment Production