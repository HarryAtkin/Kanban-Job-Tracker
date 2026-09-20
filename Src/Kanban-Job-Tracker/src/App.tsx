import LoginPage from './pages/login'
import './css/App.css'
import SignUpPage from './pages/sign-up';
import HomePage from './pages/homepage';
import { useState } from 'react';

function getPage() : string {
  var page = localStorage.getItem('page')?.toString()
  return page !== undefined ? page : 'homepage';
}

function App() {

    const [page, setPage] = useState<string>(() => {
      const token = localStorage.getItem('accessToken');
      if(token){
        const { exp } = JSON.parse(atob(token.split('.')[1]));
        return exp * 1000 > Date.now() ? getPage() : 'login';
      }
      return 'login';
    });

  return (
    <>
      {page === 'login' && <LoginPage setPage={setPage} />}
      {page === 'signup' && <SignUpPage setPage={setPage} />}
      {page === 'homepage' && <HomePage setPage={setPage} />}
    </>
  )
}

export default App
