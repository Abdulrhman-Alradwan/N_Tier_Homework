using System.Collections.Generic;
using System.Linq;
using NTierTodoApp.Models;

namespace NTierTodoApp.DataAccess
{
    /// <summary>
    /// مستودع البيانات لإدارة المهام باستخدام قائمة في الذاكرة
    /// Data repository for task management using in-memory list
    /// </summary>
    public class TaskRepository
    {
        // قائمة المهام الأولية
        // Initial tasks list
        private readonly List<TaskItem> tasks = new List<TaskItem>
        {
            new TaskItem { Id = 1, Title = "مهمة أولى", IsComplete = false },
            new TaskItem { Id = 2, Title = "مهمة ثانية", IsComplete = false }
        };

        /// <summary>
        /// جلب جميع المهام
        /// Retrieve all tasks
        /// </summary>
        /// <returns>قائمة المهام | List of tasks</returns>
        public List<TaskItem> GetAll() => tasks;

        /// <summary>
        /// إضافة مهمة جديدة
        /// Add a new task
        /// </summary>
        /// <param name="task">المهمة المضافة | Task to add</param>
        public void Add(TaskItem task)
        {
            tasks.Add(task);
        }

        /// <summary>
        /// البحث عن مهمة بواسطة المعرف
        /// Find task by ID
        /// </summary>
        /// <param name="id">معرف المهمة | Task ID</param>
        /// <returns>المهمة المطلوبة أو null | Found task or null</returns>
        public TaskItem GetById(int id)
        {
            return tasks.FirstOrDefault(t => t.Id == id);
        }

        /// <summary>
        /// حذف مهمة بواسطة المعرف
        /// Delete task by ID
        /// </summary>
        /// <param name="id">معرف المهمة | Task ID</param>
        public void Delete(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task != null)
            {
                tasks.Remove(task);
            }
        }
    }
}