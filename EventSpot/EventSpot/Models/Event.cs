﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EventSpot.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string EventName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EventDate { get; set; }


        [Required]
        [RegularExpression(@"([01]?[0-9]|2[0-3]):[0-5][0-9]", ErrorMessage = "Invalid Time.")]
        public string StartTime { get; set; }

        public string EventDescription { get; set; }

        [ForeignKey("Organizer")]
        public string OrganizerId { get; set; }

        public ApplicationUser Organizer { get; set; }

        public byte[] EventPhoto { get; set; }

        
     //   public ICollection<string> Attendant { get; set; }

        public bool IsOrganizer(string name)
        {
            return this.Organizer.UserName.Equals(name);
        }



    }
}