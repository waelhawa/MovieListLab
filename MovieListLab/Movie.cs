using System;
using System.Collections.Generic;
using System.Text;

namespace MovieListLab
{
    class Movie
    {
        private string title;
        private string category;

        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }

        public string Category
        {
            get
            {
                return category;
            }
            set
            {
                category = value;
            }
        }

        public Movie (string title, string category)
        {
            this.title = title;
            this.category = category;
        }
    }
}
