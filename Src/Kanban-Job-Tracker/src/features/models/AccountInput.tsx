export class AccountLogin{
    Email: string ="";
    Password: string ="";
}

export class AccountSignUp{

    FName: string;
    LName: string;
    Email: string;
    Password: string;
    public constructor(fName: string, lName: string, email: string, password: string){
        this.FName = fName;
        this.LName = lName;
        this.Email = email;
        this.Password = password;
    }
}