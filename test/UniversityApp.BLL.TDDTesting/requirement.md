## we write test driven development for new course entry 

### 1) need to create request and response object to insert data 

```
request data 
{
    name: "object oriend programming,
    code: "cs002,
    credit: 3.0
}

response data object 

{
    Id: 1
    name: "object oriend programming,
    code: "cs002,
    credit: 3.0
}
```

### 2) we need validation for our request data 
```
1) request not null
2) course name not empty and name must be between 3 to 50 character
3) course code not empty and code must be betwee 3 to 20 character
4) course credit between 1.0 to 5.0
```

### 3) we create validation using fluent validator library

### 4) before inserting data in database check name or code already exists in system

### 5) If code or name not exists in system then course data insert in database