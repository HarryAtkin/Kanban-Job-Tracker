using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

public class Board
{
    public int? Id { get; }

    public int OwnerId { get; }

    public string Title { get; set; }

    public DateTime CreatedAt { get; set; }

    public Board()
    {

    }

    public Board(int? id, int ownerId, string title, DateTime createdAt)
    {
        Id = id;
        OwnerId = ownerId;
        Title = title;
        CreatedAt = createdAt;
    }
}