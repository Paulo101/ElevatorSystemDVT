using ElevatorLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorLibrary.Classes
{
    //ElevatorSystem inherits from IElevatorSystem and implements SelectFloorToMethod
    public class ElevatorSystem : IElevatorSystem
    {
        private List<Elevator> elevators;
        private Queue<(int Floor, int Persons, int Weight)> floorQueue;
        //Default Constructor
        public ElevatorSystem(int numElevators, int maxPersonsPerElevator, int maxWeightPerElevator)
        {
            elevators = new List<Elevator>();
            for (int i = 0; i < numElevators; i++)
            {
                elevators.Add(new Elevator(maxPersonsPerElevator, maxWeightPerElevator));
            }

            floorQueue = new Queue<(int Floor, int Persons, int Weight)>();
        }
        public void SelectFloorTo(int floor, int persons, int weight)
        {
            floorQueue.Enqueue((floor, persons, weight));

            while (floorQueue.Count > 0)
            {
                var request = floorQueue.Peek();
                Elevator nearestElevator = GetNearestElevator(request.Floor, request.Persons, request.Weight);
                if (nearestElevator == null)
                {
                    nearestElevator = new Elevator(request.Floor, request.Persons);
                }
                var nextRequest = floorQueue.Dequeue();
                nearestElevator.AddPeople(nextRequest.Persons, nextRequest.Weight);
                nearestElevator.GoToFloor(nextRequest.Floor);
                
            }
        }
        #region HelperMethods
        private Elevator GetNearestElevator(int targetFloor, int persons, int weight)
        {
            Elevator? nearestElevator = null;
            int minDistance = int.MaxValue;
            //Foreach elevator, get elevator that is not moving and has capacity
            foreach (var elevator in elevators)
            {
                if (!elevator.IsMoving && elevator.IsInCapacity(persons, weight))
                {
                    int distance = Math.Abs(elevator.CurrentFloor - targetFloor);
                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        nearestElevator = elevator;
                    }
                }
            }

            return nearestElevator!;
        }
        #endregion
    }
}
