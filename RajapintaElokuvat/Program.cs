using System.Text.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace Eloranta7_3;
class Program : Movie
{
    static async Task Main()
    {
        // Tee ohjelma, joka hyödyntää REST/JSON api tiedon hakemiseen
        // Tehdään ohjelma, joka hakee 3 suosituinta elokuvaa käyttäjän valitsemalta vuodelta
        // Toivotetaan käyttäjä tervetulleeksi käyttämään ohjelmaa ja kysytään vuosiluku
        Console.WriteLine("Tervetuloa selaamaan suosituimpia elokuvia vuosiluvun perusteella sivustolta https://www.themoviedb.org/");
        Console.WriteLine("Minkä vuoden elokuvia haluaisit selata? (Syötä vuosiluku)");
        string? input = Console.ReadLine();

        // Kaikilla elokuvilla ei ollut vuosilukuja. Mutta sovitaan, että syötetyn luvun tulee olla suurempi kuin 1800
        if (int.TryParse(input, out int year) && year <= DateTime.Now.Year && year > 1800)
        {
            Console.WriteLine($"Haluat nähdä kolme suosituinta elokuvaa vuodelta {year}");
            Console.WriteLine();
            
            await ProcessMovieData(year);
        }

        else
        {
            Console.WriteLine("Virheellinen syöte, käynnistä ohjelma uudelleen");
        }
    }

    // Asynkroninen metodi, jossa haetaan data ja käydään sitä läpi
    private static async Task ProcessMovieData(int year)
    {
        try
        {
            // Luodaan HttpClientHandler-olio automaattista purkamista GZip ja Deflate-menetelmillä varten
            HttpClientHandler handler = new HttpClientHandler()
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            };

            // Luodaan HttpClient olio, joka käyttää handler oliota
            HttpClient client = new HttpClient(handler);
            // Tyhjennetään oletuspyyntöotsikot
            client.DefaultRequestHeaders.Accept.Clear();
            // Lisätään pyyntöotsikko hyväksyä json
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            // Lisätään pyyntöotsikko hyväksyä GZip-pakattua dataa
            client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip");

            // API-key, jotta rajapintaa voitiin käyttää
            string apiKey = "1da6c8e99d64dd5e26bab656373ce1c1";
            // Osoite tietokantaan, täydennetään api-key ja käyttäjältä kysytty vuosi
            string apiUrl = $"https://api.themoviedb.org/3/discover/movie?api_key={apiKey}&original_language=en&primary_release_year={year}&sort_by=popularity.desc";

            // Kutsutaan url
            var responseStream = await client.GetStreamAsync(apiUrl);
            // Muutetaan JSON-teksti olioksi
            var response = await JsonSerializer.DeserializeAsync<Response>(responseStream);

            // Looppi, jossa käydään oliota läpi
            // Lasketaan kierroksia countilla, kun kierroksia on tullut täyteen 3, katkaistaan
            int count = 0;
            foreach (var movie in response.results)
            {
                if (count >= 3)
                {
                    break;
                }
                count ++;

                // Tulostetaan elokuvan nimi, julkaisupäivä, pisteet sekä kuvaus
                Console.WriteLine(movie.title + ", julkaistu: " + movie.release_date + " - pisteet: " + movie.vote_average);
                Console.WriteLine(movie.overview);
                Console.WriteLine();                
            }

        }

        // Jos tapahtuu virhe
        catch (HttpRequestException e)
        {
            Console.WriteLine("\nException Caught!");
            Console.WriteLine("Message :{0}", e.Message);
        }
    }
}