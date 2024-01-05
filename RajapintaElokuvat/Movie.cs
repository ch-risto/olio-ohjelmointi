using System.Text.Json.Serialization;
using System;

// Tutkittiin dataa jsonviewer.stack.hu ja huomattiin että saatu data on lista result, josta elokuvat löytyvät
public class Response
{
    public List<Movie> results { get; set; }
}

// Mallinnetaan olioon halutut tiedot JSON-tekstin perusteella
public class Movie
{
    public string? title { get; set; }
    public float vote_average { get; set; }
    public string? overview { get; set; }
    public string? release_date { get; set; }
}
