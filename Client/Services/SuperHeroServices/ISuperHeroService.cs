namespace BlazorfullStack.Client.Services.SuperHeroServices
{
    public interface ISuperHeroService
    {
        List<SuperHero> Heroes { get; set; }
        List<Comic> Comics { get; set; }
        Task GetComics();
        Task GetSuperHeroes();
        Task<SuperHero> GetSingleHero(int id);
        Task<Comic> GetSingleComic(int id);
        //hero
        Task CreateHero(SuperHero hero);
        Task UpdateHero(SuperHero hero);
        Task DeleteHero(int id);
        // comic
        Task CreateComic(Comic comc);
        Task UpdateComic(Comic comc);
        Task DeleteComic(int id);

    }
}
