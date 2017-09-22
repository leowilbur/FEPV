using FEPV.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FEPV.Implementation
{
    public static class Trucks_Factory
    {
        public static ITruckDAL CreateTruck(string typeName)
        {
            switch (typeName)
            {
                case "JointTruck":
                    return new JointTruck_DAL();
                case "PtaEgTruck":
                    return new PtaEgTruck_DAL();
                case "UnJointTruck":
                    return new UnJointTruck_DAL();
                case "SpecialTruck":
                    return new SpecialTruck_DAL();
                case "NearTruck":
                    return new NearTruck_DAL();
                default:
                    throw new Exception("No type found " + typeName.ToString());
            }
        }
    }
}
