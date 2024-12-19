using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_8
{
    internal class TaskManager
    {
        public List<Person> Team { get; set; } = new List<Person>();
        public List<Project> Projects { get; set; } = new List<Project>();
        private int nextPersonId = 1;


        public void CreateTeamMember(string name)
        {
            Person person = new Person(nextPersonId, name);
            Team.Add(person);
            Console.WriteLine($"Создан член команды: {person.Name}");
            nextPersonId++;
        }


        public void CreateProject(string description, DateTime dueDate, Person initiator, Person teamLead)
        {
            Project project = new Project(description, dueDate, initiator, teamLead);
            Projects.Add(project);
            Console.WriteLine($"Создан проект: {project.Description}");
        }

        public void AssignTaskToProject(Project project, string taskDescription, DateTime taskDueDate, Person taskInitiator)
        {
            if (project == null)
            {
                Console.WriteLine($"Ошибка: Проект не найден");
            }
            if (project.Status != ProjectStatus.Project)
            {
                Console.WriteLine("Ошибка: Задачи можно добавлять только в проект со статусом 'Проект'");
            }

            Task task = new Task(taskDescription, taskDueDate, taskInitiator);
            project.AddTask(task);
        }


        public void AssignTaskToPerson(Task task, Person person)
        {
            if (task == null)
            {
                Console.WriteLine("Ошибка: Задача не найдена.");
            }

            if (person == null)
            {
                Console.WriteLine("Ошибка: Человек не найден.");
            }


            if (task.Status != TaskStatus.Assigned)
            {
                Console.WriteLine("Ошибка: Задачу можно назначить только в статусе 'Назначена'");
            }
            task.Assignee = person;
            Console.WriteLine($"Задача '{task.Description}' назначена на '{person.Name}'.");
            ChangeTaskStatus(task, TaskStatus.InProgress);
        }

        public void DelegateTask(Task task, Person newAssignee)
        {

            if (task == null)
            {
                Console.WriteLine("Ошибка: Задача не найдена.");
            }

            if (newAssignee == null)
            {
                Console.WriteLine("Ошибка: Человек не найден.");
            }
            if (task.Status != TaskStatus.InProgress)
            {
                Console.WriteLine("Ошибка: Делегировать можно только задачи в статусе 'В работе'.");
            }
            task.Assignee = newAssignee;
            ChangeTaskStatus(task, TaskStatus.Assigned);

            Console.WriteLine($"Задача '{task.Description}' делегирована '{newAssignee.Name}'.");

        }

        public void RejectTask(Task task)
        {
            if (task == null)
            {
                Console.WriteLine("Ошибка: Задача не найдена.");
            }
            if (task.Status != TaskStatus.InProgress)
            {
                Console.WriteLine("Ошибка: Отклонить можно только задачи в статусе 'В работе'.");
            }
            task.Assignee = null;
            Console.WriteLine($"Задача '{task.Description}' отклонена и исполнитель убран.");
            ChangeTaskStatus(task, TaskStatus.Assigned);
        }

        public void SubmitReport(Task task, string reportText, Person reportAuthor)
        {
            if (task == null)
            {
                Console.WriteLine("Ошибка: Задача не найдена.");
            }
            if (task.Status != TaskStatus.InProgress && task.Status != TaskStatus.InReview)
            {
                Console.WriteLine("Ошибка: Отчет можно добавить только к задаче в статусе 'В работе' или 'На проверке'.");
            }
            Report report = new Report(reportText, reportAuthor);
            task.AddReport(report);
            if (task.Report != null)
            {
                ChangeTaskStatus(task, TaskStatus.InReview);
                Console.WriteLine($"Отчет к задаче '{task.Description}' добавлен.");
            }
        }

        public void ApproveReport(Task task)
        {
            if (task == null)
            {
                Console.WriteLine("Ошибка: Задача не найдена.");
            }
            if (task.Status != TaskStatus.InReview)
            {
                Console.WriteLine("Ошибка: Отчет можно утвердить только для задач в статусе 'На проверке'.");
            }
            ChangeTaskStatus(task, TaskStatus.Completed);
            Console.WriteLine($"Отчет по задаче '{task.Description}' утвержден.");

        }


        public void ChangeTaskStatus(Task task, TaskStatus status)
        {
            task.ChangeStatus(status);
        }
        public void ChangeProjectStatus(Project project, ProjectStatus status)
        {
            project.ChangeStatus(status);
        }



        public bool IsProjectClosed(Project project)
        {
            if (project == null)
            {
                return false;
            }

            foreach (var task in project.Tasks)
            {
                if (task.Status != TaskStatus.Completed)
                {
                    return false;
                }
            }
            return true;

        }
        public Person FindPersonById(int id)
        {
            foreach (var person in Team)
            {
                if (person.Id == id)
                {
                    return person;
                }
            }
            return null;
        }
        public Task FindTaskByDescription(Project project, string description)
        {
            if (project == null)
            {
                return null;
            }
            foreach (var task in project.Tasks)
            {
                if (task.Description == description)
                {
                    return task;
                }
            }
            return null;
        }
        public Project FindProject(string description)
        {
            if (Projects == null)
            {
                return null;
            }
            foreach (var project in Projects)
            {
                if (project.Description == description)
                {
                    return project;
                }
            }
            return null;
        }

    }
}
