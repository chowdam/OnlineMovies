using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMovies.BL
{
    public class UnitOfWork : IDisposable
    {
        private OnlineMoviesDB context = new OnlineMoviesDB();

        private GenericRepository<Movie> movieRepository;
        private GenericRepository<Movie_Reviews> movieReviewsRepository;

        public GenericRepository<Movie> MovieRepository
        {
            get
            {

                if (this.movieRepository == null)
                {
                    this.movieRepository = new GenericRepository<Movie>(context);
                }
                return movieRepository;
            }
        }
        public GenericRepository<Movie_Reviews> MovieReviewsRepository
        {
            get
            {

                if (this.movieReviewsRepository == null)
                {
                    this.movieReviewsRepository = new GenericRepository<Movie_Reviews>(context);
                }
                return movieReviewsRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
