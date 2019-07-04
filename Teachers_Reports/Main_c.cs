using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Teachers_Reports
{
    public class Main_c { 
    
    new Dictionary<string, Marks> Students = new Dictionary<string, Marks>();
        
    struct Marks
      {
         public int Math;
         public int Language;
      }
    
    public void ReadMarks(string file_name)
    {


            List<string> lines = File.ReadAllLines(file_name).ToList();
            string subject = lines[0];
            for (int i = 1; i < lines.Count; i++)
        {
            string name;
            string mark;
            int delim_pos = lines[i].IndexOf('-');
                name = lines[i].Substring(0, delim_pos);
                mark = lines[i].Substring(delim_pos + 1);


            if (!Students.ContainsKey(name))
            {
                Students.Add(name, new Marks());
            }
            
            Marks temp = Students[name];
            switch (subject)
            {
                case "Math":

                    temp.Math = Convert.ToInt32(mark);
                    Students[name] = temp;
                    break;


                case "Language":
                    temp.Language = Convert.ToInt32(mark);
                    Students[name] = temp;
                    break;
            }
        }
    }

    public void CountAvarageMark(string final_file_name)
        {
            File.AppendAllText(final_file_name, "Avarage\r\n");
            foreach (KeyValuePair<string, Marks> pair in Students)
            {
                double AvarageMark = (pair.Value.Math + pair.Value.Language) / 2;
                File.AppendAllText(final_file_name, $"{pair.Key}-{AvarageMark.ToString()} \r\n");
            }
        }
    public static void Main(string[] args)
        {
            File.Delete("final.txt");
            Main_c student = new Main_c();
            
            student.ReadMarks("subject1.txt");
            student.ReadMarks("subject2.txt");

            student.CountAvarageMark("final.txt");
        }
    }
}