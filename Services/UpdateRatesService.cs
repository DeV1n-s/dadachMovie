using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using dadachMovie.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace dadachMovie.Services
{
    public class UpdateRatesService : IHostedService, IDisposable
    {
        private readonly IServiceProvider _serviceProvider;
        private Timer _timer;
        
        public UpdateRatesService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromDays(1));
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        private async void DoWork(object state)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                var moviesService = scope.ServiceProvider.GetRequiredService<IMoviesService>();
                var seriesService = scope.ServiceProvider.GetRequiredService<ISeriesService>();
                var movies = await dbContext.Movies.ToListAsync();
                var series = await dbContext.Series.ToListAsync();


                foreach (var movie in movies)
                {
                    await moviesService.SetMovieRatingsAsync(movie);
                }

                foreach (var serie in series)
                {
                    await seriesService.SetSerieRatingsAsync(serie);
                }

                await dbContext.SaveChangesAsync();
            }
        }
    }
}
