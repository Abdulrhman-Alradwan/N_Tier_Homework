using System.Collections.Generic;
using System.Linq;
using NTierTodoApp.Models;

namespace NTierTodoApp.DataAccess
{
    /// <summary>
    /// مخزن البيانات للتعامل مع المهام باستخدام الذاكرة كتخزين مؤقت.
    /// </summary>
    public class TaskRepository
    {
        private List<TaskItem> tasks = new List<TaskItem>
        {
            new TaskItem { Id = 1, Title = "المهمة الأولى", IsComplete = false },
            new TaskItem { Id = 2, Title = "المهمة الثانية", IsComplete = false }
        };

        public List<TaskItem> GetAll() => tasks;

        public void Add(TaskItem task)
        {
            tasks.Add(task);
        }

        public TaskItem GetById(int id)
        {
            return tasks.FirstOrDefault(t => t.Id == id);
        }

        // TODO: تنفيذ عملية حذف المهمة
        public void Delete(int id)
        {
            // TODO: ابحث عن المهمة باستخدام id
            
            // TODO: إذا كانت المهمة موجودة، إزالتها من المجموعة
        }
    }
}