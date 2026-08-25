
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

[Table("lane")]
[PrimaryKey(nameof(Id))]
public class LaneEntity
{
    [Column("id")]
    public int? Id { get; }

    [Column("title")]
    public string Title { get; set; }

    [Column("lane_description")]
    public string Description { get; set; }

    [Column("board_id")]
    public int BoardId { get; set; }

    [Column("lane_order")]
    public int LaneOrder { get; set; }

    public LaneEntity()
    {

    }

    public LaneEntity(int? id, string title, string description, int boardId, int laneOrder)
    {
        Id = id;
        Title = title;
        Description = description;
        BoardId = boardId;
        LaneOrder = laneOrder;
    }

    public Lane ToLane => new Lane(
        id: Id,
        title: Title,
        description: Description,
        boardId: BoardId,
        laneOrder: LaneOrder
    );
}