using Domains;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Convert.Tests
{
    [TestClass()]
    public class ConvertTests
    {
        [TestMethod()]
        public void ConvertTest()
        {
           Assert.IsTrue( ConvertClass.Convert(new student() { age = "男", name="付博文", sex=1, },new score()));
        }

        public class student
        {
            public string name { get; set; }
            public string age { get; set; }
            public int sex { get; set; }
        }

        public class score
        {
            public string name { get; set; }
            public string age { get; set; }
            
        }
    }
}