using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_8
{
    public class Project
    {
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public Person Initiator { get; set; }
        public Person TeamLead { get; set; }
        public List<Task> Tasks { get; set; } = new List<Task>();
        public ProjectStatus Status { get; set; }

        public Project(string description, DateTime dueDate, Person initiator, Person teamLead)
        {
            Description = description;
            DueDate = dueDate;
            Initiator = initiator;
            TeamLead = teamLead;
            Status = ProjectStatus.Project;
        }
        public void AddTask(Task task)
        {
            if (Status == ProjectStatus.Project)
            {
                Tasks.Add(task);
                Console.WriteLine($"Задача '{task.Description}' добавлена в проект '{Description}'.");
            }
            else
            {
                Console.WriteLine($"Ошибка: Задачи можно добавлять только в проект со статусом 'Проект'.");
            }
        }
        public void ChangeStatus(ProjectStatus newStatus)
        {
            Status = newStatus;
        }

    }
}
