using Microsoft.AspNetCore.Mvc;
using NTierTodoApp.Business;

namespace NTierTodoApp.Controllers
{
    /// <summary>
    /// Controller for handling task-related operations
    /// متحكم لمعالجة العمليات المتعلقة بالمهام
    /// </summary>
    public class HomeController : Controller
    {
        private readonly TaskService _taskService;

        /// <summary>
        /// Initializes a new instance of HomeController
        /// تهيئة مثيل جديد من HomeController
        /// </summary>
        /// <param name="service">Task service instance - خدمة المهام</param>
        public HomeController(TaskService service)
        {
            _taskService = service;
        }

        /// <summary>
        /// Displays the task list view
        /// عرض قائمة المهام
        /// </summary>
        public IActionResult Index()
        {
            var tasks = _taskService.GetTasks();
            return View(tasks);
        }

        /// <summary>
        /// Adds a new task
        /// إضافة مهمة جديدة
        /// </summary>
        /// <param name="title">Task title - عنوان المهمة</param>
        [HttpPost]
        public IActionResult AddTask(string title)
        {
            if (!string.IsNullOrWhiteSpace(title))
                _taskService.AddTask(title);

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Marks a task as complete
        /// تعليم المهمة كمكتملة
        /// </summary>
        /// <param name="id">Task ID - معرّف المهمة</param>
        [HttpPost]
        public IActionResult CompleteTask(int id)
        {
            _taskService.CompleteTask(id);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Deletes a task
        /// حذف مهمة
        /// </summary>
        /// <param name="id">Task ID - معرّف المهمة</param>
        [HttpPost]
        public IActionResult DeleteTask(int id)
        {
            _taskService.DeleteTask(id);
            return RedirectToAction("Index");
        }
    }
}