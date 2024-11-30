using AplikacjeWebowe.Cwiczenia5;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Reflection;
namespace ExamplesLinq

{
    public class Department(int id, string name)
    {
        public int Id { get; set; } = id;
        public String Name { get; set; } = name;

        public override string ToString()
        {
            return $"{Id,2}), {Name,11}";
        }
    }

    public enum Gender
    {
        Female,
        Male,
        Non_binary,
        Other
    }

    public class StudentWithTopics(int id, int index, string name, Gender gender, bool active,
        int departmentId, List<string> topics)
    {
        public int Id { get; set; } = id;
        public int Index { get; set; } = index;
        public string Name { get; set; } = name;
        public Gender Gender { get; set; } = gender;
        public bool Active { get; set; } = active;
        public int DepartmentId { get; set; } = departmentId;

        public List<string> Topics { get; set; } = topics;

        public override string ToString()
        {
            var result = $"{Id,2}) {Index,5}, {Name,11}, {Gender,6},{(Active ? "active" : "no active"),9},{DepartmentId,2}, topics: ";
            foreach (var str in Topics)
                result += str + ", ";
            return result;
        }
    }

    public class Topic(int id, string name)
    {
        public int Id { get; set; } = id;
        public string Name { get; set; } = name;
        public override string ToString()
        {
            return $"{Id}, {Name}";
        }
    }

    public class StudentWitTopicIds(int id, int index, string name, Gender gender, bool active, int departmentId, List<int> topicIds)
    {
        public int Id { get; set; } = id;
        public int Index { get; set; } = index;
        public string Name { get; set; } = name;
        public Gender Gender { get; set; } = gender;
        public bool Active { get; set; } = active;
        public int DepartmentId { get; set; } = departmentId;
        public List<int> TopicIds { get; set; } = topicIds;
        public override string ToString()
        {
            var result = $"{Id,2}) {Index,5}, {Name,11}, {Gender,6},{(Active ? "active" : "no active"),9},{DepartmentId,2}, topic ids: ";
            foreach (var str in TopicIds)
                result += str + ", ";
            return result;
        }
    }

    public static class Generator
    {
        public static List<StudentWithTopics> GenerateStudentsWithTopicsEasy()
        {
            return [
            new StudentWithTopics(1,12345,"Nowak", Gender.Female,true,1,
                    ["C#","PHP","algorithms"]),
            new StudentWithTopics(2, 13235, "Kowalski", Gender.Male, true,1,
                    ["C#","C++","fuzzy logic"]),
            new StudentWithTopics(3, 13444, "Schmidt", Gender.Male, false,2,
                    ["Basic","Java"]),
            new StudentWithTopics(4, 14000, "Newman", Gender.Female, false,3,
                    ["JavaScript","neural networks"]),
            new StudentWithTopics(5, 14001, "Bandingo", Gender.Male, true,3,
                    ["Java","C#"]),
            new StudentWithTopics(6, 14100, "Miniwiliger", Gender.Male, true,2,
                    ["algorithms","web programming"]),
            new StudentWithTopics(11,22345,"Nowak", Gender.Female,true,2,
                    ["C#","PHP","web programming"]),
            new StudentWithTopics(12, 23235, "Nowak", Gender.Male, true,1,
                    ["C#","C++","fuzzy logic"]),
            new StudentWithTopics(13, 23444, "Showner", Gender.Male, false,2,
                    ["Basic","C#"]),
            new StudentWithTopics(14, 24000, "Neumann", Gender.Female, false,3,
                    ["JavaScript","neural networks"]),
            new StudentWithTopics(15, 24001, "Rocky", Gender.Male, true,2,
                    ["fuzzy logic","C#"]),
            new StudentWithTopics(16, 24100, "Bruno", Gender.Female, false,2,
                    ["algorithms","web programming"]),
            ];
        }

        public static List<Topic> GenerateTopicsEasy()
        {
            return new List<Topic>()
            {
                new Topic(1, "C#"),
                new Topic(2, "PHP"),
                new Topic(3, "algorithms"),
                new Topic(4, "C++"),
                new Topic(5, "fuzzy logic"),
                new Topic(6, "Basic"),
                new Topic(7, "Java"),
                new Topic(8, "JavaScript"),
                new Topic(9, "neural networks"),
                new Topic(10, "web programming")
            };
        }
    }

    class Lista7
    {
        static void Zad1(int n)
        {
            var sortedStudents = 
                (from students in Generator.GenerateStudentsWithTopicsEasy()
                orderby students.Name, students.Index
                select students).ToList();


            var groupedStudents = (from student in sortedStudents
                                  let index = sortedStudents.IndexOf(student)
                                  group student by index / n);

            int i = 0;
            foreach (var studentGroup in groupedStudents)
            {
                Console.WriteLine($"Group {i++}");
                foreach (StudentWithTopics student in studentGroup)
                {
                    Console.WriteLine(student);
                }
            }
        }

        static void Zad2a()
        {
            var topicsByFrequency = (from student in Generator.GenerateStudentsWithTopicsEasy()
                                     from topic in student.Topics
                                     group topic by topic into topicGroup
                                     orderby topicGroup.Count() descending
                                     select (topicGroup, topicGroup.Count())).ToList();

            foreach (var topic in topicsByFrequency)
            {
                Console.WriteLine(topic.topicGroup.Key + " - " + topic.Item2);
            }
        }

        static void Zad2b()
        {
            var topicByGenderAndFrequency = (from student in Generator.GenerateStudentsWithTopicsEasy()
                                             group student by student.Gender into genderGroups
                                             from genderGroup in genderGroups
                                             from topic in genderGroup.Topics
                                             group topic by (genderGroups.Key, topic) into topicGroup
                                             orderby topicGroup.Count() descending
                                             select (topicGroup, topicGroup.Count())).ToList();

            foreach (var topic in topicByGenderAndFrequency)
            {
                Console.WriteLine(topic.topicGroup.Key + " - " + topic.Item2);
            }
        }

        static void Zad3()
        {
            var studentsWithTopicIds = Generator.GenerateStudentsWithTopicsEasy().Select(student => new StudentWitTopicIds(
                student.Id,
                student.Index,
                student.Name,
                student.Gender,
                student.Active,
                student.DepartmentId,
                student.Topics.Select(topicName => Generator.GenerateTopicsEasy().First(topic => topic.Name == topicName))
                                .Select(topic => topic.Id).ToList()
                                .ToList()
            )).ToList();

            foreach (var student in studentsWithTopicIds)
            {
                Console.WriteLine(student);
            }
        }

        class MyObj(string a)
        {
            public string A { get; set; } = a;

            public string PrintAB(string b)
            {
                var res = A + " " + b;
                Console.WriteLine("Wypisanie w metodzie: " + res);
                return res;
            }
        }

        static void Zad4()
        {
            object obj = new MyObj("jakis");
            MethodInfo method = obj.GetType().GetMethod("PrintAB");
            object[] param = {"tekst"};
            object result = method.Invoke(obj, param);
            Console.WriteLine("Wypisanie wyniku: " + result);
        }

        static void Main()
        {
            Console.WriteLine("Które zadanie uruchomić?");
            string zadanie = Console.ReadLine();
            switch (zadanie)
            {
                case "1":
                    Console.WriteLine("Dla n=2: ");
                    Zad1(2);
                    Console.WriteLine("Dla n=5: ");
                    Zad1(5);
                    break;
                case "2a":
                    Zad2a();
                    break;
                case "2b":
                    Zad2b();
                    break;
                case "3":
                    Zad3();
                    break;
                case "4":
                    Zad4();
                    break;
                default:
                    Console.WriteLine("Nie ma takiego zadania");
                    break;
            }
        }
    }
}
