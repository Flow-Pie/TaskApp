using Microsoft.EntityFrameworkCore;
using TaskApp.Entities;
namespace TaskApp.Data;


//DbContext class are used to save instances of Entity classes
public class TaskStoreContext(DbContextOptions<TaskStoreContext> options ) : DbContext(options)
{
    public DbSet<Tasks> tasks => Set<Tasks>();
    public DbSet<User> users => Set<User>();
    public DbSet<TaskHistory> taskHistories => Set<TaskHistory>();
    public DbSet<Reminder> reminders => Set<Reminder>();
    public DbSet<Calendar> calendars => Set<Calendar>();

}