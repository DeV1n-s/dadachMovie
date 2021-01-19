using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace dadachMovie.Services
{
    public class CastAndDirectorUpdateService : IHostedService, IDisposable
    {
        private readonly IServiceProvider _serviceProvider;
        private Timer _timer;

        public CastAndDirectorUpdateService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public void Dispose()
        {
            _timer?.Dispose();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromHours(1));
            return Task.CompletedTask;
        }

        private async void DoWork(object state)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                var moviesCasts = await context.MoviesCasts.Select(p => p.PersonId).ToListAsync();
                var moviesDirectors = await context.MoviesDirectors.Select(p => p.PersonId).ToListAsync();
                if (moviesCasts.Any())
                {
                    foreach (var id in moviesCasts)
                    {
                        var person = await context.People.FirstOrDefaultAsync(p => p.Id == id);
                        person.IsCast = true;
                    }
                }

                if (moviesDirectors.Any())
                {
                    foreach (var id in moviesDirectors)
                    {
                        var person = await context.People.FirstOrDefaultAsync(p => p.Id == id);
                        person.IsDirector = true;
                    }
                    await context.SaveChangesAsync();
                }
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }
    }
}