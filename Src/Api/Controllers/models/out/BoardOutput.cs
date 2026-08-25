using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

public class BoardOutput
{
    public int Id { get; }

    public int OwnerId { get; }

    public string Title { get; set; }

    public DateTime CreatedAt { get; set; }

    public BoardOutput(int id, int ownerId, string title, DateTime createdAt)
    {
        Id = id;
        OwnerId = ownerId;
        Title = title;
        CreatedAt = createdAt;
    }
}