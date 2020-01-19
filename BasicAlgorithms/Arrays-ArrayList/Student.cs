
/*
   Create a class called Test (aka StudentArrays) that has data members for a student's name and number indicating the test number. 
   This class is used in the following scenario : When a student turns in a test, they place it face down on the desk. If a student wants to check an answer, 
   the teacher has to turn the stack over so the first test is face up, work through the stack until the student's test is found, and then remove the test from the stack. 
   When the student finishes checking the test , it is reinserted at the end of the stack . 
*/
using System.Collections;
using System.Collections.Generic;

public class Student
{
    public string Name { get; set; }

    public int Number { get; set; }


    public Student(string name, int number)
    {
        this.Name = name;
        this.Number = number;

    }

    public Student()
    {

    }

}

public class TestManager
{
    private List<Student> students;
    bool isReversed;
    public TestManager(List<Student> students)
    {
        this.students = students;
    }

    public List<Student> GetStudentsFromDesk()
    {
        if (!isReversed)
        {
            students.Reverse();
            isReversed = true;
        }
        return students;
    }

    public Student GetStudentTest(Student student)
    {
        Student result= students.Find((s) => {return s.Name == student.Name;} );
        if(result !=null) {
           students.Remove(result); 
        }
        return result;
    }

    //Just demonstrates Anonymous function technique
    public Student GetStudentByName(string name)
    {
       Student result = students.Find(delegate (Student s) { return s.Name == name; });
        if(result !=null) {
           students.Remove(result); 
        }
        return result;
    }

    public void ReinsertStudent(Student student)
    {
        if(isReversed) {
           students.Reverse();
           isReversed = false;
        }
           students.Add(student);
        
    }

}