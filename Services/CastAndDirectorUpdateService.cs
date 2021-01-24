// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading;
// using System.Threading.Tasks;
// using dadachMovie.Entities;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.Extensions.DependencyInjection;
// using Microsoft.Extensions.Hosting;

// namespace dadachMovie.Services
// {
//     public class CastAndDirectorUpdateService : IHostedService, IDisposable
//     {
//         private readonly IServiceProvider _serviceProvider;
//         private Timer _timer;

//         public CastAndDirectorUpdateService(IServiceProvider serviceProvider)
//         {
//             _serviceProvider = serviceProvider;
//         }
//         public void Dispose()
//         {
//             _timer?.Dispose();
//         }

//         public Task StartAsync(CancellationToken cancellationToken)
//         {
//             _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromHours(1));
//             return Task.CompletedTask;
//         }

//         private async void DoWork(object state)
//         {
//             using (var scope = _serviceProvider.CreateScope())
//             {
//                 var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
//                 var moviesCasts = await context.MoviesCasts.Select(p => p.PersonId).ToListAsync();
//                 var test = context.Movies.Select(x => x.Casts.Where(x => x.Person.Categories.Any(x => x.Id != 1)));
//                 var test2 = context.People.Select(x => x.Categories.Where(y => y.Id != 2).ToList());
//                 foreach (var item in test2)
//                 {
//                     item.Add(new Category{Id = 1});
//                 }

//                 foreach (var item in test)
//                 {
//                     item.Select(x => x.Person.Categories.Where(x => x.Id != 1).Append(new Category{Id = 1}));
//                 }
//                 var moviesDirectors = await context.Movies.Select(x => x.Directors.Select(y => y.Id)).ToListAsync();
//                 if (moviesCasts.Any())
//                 {
//                     foreach (var id in moviesCasts)
//                     {
//                         var person = await context.People.FirstOrDefaultAsync(p => p.Id == id);
//                         if (!person.Categories.Any(x => x.Id == 1))
//                         {
//                             person.Categories.Add(new Category{Id = 1});
//                         }
//                     }
//                 }

//                 if (moviesDirectors.Any())
//                 {
//                     foreach (var id in moviesDirectors)
//                     {
//                         var person = await context.People.FirstOrDefaultAsync(p => p.Id == id);
//                         person.IsDirector = true;
//                     }
//                     await context.SaveChangesAsync();
//                 }
//             }
//         }

//         public Task StopAsync(CancellationToken cancellationToken)
//         {
//             _timer?.Change(Timeout.Infinite, 0);
//             return Task.CompletedTask;
//         }
//     }
// }