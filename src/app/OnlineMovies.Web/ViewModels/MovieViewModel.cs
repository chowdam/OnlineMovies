using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineMovies.BL;

namespace OnlineMovies.Web.ViewModels
{
    public class MovieViewModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int Rating { get; set; }

        public string ReleaseDate { get; set; }



    }
}