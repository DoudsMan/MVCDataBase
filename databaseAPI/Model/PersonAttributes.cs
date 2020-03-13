using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace databaseAPI.Model
{
    public partial class PersonAttributes
    {
        [Key]
        [Column("PersonID")]
        public int PersonId { get; set; }
        [StringLength(255)]
        public string Height { get; set; }
        [StringLength(255)]
        public string Weight { get; set; }
        public int? Age { get; set; }
        [StringLength(255)]
        public string Gender { get; set; }
        [StringLength(255)]
        public string Ethnicity { get; set; }
    }
}
