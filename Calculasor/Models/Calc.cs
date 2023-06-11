using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Calculasor.Models
{
    public class Calc
    {
        [Range(-15, 15,
        ErrorMessage = "Number {0} in {1} - {2}.")]
        [Display(Name = "Operand 1")]
        public byte Operand1 { get; set; }
        [Required(ErrorMessage = "Enter a required Operand2")]
        [Display(Name = "Operand 2")]
        public byte Operand2 { get; set; }
        public float Result { get; set; }
        public string Operation { get; set; }

    }
}