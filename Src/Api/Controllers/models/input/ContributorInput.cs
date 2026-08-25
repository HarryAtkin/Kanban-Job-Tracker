
public class ContributorInput
{
    public int BoardId { get; set; }
    public int AccountId { get; set; }
    public string PermissionType { get; set; } //Change to enum

    public ContributorInput(int boardId, int accountId, string permissionType)
    {
        BoardId = boardId;
        AccountId = accountId;
        PermissionType = permissionType;
    }
}