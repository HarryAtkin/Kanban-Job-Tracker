using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

[Table("account")]
[PrimaryKey(nameof(Id))]
public class AccountEntity
{
    [Column("id")]
    public int Id { get; }

    [Column("f_name")]
    public string FName { get; set; }

    [Column("l_name")]
    public string LName { get; set; }

    [Column("email")]
    public string Email { get; set; }

    [Column("user_password")]
    public string Password { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    public AccountEntity()
    {

    }

    public AccountEntity(int id, string fName, string lName, string email, string password, DateTime createdAt)
    {
        Id = id;
        FName = fName;
        LName = lName;
        Email = email;
        Password = password;
        CreatedAt = createdAt;
    }

    public Account ToAccount => new Account(
        id: Id,
        fName: FName,
        lName: LName,
        email: Email,
        password: Password
        );
}