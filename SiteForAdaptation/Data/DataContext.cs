using Microsoft.EntityFrameworkCore;
using SiteForAdaptation.Data.Entities;

namespace SiteForAdaptation.Data
{
    public class DataContext : DbContext
    {
        internal object userStatistics;

        public DataContext(DbContextOptions<DataContext> options)
            : base(options) { }

        public DbSet<Opening> Openings { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactItem> ContactItems { get; set; }
        public DbSet<MemoForManager> MemoForManagers { get; set; }
        //public DbSet<MemoForManagerItem> MemoForManagerItems { get; set; }
        //public DbSet<StoryItem> StoryItems { get; set; }
        public DbSet<StoryMap> StoryMaps { get; set; }
        public DbSet<UserTaskItem> UserTaskItems { get; set; }
        public DbSet<UserTaskParagraph> UserTaskParagraphs { get; set; }
        public DbSet<UserTask> UserTasks { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<UserTaskFile> UserTaskFiles { get; set; }
        public DbSet<UserTaskLink> UserTaskLinks { get; set; }
        public DbSet<UserStatistic> UserStatistics { get; set; }
        public DbSet<NavBar> NavBars { get; set; }
    }
}
