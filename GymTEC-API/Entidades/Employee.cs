﻿namespace GymTEC_API.Entidades
{
    public class Employee
    {

        public string Employee_ID { get; set; } = string.Empty; //PK

        public string Branch_Name { get; set; } = string.Empty;
        public string Employee_Province { get; set; } = string.Empty;
        public string Employee_District { get; set; } = string.Empty;
        public string Employee_Canton { get; set; } = string.Empty;
        public string Employee_Email { get; set; } = string.Empty;
        public string Employee_Password { get; set; } = string.Empty;
        
        public string Employee_Fname { get; set; } = string.Empty;
        public string Employee_Mname { get; set; } = string.Empty; // middle name
        public string Employee_LName1 { get; set; } = string.Empty;
        public string Employee_LName2 { get; set; } = string.Empty;
        public string Employee_Workstation_id { get; set; } = string.Empty;
        public string Employee_payroll_id { get; set; } = string.Empty;

       



    }
}
