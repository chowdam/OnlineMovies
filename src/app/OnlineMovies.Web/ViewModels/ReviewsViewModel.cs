using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineMovies.BL;

namespace OnlineMovies.Web.Models
{
    public class ReviewsViewModel
    {
        public int Id { get; set; }


        public string ReviewerName { get; set; }


        public string MovieReview { get; set; }


        public string ReviewDate { get; set; }

        public int MovieId { get; set; }

        public IEnumerable<Movie> MoviesList { get; set; }

    }
}