﻿using PracticeManagement.Library.Services;

namespace PracticeManagement.Library.Models
{
    public class Time
    {

        public DateTime Date { get; set; }
        public string Narrative { get; set; }
        public int Id { get; set; }

        public double Hours { get; set; }

        public bool Billed { get; set; }

        public Project Project { get; set; }

        public Employee Employee { get; set; }

        public Time(string narrative, DateTime date, double hrs, Project currentProject, Employee currentEmployee)
        {

            Narrative = narrative;
            Date = date;
            Hours = hrs;
            Project = currentProject;
            Employee = currentEmployee;
            Billed = false;

        }

        public string prettyHours
        {
            get
            {
                return String.Format("{0:0.0}", Hours) + "hrs";
            }
        }
        public override string ToString()
        {
            return $" {Date.ToShortDateString()}  {Employee.Name}  {prettyHours} \n {Project.ToString()} \t  {Narrative}  ";
        }

    }
}
