namespace MK97_FarzadSoltani_HW4.Entities;

public class Users
{
    public int UserId { get; set; }
    public string UserName { get; set; } 
    public string Mobile { get; set; }
    public DateTime BirthDate { get; set; }
    public DateTime InsertDate { get; set; } = DateTime.Now;
}