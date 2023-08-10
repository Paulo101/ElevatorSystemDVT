using ElevatorLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorLibrary.Classes
{
    //Elevator inherits from IElevator and implements GoToFloor
    public class Elevator : IElevator
    {
        private bool isElevatorMoving;
        private int currentFloor;
        private int currentPersons;
        private int maximumWeight;
        private int currentWeight;
        private int maxPersons;
        //Default Constructor
        public Elevator(int maxWeight, int maxPersons)
        {
            currentFloor = 1;
            isElevatorMoving = false;
            this.maximumWeight = maxWeight;
            this.maxPersons = maxPersons;
        }
        public bool IsMoving => isElevatorMoving;
        public int CurrentFloor {
            get { return currentFloor; }
            private set { currentFloor = value; } 
        }
        public int MaxPersons
        {
            get { return maxPersons; }
            private set { maxPersons = value; }
        }
        public int CurrentPersons
        {
            get { return currentPersons; }
            private set { currentPersons = value; }
        }
        public int MaxWeight
        {
            get { return maximumWeight; }
            private set { maximumWeight = value; }
        }
        public int CurrentWeight
        {
            get { return currentWeight; }
            private set { currentWeight = value; }
        }
        public void GoToFloor(int selectedFloor)
        {
            if (isElevatorMoving)
            {
                Console.WriteLine("\tElevator is already in motion.");
                return;
            }

            isElevatorMoving = true;
            Console.WriteLine($"\tElevator is moving from floor {currentFloor} to floor {selectedFloor}.");

            // Simulate elevator movement
            for (int floor = currentFloor; floor != selectedFloor;)
            {
                floor += (selectedFloor - floor) / Math.Abs(selectedFloor - floor);
                Console.WriteLine($"\tElevator is passing floor {floor}.");
            }

            currentFloor = selectedFloor;
            isElevatorMoving = false;
            Console.WriteLine($"\tElevator has arrived at floor {currentFloor}.");

        }

        public bool IsInCapacity(int people, int weight)
        {
            return currentPersons
                + people <= maxPersons && currentWeight + weight <= maximumWeight;

        }
        public void AddPeople(int persons, int weight)
        {
            currentPersons += persons;
            currentWeight += weight;
        }
    }
}
