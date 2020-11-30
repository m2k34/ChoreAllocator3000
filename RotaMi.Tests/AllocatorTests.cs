using NUnit.Framework;
using RotaMi.Logic;
using RotaMi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotaMi.Tests
{
    [TestFixture]
    public class AllocatorTests
    {

        List<User> Users = new List<User>() 
        { 
            new User { Name = "PersonA" }, 
            new User { Name = "PersonB" }, 
            new User { Name = "PersonC" }, 
            new User { Name = "PersonD" }, 
            new User { Name = "PersonE" } 
        };

        List<UserTask> Tasks = new List<UserTask>()
        { 
            new UserTask { Name = "TaskA" }, 
            new UserTask { Name = "TaskB" } , 
            new UserTask { Name = "TaskC" } , 
            new UserTask { Name = "TaskD" } 
        };
        List<User> UsersWithTasks = new List<User>()
        {
            new User { Name = "PersonA", TimeStamp = DateTime.Now.AddDays(-1) , Task = new UserTask() {Name = "TaskA" } },
        };

        [Test]
        public void Can_Allocate_Tasks()
        {
            
            var allocator = new Allocator(Users,Tasks);
            allocator.AllocateTasks();
            
            Assert.IsTrue(allocator.Users.First().Task != null);
        }

        [Test]
        public void Can_Change_Tasks()
        {
            var allocator = new Allocator(Users, Tasks);
            allocator.AllocateTasks();
            var currentTask = allocator.Users.First().Task;
            allocator.AssignNewTasks();
            var newTask = allocator.Users.First().Task;

            Assert.AreNotEqual(currentTask.Name, newTask.Name);
        }

        [Test]
        public void Can_Update_Tasks_After_1Day()
        {
   
            var allocator = new Allocator(UsersWithTasks, Tasks);
            allocator.UpdateTasks();
            var newTask = allocator.Users.First().Task.Name;
            Assert.AreNotEqual("TaskA", newTask);

        }
    }
}
