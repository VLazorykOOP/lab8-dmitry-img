using System.Text;
using System.Text.RegularExpressions;
using System.IO;


namespace Lab8CSharp
{
    
    class Program
    {
        static void Main(string[] args)
        {
            Task1();
            Task2();
            Task3();
            Task4();
            Task5();
        }
        public static void Task1()
        {
            string inputFile = @"D:\.1Programming\VSProjects\Lab8_CS\Lab8CSharp\inputTask1.txt";
            string outputFile = @"D:\.1Programming\VSProjects\Lab8_CS\Lab8CSharp\outputTask1.txt";
            string pattern = "(((([0-1][0-9])|(2[0-3])):?[0-5][0-9]:?[0-5][0-9]))";

            using (var reader = new StreamReader(inputFile))
            using (var writer = new StreamWriter(outputFile))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var matches = Regex.Matches(line, pattern);
                    foreach (Match match in matches)
                    {
                        writer.WriteLine(match.Value);
                    }
                }
            }
            List<string> strings = new List<string>();
            using (var reader = new StreamReader(outputFile))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    strings.Add(line);
                }
            }

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Choose string you would like to modify:");
                for (int i = 0; i < strings.Count; i++)
                {
                    Console.WriteLine("{0}. {1}", i + 1, strings[i]);
                }
                Console.WriteLine("-1. To Exit");
                int choice = Convert.ToInt32(Console.ReadLine());
                if (choice <= 0)
                {
                    break;
                }
                Console.Clear();
                Console.WriteLine("Enter string in format hh:mm::ss");
                string newLine = Console.ReadLine();
                if (Regex.IsMatch(newLine, pattern))
                {
                    strings[choice - 1] = newLine;
                    Console.WriteLine("Line has been modified successfully!");
                }
                else
                {
                    Console.WriteLine("Something went wrong! It seems that the line wasn't in the right format...");
                }
                Console.ReadKey();
            }

            using (var writer = new StreamWriter(outputFile))
            {
                foreach (string str in strings)
                {
                    writer.WriteLine(str);
                }
            }
        }

        public static void Task2()
        {
            using (var reader = new StreamReader(@"D:\.1Programming\VSProjects\Lab8_CS\Lab8CSharp\inputTask2.txt"))
            using (var writer = new StreamWriter(@"D:\.1Programming\VSProjects\Lab8_CS\Lab8CSharp\outputTask2.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    StringBuilder sb = new StringBuilder();
                    for (int i = line[0]; i <= line[2]; i++)
                    {
                        sb.Append((char)i);
                    }
                    writer.WriteLine(sb.ToString());
                }
            }
        }
        public static void Task3()
        {
            using (var reader = new StreamReader(@"D:\.1Programming\VSProjects\Lab8_CS\Lab8CSharp\inputTask3.txt"))
            using (var writer = new StreamWriter(@"D:\.1Programming\VSProjects\Lab8_CS\Lab8CSharp\outputTask3.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    writer.WriteLine(line.Replace("Dima","Andrii"));
                }
            }
        }
        public static void Task4()
        {
            Console.WriteLine("Enter a sequence of numbers separated by a space:");
            string input = Console.ReadLine();
            List<int> numbers = input.Split(' ').Select(int.Parse).ToList();

            using (var writerInput = new StreamWriter(@"D:\.1Programming\VSProjects\Lab8_CS\Lab8CSharp\inputTask4.txt"))
            using (var writerOutput = new StreamWriter(@"D:\.1Programming\VSProjects\Lab8_CS\Lab8CSharp\outputTask4.txt"))
            {
                writerInput.WriteLine(input);
                writerOutput.WriteLine(string.Join(" ", numbers.Where(x => x > 0)));
            }
        }
        public static void Task5()
        {
            static void ShowInfo(FileInfo fileInfo)
            {
                fileInfo.GetType().GetProperties().ToList().ForEach(x => Console.WriteLine(x.Name + ": " + x.GetValue(fileInfo)));
            }
           
            Directory.CreateDirectory("D:\\temp");
      
            Directory.CreateDirectory("D:\\temp\\Паскар_Дмитро1");
            Directory.CreateDirectory("D:\\temp\\Паскар_Дмитро2");


            using(var writerT1 = File.AppendText("D:\\temp\\Паскар_Дмитро1\\t1.txt"))
            using(var writerT2 = File.AppendText("D:\\temp\\Паскар_Дмитро1\\t2.txt"))
            {
                writerT1.WriteLine("Паскар Дмитро Вячеславович, 2002 року народження, місце проживання м. Чернівці");
                writerT2.WriteLine("Бандура Богдан Володимирович, 2003 народження, місце проживання м. Чернівці");
            }

            using (var readerT1 = new StreamReader("D:\\temp\\Паскар_Дмитро1\\t1.txt"))
            using (var readerT2 = new StreamReader("D:\\temp\\Паскар_Дмитро1\\t2.txt"))
            using (var writer = File.AppendText("D:\\temp\\Паскар_Дмитро2\\t3.txt"))
            {
                string line = readerT1.ReadLine();
                writer.WriteLine(line);
                line = readerT2.ReadLine();
                writer.WriteLine(line);
            }

            FileInfo t1 = new FileInfo("D:\\temp\\Паскар_Дмитро1\\t1.txt");
            FileInfo t2 = new FileInfo("D:\\temp\\Паскар_Дмитро1\\t2.txt");
            FileInfo t3 = new FileInfo("D:\\temp\\Паскар_Дмитро2\\t3.txt");

            Console.WriteLine("t1.txt");
            ShowInfo(t1);
            Console.WriteLine();
            Console.WriteLine("t2.txt");
            ShowInfo(t2);
            Console.WriteLine();
            Console.WriteLine("t3.txt");
            ShowInfo(t3);
            Console.WriteLine();



            File.Move("D:\\temp\\Паскар_Дмитро1\\t2.txt", "D:\\temp\\Паскар_Дмитро2\\t2.txt");
            
            File.Copy("D:\\temp\\Паскар_Дмитро1\\t1.txt", "D:\\temp\\Паскар_Дмитро2\\t1.txt");
            Directory.Move("D:\\temp\\Паскар_Дмитро2", "D:\\temp\\ALL");
            Directory.Delete("D:\\temp\\Паскар_Дмитро1", true);

            DirectoryInfo all = new DirectoryInfo("D:\\temp\\ALL");
            Console.WriteLine("ALL");
            all.GetType().GetProperties().ToList().ForEach(x => Console.WriteLine(x.Name + ": " + x.GetValue(all)));
            Console.WriteLine();
            all.GetFiles().ToList().ForEach(x => ShowInfo(x));

        }

        
    }
}


