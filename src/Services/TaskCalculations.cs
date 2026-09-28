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
    }
}