﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MuaythaiSportManagementSystemApi.Models
{
    public class FightJudgesMapping
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Main { get; set; }
        public int FightId { get; set; }
        public string JudgeId { get; set; }
        public virtual Fight Fight { get; set; }
        public virtual ApplicationUser Judge { get; set; }
    }
}