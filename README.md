# How to create .NET8 CRUD WebAPI Azure MySQL Microservice and deploy to Docker Desktop and Kubernetes (in your local laptop)

The source code is available in this github: https://github.com/luiscoco/MicroServices_dotNET8_CRUD_WebAPI-Azure-MySQL

## 1. Prerequisite

### 1.1. Create Azure MySQL instance

We navigate to **Create a resource** and select **Databases**

![image](https://github.com/luiscoco/MicroServices_dotNET8_CRUD_WebAPI-Azure-MySQL/assets/32194879/7bb4ea70-3f0f-48bc-8b89-e35bb54c5560)

We select **Azure Database for MySQL**

![image](https://github.com/luiscoco/MicroServices_dotNET8_CRUD_WebAPI-Azure-MySQL/assets/32194879/85c7aaa5-e78a-44be-90a3-ba0f3bb044ec)

We select create **Flexible server**

![image](https://github.com/luiscoco/MicroServices_dotNET8_CRUD_WebAPI-Azure-MySQL/assets/32194879/3cffaceb-5f74-4ad9-aacd-ec4a7bb09561)

Server Name: mysqlserver1974

![image](https://github.com/luiscoco/Azure_MySQL_database_sample/assets/32194879/7888e174-5874-4088-b60d-169e633ce207)

![image](https://github.com/luiscoco/Azure_MySQL_database_sample/assets/32194879/66bbe93a-8f4d-4fd3-a040-404ac83d29be)

![image](https://github.com/luiscoco/Azure_MySQL_database_sample/assets/32194879/0bacefd4-d435-4f16-a3c0-94d53fdcb54b)

Admin username: adminmysql

Password: LuiscocoXXXXXXXXXXX

![image](https://github.com/luiscoco/Azure_MySQL_database_sample/assets/32194879/d5d3aa4e-ca08-4685-b34a-5646218a7b06)

We navigate to the **Networking** tab and we add our laptop IP address as a FireWall rule

![image](https://github.com/luiscoco/MicroServices_dotNET8_CRUD_WebAPI-Azure-MySQL/assets/32194879/1d7c4f75-f426-4a7f-9f5a-e77d476d9017)

![image](https://github.com/luiscoco/MicroServices_dotNET8_CRUD_WebAPI-Azure-MySQL/assets/32194879/1d162c08-e972-43c2-9d0a-a6d9a52394e5)

We can now access Azure MySQL from MySQL Workbench setting the hostname, username and password

![image](https://github.com/luiscoco/Azure_MySQL_database_sample/assets/32194879/4adddbe8-dbdc-46a4-b7d5-8cd2abb2012c)

### 1.2. Run MySQL Workbench and create new database

We run **MySQL Workbench** and we create a new connection

![image](https://github.com/luiscoco/Azure_MySQL_database_sample/assets/32194879/d9b15ade-9287-4ee3-a823-7c069d3f5882)

We input the new connection data

![image](https://github.com/luiscoco/Azure_MySQL_database_sample/assets/32194879/6a4a4128-909f-4c25-b418-dfbc581415fe)

For input the password press the **Store in Vault** button

![image](https://github.com/luiscoco/Azure_MySQL_database_sample/assets/32194879/69bcae6e-f4e1-41af-9682-e24fed6fde37)

Now we can test the connection pressing on the **Test connection** button 

![image](https://github.com/luiscoco/Azure_MySQL_database_sample/assets/32194879/dc4aa2c0-eec2-4e82-b1b7-6b50f5c894c8)

![image](https://github.com/luiscoco/Azure_MySQL_database_sample/assets/32194879/ca86f888-4e09-4a90-b536-5c054ae4bc97)

We create a database running this command

```sql
CREATE DATABASE mysqldatabase
```

![image](https://github.com/luiscoco/Azure_MySQL_database_sample/assets/32194879/2fcf9252-d1ed-40d2-8a77-2e013f890f3b)

We create a new Table an insert some rows

```sql
CREATE TABLE Items (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Name VARCHAR(255) NOT NULL
    -- Add other fields here as per your model
);

INSERT INTO Items (Name) VALUES ('Item 1');
INSERT INTO Items (Name) VALUES ('Item 2');
INSERT INTO Items (Name) VALUES ('Item 3');
```

![image](https://github.com/luiscoco/MicroServices_dotNET8_CRUD_WebAPI-Azure-MySQL/assets/32194879/37def597-fdf8-4751-bdac-6be5a0122adc)

We can verify the inserted items

![image](https://github.com/luiscoco/MicroServices_dotNET8_CRUD_WebAPI-Azure-MySQL/assets/32194879/5b50e136-99a2-43c8-83ae-9d9037317211)

## 2. How to Create .NET 8 WebAPI CRUD Microservice with Dapper

We run Visual Studio 2022 Community Edition and we create a new project

![image](https://github.com/luiscoco/MicroServices_dotNET8_CRUD_WebAPI-Azure-MySQL/assets/32194879/af1466b6-cc3c-4e12-9354-e32c964452bd)

We select the **ASP Net Core Web API** project template

![image](https://github.com/luiscoco/MicroServices_dotNET8_CRUD_WebAPI-Azure-MySQL/assets/32194879/4fcaf53f-a3d9-4fee-bcca-40deea423567)

We set the project name and location

![image](https://github.com/luiscoco/MicroServices_dotNET8_CRUD_WebAPI-Azure-MySQL/assets/32194879/1a0e2858-4f16-44a9-80dd-003e53d0c4c2)

We select the project main features

![image](https://github.com/luiscoco/MicroServices_dotNET8_CRUD_WebAPI-Azure-MySQL/assets/32194879/13ae7b79-5c3f-4635-a162-574d0895d049)

We create the following project folders structure, with the **Data** and **Models** new folders

![image](https://github.com/luiscoco/MicroServices_dotNET8_CRUD_WebAPI-Azure-MySQL/assets/32194879/8c763bd8-f05b-4702-8ad0-8b3897d9e8c0)

We load the dependencies: **Dapper**, Microsoft.VisualStudio.Azure.Containers.Tools.Targets, **MySql.Data** and Swashbuckle.AspNetCore

![image](https://github.com/luiscoco/MicroServices_dotNET8_CRUD_WebAPI-Azure-MySQL/assets/32194879/ba031007-9602-4743-abee-1619afe029f3)

We define in the **appsettings.json** file the database connection string 

![image](https://github.com/luiscoco/MicroServices_dotNET8_CRUD_WebAPI-Azure-MySQL/assets/32194879/484d634c-fba3-4562-98a7-3a5156182fcd)

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "server=mysqlserver1974.mysql.database.azure.com;database=mysqldatabase;user=adminmysql;password=Luiscoco123456"
  }
}
```

We register the database service in the **pogram.cs** file 

**progam.cs**

```csharp
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AzureMySQLWebAPI.Data;
using AzureMySQLWebAPI.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Register database repository
builder.Services.AddScoped<ItemRepository>(serviceProvider =>
    new ItemRepository(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
```

We create the database **Model** in the Item.cs file

**Item.cs**

```csharp
namespace AzureMySQLWebAPI.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        // Add other properties as needed
    }
}
```

We create the database **Repository** in the ItemRepository.cs file

**ItemRepository.cs**

```csharp
using Dapper;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using AzureMySQLWebAPI.Models;

namespace AzureMySQLWebAPI.Data
{
    public class ItemRepository
    {
        private readonly string _connectionString;

        public ItemRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<Item>> GetAllItemsAsync()
        {
            using (IDbConnection db = new MySqlConnection(_connectionString))
            {
                return await db.QueryAsync<Item>("SELECT * FROM Items");
            }
        }

        // Add method to retrieve a single item by id
        public async Task<Item> GetItemByIdAsync(int id)
        {
            using (IDbConnection db = new MySqlConnection(_connectionString))
            {
                return await db.QueryFirstOrDefaultAsync<Item>("SELECT * FROM Items WHERE Id = @Id", new { Id = id });
            }
        }

        // Add method to insert a new item
        public async Task<int> AddItemAsync(Item item)
        {
            using (IDbConnection db = new MySqlConnection(_connectionString))
            {
                var sql = "INSERT INTO Items (Name) VALUES (@Name); SELECT LAST_INSERT_ID();";
                return await db.ExecuteScalarAsync<int>(sql, item);
            }
        }

        // Add method to update an existing item
        public async Task UpdateItemAsync(Item item)
        {
            using (IDbConnection db = new MySqlConnection(_connectionString))
            {
                var sql = "UPDATE Items SET Name = @Name WHERE Id = @Id";
                await db.ExecuteAsync(sql, item);
            }
        }

        // Add method to delete an item
        public async Task DeleteItemAsync(int id)
        {
            using (IDbConnection db = new MySqlConnection(_connectionString))
            {
                await db.ExecuteAsync("DELETE FROM Items WHERE Id = @Id", new { Id = id });
            }
        }

        public async Task AddItemUsingStoredProcedureAsync(Item item)
        {
            using (IDbConnection db = new MySqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("itemName", item.Name, DbType.String);

                await db.ExecuteAsync("AddNewItem", parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
```

We create the **Controller** for defining the database CRUD actions

**ItemsController.cs**

```csharp
using Microsoft.AspNetCore.Mvc;
using AzureMySQLWebAPI.Data;
using AzureMySQLWebAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureMySQLWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly ItemRepository _repository;

        public ItemsController(ItemRepository repository)
        {
            _repository = repository;
        }

        // GET: api/items
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> GetItems()
        {
            var items = await _repository.GetAllItemsAsync();
            return Ok(items);
        }

        // GET: api/items/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> GetItem(int id)
        {
            var item = await _repository.GetItemByIdAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        // POST: api/items
        [HttpPost]
        public async Task<ActionResult<Item>> PostItem(Item item)
        {
            int id = await _repository.AddItemAsync(item);
            item.Id = id;
            return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item);
        }

        // PUT: api/items/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItem(int id, Item item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            await _repository.UpdateItemAsync(item);

            return NoContent();
        }

        // DELETE: api/items/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            await _repository.DeleteItemAsync(id);
            return NoContent();
        }

        // POST: api/items/sp
        [HttpPost("sp")]
        public async Task<IActionResult> PostItemUsingStoredProcedure([FromBody] Item item)
        {
            await _repository.AddItemUsingStoredProcedureAsync(item);
            return CreatedAtAction("GetItem", new { id = item.Id }, item);
        }
    }
}
```

We **run the application** and we verify the enpoints with swagger

![image](https://github.com/luiscoco/MicroServices_dotNET8_CRUD_WebAPI-Azure-MySQL/assets/32194879/ad9de442-3317-4841-a5ca-c3e0a8812f6e)

![image](https://github.com/luiscoco/MicroServices_dotNET8_CRUD_WebAPI-Azure-MySQL/assets/32194879/4381ea06-ee29-4a77-a6d5-da690afad46c)

## 3. How to deploy the WebAPI Microservice to Docker Desktop

We right click on the project and we add Docker support... 

Automatically Visual Studio will create the Dockerfile

**Dockerfile**

```
#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["AzureMySQLWebAPI.csproj", "."]
RUN dotnet restore "./././AzureMySQLWebAPI.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "./AzureMySQLWebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./AzureMySQLWebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AzureMySQLWebAPI.dll"]
```

We right click on the project and select **Open in Terminal** and the we run the following command to create the Docker image

```
docker build -t myapp:latest .
```

We verify the **Docker image** was created with the command

```
docker images
```

We run the **Docker container** with the following command

```
docker run -d -p 8080:8080 myapp:latest
```

Also in **Docker Desktop** we can see the Docker image and the running container

![image](https://github.com/luiscoco/MicroServices_dotNET8_CRUD_WebAPI-Azure-MySQL/assets/32194879/416a9cba-1f26-474e-bae7-f0a86a5d583d)

![image](https://github.com/luiscoco/MicroServices_dotNET8_CRUD_WebAPI-Azure-MySQL/assets/32194879/39c252c9-82d5-4442-ac8c-1d2dff5a38c2)

We verify the running docker container with the command

```
docker ps
```

We can access with **HTTP** protocol to the  **application endpoints**

http://localhost:8080/api/Items

![image](https://github.com/luiscoco/MicroServices_dotNET8_CRUD_WebAPI-Azure-MySQL/assets/32194879/517b7597-a1c6-4f04-9fde-244456653c5a)

If we would like to access with Swagger the API documentation, we first should comment in program.cs the following lines:

```csharp
...
// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}
...
```

Now we can run the docker container and access to API documentation (Swagger)

![image](https://github.com/luiscoco/MicroServices_dotNET8_CRUD_WebAPI-Azure-MySQL/assets/32194879/2015e1a3-ae5d-41ca-b9d9-006ec9f709a4)

If we would like to run the application with **HTTPS** protocol we have to create a certificate

We create a certificate running in PowerShell this command

```
New-SelfSignedCertificate -DnsName localhost -CertStoreLocation cert:\LocalMachine\My
```

![image](https://github.com/luiscoco/MicroServices_dotNET8_CRUD_WebAPI-Azure-MySQL/assets/32194879/3e8997b8-68a5-4d8e-89aa-54ff260abe90)

We open **Manage Computer Certificates** and look for the certificate in the **Personal/Certificates** folder

![image](https://github.com/luiscoco/MicroServices_dotNET8_CRUD_WebAPI-Azure-MySQL/assets/32194879/f00ee620-1068-4589-8ead-3161452be58c)

We select the certificate and we **export to PFX** file

![image](https://github.com/luiscoco/MicroServices_dotNET8_CRUD_WebAPI-Azure-MySQL/assets/32194879/f9dd52b9-7ee4-49ac-a594-dd21c30e9f36)

![image](https://github.com/luiscoco/MicroServices_dotNET8_CRUD_WebAPI-Azure-MySQL/assets/32194879/9eac1ab9-6767-44f1-9f58-da57e3e94dd2)

We select the option **Yes export the private key**

![image](https://github.com/luiscoco/MicroServices_dotNET8_CRUD_WebAPI-Azure-MySQL/assets/32194879/df5985e7-4c3b-47d1-8c94-8c55b8e530c3)

![image](https://github.com/luiscoco/MicroServices_dotNET8_CRUD_WebAPI-Azure-MySQL/assets/32194879/c01568e6-ed64-412c-a1aa-d44d3521dbac)

![image](https://github.com/luiscoco/MicroServices_dotNET8_CRUD_WebAPI-Azure-MySQL/assets/32194879/c750eada-574d-4463-b6cb-ab0bd12c0ddc)

We save the **PFX** file in our local application source code folder

![image](https://github.com/luiscoco/MicroServices_dotNET8_CRUD_WebAPI-Azure-MySQL/assets/32194879/64206cce-9839-438f-8cf8-ee40d586053f)

We also copy the certificate from **Personal/Certificates** folder to **Trusted Root Certification Authorities/Certificates** folder

![image](https://github.com/luiscoco/MicroServices_dotNET8_CRUD_WebAPI-Azure-MySQL/assets/32194879/36381d7e-387b-4788-a323-82bfa501f119)

We first have to modify the **appsettings.json** file

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "server=mysqlserver1974.mysql.database.azure.com;database=mysqldatabase;user=adminmysql;password=Luiscoco123456"
  },
  "Kestrel": {
    "Endpoints": {
      "Http": {
        "Url": "http://*:8080"
      },
      "Https": {
        "Url": "https://*:8081",
        "Certificate": {
          "Path": "certificate.pfx",
          "Password": "123456"
        }
      }
    }
  }
}
```

We also need to modify the **Program.cs** file commenting this line: //app.UseHttpsRedirection();

And also to modify the **Dockerfile** to copy the certificate adding this line: 

```
# Copy the certificate file into the Docker image
COPY ["certificate.pfx", "."]
```

See the new Dockerfile

```
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["AzureMySQLWebAPI.csproj", "."]
RUN dotnet restore "./././AzureMySQLWebAPI.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "./AzureMySQLWebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./AzureMySQLWebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
# Copy the certificate file into the Docker image
COPY ["certificate.pfx", "."]
ENTRYPOINT ["dotnet", "AzureMySQLWebAPI.dll"]
```

If we would like to access our application via **HTTP** or **HTTPS** we run the docker container with this command

```
docker run -d -p 8080:8080 -p 8081:8081 myapp:latest
```

We verify in **Docker Desktop**

![image](https://github.com/luiscoco/MicroServices_dotNET8_CRUD_WebAPI-Azure-MySQL/assets/32194879/cd1fd66b-f245-4113-897b-ae805d8a9584)

We verify the **application endpoints**

http://localhost:8080/swagger/index.html

![image](https://github.com/luiscoco/MicroServices_dotNET8_CRUD_WebAPI-Azure-MySQL/assets/32194879/21012929-8ba2-4a7e-a0c2-faec5e33e196)

https://localhost:8081/swagger/index.html

![image](https://github.com/luiscoco/MicroServices_dotNET8_CRUD_WebAPI-Azure-MySQL/assets/32194879/51d9fa18-db7f-48b7-a3cd-47a19e16ff07)

## 4. How to deploy the WebAPI Microservice to Kubernetes (in Docker Desktop)

For more details about this section see the repo: https://github.com/luiscoco/Kubernetes_Deploy_dotNET_8_Web_API

We enable **Kubernetes** in **Docker Desktop**

We run **Docker Desktop** and press on **Settings** button

![image](https://github.com/luiscoco/MicroServices_dotNET8_CRUD_WebAPI-Azure-MySQL/assets/32194879/8400e0df-1b4b-48c6-8b8d-a2abc4cd1868)

We select **Enable Kubernetes** in the left hand side menu an press **Apply & Restart** button

![image](https://github.com/luiscoco/MicroServices_dotNET8_CRUD_WebAPI-Azure-MySQL/assets/32194879/40aac32a-67a4-4b1e-9bf6-c1bff1843896)

![image](https://github.com/luiscoco/MicroServices_dotNET8_CRUD_WebAPI-Azure-MySQL/assets/32194879/c7823d67-e0cc-4162-b6db-2218420ac3a6)

Here are the general steps to deploy your .NET 8 Web API to Kubernetes:

- **Build** and **Push** the Docker image to the **Docker Hub registry/repo**

- Create Kubernetes **Deployment YAML file**. This file defines how your application is deployed in Kubernetes.

- Create Kubernetes **Service YAML file**. This file defines how your application is exposed, either within Kubernetes cluster or to the outside world.

- Apply the **YAML** files to your Kubernetes Cluster: use the command "kubectl apply" to create the resource defined in your YAML file in your Kubernetes cluster.

We start building and pushing the application Docker image to the Docker Hub registry/repo

```
docker build -t luiscoco/myapp:latest .
```

To verify we created the docker image run the command:

```
docker images
```

Then we use the docker push command to upload the image to the Docker Hub repository:

```
docker push luiscoco/myapp:latest
```

**Note**: run the "**docker login**" command if you have no access to Docker Hub repo

We create the deployment.yml and the service.yml files in our project

![image](https://github.com/luiscoco/MicroServices_dotNET8_CRUD_WebAPI-Azure-MySQL/assets/32194879/45cd598d-c158-46ec-a738-015c93f985ed)

**deployment.yml**

```yaml
apiVersion: apps/v1
kind: Deployment
metadata:
  name: myapp-deployment
spec:
  replicas: 2
  selector:
    matchLabels:
      app: myapp
  template:
    metadata:
      labels:
        app: myapp
    spec:
      containers:
      - name: myapp
        image: luiscoco/myapp:latest
        ports:
        - containerPort: 8080
        - containerPort: 8081
        env:
        - name: ConnectionStrings__DefaultConnection
          value: server=mysqlserver1974.mysql.database.azure.com;database=mysqldatabase;user=adminmysql;password=Luiscoco123456
        volumeMounts:
        - mountPath: /app/certificate.pfx
          name: cert-volume
          subPath: certificate.pfx
      volumes:
      - name: cert-volume
        secret:
          secretName: myapp-cert
```

**service.yml**

```yml
apiVersion: v1
kind: Service
metadata:
  name: myapp-service
spec:
  type: LoadBalancer
  selector:
    app: myapp
  ports:
    - name: http
      protocol: TCP
      port: 80
      targetPort: 8080
    - name: https
      protocol: TCP
      port: 443
      targetPort: 8081
```

We set the current Kubernetes context to Docker Desktop Kubernetes with this command:

```
kubectl config use-context docker-desktop
```

In a typical Kubernetes deployment, the files used for configuration (like **certificates**) need to be accessible to the Kubernetes cluster. 

The most secure and common approach is to use a **Kubernetes Secret**. 

Since your certificate is a sensitive file, it should be managed as a Secret. 

Here's how you can modify your deployment to use a Kubernetes Secret for your certificate:

**We create a Kubernetes Secret that contains your certificate**. 

You can do this by running the following command in your terminal (make sure you're in the directory where **certificate.pfx** is located):

```
kubectl create secret generic myapp-cert --from-file=certificate.pfx
```

This command creates a new Secret named myapp-cert with the contents of certificate.pfx.

Now we can apply both kubernetes manifest files with these commands

```
kubectl apply -f deployment.yml
```

and

```
kubectl apply -f service.yml
```

We can use the command "**kubectl get services**" to check the **external IP** and port your application is accessible on, if using a LoadBalancer.

Verify the Deployment with the command:

```
kubectl get deployments
```

Verify the service status with the command:

```
kubectl get services
```

We can also verify the deployment with this command

```
kubectl get all
```

![image](https://github.com/luiscoco/MicroServices_dotNET8_CRUD_WebAPI-Azure-MySQL/assets/32194879/587f6d89-ac35-4edc-a9cf-c882d2e61f44)

We verify the application access endpoint

http://localhost/swagger/index.html

![image](https://github.com/luiscoco/MicroServices_dotNET8_CRUD_WebAPI-Azure-MySQL/assets/32194879/d39b1a51-11fe-4058-9bbd-b902e123ee77)


![image](https://github.com/luiscoco/MicroServices_dotNET8_CRUD_WebAPI-Azure-MySQL/assets/32194879/a4a4108d-21e6-4b69-81ff-49c38d3051f4)


