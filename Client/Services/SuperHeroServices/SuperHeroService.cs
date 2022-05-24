using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;

namespace BlazorfullStack.Client.Services.SuperHeroServices
{
    public class SuperHeroService : ISuperHeroService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManger;

        public SuperHeroService(HttpClient http, NavigationManager navigationManger)
        {
            _http = http;
            _navigationManger = navigationManger;
        }
        public List<SuperHero> Heroes { get ; set; } = new List<SuperHero>();
        public List<Comic> Comics { get; set; } = new List<Comic>();

        public async Task CreateHero(SuperHero hero)
        {
            var result = await _http.PostAsJsonAsync("api/superhero", hero);
            await SetHeroes(result);
        }

        private async Task SetHeroes(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<SuperHero>>();
            Heroes = response;
            _navigationManger.NavigateTo("superheroes");
        }

        public async Task DeleteHero(int id)
        {
            var result = await _http.DeleteAsync($"api/superhero/{id}");
            await SetHeroes(result);
        }

        private void NewMethod(List<SuperHero>? response)
        {
            Heroes = response;
        }

        public async Task GetComics()
        {
            var result = await _http.GetFromJsonAsync<List<Comic>>("api/comic");
            if (result != null)
                Comics = result;
        }

        public async Task<SuperHero> GetSingleHero(int id)
        {
            var result = await _http.GetFromJsonAsync<SuperHero>($"api/superhero/{id}");
            if (result != null)
                return result;
            throw new Exception("Hero not found!");
        }

        public async Task GetSuperHeroes()
        {
            var result = await _http.GetFromJsonAsync<List<SuperHero>>("api/superhero");
            if (result != null)
                Heroes = result;

        }

        public async Task UpdateHero(SuperHero hero)
        {
            var result = await _http.PutAsJsonAsync($"api/superhero/{hero.Id}", hero);
          /*  var response = await result.Content.ReadFromJsonAsync<List<SuperHero>>();*/
            await SetHeroes(result);
        }

        public async Task<Comic> GetSingleComic(int id)
        {
            var result = await _http.GetFromJsonAsync<Comic>($"api/comic/{id}");
            if (result != null)
                return result;
            throw new Exception("Comic not found!");
        }


        public async Task DeleteComic(int id)
        {
            var result = await _http.DeleteAsync($"api/comic/{id}");
            await SetComics(result);
        }

        public async Task CreateComic(Comic comc)
        {
            var result = await _http.PostAsJsonAsync("api/comic", comc);
            await SetComics(result);
        }

        private async Task SetComics(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<Comic>>();
            Comics = response;
            _navigationManger.NavigateTo("comices");
        }

        public async Task UpdateComic(Comic comc)
        {
            var result = await _http.PutAsJsonAsync($"api/comic/{comc.Id}", comc);
            /*  var response = await result.Content.ReadFromJsonAsync<List<SuperHero>>();*/
            await SetComics(result);
        }
    }
}
