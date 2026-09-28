using RTLab1.Models;

namespace RTLab1.Services
{
    public static class TaskCalculations
    {
        public static double Slack(TaskModel task)
        {
            return task.D - task.C;
        }
    }
}