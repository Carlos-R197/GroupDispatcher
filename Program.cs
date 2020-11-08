using System;
using System.IO;
using System.Threading;
using System.Collections.Generic;
using System.Linq;

namespace GroupDispatcher
{
    class Program
    {
        static void Main(string[] args)
        {
            start:
            Console.Write("Inserte la ruta absoluta del archivo de estudiantes: ");
            string studentFilePath =  Console.ReadLine();
            Console.Write("Inserte la ruta absoluta del archivo de temas: ");
            string subjectFilePath = Console.ReadLine();
            Console.Write("Inserte la cantidad de grupos: ");
            int groupsAmount = int.Parse(Console.ReadLine());

            string[] students = File.ReadAllLines(studentFilePath);
            string[] subjects = File.ReadAllLines(subjectFilePath);

            if (students.Length < groupsAmount || subjects.Length < groupsAmount)
            {
                Console.Write("No hay suficientes estudiantes o temas para cada grupo.");
                Thread.Sleep(1500);
                Console.Clear();
                goto start;
            }

            //Separate the students from their ids, since we only need their names
            string[] studentsNames = new string[students.Length];
            char[] charactersToTrim = new char[] {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '-'};

            for (int i = 0; i < studentsNames.Length; i++)
            {
                studentsNames[i] = students[i].TrimStart(charactersToTrim);
            }

            var groups = new Group[groupsAmount];
            int amountStudentsPerGroup = students.Length / groupsAmount;
            int amountSubjectPerGroup = subjects.Length / groupsAmount;
            int extraStudentsAmount = students.Length % groupsAmount;
            int extraSubjectsAmount = subjects.Length % groupsAmount;

            //Shuffle the students and allocate them into groups
            var rnd = new Random();
            var randomStudents = studentsNames.OrderBy(t => rnd.Next()).ToArray();
            var randomSubjects = subjects.OrderBy(t => rnd.Next()).ToArray();

            var studentsQueue = new Queue<string>(randomStudents);
            var subjectsQueue = new Queue<string>(randomSubjects);

            for (int i = 0; i < groups.Length; i++)
            {
                groups[i] = new Group();

                for (int j = 0; j < amountStudentsPerGroup; j++)
                    groups[i].students.Add(studentsQueue.Dequeue());

                for (int j = 0; j < amountSubjectPerGroup; j++)
                    groups[i].subjects.Add(subjectsQueue.Dequeue());
            }

            //Allocate extra students
            var groupsIndexesToExclude = new HashSet<int>();
            for (int i = 0; i < extraStudentsAmount; i++)
            {
                int randomGroupIndex = GetRandomNumberExcept(0, groupsAmount - 1, groupsIndexesToExclude);
                groups[randomGroupIndex].students.Add(studentsQueue.Dequeue());
                groupsIndexesToExclude.Add(randomGroupIndex);
            }

            //Allocate extra subjects
            groupsIndexesToExclude.Clear();
            for (int i = 0; i < extraSubjectsAmount; i++)
            {
                int randomGroupIndex = GetRandomNumberExcept(0, groupsAmount - 1, groupsIndexesToExclude);
                groups[randomGroupIndex].subjects.Add(subjectsQueue.Dequeue());
                groupsIndexesToExclude.Add(randomGroupIndex);
            }

            PrintGroupsData(groups);
        }

        static int GetRandomNumberExcept(int start, int end, HashSet<int> numbersToExclude)
        {
            IEnumerable<int> range = Enumerable.Range(start, end).Where(t => !numbersToExclude.Contains(t));
            var rnd = new Random();
            int index = rnd.Next(start, end - numbersToExclude.Count);
            return range.ElementAt(index);
        }

        static void PrintGroupsData(Group[] groups)
        {
            for (int i = 0; i < groups.Length; i++)
            {
                Console.WriteLine($"Grupo {i + 1} (Estudiantes: {groups[i].students.Count}, Temas: {groups[i].subjects.Count})");

                Console.WriteLine("     Estudiantes:");
                foreach (string student in groups[i].students)
                    Console.WriteLine($"         {student}");
                
                Console.WriteLine("     Temas:");
                foreach (string subject in groups[i].subjects)
                    Console.WriteLine($"         {subject}");
            }
        }
    }

    public class Group
    {
        public List<string> students { get; set; }
        public List<string> subjects {get; set; }

        public Group()
        {
            students = new List<string>();
            subjects = new List<string>();
        }
    }
}
