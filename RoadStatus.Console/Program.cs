using System;
using System.Collections.Generic;
using System.Linq;
using RoadStatus.Code.Concretes;
using RoadStatus.Code.Contracts;
using RoadStatus.Code.Dtos;

namespace RoadStatus.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                IRoadService service = new RoadService();
                var road = args.Length > 0 ? args[0] : null;
                var corridors = service.GetRoadStatus(road);

                foreach (var corridor in corridors)
                {
                    System.Console.WriteLine($"The status of the {corridor.DisplayName} is as follows");
                    System.Console.WriteLine($" Road Status is {corridor.StatusSeverity}");
                    System.Console.WriteLine($" Road Status Description is {corridor.StatusSeverityDescription}");
                }

                System.Environment.Exit(0);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                System.Environment.Exit(1);
            }
        }
    }
}
