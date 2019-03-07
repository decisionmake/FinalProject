using System.Data.Entity;

namespace FinalProject.DAL
{
    internal class MovieVotingHistoryDbIntializer : CreateDatabaseIfNotExists<MovieVotingHistoryDbContext>
    {

        protected override void Seed(MovieVotingHistoryDbContext context)
        {
            base.Seed(context);

            context.SaveChanges();
        }

    }
}
