interface HomePageProps {
    setPage: (page: 'login' | 'signup' | 'homepage') => void;
}


export default function HomePage ({setPage}: HomePageProps) {
    return(
        <p>Hello</p>
    )
    
}