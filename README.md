# How to create Azure MySQL instance

The source code is available in this github: https://github.com/luiscoco/MicroServices_dotNET8_CRUD_WebAPI-Azure-MySQL

## 1. Prerequisite -> Create Azure MySQL instance

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

![image](https://github.com/luiscoco/MicroServices_dotNET8_CRUD_WebAPI-Azure-MySQL/assets/32194879/668b307f-4617-4ebd-a431-8d07d911c928)

We can now access Azure MySQL from MySQL Workbench setting the hostname, username and password

![image](https://github.com/luiscoco/Azure_MySQL_database_sample/assets/32194879/4adddbe8-dbdc-46a4-b7d5-8cd2abb2012c)

We run **MySQL Workbench** and we create a new connection

![image](https://github.com/luiscoco/Azure_MySQL_database_sample/assets/32194879/d9b15ade-9287-4ee3-a823-7c069d3f5882)

We input the new connection data

![image](https://github.com/luiscoco/Azure_MySQL_database_sample/assets/32194879/6a4a4128-909f-4c25-b418-dfbc581415fe)

For input the password press the **Store in Vault** button

![image](https://github.com/luiscoco/Azure_MySQL_database_sample/assets/32194879/69bcae6e-f4e1-41af-9682-e24fed6fde37)

Now we can test the connection pressing on the **Test connection** button 

![image](https://github.com/luiscoco/Azure_MySQL_database_sample/assets/32194879/dc4aa2c0-eec2-4e82-b1b7-6b50f5c894c8)

![image](https://github.com/luiscoco/Azure_MySQL_database_sample/assets/32194879/ca86f888-4e09-4a90-b536-5c054ae4bc97)

![image](https://github.com/luiscoco/Azure_MySQL_database_sample/assets/32194879/2fcf9252-d1ed-40d2-8a77-2e013f890f3b)

## 2. How to Create .NET 8 WebAPI CRUD Microservice with Dapper


