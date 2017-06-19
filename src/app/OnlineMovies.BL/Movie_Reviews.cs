namespace OnlineMovies.BL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Movie_Reviews
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(100)]
        public string ReviewerName { get; set; }

        [StringLength(200)]
        public string MovieReview { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ReviewDate { get; set; }

        public int MovieId { get; set; }

        public virtual Movie Movie { get; set; }
    }
}
