using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace CP.Mobile.ImageSlider
{
    public class Movie
    {
        public string Title { get; set; }
        public string Cast { get; set; }
        public string ImageUrl { get; set; }
        public Color BgColor { get; set; }
    }
    public class MovieService
    {
        public List<Movie> GetMoviesList()
        {
            return new List<Movie>()
            {
              new Movie()
              {
                Title="Dardar",
                Cast="gvgvgvgvgvgvg",
                ImageUrl="https://i.ytimg.com/vi/o8-ujo1O85I/maxresdefault.jpg",
                BgColor = Color.AliceBlue
              },
               new Movie()
              {
                Title="şşşşş",
                Cast="gvgvgvgvgvgvg",
                ImageUrl="https://i.ytimg.com/vi/o8-ujo1O85I/maxresdefault.jpg",
                BgColor = Color.AliceBlue
              },
                new Movie()
              {
                Title="ççççç",
                Cast="gvgvgvgvgvgvg",
                ImageUrl="https://i.ytimg.com/vi/o8-ujo1O85I/maxresdefault.jpg",
                BgColor = Color.AliceBlue
              },
                 new Movie()
              {
                Title="dddd",
                Cast="gvgvgvgvgvgvg",
                ImageUrl="https://i.ytimg.com/vi/o8-ujo1O85I/maxresdefault.jpg",
                BgColor = Color.AliceBlue
              }
            };
        }
    }
}
