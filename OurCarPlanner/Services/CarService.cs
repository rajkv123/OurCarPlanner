﻿using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using OurCarPlanner.Models;
using System.IO;
using MongoDB.Driver.GridFS;
using System.Threading.Tasks;
using MongoDB.Bson;
namespace OurCarPlanner.Services
{
    public class CarService
    {
        private readonly IMongoCollection<Car> cars;
        private IGridFSBucket bucket;
        private byte[] source;
        private ObjectId id;
        public CarService(IConfiguration config)
        {
            MongoClient client = new MongoClient(config.GetConnectionString("OurCarDb"));
            IMongoDatabase database = client.GetDatabase("OurCarDb");
            cars = database.GetCollection<Car>("Cars");
            
            var fs = new GridFSBucket(database);
            var options = new GridFSUploadOptions
            {
                ChunkSizeBytes = 64512, // 63KB
                Metadata = new BsonDocument{
                    { "resolution", "1080P" },
                    { "copyrighted", true }
                }
            };
            var id = UploadFile(fs);

            DownloadFile(fs, id);
        }

        public List<Car> Get()
        {
            return cars.Find(car => true).ToList();
        }

        public Car Get(string id)
        {
            return cars.Find(car => car.Id == id).FirstOrDefault();
        }

        public Car Create(Car car)
        { 
            source = ReadImageFile(car.ImageUrl);
            cars.InsertOne(car);
            return car;
        }

        public void Update(string id, Car carIn)
        {
            cars.ReplaceOne(car => car.Id == id, carIn);
        }

        public void Remove(Car carIn)
        {
            cars.DeleteOne(car => car.Id == carIn.Id);
        }

        public void Remove(string id)
        {
            cars.DeleteOne(car => car.Id == id);
        }
        private static ObjectId UploadFile(GridFSBucket fs)
        {
            using (var s = File.OpenRead(@"C:\OurCarPlanner\OurCarPlanner\wwwroot\images\bentley.jpg"))
            {
                var t = Task.Run<ObjectId>(() => {
                    return
                    fs.UploadFromStreamAsync("bentley.jpg", s);
                });

                return t.Result;
            }
        }
        private static void DownloadFile(GridFSBucket fs, ObjectId id)
        {
            //This works
            var t = fs.DownloadAsBytesByNameAsync("bentley.jpg");
            Task.WaitAll(t);
            var bytes = t.Result;


            //This blows chunks (I think it's a driver bug, I'm using 2.1 RC-0)
            var x = fs.DownloadAsBytesAsync(id);
            Task.WaitAll(x);
        }

        public static byte[] ReadImageFile(string imageLocation)
        {
            byte[] imageData = null;
            FileInfo fileInfo = new FileInfo(imageLocation);
            long imageFileLength = fileInfo.Length;
            FileStream fs = new FileStream(imageLocation, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            imageData = br.ReadBytes((int)imageFileLength);
            return imageData;
        }
    }
}
