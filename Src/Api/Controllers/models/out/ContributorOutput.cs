
public class ContributorOutput
{
    public int? Id { get; }
    public int BoardId { get; set; }
    public int AccountId { get; set; }
    public string PermissionType { get; set; } //Change to enum

    public ContributorOutput(int? id, int boardId, int accountId, string permissionType)
    {
        Id = id;
        BoardId = boardId;
        AccountId = accountId;
        PermissionType = permissionType;
    }
}