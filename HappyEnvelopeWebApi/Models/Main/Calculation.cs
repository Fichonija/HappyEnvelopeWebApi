using HappyEnvelopeWebApi.Models.Codebook;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HappyEnvelopeWebApi.Models.Main
{
    public class Calculation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [ForeignKey("salary")]
        public int salary_id { get; set; }
        public Salary salary { get; set; }
        public int attending { get; set; }
        [ForeignKey("relationship")]
        public int relationship_id { get; set; }
        public Relationship relationship { get; set; }
        public int festivities { get; set; }
        [ForeignKey("locale")]
        public int locale_id { get; set; }
        public Locale locale { get; set; }
        [ForeignKey("event")]
        public int event_id { get; set; }
        public Event @event { get; set; }
        [ForeignKey("season")]
        public int season_id { get; set; }
        public Season season { get; set; }
        public double calculationSum { get; set; }
    }
}