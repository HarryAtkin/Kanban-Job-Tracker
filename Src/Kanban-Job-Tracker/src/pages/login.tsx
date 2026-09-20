import { AlertTitle, Button, Grid, IconButton, InputAdornment, TextField } from '@mui/material';
import Card from '@mui/material/Card';
import Box from '@mui/material/Box';
import { useState } from 'react';
import { VisibilityOff, Visibility } from '@mui/icons-material';
import { login } from '../features/Auth';
import ErrorModal from './components/errorModal';

interface LoginPageProps {
    setPage: (page: 'login' | 'signup' | 'homepage') => void;
}

const fetchLogin = (email: string, password: string) => {
        return login(email, password);
}   

export default function LoginPage ({setPage}: LoginPageProps) {
    
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [type, setType] = useState('password');
    
    const [error, setError] = useState<boolean>(false);
    const [errorText, setErrorText] = useState("");
    
    return (
        <Card variant="elevation" sx={{ alignSelf: 'center', width: '50%', height: '80vh', marginTop: '8%', background: '#f9f9f9', alignItems: 'center'}}>
            <Box sx={{ p: 8, paddingTop: '20%' }}>
                <Grid container spacing={4}>
                    <Grid size={20} sx={{ boxSizing: 'border-box', marginLeft: '5%', marginRight: '5%' }}>
                        <AlertTitle>Email</AlertTitle>
                        <TextField
                            required
                            id="outlined-required"
                            label="Email"
                            sx={{width: '100%'}}
                            onChange={(e) => setEmail(e.target.value)}
                        />
                    </Grid>

                    <Grid size={20} sx={{ boxSizing: 'border-box', marginLeft: '5%', marginRight: '5%' }}>
                        <AlertTitle>Password</AlertTitle>
                        <TextField
                            id="outlined-adornment-password"
                            label="Password"
                            type={type}
                            name="password"
                            value={password}
                            onChange={(e) => setPassword(e.target.value)}
                            autoComplete="current-password"
                            sx={{width: '100%'}}
                            slotProps={{
                                input: {
                                    endAdornment: (
                                        <InputAdornment position='end'>
                                            <IconButton
                                                onClick={() => {
                                                    type === "password" ? setType('') : setType('password')
                                                    
                                                } }
                                                edge="end"
                                                >
                                                {type ? <VisibilityOff /> : <Visibility />}
                                            </IconButton>
                                        </InputAdornment>
                                    )
                                }
                            }
                        }
                        >
                            
                        </TextField>
                    </Grid>

                    <Grid size={20} sx={{ boxSizing: 'border-box', marginLeft: '5%', marginRight: '5%' }}>
                        <Button variant="contained" onClick={() => { 
                            fetchLogin(email, password)
                            .then(() => { setPage('homepage') })
                            .catch(err => {
                                        var errorText = err.toString();
                                        errorText = errorText.includes("401") ? "Incorrect Email or Password" : errorText.split('\n')[0]
                                        setError(true);
                                        setErrorText(errorText);
                                    });
                        }}
                            sx={{ margin: '2%', width: '50%' }}>
                            Login
                        </Button>
                        <Button variant="contained" onClick={() => { setPage('signup'); } } sx={{ margin: '2%', width: '50%' }}>
                            Sign-up
                        </Button>
                    </Grid>
                    <ErrorModal
                        setError={setError}
                        isOpen={error}
                        errorText={errorText}
                    />
                </Grid>
            </Box>
        </Card>
    );
}