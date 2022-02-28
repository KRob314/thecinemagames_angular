﻿using System.Text;

namespace CinemaGames.Data
{
    public class RandomData
    {
        private readonly Random _random = new Random();

        public int Number(int min, int max)
        {
            return _random.Next(min, max);
        }

        public string FirstName()
        {
            List<string> names = new List<string>()
            {
                "Chad",
                "Becky",
                "Todd",
                "Mark",
                "Sue",
                "Brittany",
                "Garrett",
                "Joe",
                "Kate",
                "Jonathan",
                "Erin",
                "Levi"
            };
            int randomIndex = Number(0, names.Count);

            return names[randomIndex];
        }

        public string LastName()
        {
            List<string> names = new List<string>()
            {
                "Jackson",
                "Davis",
                "Jones",
                "Roberts",
                "Hall",
                "Vega",
                "Watts",
                "Bush",
                "Markley",
                "Pearson",
                "Yang",
                "Bishop"
            };
            int randomIndex = Number(0, names.Count);

            return names[randomIndex];
        }

        public string Genre()
        {
            List<string> names = new List<string>()
            {
                "Comedy",
                "Drama",
                "Western",
                "Science Fiction",
                "Thriller",
                "Romance",
                "Crime",
                "Historical",
                "Adcenture",
                "Animation",
                "Musical",
                "Action"
            };
            int randomIndex = Number(0, names.Count);

            return names[randomIndex];
        }

        public string RandomString(int size, bool lowerCase = false)
        {
            var builder = new StringBuilder(size);

            // char is a single Unicode character  
            char offset = lowerCase ? 'a' : 'A';
            const int lettersOffset = 26; // A...Z or a..z: length = 26  

            for (var i = 0; i < size; i++)
            {
                var @char = (char)_random.Next(offset, offset + lettersOffset);
                builder.Append(@char);
            }

            return lowerCase ? builder.ToString().ToLower() : builder.ToString();
        }

        public string RandonWords(int maxLength, int minLength = 0)
        {
            StringBuilder sb = new StringBuilder();
            int length = Number(10, maxLength);

            while(sb.Length <= length)
            {
                sb.Append(RandomString(Number(2, 10)));
                sb.Append(" ");
            }

            if(sb.Length > maxLength)
            {
                sb.Remove(maxLength, sb.Length  - maxLength);
            }

            return sb.ToString();
        }

        public string Movie()
        {
            List<string> names = new List<string>()
            {
                "Aliens",
"Armageddon",
"As Good As It Gets",
"Braveheart",
"Chasing Amy",
"Contact",
"Dante's Peak",
"Deep Impact",
"Executive Decision",
"Forrest Gump",
"Ghost",
"Gone with the Wind",
"Good Will Hunting",
"Grease",
"Halloween",
"Hard Rain",
"I Know What You Did Last Summer",
"Independence Day",
"Indiana Jones and the Last Crusade",
"Jaws",
"Men in Black",
"Multiplicity",
"Pulp Fiction",
"Raiders of the Lost Ark",
"Saving Private ryan",
"Schindler's List",
"Scream",
"Speed 2:Cruise Control",
"Terminator",
"The American President",
"The Fifth Element",
"The Game",
"The Man in the Iron Mask",
"Titanic",
"True Lies",
"Volcano",
"The Shawshank Redemption (1994)",
"The Godfather (1972)",
"The Godfather: Part II (1974)",
"Pulp Fiction (1994)",
"The Good, the Bad and the Ugly (1966)",
"The Dark Knight (2008)",
"12 Angry Men (1957)",
"Schindler's List (1993)",
"The Lord of the Rings: The Return of the King (2003)",
"Fight Club (1999)",
"Star Wars: Episode V - The Empire Strikes Back (1980)",
"The Lord of the Rings: The Fellowship of the Ring (2001)",
"One Flew Over the Cuckoo's Nest (1975)",
"Goodfellas (1990)",
"Seven Samurai (1954)",
"Inception (2010)",
"Star Wars (1977)",
"Forrest Gump (1994)",
"The Matrix (1999)",
"The Lord of the Rings: The Two Towers (2002)",
"City of God (2002)",
"The Silence of the Lambs (1991)",
"Se7en (1995)",
"Once Upon a Time in the West (1968)",
"Casablanca (1942)",
"The Usual Suspects (1995)",
"Raiders of the Lost Ark (1981)",
"Rear Window (1954)",
"It's a Wonderful Life (1946)",
"Psycho (1960)",
"Léon: The Professional (1994)",
"Sunset Blvd. (1950)",
"American History X (1998)",
"Apocalypse Now (1979)",
"Terminator 2: Judgment Day (1991)",
"Memento (2000)",
"Saving Private Ryan (1998)",
"City Lights (1931)",
"Dr. Strangelove or: How I Learned to Stop Worrying and Love the Bomb (1964)",
"Alien (1979)",
"Modern Times (1936)",
"Spirited Away (2001)",
"Gravity (2013)",
"North by Northwest (1959)",
"Back to the Future (1985)",
"Citizen Kane (1941)",
"The Pianist (2002)",
"M (1931)",
"Life Is Beautiful (1997)",
"The Shining (1980)",
"The Departed (2006)",
"Paths of Glory (1957)",
"Vertigo (1958)",
"American Beauty (1999)",
"Django Unchained (2012)",
"Double Indemnity (1944)",
"Taxi Driver (1976)",
"The Dark Knight Rises (2012)",
"Aliens (1986)",
"The Green Mile (1999)",
"The Intouchables (2011)",
"Gladiator (2000)",
"WALL·E (2008)",
"The Lives of Others (2006)",
"Toy Story 3 (2010)",
"The Great Dictator (1940)",
"A Clockwork Orange (1971)",
"The Prestige (2006)",
"Amélie (2001)",
"Lawrence of Arabia (1962)",
"To Kill a Mockingbird (1962)",
"Reservoir Dogs (1992)",
"Das Boot (1981)",
"Cinema Paradiso (1988)",
"The Lion King (1994)",
"The Treasure of the Sierra Madre (1948)",
"The Third Man (1949)",
"Once Upon a Time in America (1984)",
"Requiem for a Dream (2000)",
"Star Wars: Episode VI - Return of the Jedi (1983)",
"Eternal Sunshine of the Spotless Mind (2004)",
"Full Metal Jacket (1987)",
"Braveheart (1995)",
"L.A. Confidential (1997)",
"Oldboy (2003)",
"Singin' in the Rain (1952)",
"Metropolis (1927)",
"Chinatown (1974)",
"Rashomon (1950)",
"Some Like It Hot (1959)",
"Bicycle Thieves (1948)",
"All About Eve (1950)",
"Monty Python and the Holy Grail (1975)",
"Princess Mononoke (1997)",
"Amadeus (1984)",
"2001: A Space Odyssey (1968)",
"Witness for the Prosecution (1957)",
"The Apartment (1960)",
"The Sting (1973)",
"Unforgiven (1992)",
"Grave of the Fireflies (1988)",
"Indiana Jones and the Last Crusade (1989)",
"Raging Bull (1980)",
"The Bridge on the River Kwai (1957)",
"Die Hard (1988)",
"Yojimbo (1961)",
"Batman Begins (2005)",
"A Separation (2011)",
"Inglourious Basterds (2009)",
"For a Few Dollars More (1965)",
"Mr. Smith Goes to Washington (1939)",
"Snatch. (2000)",
"Toy Story (1995)",
"On the Waterfront (1954)",
"The Great Escape (1963)",
"Downfall (2004)",
"Pan's Labyrinth (2006)",
"Up (2009)",
"The General (1926)",
"The Seventh Seal (1957)",
"Heat (1995)",
"The Elephant Man (1980)",
"The Maltese Falcon (1941)",
"The Kid (1921)",
"Blade Runner (1982)",
"Wild Strawberries (1957)",
"Rebecca (1940)",
"Scarface (1983)",
"Ikiru (1952)",
"Ran (1985)",
"Fargo (1996)",
"Gran Torino (2008)",
"Touch of Evil (1958)",
"The Big Lebowski (1998)",
"The Gold Rush (1925)",
"The Deer Hunter (1978)",
"Cool Hand Luke (1967)",
"It Happened One Night (1934)",
"Diabolique (1955)",
"No Country for Old Men (2007)",
"The Sixth Sense (1999)",
"Lock, Stock and Two Smoking Barrels (1998)",
"Jaws (1975)",
"Good Will Hunting (1997)",
"Strangers on a Train (1951)",
"Casino (1995)",
"Judgment at Nuremberg (1961)",
"The Grapes of Wrath (1940)",
"The Wizard of Oz (1939)",
"Platoon (1986)",
"Sin City (2005)",
"Butch Cassidy and the Sundance Kid (1969)",
"Kill Bill: Vol. 1 (2003)",
"The Thing (1982)",
"Trainspotting (1996)",
"Gone with the Wind (1939)",
"High Noon (1952)",
"Annie Hall (1977)",
"Hotel Rwanda (2004)",
"The Hunt (2012)",
"Warrior (2011)",
"The Secret in Their Eyes (2009)",
"Finding Nemo (2003)",
"My Neighbor Totoro (1988)",
"V for Vendetta (2005)",
"Notorious (1946)",
"Dial M for Murder (1954)",
"The Avengers (2012)",
"How to Train Your Dragon (2010)",
"Life of Brian (1979)",
"Into the Wild (2007)",
"The Best Years of Our Lives (1946)",
"Network (1976)",
"The Terminator (1984)",
"Million Dollar Baby (2004)",
"There Will Be Blood (2007)",
"Ben-Hur (1959)",
"The Night of the Hunter (1955)",
"The Big Sleep (1946)",
"The King's Speech (2010)",
"Stand by Me (1986)",
"The 400 Blows (1959)",
"Twelve Monkeys (1995)",
"Groundhog Day (1993)",
"Donnie Darko (2001)",
"Dog Day Afternoon (1975)",
"Amores Perros (2000)",
"Howl's Moving Castle (2004)",
"Mary and Max (2009)",
"Gandhi (1982)",
"The Bourne Ultimatum (2007)",
"A Beautiful Mind (2001)",
"Persona (1966)",
"The Killing (1956)",
"The Graduate (1967)",
"Rush (2013)",
"Black Swan (2010)",
"The Princess Bride (1987)",
"Who's Afraid of Virginia Woolf? (1966)",
"The Hustler (1961)",
"The Man Who Shot Liberty Valance (1962)",
"La Strada (1954)",
"Anatomy of a Murder (1959)",
"8½ (1963)",
"The Manchurian Candidate (1962)",
"Rocky (1976)",
"The Exorcist (1973)",
"Slumdog Millionaire (2008)",
"In the Name of the Father (1993)",
"Stalag 17 (1953)",
"Rope (1948)",
"The Wild Bunch (1969)",
"Barry Lyndon (1975)",
"Monsters, Inc. (2001)",
"Fanny and Alexander (1982)",
"Infernal Affairs (2002)",
"The Truman Show (1998)",
"Roman Holiday (1953)",
"Life of Pi (2012)",
"Pirates of the Caribbean: The Curse of the Black Pearl (2003)",
"Memories of Murder (2003)",
"All Quiet on the Western Front (1930)",
"Harry Potter and the Deathly Hallows: Part 2 (2011)",
"Sleuth (1972)",
"Stalker (1979)",
"Jurassic Park (1993)",
"A Streetcar Named Desire (1951)",
"Star Trek (2009)",
"Ratatouille (2007)",
"Ip Man (2008)",
"A Fistful of Dollars (1964)",
"The Diving Bell and the Butterfly (2007)",
"The Hobbit: An Unexpected Journey (2012)",
"District 9 (2009)",
"Shutter Island (2010)",
"Rain Man (1988)",
"Incendies (2010)",
"Rosemary's Baby (1968)",
"La Haine (1995)",
"3 Idiots (2009)",
"The Artist (2011)",
"Nausicaä of the Valley of the Wind (1984)",
"Beauty and the Beast (1991)",
"Three Colors: Red (1994)",
"Bringing Up Baby (1938)",
"Mystic River (2003)",
"In the Heat of the Night (1967)",
"Arsenic and Old Lace (1944)",
"Before Sunrise (1995)",
"Papillon (1973)",


            };

           int randomIndex = Number(0, names.Count);

            return names[randomIndex];
        }
    }
}
