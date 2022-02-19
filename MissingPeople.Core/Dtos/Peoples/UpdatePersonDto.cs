﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissingPeople.Core.Dtos.Peoples
{
    //lista parametrów do aktualizacji przez użytkownika
    public class UpdatePersonDto
    {
        public string City { get; set; }
        public bool IsAtRisk { get; set; }
        [MaxLength(40)]
        public string RiskDescription { get; set; }
        public string OtherDetails { get; set; }
        public bool IsWaiting { get; set; }
    }
}
