import axios from 'axios'
// import axios, { type AxiosInstance } from 'axios'
import { AccountInput } from './models/AccountInput';

function setupApi(){
    //Put port and stuff into a VITE-xxxx.Env file
    const Api = axios.create({
        baseURL: "http://localhost:5253",
        timeout: 10000,
        headers: {
            'Content-Type': 'application/json',
            'Accept': 'application/json',
        },
    });

    return Api

}

// function setupAuth(Api: AxiosInstance){
//     Api.interceptors.request.use(
//             (config) => {
//                 const jwtToken = localStorage.getItem('accessToken'); 
//                   config.headers.Authorization = `Bearer ${jwtToken}`;
//                 return config;
//                 },
//                 (error) => {
//                         console.error('Request Interceptor Error:', error);
//                         return Promise.reject(error); 
//                     }
//                 );
            
//                 return Api
            
//             }
                
export async function Auth(account: AccountInput){
    //Put port and stuff into a VITE-xxxx.Env file
    var api = setupApi();

    const res = await api.post('/Auth/Authenticate', account);
    localStorage.setItem('accessToken', res.data.token);
    console.log(account)
    console.log(res)
}

export async function CreateAccount(account: AccountInput){
    //Put port and stuff into a VITE-xxxx.Env file
    var api = setupApi();

    const res = await api.post('/Auth/Create', account);
    localStorage.setItem('accessToken', res.data.token);
    
}
                
                
                
                