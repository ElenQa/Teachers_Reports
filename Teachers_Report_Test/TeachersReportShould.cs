using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teachers_Reports;

namespace Teachers_Report_Test
{
    [TestFixture]
    public class TeachersReportShould
    {
        string input_file_name1;
        string input_file_name2;
        string output_file_name;
        string input_test_file_name1;
        string input_test_file_name2;
        string output_test_file_name;
                
        [OneTimeSetUp]
        public void SetUp()
        {
            try
            {
                input_file_name1 = TestContext.Parameters["input_file_name1"].ToString();
                input_file_name2 = TestContext.Parameters["input_file_name2"].ToString();
                input_test_file_name1 = TestContext.Parameters["input_test_file_name1"].ToString();
                input_test_file_name2 = TestContext.Parameters["input_test_file_name2"].ToString();
                output_test_file_name = TestContext.Parameters["output_test_file_name"].ToString();

            }
            catch (Exception e)
            {
                Assert.Fail("Test can not be executed, because of missing input params" + e.Message);
            }

            output_file_name = TestContext.Parameters["output_file_name"].ToString();
        }

        [Test]
        public void FinalFileExsist()
        {
            
        }

        [Test]
        [TestCase(72)]
        public void AvarageResultCorrect(int ExpectedAvarageMark)
        {
            try
            {
                Assert.That(File.Exists(output_file_name));
            }

            catch (Exception e)
            {
                Assert.Fail("Test can not be executed, because of missing input params" + e.Message);
            }

            Main_c student1 = new Main_c();
            
            student1.ReadMarks(input_test_file_name1);
            student1.ReadMarks(input_test_file_name2);
            
            student1.CountAvarageMark(output_test_file_name);
           
            List<string> Mark = File.ReadAllLines(output_test_file_name).ToList();
            int delim_pos = Mark[1].IndexOf('-');
            int ActualMark = Convert.ToInt32(Mark[1].Substring(delim_pos + 1));
            

            Assert.That(ActualMark, Is.EqualTo(ExpectedAvarageMark));
        }

        [Test]
        public void NotReturnDuplicationStudents()
        {
            List<string> Students = File.ReadAllLines(output_file_name).ToList();
            List<string> Students_Names = new List<string>();
            for (int i = 1; i < Students.Count; i++)
            {
              
                int delim_pos = Students[i].IndexOf('-');
                string name = Students[i].Substring(0, delim_pos);

                foreach (string St in Students)
                {
                    Students_Names.Add(name);

                    if (Students_Names.Contains(name)){
                        break;
                    }
                        
                }
            }
            
            Assert.That(Students_Names, Is.Unique);

        }
       
    }
    
}


