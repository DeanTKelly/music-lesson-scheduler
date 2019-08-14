using MusicLessonScheduler.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MusicLessonScheduler
{
    public class Database
    {
        public static SQLiteAsyncConnection connection;
        public Database(string databasePath)
        {
            connection = new SQLiteAsyncConnection(databasePath);
            connection.CreateTablesAsync<Student, Lesson>().Wait();
        }
        public void EvaluationData()
        {
            Student DummyStudent = new Student();
            Lesson DummyLesson = new Lesson();

            var checkStudent = connection.Table<Student>().Where(x => x.StudentName == "Dean Kelly").ToListAsync();

            if (checkStudent.Result.Count == 0)
            {
                DummyStudent.StudentName = "Dean Kelly";
                DummyStudent.StudentPhone = "(423)344-2879";
                DummyStudent.StudentEmail = "dkell80@wgu.edu";
                DummyStudent.StudentSkillLevel = "Intermediate";
                DummyStudent.StudentInstrument = "Guitar";
                SaveStudent(DummyStudent);

                var relatedStudent = connection.Table<Student>().Where(x => x.StudentName == "Dean Kelly").ToListAsync();
                if (relatedStudent.Result.Count == 1)
                {
                    DummyLesson.LessonName = "Augmented Arpeggios";
                    DummyLesson.LessonDate = DateTime.Today.AddDays(1);
                    DummyLesson.LessonTime = "2:00-3:00pm";
                    DummyLesson.LessonReminder = true;
                    DummyLesson.LessonNotes = "We'll be covering augmented arpeggio patterns and fretboard diagrams.";
                    DummyLesson.StudentID = DummyStudent.StudentID;
                    SaveLesson(DummyLesson);
                }
            }
        }
            public Task<List<Student>> ShowStudents()
        {
            return connection.Table<Student>().ToListAsync();
        }
        public Task<Student> ShowStudents(int id)
        {
            return connection.Table<Student>().Where(i => i.StudentID == id).FirstOrDefaultAsync();
        }
        public Task<int> SaveStudent(Student student)
        {
            if(student.StudentID == 0)
            {
                return connection.InsertAsync(student);                 
            }
            else
            {
                return connection.UpdateAsync(student);
            }
        }
        public Task<int> DeleteStudent(Student student)
        {
            return connection.DeleteAsync(student);
        }
        public Task<List<Lesson>> ShowLessons(Student student)
        {
            return connection.Table<Lesson>().Where(a => a.StudentID == student.StudentID).ToListAsync();
        }
        public Task<int> SaveLesson(Lesson lesson)
        {
            if(lesson.LessonID == 0)
            {
                return connection.InsertAsync(lesson);
            }
            else
            {
                return connection.UpdateAsync(lesson);
            }
        }
        public Task<int> DeleteLesson(Lesson lesson)
        {
            return connection.DeleteAsync(lesson);
        }
        public Task<Lesson> ShowLessons(int StudentID)
        {
            return connection.Table<Lesson>()
                .Where(a => a.StudentID == StudentID).FirstOrDefaultAsync();
        }
    }
}
