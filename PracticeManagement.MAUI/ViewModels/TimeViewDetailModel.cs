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

        public bool createNew { get; set; }

        public TimeViewDetailModel(Time? currentTime) 
        {
            SelectedTime = currentTime;
            if (SelectedTime != null)
            {
                UpdatedDate = SelectedTime.Date;
                UpdatedNarrative = SelectedTime.Narrative;
                createNew = false;
            }
            else
            {
                UpdatedDate = null;
                UpdatedNarrative = null;
                createNew = true;
            }
        }

        public void Update()
        { 
            if(SelectedTime != null)
            { 
               SelectedTime.Date = (DateTime) UpdatedDate;
               SelectedTime.Narrative = UpdatedNarrative;
            }
            else
            {
                SelectedTime = new Time(UpdatedNarrative,(DateTime) UpdatedDate);
            }
        }

  
    }
}
