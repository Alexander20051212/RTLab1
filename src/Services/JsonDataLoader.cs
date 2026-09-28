using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using RTLab1.Models;

namespace RTLab1.Services
{
    public static class JsonDataLoader
    {
        public static InputData Load(string filePath)
        {
            string json = File.ReadAllText(filePath);

            return JsonConvert.DeserializeObject<InputData>(json);
        }
    }
}