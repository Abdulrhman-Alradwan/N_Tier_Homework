using System.Collections.Generic;
using System.Linq;
using NTierTodoApp.DataAccess;
using NTierTodoApp.Models;

namespace NTierTodoApp.Business
{
    /// <summary>
    /// يطبق المنطق التجاري لإدارة المهام
    /// Implements business logic for task management
    /// </summary>
    public class TaskService
    {
        private readonly TaskRepository repository;

        /// <summary>
        /// Initialize a new instance of TaskService
        /// تهيئة مثيل جديد من TaskService
        /// </summary>
        /// <param name="repo">TaskRepository instance - مثيل TaskRepository</param>
        public TaskService(TaskRepository repo)
        {
            repository = repo;
        }

        /// <summary>
        /// Retrieve all tasks - جلب جميع المهام
        /// </summary>
        /// <returns>List of tasks - قائمة المهام</returns>
        public List<TaskItem> GetTasks() => repository.GetAll();

        /// <summary>
        /// Add a new task - إضافة مهمة جديدة
        /// </summary>
        /// <param name="title">Task title - عنوان المهمة</param>
        public void AddTask(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                return;

            var tasks = repository.GetAll();
            int newId = tasks.Any() ? tasks.Max(t => t.Id) + 1 : 1;

            var newTask = new TaskItem
            {
                Id = newId,
                Title = title,
                IsComplete = false
            };

            repository.Add(newTask);
        }

        /// <summary>
        /// Mark a task as complete - تعليم المهمة كمكتملة
        /// </summary>
        /// <param name="id">Task ID - معرّف المهمة</param>
        public void CompleteTask(int id)
        {
            var task = repository.GetById(id);
            if (task != null)
                task.IsComplete = true;
        }

        /// <summary>
        /// Delete a task by ID - حذف مهمة حسب المعرف
        /// </summary>
        /// <param name="id">Task ID - معرّف المهمة</param>
        public void DeleteTask(int id)
        {
            repository.Delete(id);
        }
    }
}