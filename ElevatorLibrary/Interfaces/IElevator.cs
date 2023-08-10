using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorLibrary.Interfaces
{
    public interface IElevator
    {
        void GoToFloor(int selectedFloor);
        bool IsInCapacity(int people, int weight);
        void AddPeople(int people, int weight);
        
    }
}
