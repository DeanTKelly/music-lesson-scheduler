using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicLessonScheduler.Model
{
    public class Lesson
    {
        [PrimaryKey, AutoIncrement]
        public int LessonID { get; set; }
        public string LessonName { get; set; }
        public DateTime LessonDate { get; set; }
        public string LessonTime { get; set; }
        public bool LessonReminder { get; set; }
        public string LessonNotes { get; set; }
        public int StudentID { get; set; }
    }
}
