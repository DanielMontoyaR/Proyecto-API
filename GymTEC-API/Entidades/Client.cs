﻿namespace GymTEC_API.Entidades
{
    public class Client
    {
        public string ID_Client { get; set; } = string.Empty;
        public string Address { get; set;} = string.Empty;
        public int Weight { get; set; } = 0;
        public int BMI { get; set; } = 0;
        public string FName1 { get; set; } = string.Empty;
        public string FName2 { get; set; } = string.Empty;
        public string Last_name1 { get; set; } = string.Empty;
        public string Last_name2 { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Birth_Date { get; set; } = string.Empty;
        //public List<Lesson> Lessons_Attended { get; set; } = new List<Lesson>();
        //public string Dia { get; set; } = string.Empty;
        //public string Mes { get; set; } = string.Empty;
        //public string Año { get; set; } = string.Empty;

    }
}
