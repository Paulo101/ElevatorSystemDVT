using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorLibrary.Interfaces
{
    internal interface IElevatorSystem
    {
        void SelectFloorTo(int floor, int persons, int weight);
    }
}
