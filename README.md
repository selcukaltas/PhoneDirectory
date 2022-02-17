# PhoneDirectory
This project micro service implementation for person and report domains. The ddd approach has been tried to be taken as an example.

# Requirements

* .NET 5
* .PostgreSql
* .Docker
* .RabbitMq
# How to run
Easily run 'RabbitMq' on docker container
```bash
docker run -d -it --rm --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:3.9-management
```
Solution properties and multiple startup project Directory api, Report api and Gateway api
![image](https://user-images.githubusercontent.com/65852808/154561377-3a215f36-8936-4548-bed8-c117480854c0.png)

or you can use cmd  for every service **dotnet run**

# Gateway
Created gateway with ocelot and i use MMLib.SwaggerForOcelot so you can manage your microservices from gateway's swagger screen easily..You can see the endpoints below from gateway

![GatewaySwaggerPhone](https://user-images.githubusercontent.com/65852808/154561897-90d1ac61-9bc8-4cff-bd1d-d6fd33370422.png)

# 

# Equipments
* RabbitMq
* EFCore
* AutoMapper
* Ocelot
* MMlib.SwaggerForOcelot
* MMlib.Ocelot.Provider.AppConfiguration
* Swagger
