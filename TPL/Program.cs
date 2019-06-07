using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TPL
{
    class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                Console.WriteLine("Do u want some Chuck Norris joke?\n1 - Yeah\n2 - NO GOD PLEASE NO");
                int answer = int.Parse(Console.ReadLine());

                switch (answer)
                {
                    case 1:
                        var task = GetJoke();
                        Console.WriteLine("\n" + task.Result + "\n\n");
                        break;
                    case 2: Environment.Exit(0); break;
                    default:
                        Console.WriteLine("There's no such answer");
                        break;
                }
            }
        }

        static Task<string> GetJoke()
        {
            using (var client = new WebClient())
            {
                client.Headers.Add("X-RapidAPI-Host", "matchilling-chuck-norris-jokes-v1.p.rapidapi.com");
                client.Headers.Add("X-RapidAPI-Key", "91bc8dd57emsh82ae53456504a93p1c3d6bjsneb0fa1067833");
                client.Headers.Add("accept", "application/json");

                var jsonString = client.DownloadString("https://matchilling-chuck-norris-jokes-v1.p.rapidapi.com/jokes/random");

                var joke = JsonConvert.DeserializeObject<ChuckJoke>(jsonString);
                return Task.FromResult(joke.Value);
            }
        }
    }
}
