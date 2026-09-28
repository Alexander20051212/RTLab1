using System.Collections.Generic;
using RTLab1.Models;

namespace RTLab1.Services
{
    public static class TaskCalculations
    {
        public static double Slack(TaskModel task)
        {
            return task.D - task.C;
        }

        public static bool IsFeasible(TaskModel task)
        {
            return Slack(task) >= 0;
        }

        public static string DeadlineType(TaskModel task)
        {
            if (task.D == task.T)
            {
                return "Неявный";
            }

            if (task.D < task.T)
            {
                return "Ограниченный";
            }

            return "Произвольный";
        }

        public static string ClassifySystem(List<TaskModel> tasks)
        {
            foreach (TaskModel task in tasks)
            {
                if (task.Class == TaskClass.Hard)
                {
                    return "Жёсткое реальное время";
                }
            }

            return "Мягкое реальное время";
        }

        public static TaskModel CriticalTask(List<TaskModel> tasks)
        {
            TaskModel criticalTask = null;

            foreach (TaskModel task in tasks)
            {
                if (task.Class != TaskClass.Hard)
                {
                    continue;
                }

                if (criticalTask == null || Slack(task) < Slack(criticalTask))
                {
                    criticalTask = task;
                }
            }

            return criticalTask;
        }
    }
}