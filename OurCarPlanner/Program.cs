using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;

namespace OurCarPlanner
{
    public class Program
    {
        public static void Main(string[] args)
        {

            IConfigurationRoot configuration = new ConfigurationBuilder()
          .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
          .AddJsonFile("appsettings.json")
          .Build();
            MongoClient client = new MongoClient(configuration.GetConnectionString("OurCarDb"));
            IMongoDatabase database = client.GetDatabase("OurCarDb");


            //var collection1 = database.GetCollection<BsonDocument>("UserMaster");
            //BsonArray dataFields1 = new BsonArray { new BsonDocument {
            //{ "ID" , ObjectId.GenerateNewId()}, { "NAME", "ID"}} };

            //BsonDocument document1 = new BsonDocument {
            //    { "UserId",10001},
            //    { "Username" , "Ranjith Kumar"},
            //    { "Password" , "#123@"},
            //    { "Dob" , "27/12/1980"},
            //    { "Address" , "#502,Eternity Ecstasy Apartment"},
            //    { "ContactNo" , "9880892916"},
            //    { "Email" , "ranjit_kumar@gmail.com"},
            //    { "UserTypeId" , 12345},
            //    { "Creation_Date" , "27/08/2021"}};

            //collection1.InsertOne(document1);

            //var collection2 = database.GetCollection<BsonDocument>("UserMaster");
            //BsonArray dataFields2 = new BsonArray { new BsonDocument {
            //{ "ID" , ObjectId.GenerateNewId()}, { "NAME", "ID"}} };

            //BsonDocument document2 = new BsonDocument {
            //    { "UserId",10002},
            //    { "Username" , "Ranjan Kumar"},
            //    { "Password" , "#123@"},
            //    { "Dob" , "27/12/1980"},
            //    { "Address" , "#502,Eternity Ecstasy Apartment"},
            //    { "ContactNo" , "9880892916"},
            //    { "Email" , "ranjit_kumar@gmail.com"},
            //    { "UserTypeId" , 12345},
            //    { "Creation_Date" , "27/08/2021"}};

            //collection2.InsertOne(document2);

            //var collection3 = database.GetCollection<BsonDocument>("UserMaster");
            //BsonArray dataFields3 = new BsonArray { new BsonDocument {
            //{ "ID" , ObjectId.GenerateNewId()}, { "NAME", "ID"}} };

            //BsonDocument document3 = new BsonDocument {
            //    { "UserId",10003},
            //    { "Username" , "Ranjith Kumar"},
            //    { "Password" , "#123@"},
            //    { "Dob" , "27/12/1980"},
            //    { "Address" , "#502,Eternity Ecstasy Apartment"},
            //    { "ContactNo" , "9880892916"},
            //    { "Email" , "ranjit_kumar@gmail.com"},
            //    { "UserTypeId" , 12345},
            //    { "Creation_Date" , "27/08/2021"}};

            //collection3.InsertOne(document3);

            //var collection4 = database.GetCollection<BsonDocument>("UserMaster");
            //BsonArray dataFields4 = new BsonArray { new BsonDocument {
            //{ "ID" , ObjectId.GenerateNewId()}, { "NAME", "ID"}} };

            //BsonDocument document4 = new BsonDocument {
            //    { "UserId",10004},
            //    { "Username" , "Ranjith Kumar"},
            //    { "Password" , "#123@"},
            //    { "Dob" , "27/12/1980"},
            //    { "Address" , "#502,Eternity Ecstasy Apartment"},
            //    { "ContactNo" , "9880892916"},
            //    { "Email" , "ranjit_kumar@gmail.com"},
            //    { "UserTypeId" , 12345},
            //    { "Creation_Date" , "27/08/2021"}};

            //collection4.InsertOne(document4);

            //var collection2 = database.GetCollection<BsonDocument>("Booking");
            //BsonArray dataFields2 = new BsonArray { new BsonDocument {
            //{ "ID" , ObjectId.GenerateNewId()}, { "NAME", "ID"}} };

            //BsonDocument document2 = new BsonDocument {
            //    { "BookingId" , "12345" },
            //    { "Name" , "Ranjith"},
            //    { "FromDate" , "27/12/2021"},
            //    { "ToDate" , "27/12/2021"},
            //    { "S_Address" , "SilkBoard" },
            //    { "D_Address" , "Belendur" },
            //    { "UserId" , "12345" },
            //    { "Email" , "Ranjith@gmail.com" },
            //    { "ContactNo" , "9880892916"},
            //    { "Amount" , "PaymentStatus" },
            //    { "PaymentStatus" , "Y" },
            //    { "CarId", 123456},
            //    { "CreatedOn", "27/08/2021" }
            //};
            //collection2.InsertOne(document2);

            //var collection3 = database.GetCollection<BsonDocument>("PaymentTB");
            //BsonArray dataFields3 = new BsonArray { new BsonDocument {
            //{ "ID" , ObjectId.GenerateNewId()}, { "NAME", "ID"}} };

            //BsonDocument document3 = new BsonDocument {
            //    { "PaymentId" , 12345 },
            //    { "CarId" , 123456},
            //    { "Amount" , "12345678.00" },
            //    { "PaymentDate" , "27/12/2021" },
            //    { "BankId" , 12345 },
            //    { "UserId" , 12345 },
            //    { "BookingId" , 12345 },
            //    { "CreatedOn", "27/08/2021" }
            //};
            //collection3.InsertOne(document3);

            //var collection5 = database.GetCollection<BsonDocument>("UserType");
            //BsonArray dataFields5 = new BsonArray { new BsonDocument {
            //{ "ID" , ObjectId.GenerateNewId()}, { "NAME", "ID"}} };

            //BsonDocument document5 = new BsonDocument {
            //    { "UserTypeId" , 12345 },
            //    { "UserTypeName" , "IT Employee"}
            //};
            //collection5.InsertOne(document5);

            //var collection5 = database.GetCollection<BsonDocument>("TokenManager");
            //BsonArray dataFields5 = new BsonArray { new BsonDocument {
            //{ "ID" , ObjectId.GenerateNewId()}, { "NAME", "ID"}} };

            //BsonDocument document5 = new BsonDocument {
            //    { "TokenId" , 12345 },
            //    { "TokenKey" , "12345678901234567890"},
            //    { "IssueOn" , "27/08/2021"},
            //    { "ExpiresOn" , "27/08/2022"},
            //    { "CreatedOn" , "27/08/2021"},
            //    { "UserId" , "12345"}     
            //};
            //collection5.InsertOne(document5);

            //var collection6 = database.GetCollection<BsonDocument>("BankTB");
            //BsonArray dataFields6 = new BsonArray { new BsonDocument {
            //{ "ID" , ObjectId.GenerateNewId()}, { "NAME", "ID"}} };

            //BsonDocument document6 = new BsonDocument {
            //    { "BankId" , 12345 },
            //    { "BankName" , "State Banak Of India"},
            //};
            //collection6.InsertOne(document6);

            //var collection6 = database.GetCollection<BsonDocument>("GroupMaster");
            //BsonArray dataFields6 = new BsonArray { new BsonDocument {
            //{ "ID" , ObjectId.GenerateNewId()}, { "NAME", "ID"}} };

            //BsonDocument document6 = new BsonDocument {
            //    { "GroupId" , 12345 },
            //    { "GroupName" , "ABCD"},
            //    { "GroupImageUrl" , "http:\\google.com"},
            //    { "GroupAdminId" , "12345"},
            //    { "NumberOfMembers" , "4"},
            //    { "GroupMembers" , "Yes"},
            //    { "UserId" , "10001"}
            //};
            //collection6.InsertOne(document6);



            CreateWebHostBuilder(args).Build().Run();

        }
    
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
