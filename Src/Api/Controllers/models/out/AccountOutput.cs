public class AccountOutput
{
    public int Id {  get; set; }
    public string FName {get; set;}
    public string LName {get; set;}
    public string Email {get; set;}
    public string Password {get; set;}
    public DateTime? CreatedAt {get; set;}
    public string Token { get; set;}

    public AccountOutput(int id, string fName, string lName, string email, string password, DateTime? createdAt, string token)
    {
        Id = id;
        FName = fName;
        LName = lName;
        Email = email;
        Password = password;
        CreatedAt = createdAt;
        Token = token;
    }
}