
namespace LRPProject.Models;


public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Role { get; set; } 
    public string? StudentNumber { get; set; } 
}


public class Lab
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Location { get; set; } 
}


public class Computer
{
    public int Id { get; set; }
    public string Brand { get; set; } 
    public string CPU { get; set; } 
    public string RAM { get; set; } 
    public string AssetCode { get; set; } 

    
    public int LabId { get; set; } 
    public int? AssignedUserId { get; set; } 
}