using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

[Table("contributors")]
[PrimaryKey(nameof(Id))]
public class ContributorEntity
{
    [Column("id")]
    public int Id { get; }

    [Column("board_id")]
    public int BoardId { get; set; }

    [Column("account_id")]
    public int AccountId { get; set; }

    [Column("permission_type")]
    public string PermissionType { get; set; } //Change to enum

    public ContributorEntity()
    {

    }

    public ContributorEntity(int id, int boardId, int accountId, string permissionType)
    {
        Id = id;
        BoardId = boardId;
        AccountId = accountId;
        PermissionType = permissionType;
    }

    public Contributor ToContributor => new Contributor(
        id: Id,
        boardId: BoardId,
        accountId: AccountId,
        permissionType: PermissionType
    );
}