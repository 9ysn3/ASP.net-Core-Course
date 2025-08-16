using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDolistMVC.IRepositories;
using ToDolistMVC.Models;
using ToDolistMVC.Services;

namespace Testing
{
    public class TaskServiceTests
    {
        [Fact]
        public async void AddTask_ShouldIncreaseTaskCount()
        {
            // Arrange
            var mockRepo = new Mock<ITaskRepository>();
            var taskList = new List<TaskItem>();

            mockRepo.Setup(r => r.GetAll()).ReturnsAsync(taskList);
            mockRepo.Setup(r => r.Add(It.IsAny<TaskItem>()))
                    .Callback<TaskItem>(task => taskList.Add(task));

            var service = new TaskService(mockRepo.Object);
            var tasksList = await service.GetTasks();
            int initialCount = tasksList.Count;

            // Act
            var newTask = new TaskItem { Title = "Test Task", DueDate = DateTime.UtcNow };
            service.AddTask(newTask);

            // Assert
             tasksList = await service.GetTasks();
            Assert.Equal(initialCount + 1, tasksList.Count);
        }
    }
}
