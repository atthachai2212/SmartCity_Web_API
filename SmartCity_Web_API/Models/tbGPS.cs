namespace SmartCity_Web_API.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbGPS
    {
        [Required]
        [Key]
        [Column(Order = 0, TypeName = "date")]
        public DateTime Date { get; set; }

        [Required]
        [Key]
        [Column(Order = 1)]
        public TimeSpan Time { get; set; }

        [Required]
        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Required]
        public float Latitude { get; set; }

        [Required]
        public float Longitude { get; set; }

        [Required]
        [StringLength(100)]
        public string Emergency { get; set; }

        public float Battery { get; set; }

        public float RSSI { get; set; }

        public float SNR { get; set; }


    }
}
