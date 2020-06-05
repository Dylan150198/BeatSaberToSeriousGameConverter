using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;

namespace BeatSaberToSeriousGameConverter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<NoteIn> notes;
           
            // replace string with different .json file for converting different songs
            using (StreamReader r = new StreamReader(@"..\\..\\..\\PsyStyle.json"))
            {
                string json = r.ReadToEnd();
                notes = JsonConvert.DeserializeObject<List<NoteIn>>(json);
            }

            List<NoteOut> noteOuts = new List<NoteOut>();

            foreach (NoteIn item in notes)
            {
                NoteOut noteOut = new NoteOut();
                var random = new Random();
                var list = new List<string> { "C Spawner", "L1 Spawner", "L2 Spawner", "R1 Spawner", "R2 Spawner"};
                int index = random.Next(list.Count);
                noteOut.spawner = list[index];

                switch (item._cutDirection.ToString())
                {
                    case "0":
                        noteOut.spawnPosition = "Spawn_Center";
                        break;
                    case "1":
                        noteOut.spawnPosition = "Spawn_Up_1";
                        break;
                    case "2":
                        noteOut.spawnPosition = "Spawn_Up_2";
                        break;
                    case "3":
                        noteOut.spawnPosition = "Spawn_Up_3";
                        break;
                    case "4":
                        noteOut.spawnPosition = "Spawn_Up_4";
                        break;
                    case "5":
                        noteOut.spawnPosition = "Spawn_Down_1";
                        break;
                    case "6":
                        noteOut.spawnPosition = "Spawn_Down_2";
                        break;
                    case "7":
                        noteOut.spawnPosition = "Spawn_Down_3";
                        break;
                    case "8":
                        noteOut.spawnPosition = "Spawn_Down_4";
                        break;
                }

                noteOut.timeInMs = item._time;
                noteOuts.Add(noteOut);
            }

            string finalConvert = JsonConvert.SerializeObject(noteOuts, Formatting.Indented);

        }
    }
}
