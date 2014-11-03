using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalendarSystem;

namespace TestCalendarSystem
{
    [TestClass]
    public class TestCommandExecutor
    {
        [TestMethod]
        public void TestProcessAddEventCommandWithThreeParameters()
        {
            CommandExecutor cmdExecutor = new CommandExecutor(new EventsManagerFast());
            Command cmd = new Command
            {
                CommandName = "AddEvent",
                Parameters = new string[]
                {
                    "2001-01-01T12:00:00",
                    "Chalga party - 406733",
                    "telerik academy"
                }
            };
            string result = cmdExecutor.ProcessCommand(cmd);
            Assert.AreEqual("Event added", result);
        }

        [TestMethod]
        public void TestProcessAddEventCommandWithTwoParameters()
        {
            CommandExecutor cmdExecutor = new CommandExecutor(new EventsManagerFast());
            Command cmd = new Command
            {
                CommandName = "AddEvent",
                Parameters = new string[]
                {
                    "2001-01-01T10:30:03",
                    "party Lora"
                }
            };
            string result = cmdExecutor.ProcessCommand(cmd);
            Assert.AreEqual("Event added", result);
        }

        [TestMethod]
        public void TestProcessDeleteEventsCommandWithTwoParameters()
        {
            CommandExecutor cmdExecutor = new CommandExecutor(new EventsManagerFast());
            Command cmd = new Command
            {
                CommandName = "DeleteEvents",
                Parameters = new string[]
                {
                    "Rock party",
                }
            };
            string result = cmdExecutor.ProcessCommand(cmd);
            Assert.AreEqual("No events found", result);
        }

        [TestMethod]
        public void TestProcessDeleteExistingEvents()
        {
            CommandExecutor cmdExecutor = new CommandExecutor(new EventsManagerFast());
            Command addCommand = new Command
            {
                CommandName = "AddEvent",
                Parameters = new string[]
                {
                    "2001-01-01T10:30:03",
                    "party Lora"
                }
            };
            cmdExecutor.ProcessCommand(addCommand);

            Command deleteCommand = new Command
            {
                CommandName = "DeleteEvents",
                Parameters = new string[]
                {
                    "party Lora",
                }
            };
            string result = cmdExecutor.ProcessCommand(deleteCommand);
            Assert.AreEqual("1 events deleted", result);
        }

        [TestMethod]
        public void TestProcesListEventsCommandWithoutEvents()
        {
            CommandExecutor cmdExecutor = new CommandExecutor(new EventsManagerFast());
            Command listCmd = new Command
            {
                CommandName = "ListEvents",
                Parameters = new string[]
                {
                    "2012-03-31T23:59:57",
                    "5"
                }
            };
            string result = cmdExecutor.ProcessCommand(listCmd);
            Assert.AreEqual("No events found", result);
        }
    }
}
