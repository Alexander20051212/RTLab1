using System;
using System.Collections.Generic;
using RTLab1.Models;
using RTLab1.Services;

namespace RTLab1
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "data/tasks.json";

            InputData data = JsonDataLoader.Load(filePath);
            List<TaskModel> tasks = data.Tasks;

            Console.WriteLine("==============================================");
            Console.WriteLine(" Классификация систем реального времени");
            Console.WriteLine("==============================================");
            Console.WriteLine();

            Console.WriteLine("Таблица задач:");
            Console.WriteLine();

            Console.WriteLine(
                "{0,-32} {1,-8} {2,6} {3,6} {4,6} {5,8} {6,-12} {7,-12}",
                "Задача", "Класс", "C", "D", "T", "L", "Дедлайн", "Выполнимость");

            Console.WriteLine(new string('-', 115));

            foreach (TaskModel task in tasks)
            {
                double slack = TaskCalculations.Slack(task);
                bool feasible = TaskCalculations.IsFeasible(task);
                string deadlineType = TaskCalculations.DeadlineType(task);

                Console.WriteLine(
                    "{0,-32} {1,-8} {2,6:F1} {3,6:F1} {4,6:F1} {5,8:F1} {6,-12} {7,-12}",
                    task.Name,
                    task.Class,
                    task.C,
                    task.D,
                    task.T,
                    slack,
                    deadlineType,
                    feasible ? "Да" : "Нет");
            }

            Console.WriteLine();
            Console.WriteLine("==============================================");
            Console.WriteLine(" Результаты расчётов");
            Console.WriteLine("==============================================");

            string systemClass = TaskCalculations.ClassifySystem(tasks);
            TaskModel criticalTask = TaskCalculations.CriticalTask(tasks);
            double requiredReactionTime =
                TaskCalculations.RequiredReactionTime(tasks);
            double utilization =
                TaskCalculations.Utilization(tasks);
            string architecture =
                TaskCalculations.ClassifyArchitecture(
                    data.Processors,
                    data.HasNetwork);

            Console.WriteLine();
            Console.WriteLine("Класс системы: " + systemClass);

            if (criticalTask != null)
            {
                Console.WriteLine(
                    "Критическая задача: {0} (L = {1:F1} мс)",
                    criticalTask.Name,
                    TaskCalculations.Slack(criticalTask));
            }
            else
            {
                Console.WriteLine("Критическая задача: отсутствует");
            }

            Console.WriteLine(
                "Требуемое время реакции: {0:F1} мс",
                requiredReactionTime);

            Console.WriteLine(
                "Загрузка процессора: U = {0:F2}",
                utilization);

            Console.WriteLine(
                "Проверка U <= 1: {0}",
                utilization <= 1.0 ? "выполняется" : "не выполняется");

            Console.WriteLine(
                "Архитектура системы: " + architecture);

            Console.WriteLine();
            Console.WriteLine("Расчёт завершён.");

            Console.ReadKey();
        }
    }
}