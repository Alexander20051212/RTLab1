using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTLab1.Models
{
    public enum TaskClass
    {
        Hard,
        Firm,
        Soft
    }

    public class TaskModel
    {
        public string Name { get; set; }

        public TaskClass Class { get; set; }

        public double C { get; set; }

        public double D { get; set; }

        public double T { get; set; }
    }
}