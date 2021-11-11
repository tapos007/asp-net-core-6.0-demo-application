# This is our first asp net core 6.0 application

## we use service repository pattern for implementing our application

### docker network create command

```
docker network create my-postgres
```

### postgres database setup in docker command
```
docker run --name my-postgres -p 5432:5432 \
--net my-postgres \
-v my-postgres-data:/var/lib/postgresql/data \
-e POSTGRES_PASSWORD=tapos007 -d postgres
```

### postgres database admin portal setup in docker command
```
docker run --name my-postgres-admin \
-p 9080:80 \
--net my-postgres \
-e 'PGADMIN_DEFAULT_EMAIL=tapos.aa@gmail.com' \
-e 'PGADMIN_DEFAULT_PASSWORD=tapos007' \
-d dpage/pgadmin4
```

### add new migration command

```
dotnet ef migrations add InitialMigration --project "src/UniversityApp.DLL" --startup-project "src/UniversityApp.API"
```

### migration update database command

```
dotnet ef database update --project "src/UniversityApp.DLL" --startup-project "src/UniversityApp.API"
```

### migration script generate command

```
dotnet ef migrations script --project "src/UniversityApp.DLL" --startup-project "src/UniversityApp.API" -o ./script.sql
```