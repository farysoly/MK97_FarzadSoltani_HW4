using System.ComponentModel.DataAnnotations;

namespace MK97_FarzadSoltani_HW4.Entities;

public class Users
{
    [Key] public int Id { get; set; }
    public string UserName { get; set; } 
    public string Mobile { get; set; }
    public DateTime BirthDate { get; set; }
    public DateTime InsertDate { get; set; } = DateTime.Now;
}