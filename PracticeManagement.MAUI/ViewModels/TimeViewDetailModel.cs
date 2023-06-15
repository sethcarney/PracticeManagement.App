using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using PracticeManagement.Library.Models;
using PracticeManagement.Library.Services;

namespace PracticeManagement.MAUI.ViewModels
{
    public class TimeViewDetailModel
    {

        public Time? SelectedTime { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? UpdatedNarrative { get; set; }

        public string? UpdatedHours { get; set; }
        DateTime SelectedDate { get; set; }
        public bool createNew { get; set; }

        public TimeViewDetailModel(Time? currentTime) 
        {
            SelectedTime = currentTime;
            if (SelectedTime != null)
            {
                SelectedDate = SelectedTime.Date;
                UpdatedNarrative = SelectedTime.Narrative;
                UpdatedHours = SelectedTime.Hours.ToString();
                createNew = false;
            }
            else
            {
                SelectedDate = DateTime.Today;
                UpdatedNarrative = null;
                UpdatedHours = "0.0";
                createNew = true;
            }
        }

        public bool Update()
        {
            double holder;
            var RateGiven = double.TryParse(UpdatedHours, out holder);
            if (RateGiven == false)
                return false;
            if (SelectedTime != null)
            { 
               SelectedTime.Date = SelectedDate;
                SelectedTime.Hours = holder;
               SelectedTime.Narrative = UpdatedNarrative;
            }
            else
            {
                SelectedTime = new Time(UpdatedNarrative,SelectedDate,holder);
            }
            return true;
        }

  
    }
}
