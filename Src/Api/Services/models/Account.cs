public class Account
{
    public int? Id {get;}
    public string FName {get; set;}
    public string LName {get; set;}
    public string Email {get; set;}
    public string Password {get; set;}
    public DateTime? CreatedAt {get; set;}
    public bool IsAdmin { get; }
    public string Token { get; set;}

    public Account(int? id, string fName, string lName, string email, string password, bool isNew = false, bool isAdmin = false, string token = "")
    {
        Id = id;
        FName = fName;
        LName = lName;
        Email = email;
        Password = password;
        CreatedAt = isNew ? DateTime.UtcNow : null;
        IsAdmin = isAdmin;
        Token = token;
    }

    //public AccountEntity ToEntity => new AccountEntity(
    //    id: Id,
    //    fName: FName,
    //    lName: LName,
    //    email: Email,
    //    password: Password,
    //    createdAt: CreatedAt
    //    );
}