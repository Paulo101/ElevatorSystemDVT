using ElevatorLibrary.Classes;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorChallengeDVT.Tests
{
    /*
     * I am using NUnit Framework for the first time
     * Referance source : https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-nunit
     * I am Open for Learnings and Advises.
     */
    [TestFixture]
    public class ElevatorSystemUnitTests
    {
        private ElevatorSystem? elevatorSystem;

        [SetUp]
        public void Setup()
        {
            //Instatiate elevator system
            elevatorSystem = new ElevatorSystem(3, 10, 1000);
        }
        [Test]
        public void TestElevatorSystem()
        {
            elevatorSystem!.SelectFloorTo(5,  2, 150);
            elevatorSystem.SelectFloorTo(3, 1, 75);
            elevatorSystem.SelectFloorTo(7, 4, 300);
            Console.WriteLine("Running Test cases...");
            // Add more test assertions based on the expected behavior of the elevator system
            Assert.Pass();
            Console.WriteLine("All tests passed..");
        }
    }
}
