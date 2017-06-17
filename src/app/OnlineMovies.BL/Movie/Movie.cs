namespace OnlineMovies.Web
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public partial class Movie
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        [Column(TypeName = "date")]
        public DateTime ReleaseDate { get; set; }

        public int Rating { get; set; }

        public bool IsReleased { get; set; }
    }
}
