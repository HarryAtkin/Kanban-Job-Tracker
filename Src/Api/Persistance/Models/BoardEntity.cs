using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

[Table("board")]
[PrimaryKey(nameof(Id))]
public class BoardEntity
{
    [Column("id")]
    public int Id { get; }

    [Column("owner_id")]
    public int OwnerId { get; set; }

    [Column("title")]
    public string Title { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    public BoardEntity()
    {

    }

    public BoardEntity(int id, int ownerId, string title, DateTime createdAt)
    {
        Id = id;
        OwnerId = ownerId;
        Title = title;
        CreatedAt = createdAt;
    }

    public Board ToBoard => new Board(
        id: Id,
        ownerId: OwnerId,
        title: Title,
        createdAt: CreatedAt
        );
}