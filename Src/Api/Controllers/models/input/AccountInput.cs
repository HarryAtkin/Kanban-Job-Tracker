public class AccountInput
{
    public string FName {get; set;}
    public string LName {get; set;}
    public string Email {get; set;}
    public string Password {get; set;}
    public DateTime? CreatedAt {get; set;}

    public AccountInput(int id, string fName, string lName, string email, string password, bool isNew = false)
    {
        FName = fName;
        LName = lName;
        Email = email;
        Password = password;
        CreatedAt = isNew ? DateTime.UtcNow : null;
    }
}