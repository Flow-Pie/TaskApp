public class User {
    public int UserId { get; set; }
    public required string Username { get; set; }
    public required string Password  { get; set; }
    public required string Email { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Role { get; set; }
    public required DateTime DateRegistered { get; set; }
    
}