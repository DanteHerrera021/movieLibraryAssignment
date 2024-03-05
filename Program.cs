
// NO EXTRA CREDIT
// AMOUNT OF MOVIES TO RETURN IN CONSOLE
int returnMovieAmount = 10;

string file = "ml-latest-small/movies.csv";
string choice;

do
{
    Console.WriteLine("1) Read movies.");
    Console.WriteLine("2) Add a movie to the file.");
    Console.WriteLine("Enter any other key to exit.");
    // input response
    choice = Console.ReadLine();

    if (choice == "1")
    {
        // read data from file
        if (File.Exists(file))
        {
            StreamReader sr = new StreamReader(file);
            Console.WriteLine("How many movies would you like to see (sorted by Movie ID)");

            returnMovieAmount = int.Parse(Console.ReadLine());
            int movieNum = 0;

            Console.WriteLine();
            Console.WriteLine($"----- LIST OF {returnMovieAmount} MOVIE(S) -----");
            Console.WriteLine();

            while (!sr.EndOfStream && movieNum != returnMovieAmount)
            {

                string line = sr.ReadLine();

                string[] movieArr = line.Split(',');

                string[] genreArr = movieArr[2].Split("|");
                string genreStr = "";

                for (int i = 0; i < genreArr.Length; i++)
                {
                    genreStr = genreStr + ", " + genreArr[i];
                }

                genreStr = genreStr.Substring(2);

                if (movieArr[0] != "movieId")
                {
                    Console.WriteLine($"ID: {movieArr[0]}, {movieArr[1]}");
                    Console.WriteLine($"Genre: {genreStr}");
                    Console.WriteLine();

                    movieNum++;
                }

            }
            sr.Close();
        }
        else
        {
            Console.WriteLine("File does not exist");
        }
    }
    else if (choice == "2")
    {
        StreamWriter sw = File.AppendText(file);

        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine("Add a new movie (Y/N)?");

            string resp = Console.ReadLine().ToUpper();
            if (resp != "Y") { break; }
            sw.WriteLine();

            Console.WriteLine("Enter the movie ID.");
            string movieId = Console.ReadLine();

            Console.WriteLine("Enter the movie name and year in this format:");
            Console.WriteLine("Name (0000)");
            string movieName = Console.ReadLine();

            Console.WriteLine("Enter the movie genres, in this format:");
            Console.WriteLine("Adventure|Drama|Romance");
            string movieGenre = Console.ReadLine();

            sw.Write("{0},{1},{2}", movieId, movieName, movieGenre);
        }
        sw.Close();
    }
} while (choice == "1" || choice == "2");
