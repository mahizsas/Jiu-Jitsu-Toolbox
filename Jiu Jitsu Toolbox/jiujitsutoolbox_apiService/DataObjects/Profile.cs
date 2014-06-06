using Microsoft.WindowsAzure.Mobile.Service;
using System;
using System.Collections;
using System.Collections.Generic;

namespace jiujitsutoolbox_apiService.DataObjects
{
    //public class TodoItem : EntityData
    //{
    //    public string Text { get; set; }

    //    public bool Complete { get; set; }
    //}


    public class Profile : EntityData
    {
        public Profile()
        {
            this.Training = new List<Training>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        // weight division class
        public string WeightDivision { get; set; }
        public string WeightClass { get; set; }
        public string RankColor { get; set; }
        public string RankDegree { get; set; }
        public string RankAwardedBy { get; set; }
        public int YearsExperience { get; set; }

        //address
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        
        // social
        public string Twitter { get; set; }
        public string Facebook { get; set; }
        public string Google { get; set; }

        public virtual ICollection<Training> Training { get; set; }

    }

    public class Training : EntityData
    {
        public string ProfileId { get; set; }
        public virtual Profile Profile { get; set; }

        public string SessionType { get; set; }
        public DateTime Date { get; set; }
        public string Duration { get; set; }
        public string Instructor { get; set; }
        public string Notes { get; set; }
        public int Rating { get; set; }
        public string OpponentRank { get; set; }
        public string TournamentResult { get; set; }
        public string TechniquesUsedAgainst { get; set; }
        public string TechniquesUsedOn { get; set; }
    }

    public class School : EntityData
    {
        public string Instructor { get; set; }

        public virtual Location Location { get; set; }

        public string LocationId { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
    }

    public class Event : EntityData
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual Location Location { get; set; }

        public string LocationId { get; set; }
    }

    public class Location : EntityData
    {
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }

        public string Phone { get; set; }

        public virtual ICollection<Event> Events { get; set; }

        public virtual School School { get; set; }
    }

    public class Review : EntityData
    {
        public int Rating { get; set; }
        public string Notes { get; set; }
        public string RatedBy { get; set; }

        public string SchoolId { get; set; }

        public virtual School School { get; set; }
    }
}