using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces;

namespace Domain.Services
{
    public class ElevatorLogger : IElevatorLogger
    {
        private List<int> visitedFloors;
        public List<int> VisitedFloors { get => new List<int>(visitedFloors ?? Enumerable.Empty<int>()); }


        private List<int> commandFloors;
        public List<int> CommandFloors { get => new List<int>(commandFloors ?? Enumerable.Empty<int>()); }

        public ElevatorLogger()
        {
            visitedFloors = new List<int>();
            commandFloors = new List<int>();
        }

        public void LogInternalCommand(Command command)
        {
            var floor = (int)command.Floor;
            commandFloors.Add(floor);
        }

        public void LogVisitedFloor(FloorEnum floor)
        {
            visitedFloors.Add((int)floor);
        }

        public async Task SaveTxtAsync(string txtFilePath)
        {
            await File.WriteAllLinesAsync(txtFilePath, FormatTxtLines());
        }

        private List<string> FormatTxtLines()
        {
            var lines = new List<string>();
            lines.Add("Comandos do painel interno:\n");
            commandFloors.ForEach(floor => lines.Add("\t" + floor.ToString()));
            lines.Add("\n\n\nPavimentos visitados em ordem:\n");
            visitedFloors.ForEach(floor => lines.Add("\t" + floor.ToString()));

            return lines;
        }
    }
}