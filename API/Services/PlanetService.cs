using Serilog;

namespace API.Services;

public class PlanetService
{
    private static PlanetService? _instance;
    
    public static PlanetService Instance
    {
        get { return _instance ??= new PlanetService(); }
    }
    
    public PlanetResponse GetPlanet()
    {
        using (var activity = MonitoringService.ActivitySource.StartActivity())
        {

            var planets = new[]
            {
                "Mercury",
                "Venus",
                "Earth",
                "Mars",
                "Jupiter",
                "Saturn",
                "Uranus",
                "Neptune"
            };

            var index = new Random(DateTime.Now.Millisecond).Next(0, planets.Length);
            MonitoringService.Log.Debug($"Chose planet at index {index}");
            return new PlanetResponse
            {
                Planet = planets[index]
            };
        }
    }
}