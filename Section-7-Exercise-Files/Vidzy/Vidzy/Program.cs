using System;
using System.Linq;
using System.Data.Entity;

namespace Vidzy
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new VidzyContext();
            //var videos = context.Videos; //Lazy loading
            //var videos = context.Videos.Include(c=>c.Genre).ToList();
            var videos = context.Videos.ToList(); //Explicit (1)
            //var videoGenreIds = videos.Select(v => v.GenreId); //Explicit (1.5)
            context.Genres.Load(); //*Opcion de Mosh
            //context.Genres.Where(g => videoGenreIds.Contains(g.Id)).Load(); //Explicit (2) *DO NOT FORGET THE LOAD!!!!
            foreach (var video in videos)
                Console.WriteLine("{0}, Genre: {1}", video.Name, video.Genre.Name);
        }
    }
}
