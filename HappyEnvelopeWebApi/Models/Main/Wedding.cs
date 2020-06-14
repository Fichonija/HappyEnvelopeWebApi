using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HappyEnvelopeWebApi.Models.Main
{
    public class Wedding
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        [ForeignKey("calculation")]
        public int calculation_id { get; set; }
        public Calculation calculation { get; set; }
        [ForeignKey("gift")]
        public int gift_id { get; set; }
        public Gift gift { get; set; }
    }
}