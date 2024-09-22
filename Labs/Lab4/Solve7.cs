using System.Text.RegularExpressions;

namespace SolveLabs.Labs.Lab4
{
    public static class Solve7
    {
        public static void Execute()
        {
            string[] trackList = new string[10]
            {
                "1. Gentle Giant – Free Hand [6:15]",
                "2. Supertramp – Child Of Vision [7:27]",
                "3. Camel – Lawrence [10:46]",
                "4. Yes – Don’t Kill The Whale [3:55]",
                "5. 10CC – Notell Hotel [4:58]",
                "6. Nektar – King Of Twilight [4:16]",
                "7. The Flower Kings – Monsters & Men [21:19]",
                "8. Focus – Le Clochard [1:59]",
                "9. Pendragon – Fallen Dream And Angel [5:23]",
                "10. Kaipa – Remains Of The Day [8:02]"
            };

            List<Track> tracks = new List<Track>();
            Regex regex = new Regex(@"\[(\d+):(\d+)\]");

            foreach (string track in trackList)
            {
                Match match = regex.Match(track);
                if (match.Success)
                {
                    int minutes = int.Parse(match.Groups[1].Value);
                    int seconds = int.Parse(match.Groups[2].Value);
                    TimeSpan duration = new TimeSpan(0, minutes, seconds);
                    tracks.Add(new Track
                    {
                        Original = track,
                        Duration = duration
                    });
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Невозможно разобрать длительность в строке: {track}");
                    Console.ResetColor();
                }
            }

            // Подсчёт общего времени
            TimeSpan totalDuration = new TimeSpan();
            foreach (var track in tracks)
                totalDuration = totalDuration.Add(track.Duration);

            // Поиск самой длинной и самой короткой песни
            Track longestTrack = tracks[0];
            Track shortestTrack = tracks[0];

            foreach (var track in tracks)
            {
                if (track.Duration > longestTrack.Duration)
                    longestTrack = track;
                if (track.Duration < shortestTrack.Duration)
                    shortestTrack = track;
            }

            // Поиск пары песен с минимальной разницей во времени звучания
            TimeSpan minDifference = TimeSpan.MaxValue;
            Tuple<Track, Track> minDiffPair = null;

            for (int i = 0; i < tracks.Count; i++)
            {
                for (int j = i + 1; j < tracks.Count; j++)
                {
                    TimeSpan diff = (tracks[i].Duration - tracks[j].Duration).Duration();
                    if (diff < minDifference)
                    {
                        minDifference = diff;
                        minDiffPair = new Tuple<Track, Track>(tracks[i], tracks[j]);
                    }
                }
            }

            // Вывод результатов
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nТреклист:");
            Console.ResetColor();
            foreach (var track in tracks)
            {
                Console.WriteLine(track.Original);
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nОбщее время звучания: {totalDuration.Minutes} минут {totalDuration.Seconds} секунд");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\nСамая длинная песня: {longestTrack.Original} ({longestTrack.Duration.Minutes} минут {longestTrack.Duration.Seconds} секунд)");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"Самая короткая песня: {shortestTrack.Original} ({shortestTrack.Duration.Minutes} минут {shortestTrack.Duration.Seconds} секунд)");
            Console.ResetColor();

            if (minDiffPair != null)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"\nПара песен с минимальной разницей во времени звучания ({minDifference.Minutes} минут {minDifference.Seconds} секунд):");
                Console.ResetColor();
                Console.WriteLine($"1. {minDiffPair.Item1.Original}");
                Console.WriteLine($"2. {minDiffPair.Item2.Original}");
            }
        }

        private class Track
        {
            public string Original { get; set; }
            public TimeSpan Duration { get; set; }
        }
    }
}
