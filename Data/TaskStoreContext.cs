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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlite("Data Source=TaskApp.db",
                options => options.MigrationsAssembly("TaskApp"));
        }
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TaskHistory>()
        .Property(t=>t.TaskStatus)
        .HasConversion<int>();//Enum stored as int

        modelBuilder.Entity<Tasks>().HasData(
            new Tasks 
             {   
                TaskId = -1,     
                UserId = -3,
                TaskTitle = "Task 1",
                TaskDescription = "Task 1 Description",
                TaskDate = new DateTime(2024-01-01),
                Status = true,
                TaskPriority = "High",
                dateCreated = new DateOnly(2023, 10, 1)
            }
        );
        modelBuilder.Entity<User>().HasData(
            new User
            {
                UserId = -3,
                Username = "John Doe",
                Password = "password123",
                Email = "johndoe@example.com",
                FirstName = "John",
                LastName = "Doe",
                Role = "Admin",
                DateRegistered = new DateTime(2023, 10, 1)
            }
        );
        modelBuilder.Entity<TaskHistory>().HasData(
            new TaskHistory
            {
                TaskHistoryId = 1,
                TasksId = -1,                
                TaskStatus = TaskHistory.Status.Pending,
                UpdatedAt = new DateTime(2024-2-1)        
            }
        );

        modelBuilder.Entity<Reminder>().HasData(
            new Reminder
            {
                ReminderId = -1,
                TasksId = -1,
                ReminderDate = new DateTime(2024-2-1),
                UpdatedAt = new DateTime(2024-2-1)
            }
        );

        modelBuilder.Entity<Calendar>().HasData(
            new Calendar
            {
                CalendarId = -1,
                TasksId = -1,               
                StartTime = "10:00 AM",
                EndTime = "11:00 AM",
                EventTitle = "Calendar 1 Event Title"
            }
        );

        
    }

}