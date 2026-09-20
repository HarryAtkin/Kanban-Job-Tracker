import axios, { type AxiosInstance } from 'axios'
// import axios, { type AxiosInstance } from 'axios'
import { AccountInput } from './models/AccountInput';

function setupApi(){
    const Api = axios.create({
        baseURL: import.meta.env.VITE_BASE_URL,
        timeout: 10000,
        headers: {
            'Content-Type': 'application/json',
            'Accept': 'application/json',
        },
    });

    return Api
}

function setupAuth(Api: AxiosInstance){
    Api.interceptors.request.use(
        (config) => {
            const jwtToken = localStorage.getItem('accessToken'); 
                config.headers.Authorization = `Bearer ${jwtToken}`;
            return config;
            },
            (error) => {
                    console.error('Request Interceptor Error:', error);
                    return Promise.reject(error); 
                }
            );
            return Api
        }

export async function Auth(account: AccountInput, ): Promise<number> {
    var api = setupApi();
    api = setupAuth(api);

    const res = await api.post('/Auth/Authenticate', account);
    localStorage.setItem('accessToken', res.data.token);
    console.log(res.status)
    return await res.status
}

export async function CreateAccount(account: AccountInput){
    var api = setupApi();
    const res = await api.post('/Auth/Create', account);
    localStorage.setItem('accessToken', res.data.token);
    
}
                
                
                
                