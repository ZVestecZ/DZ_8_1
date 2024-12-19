using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_8
{
    public enum ProjectStatus { Project, InProgress, Closed }
    public enum TaskStatus { Assigned, InProgress, InReview, Completed }


    public class Program
    {
        public static void Main(string[] args)
        {
            // Домашнее задание 9.1
            Console.WriteLine("Домашнее задание 9.1");

            List<Song> songs = new List<Song>();

            Song song1 = new Song("Song 1", "Artist 1");
            Song song2 = new Song("Song 2", "Artist 2", song1);
            Song song3 = new Song("Song 3", "Artist 3", song2);
            Song song4 = new Song();

            songs.Add(song1);
            songs.Add(song2);
            songs.Add(song3);
            songs.Add(song4);

            Console.WriteLine("Список песен:");
            foreach (Song song in songs)
            {
                Console.WriteLine(song.Title());
            }

            Console.ReadKey();

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            // Домашнее задание 9.2
            Console.WriteLine("Домашнее задание 9.2");



            TaskManager taskManager = new TaskManager();

            taskManager.CreateTeamMember("A");
            taskManager.CreateTeamMember("B");
            taskManager.CreateTeamMember("C");
            taskManager.CreateTeamMember("D");
            taskManager.CreateTeamMember("E");
            taskManager.CreateTeamMember("F");
            taskManager.CreateTeamMember("G");
            taskManager.CreateTeamMember("H");
            taskManager.CreateTeamMember("I");
            taskManager.CreateTeamMember("J");

            Person teamLead = taskManager.FindPersonById(1);
            Person initiator = taskManager.FindPersonById(2);

            // Создаем проект
            taskManager.CreateProject("Разработка приложения", DateTime.Now.AddMonths(3), initiator, teamLead);
            Project project = taskManager.FindProject("Разработка приложения");

            // Создаем задачи
            taskManager.AssignTaskToProject(project, "Составить план", DateTime.Now.AddDays(5), teamLead);
            taskManager.AssignTaskToProject(project, "Написать код", DateTime.Now.AddDays(15), teamLead);
            taskManager.AssignTaskToProject(project, "Создать интерфейс", DateTime.Now.AddDays(25), teamLead);




            Task task1 = taskManager.FindTaskByDescription(project, "Составить план");
            Task task2 = taskManager.FindTaskByDescription(project, "Написать код");
            Task task3 = taskManager.FindTaskByDescription(project, "Создать интерфейс");


            taskManager.ChangeProjectStatus(project, ProjectStatus.InProgress);
            Console.WriteLine($"Статус проекта '{project.Description}' изменен на '{project.Status}'.");

            Person developer1 = taskManager.FindPersonById(3);
            Person developer2 = taskManager.FindPersonById(4);
            Person developer3 = taskManager.FindPersonById(5);

            taskManager.AssignTaskToPerson(task1, developer1);
            taskManager.AssignTaskToPerson(task2, developer2);
            taskManager.AssignTaskToPerson(task3, developer3);

            Person developer4 = taskManager.FindPersonById(6);


            taskManager.DelegateTask(task2, developer4);

            taskManager.RejectTask(task3);

            Person developer5 = taskManager.FindPersonById(7);

            taskManager.AssignTaskToPerson(task3, developer5);

            taskManager.SubmitReport(task1, "План составлен", developer1);

            taskManager.ApproveReport(task1);

            taskManager.SubmitReport(task1, "План изменён", developer1);

            taskManager.SubmitReport(task3, "Интерфейс создан", developer5);

            taskManager.ApproveReport(task3);

            taskManager.SubmitReport(task2, "Интерфейс создан", developer4);

            taskManager.ApproveReport(task2);


            if (taskManager.IsProjectClosed(project))
            {
                taskManager.ChangeProjectStatus(project, ProjectStatus.Closed);
                Console.WriteLine($"Статус проекта '{project.Description}' изменен на '{project.Status}'.");
            }

            Console.ReadKey();
        }
    }
}
