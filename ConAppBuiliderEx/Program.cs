using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConAppBuiliderEx
{
    public class MainApp
    {
        static void Main(string[] args)
        {
            VehicleBuilder builder;

            Shop shop = new Shop();

            builder= new ScooterBuilder();
            shop.Construct(builder);
            builder.Vehicle.show();

            builder = new CarBuilder();
            shop.Construct(builder);
            builder.Vehicle.show();

            builder = new MotorCycleBuilder();
            shop.Construct(builder);
            builder.Vehicle.show();
        }


    }

    class Shop
    {
        public void Construct(VehicleBuilder vehicleBuilder)
        {
            vehicleBuilder.BuildFrame();
            vehicleBuilder.BuildEngine();
            vehicleBuilder.BuildWheels();
            vehicleBuilder.BuildDoors();
        }
    }



    abstract class VehicleBuilder
    {
        protected Vehicle vehicle;

        public Vehicle Vehicle
        {
            get { return vehicle; }
        }

        //Abstract Build Methods
        public abstract void BuildFrame();
        public abstract void BuildEngine();
        public abstract void BuildWheels();
        public abstract void BuildDoors();
    }

    class MotorCycleBuilder : VehicleBuilder
    {
        public MotorCycleBuilder()
        {
            vehicle = new Vehicle("MotorCycle");
        }

        public override void BuildDoors()
        {
            vehicle["doors"] = "0";
        }

        public override void BuildEngine()
        {
            vehicle["Engine"]="125 cc";
        }

        public override void BuildFrame()
        {
            vehicle["frame"] = "Motorcycle Frame";
        }

        public override void BuildWheels()
        {
            vehicle["wheels"]="2";
        }
    }
    class CarBuilder : VehicleBuilder
    {
        public CarBuilder()
        {
            vehicle = new Vehicle("Car");
        }
        public override void BuildDoors()
        {
            vehicle["doors"] = "4";
        }

        public override void BuildEngine()
        {
            vehicle["Engine"] = "2500 cc";
        }

        public override void BuildFrame()
        {
            vehicle["frame"] = "Car Frame";
        }

        public override void BuildWheels()
        {
            vehicle["wheels"] = "4";
        }
    }

    class ScooterBuilder : VehicleBuilder
    {
        public ScooterBuilder()
        {
            vehicle = new Vehicle("Scooter");
        }
        public override void BuildDoors()
        {
            vehicle["doors"] = "0";
        }

        public override void BuildEngine()
        {
            vehicle["Engine"] = "50 cc";
        }

        public override void BuildFrame()
        {
            vehicle["frame"] = "Scooter Frame";
        }

        public override void BuildWheels()
        {
            vehicle["wheels"] = "2";
        }
    }

    class Vehicle
    {
        private string _vehicleType;
        private Dictionary<string, string> _parts = new Dictionary<string, string>();
           
        public Vehicle(string vehicleType)
        {
            this._vehicleType = vehicleType;
        }

        public string this[string key]
        {
            get { return _parts[key]; }
            set { _parts[key] = value; }
        }

        public void show()
        {
            Console.WriteLine("\n-----------------------");
            Console.WriteLine("Vehicle Type: {0}",_vehicleType);
            Console.WriteLine("Frame: {0}", _parts["Frame"]);
            Console.WriteLine("Engine: {0}", _parts["Engine"]);
            Console.WriteLine("#wheels: {0}", _parts["wheels"]);
            Console.WriteLine("#Doors: {0}", _parts["doors"]);
        }
    }
}
