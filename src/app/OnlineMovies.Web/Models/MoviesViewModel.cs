using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineMovies.BL;

namespace OnlineMovies.Web.Models
{
    public class MoviesViewModel
    {
        public IList<Movie> MoviesVMs { get; set; }
        public IList<Movie_Reviews> MovieReviewsVMs { get; set; }
    }
}