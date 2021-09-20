using System.Linq;
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
        public CarService(IConfiguration config)
        {
            MongoClient client = new MongoClient(config.GetConnectionString("OurCarDb"));
            IMongoDatabase database = client.GetDatabase("OurCarDb");
            cars = database.GetCollection<Car>("Cars");
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
        //private static ObjectId UploadFile(GridFSBucket fs)
        //{
        //    using (var s = File.OpenRead(@"C:\OurCarPlanner\OurCarPlanner\wwwroot\images\bentley.jpg"))
        //    {
        //        var t = Task.Run<ObjectId>(() => {
        //            return
        //            fs.UploadFromStreamAsync("bentley.jpg", s);
        //        });

        //        return t.Result;
        //    }
        //}
        //private static void DownloadFile(GridFSBucket fs, ObjectId id)
        //{
        //    //This works
        //    var t = fs.DownloadAsBytesByNameAsync("bentley.jpg");
        //    Task.WaitAll(t);
        //    var bytes = t.Result;


        //    //This blows chunks (I think it's a driver bug, I'm using 2.1 RC-0)
        //    var x = fs.DownloadAsBytesAsync(id);
        //    Task.WaitAll(x);
        //}

       
    }
}
