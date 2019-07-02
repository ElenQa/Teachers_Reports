using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Teachers_Reports
{

    public class Main_c
    {
        static Dictionary<string, Marks> Students = new Dictionary<string, Marks>();
        struct Marks
        {
            public int Math;
            public int Language;
        }
        static void ReadMarks(string file_name)
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
        public static void Main(string[] args)
        {
            File.Delete("final.txt");
            ReadMarks("subject1.txt");
            ReadMarks("subject2.txt");
            

            foreach (KeyValuePair<string, Marks> pair in Students)
            {
                double AvarageMark = (pair.Value.Math + pair.Value.Language) / 2;
                File.AppendAllText("final.txt", $"Student {pair.Key} has Avarage Mark {AvarageMark.ToString()} \r\n");
            }

            

        }
    }
}
 
























            /*Dictionary<string, int> Students1 = new Dictionary<string, int>()
        {
            {"Ivanov", 1},
            {"Petrov", 2},
            {"Sidorov", 3}
        };
            Dictionary<string, int> Students2 = new Dictionary<string, int>()
        {
            {"Ivanov", 1},
            {"Dudkov", 2},
            {"Sidorov", 3}
        };

            Dictionary<string, int> Students3 = new Dictionary<string, int>()
        {
            {"Ivanov",1},
            {"Dudkov",2},
            {"Koltsov",3}
        };

            //Dictionary<int[], string[]> Students4 = new Dictionary<int[], string[]>();



            bool equals = false;

            if (Students1.Count == Students2.Count || Students1.Count == Students3.Count || Students2.Count == Students3.Count)
            {
                equals = true;
                foreach (var pair in Students1)
                {
                    if (!Students2.ContainsKey("Ivanov"))
                    {
                        Students1.Add("Ivanov", 1);
                    }
                    if (!Students2.ContainsKey("Petrov"))
                    {
                        Students1.Add("Petrov", 1);
                    }
                    if (!Students2.ContainsKey("Sidorov"))
                    {
                        Students1.Add("Sidorov", 1);
                    }
                    if (!Students3.ContainsKey("Dudkov"))
                    {
                        Students1.Add("Dudkov", 1);
                    }
                    if (!Students2.ContainsKey("Koltsov"))
                    {
                        Students1.Add("Koltsov", 1);
                    }
                }
            }

            File.WriteAllLines("all.txt", Students1 => "[" + Students1.Key + " " + Students1.Value + "]".ToArray());
        
        
    }
}





/*switch
{
    case 1{
        if (Students1.Values == Students2.Values)
        Students4.Add(Students1.Keys, Students1.Values);
            break;
        }



}


}
}
}
}*/







/*void ReadMarks(string[] file_name)
        {
            var dictionary = new ().Deserialize<Dictionary<int, string>>(File.ReadAllText("subject1.txt"));
            file_name = File.ReadAllLines("subject1.txt");
            List<string> lines = new List<string>();

            foreach (string s in lines)
            {
                Students.Add(1, s);
            }



            //string subject = lines[0];




            /*for (int i =1; .....)
                {
                    subject.Substring()
                }


                switch
                {

                }

                  subject = file_name[0];


        */

