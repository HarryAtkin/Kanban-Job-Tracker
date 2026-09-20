import { Auth, CreateAccount } from "./Client";
import { AccountLogin, AccountSignUp } from "./models/AccountInput";

export async function login(email: string, password: string) : Promise<number | undefined>
{
    if (!email.trim() || !password.trim()) {
    throw new Error("All fields required");
  }
    else{
        var account = new AccountLogin;
        account.Email = email.toLocaleLowerCase();
        account.Password = password;

        return await Auth(account);
    }
}

export async function create(fName: string, lName: string, email: string, password: string)
{
    if (!fName.trim() || !lName.trim() || !email.trim() || !password.trim()) {
    throw new Error("All fields required");
  }
    var account = new AccountSignUp(fName, lName, email.toLocaleLowerCase(), password);
    await CreateAccount(account);
}