using Core.Entities;

namespace Core.Data
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {
            var dreams = new List<Dream>
            {
                new Dream
                {
                    Title = "Dream 1",
                    Description = "I dreamed about a butterfly",
                    DreamMood = "Calm",
                    CreatedAt = DateTime.Now
                },
                new Dream
                {
                    Title = "Dream 2",
                    Description = "I dreamed about a Satan",
                    DreamMood = "Anxious",
                    CreatedAt = DateTime.Now
                }
            };

            await context.Dreams.AddRangeAsync(dreams);
            await context.SaveChangesAsync();
        }
    }
}