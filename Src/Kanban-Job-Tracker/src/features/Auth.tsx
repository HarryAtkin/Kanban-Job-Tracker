import { Auth, CreateAccount } from "./Client";
import { AccountLogin, AccountSignUp } from "./models/AccountInput";

export async function login(email: string | undefined, password: string | undefined) : Promise<number | undefined>
{

    if(email == undefined || password == undefined){}
    else{
        var account = new AccountLogin;
        account.Email = email;
        account.Password = password;

        console.log(account)

        return await Auth(account);
    }
}

export async function create(fName: string, lName: string, email: string, password: string)
{
    if (!fName.trim() || !lName.trim() || !email.trim() || !password.trim()) {
    throw new Error("All fields required");
  }
    var account = new AccountSignUp(fName, lName, email, password);
    console.log(account);
    await CreateAccount(account);
}