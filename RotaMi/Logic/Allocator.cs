using RotaMi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RotaMi.Logic
{
    public class Allocator
    {
        public List<User> Users { get; set; }
        public List<UserTask> Tasks { get; set; }

        public Allocator(List<User> users, List<UserTask> tasks)
        {
            Users = users;
            Tasks = tasks;
        }
        public List<User> AllocateTasks()
        {

            var taskQueue = new Queue<UserTask>(Tasks);

            for (int i = 0; i < Users.Count; i++)
            {

                try
                {
                    Users[i].Task = taskQueue.Dequeue();
                }
                catch
                {
                    Users[i].Task = new UserTask() { Name = "None" };
                }

                Users[i].TimeStamp = DateTime.Now;

            }

            return Users;
        }

        public List<User> AssignNewTasks()
        {
    
            ReorderTaskList();
            
            return AllocateTasks();
        }

        public List<User> UpdateTasks()
        {
            var dateDifference = (Users[0].TimeStamp != DateTime.MinValue) ? (DateTime.Now - Users[0].TimeStamp).Days : 0;

            if (dateDifference >= 1)
            {
                ReorderTaskList();
            }
            return AllocateTasks();
        }

        public void ReorderTaskList()
        {
            var list = new Queue<UserTask>(Tasks);

            list.Enqueue(list.Dequeue());

            Tasks = list.ToList();
        }

    }
}