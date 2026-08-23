import { Auth, CreateAccount } from "./Client";
import { AccountInput } from "./models/AccountInput";

export function login(email: string | undefined, password: string | undefined)
{

    if(email == undefined || password == undefined){}
    else{
        var account = new AccountInput;
        account.Fname = 'empty'
        account.Lname = 'empty'
        account.Email = email;
        account.Password = password;

        console.log(account)

        Auth(account);
    }
}

export function create(fName: string, lName: string, email: string, password: string)
{
    var account = new AccountInput;
    account.Fname = fName
    account.Lname = lName
    account.Email = email;
    account.Password = password;

    console.log(account);
    CreateAccount(account);
}