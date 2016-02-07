﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Payroll.Entities
{
    [Table("tbl_settings")]
    public class Setting
    {
        [Key]
        public int SettingId { get; set; }

        public string SettingKey { get; set; }

        public string Value { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }
    }
}
