using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_8
{
    public class Task
    {
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public Person Initiator { get; set; }
        public Person Assignee { get; set; }
        public TaskStatus Status { get; set; }
        public Report Report { get; set; }

        public Task(string description, DateTime dueDate, Person initiator)
        {
            Description = description;
            DueDate = dueDate;
            Initiator = initiator;
            Status = TaskStatus.Assigned;
        }


        public void AddReport(Report report)
        {
            if (Report == null)
            {
                Report = report;
            }
            else
            {
                Console.WriteLine($"Ошибка: Отчет для задачи '{Description}' уже существует.");
            }

        }

        public void ChangeStatus(TaskStatus newStatus)
        {
            Status = newStatus;
        }
    }
}
