using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAPlayground.TestingData
{
    public class TestDataHelper
    {
        public static TestData LoadTestData(string filePath)
        {
            var jsonData = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<TestData>(jsonData);
        }
    }
}
