public class AccountInput
{
    public string FName {get; set;}
    public string LName {get; set;}
    public string Email {get; set;}
    public string Password {get; set;}
    public bool IsNew {get; set;}

    public AccountInput(string fName, string lName, string email, string password, bool isNew)
    {
        FName = fName;
        LName = lName;
        Email = email;
        Password = password;
        IsNew = isNew;
    }
}