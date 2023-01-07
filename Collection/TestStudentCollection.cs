using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collection
{
    public class TestStudentCollection
    {
        public static void TestStudentCollections()
        {
            //--< Create a new Student with ID 111 >--//
            var newStudent = new Student(111, "Glen Syde", 3.90f);

            var studentList = Student.Students;
            //--< Add the new Student to the end of the List >--//
            studentList.Add(newStudent);
            Console.WriteLine("\t---< Student List >---");
            foreach (var student in studentList)
                DisplayStudent(student);

            Console.WriteLine("\n\t---< Student Dictionary >---");
            var studentDictionary = Student.StudentDictionary;

            //--< Retrieve student with ID = 105 >--//
            var oneStudent = studentDictionary[105];
            DisplayStudent(oneStudent);

            Console.WriteLine("\t---< Removed StudentId 105 >---");
            //--< Remove Student 105 from the Dictionary >--//
            studentDictionary.Remove(105);

            Console.WriteLine("\t---< Add StudentId 111 >---");
            //--< Add New Student 111 to the Dictionary >--//
            studentDictionary.Add(111, newStudent);
            foreach (var key in studentDictionary.Keys)
            {
                oneStudent = studentDictionary[key];
                DisplayStudent(oneStudent);
            }

            Console.WriteLine("\n\t---< Student Stack  >---");
            Console.WriteLine("\t---< Push StudentId 111 to the top  >---");
            var stack = Student.StudentStack;
            //--< Push the new student to the top of the Stack >--//
            stack.Push(newStudent);
            while (stack.Count() > 0)
            {
                oneStudent = stack.Pop();
                DisplayStudent(oneStudent);
            }

            Console.WriteLine("\n\t---< Student Queue  >---");
            Console.WriteLine("\t---< Enqueue StudentId 111 to the bottom  >---");
            var queue = Student.StudentQueue;
            //--< Add New Student 111 to the end of the queue >--//
            queue.Enqueue(newStudent);
            while (queue.Count() > 0)
            {
                oneStudent = queue.Dequeue();
                DisplayStudent(oneStudent);
            }
        }
        static void DisplayStudent(Student student)
        {
            Console.WriteLine($"{student.StudentId}\t{student.Name}\t{student.GPA}");
        }
    }
}
