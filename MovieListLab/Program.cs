using System;
using System.Collections.Generic;
using System.Text;

namespace MovieListLab
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Movie> movieList = new List<Movie>();
            List<string> categoryList = new List<string>();
            string text;
            bool looper = true;
            InitialList(movieList);
            foreach (Movie movie in movieList)
            {
                if (!categoryList.Contains(movie.Category))
                {
                    categoryList.Add(movie.Category);
                }
            }
            while (looper)
            {
                foreach (string category in categoryList)
                {
                    Console.WriteLine(MultipleWords(category));
                }
                text = UserEntry("What categoty are you interested in?: ").Trim().ToLower();
                if (categoryList.Contains(text))
                {
                    foreach (Movie movie in movieList)
                    {
                        if (movie.Category == text)
                            Console.WriteLine(MultipleWords(movie.Title));
                    }
                }
                else
                {
                    Console.WriteLine("There are no movies under specified category.");
                }
                looper = Verification("Continue? (Y/N): ", "Invalid Entry");
            }

        }

        public static string UserEntry (string message)
        {
            string text;
            bool checker;
            while (true)
            {
                checker = true;
                Console.Write(message);
                text = Console.ReadLine().Trim().ToLower();
                checker = Validation(text);
                if (checker)
                {
                    return text;
                }
                else
                {
                    Console.WriteLine("Try again.");
                }
            }
        } //end UserEntry

        public static string Indent (string text)
        {
            return text.Substring(0, 1).ToUpper() + text.Substring(1).ToLower();
        } //end Indent

        public static string MultipleWords(string text)
        {
            string[] words;
            char[] delimiters = {' ', '.', ':', '-' };
            int indexDifference;
            StringBuilder newText = new StringBuilder();
            words = text.Split(delimiters);
            foreach (string word in words)
            {
                if (word.Length > 0)
                {
                    newText.Append(Indent(word));
                }
            }
            for (int i = 0; i < text.Length; i++)
            {
                if(text[i].ToString().ToLower() != newText[i].ToString().ToLower())
                {
                    newText.Insert(i, text[i]);
                }
            }
            return newText.ToString().Trim();
        } //end MultipleWords

        public static bool Verification(string phrase, string error)
        {
            string text;
            while (true)
            {
                Console.Write(phrase);
                text = Console.ReadLine().Trim().ToLower();

                switch (text)
                {
                    case "y":
                    case "yes":
                        return true;


                    case "n":
                    case "no":
                        return false;


                    default:
                        Console.WriteLine(error);
                        break;
                }
            }
        } //end Verification

        public static bool Validation (string text)
        {
            if (!String.IsNullOrEmpty(text) || !String.IsNullOrWhiteSpace(text))
            {
                foreach (char letter in text.ToCharArray())
                {
                    if (Char.IsLetterOrDigit(letter) || Char.IsWhiteSpace(letter))
                    {

                    }
                    else
                    {
                            Console.WriteLine("Entry can't have special character");
                            return false;
                    }
                }
            }
            else
            {
                    Console.WriteLine("Entry can't be blank.");
                    return false;
            }
            return true;
        } //end Validation

        public static void InitialList (List<Movie> movieList)
        {
            movieList.Add(new Movie("E.T. The Extra-terrestrial", "scifi"));
            movieList.Add(new Movie("back to the future", "scifi"));
            movieList.Add(new Movie("batman returns", "action"));
            movieList.Add(new Movie("friday the 13th", "horror"));
            movieList.Add(new Movie("nightmare on elm street", "horror"));
            movieList.Add(new Movie("the croads", "animated"));
            movieList.Add(new Movie("batman", "action"));
            movieList.Add(new Movie("robocop", "action"));
            movieList.Add(new Movie("star wars", "scifi"));
            movieList.Add(new Movie("the fall from the stars", "drama"));
            movieList.Add(new Movie("gone girl", "drama"));
            movieList.Add(new Movie("2001: a space odyssey", "scifi"));
            movieList.Add(new Movie("A Clockwork Orange", "scifi"));

        } //end InitialList
    }
}
