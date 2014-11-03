using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalendarSystem;

namespace TestCalendarSystem
{
    [TestClass]
    public class TestCommand
    {
        [TestMethod]
        public void TestParseWithTwoParameters()
        {
            string inputCommand = "AddEvent 2012-03-26T08:00:00 | C# exam";
            Command actualCommand = Command.Parse(inputCommand);

            Command expectedCommand = new Command
            {
                CommandName = "AddEvent",
                Parameters = new string[] { "2012-03-26T08:00:00", "C# exam" }
            };

            Assert.AreEqual(expectedCommand, actualCommand);
        }

        [TestMethod]
        public void TestParseAddWithTwoParametersWithHour()
        {
            string inputCommand = "AddEvent 2011-01-09T03:00:59 | party Viki (11:33)";
            Command actualCommand = Command.Parse(inputCommand);

            Command expectedCommand = new Command
            {
                CommandName = "AddEvent",
                Parameters = new string[] { "2011-01-09T03:00:59", "party Viki (11:33)" }
            };

            Assert.AreEqual(expectedCommand, actualCommand);
        }

        [TestMethod]
        public void TestParseAddWithThreeParameters()
        {
            string inputCommand = "AddEvent 2011-11-11T11:11:22 | party Viki 22 | home";
            Command actualCommand = Command.Parse(inputCommand);
            
            Command expectedCommand = new Command
            {
                CommandName = "AddEvent",
                Parameters = new string[] { "2011-11-11T11:11:22", "party Viki 22", "home" }
            };

            Assert.AreEqual<Command>(expectedCommand, actualCommand);
        }

        [TestMethod]
        public void TestParseAddWithFourParameters()
        {
            string inputCommand = "AddEvent 2011-11-11T11:11:22 | party Viki 22 | home ";
            Command actualCommand = Command.Parse(inputCommand);

            Command expectedCommand = new Command
            {
                CommandName = "AddEvent",
                Parameters = new string[] { "2011-11-11T11:11:22", "party Viki 22", "home" }
            };

            Assert.AreEqual<Command>(expectedCommand, actualCommand);
        }    
    }
}