
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TestMaui.Models;

namespace TestMaui.Services
{
    public interface IMovieApIService
    {
        Task<List<Movie>> GetMovies(string search);
    }

    public class MovieApIService : IMovieApIService
    {
        private readonly HttpClient _client;

        public MovieApIService()
        {
            _client = new HttpClient();
        }

        public class MovieIdModel
        {
            [JsonPropertyName("imdb_id")]
            public string MovieId { get; set; }
        }

        public class ResultModel
        {
            [JsonPropertyName("results")]
            public List<MovieIdModel> Results { get; set; } = new List<MovieIdModel>();
        }
        public class ResultMovieModel
        {
            [JsonPropertyName("results")]
            public Movie Results { get; set; } = new Movie();
        }

        public async Task<List<Movie>> GetMovies(string search)
        {
            var requestIds = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://moviesminidatabase.p.rapidapi.com/movie/imdb_id/byTitle/{search}/"),
                Headers =
                {
              { "X-RapidAPI-Key", "2cdf14a81emshb4221322bfabc0ap110dccjsn16362add46d0" },
        { "X-RapidAPI-Host", "moviesminidatabase.p.rapidapi.com" },
                },
            };

            ResultModel result = new ResultModel();

            using (var response = await _client.SendAsync(requestIds))
            {
                if (response.IsSuccessStatusCode)
                {
                    var res = await response.Content.ReadAsStringAsync();
                    result = JsonSerializer.Deserialize<ResultModel>(res);
                }
            }

            List<Movie> movieList = new List<Movie>();  
            List<Task<Movie>> tasks = new List<Task<Movie>>();


            //foreach (var movieId in result.Results)
            //{
            //    movieList.Add(await GetMovieById(movieId.MovieId));
            //}

            foreach (var movieId in result.Results)
            {
                tasks.Add(GetMovieById(movieId.MovieId));
            }
            var taskRes = await Task.WhenAll(tasks);
            movieList.AddRange(taskRes);

            return movieList;
        }


        private async Task<Movie> GetMovieById(string movieId) 
        {
            HttpClient client = new HttpClient();

            var requestMovie = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://moviesminidatabase.p.rapidapi.com/movie/id/{movieId}"),
                Headers = {
                      { "X-RapidAPI-Key", "2cdf14a81emshb4221322bfabc0ap110dccjsn16362add46d0" },
        { "X-RapidAPI-Host", "moviesminidatabase.p.rapidapi.com" },
                    },
            };

            using (var response = await client.SendAsync(requestMovie))
            {
                if (response.IsSuccessStatusCode)
                {
                    var res = await response.Content.ReadAsStringAsync();
                    var resultMovie = JsonSerializer.Deserialize<ResultMovieModel>(res);
                    return resultMovie.Results;
                }
            }
            return null;
        }

    }



}
