using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

public class BoardInput
{
    public int OwnerId { get; }

    public string Title { get; set; }

    public DateTime CreatedAt { get; set; }

    public BoardInput(int ownerId, string title, DateTime createdAt)
    {
        OwnerId = ownerId;
        Title = title;
        CreatedAt = createdAt;
    }
}