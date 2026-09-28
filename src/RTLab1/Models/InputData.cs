using System.Collections.Generic;

namespace RTLab1.Models
{
    public class InputData
    {
        public int Processors { get; set; }

        public bool HasNetwork { get; set; }

        public List<TaskModel> Tasks { get; set; }
    }
}