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

        [Test]
        public void FinalFileExsist()
        {
            string file_name = @"C:\Users\OChernovolyk\source\repos\Teachers_Reports\Teachers_Reports\bin\Debug\final.txt";

            Assert.That(File.Exists(file_name));
        }

        [Test]
        public void AvarageResultCorrect()
        {

        }

        [Test]
        public void NotReturnDuplicationStudents()
        {

        }
    }
}

