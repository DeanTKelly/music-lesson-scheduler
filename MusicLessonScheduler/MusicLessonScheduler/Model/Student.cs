using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicLessonScheduler.Model
{
    public class Student
    {
        [PrimaryKey, AutoIncrement]
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public string StudentPhone { get; set; }
        public string StudentEmail { get; set; }
        public string StudentSkillLevel { get; set; }
        public string StudentInstrument { get; set; }
    }
}
