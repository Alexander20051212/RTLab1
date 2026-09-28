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

        public static double RequiredReactionTime(List<TaskModel> tasks)
        {
            List<TaskModel> selectedTasks = new List<TaskModel>();

            foreach (TaskModel task in tasks)
            {
                if (task.Class == TaskClass.Hard)
                {
                    selectedTasks.Add(task);
                }
            }

            if (selectedTasks.Count == 0)
            {
                selectedTasks = tasks;
            }

            double minDeadline = selectedTasks[0].D;

            foreach (TaskModel task in selectedTasks)
            {
                if (task.D < minDeadline)
                {
                    minDeadline = task.D;
                }
            }

            return minDeadline;
        }
        public static double Utilization(List<TaskModel> tasks)
        {
            double utilization = 0.0;

            foreach (TaskModel task in tasks)
            {
                utilization += task.C / task.T;
            }

            return utilization;
        }
    }
}