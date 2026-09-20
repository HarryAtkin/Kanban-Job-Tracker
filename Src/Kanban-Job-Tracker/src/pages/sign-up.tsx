import { AlertTitle, Button, Grid, IconButton, InputAdornment, Modal, TextField, Typography } from '@mui/material';
import Card from '@mui/material/Card';
import Box from '@mui/material/Box';
import { useState } from 'react';
import { BorderAllOutlined, CenterFocusStrong, Visibility, VisibilityOff } from '@mui/icons-material';
import ArrowBackIcon from '@mui/icons-material/ArrowBack';
import { create } from '../features/Auth';
import { red } from '@mui/material/colors';
import ErrorModal from './components/errorModal';

interface SignUpPageProps {
    setPage: (page: 'login' | 'signup' | 'homepage') => void;
}

export default function SignUpPage ({setPage} : SignUpPageProps) {
    
    const [fName, setFName] = useState("");
    const [lName, setLName] = useState("");
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");

    const [type, setType] = useState('password');

    const [error, setError] = useState<boolean>(false);
    const [errorText, setErrorText] = useState("");
    

    return (
        <>

            <Card variant="elevation" sx={{ alignSelf: 'center', width: '50%', height: '80vh', marginTop: '8%', background: '#f9f9f9', alignItems: 'center'}}>
                <Box sx={{ p: 8, marginTop: '0%'}}>
                    <Grid container spacing={4}>
                        <IconButton
                            onClick={() => {
                                setPage('login')
                            } 
                        }
                            >
                            <ArrowBackIcon/>
                        </IconButton>

                        <Grid size={20} sx={{ boxSizing: 'border-box', marginLeft: '5%', marginRight: '5%' }}>
                            <AlertTitle>First Name</AlertTitle>
                            <TextField
                                required
                                id="outlined-required"
                                label="First Name"
                                onChange={(e) => setFName(e.target.value)}
                                sx={{width: '100%'}}
                            />
                        </Grid>

                        <Grid size={20} sx={{ boxSizing: 'border-box', marginLeft: '5%', marginRight: '5%' }}>
                            <AlertTitle>Last Name</AlertTitle>
                            <TextField
                                required
                                id="outlined-required"
                                label="Last Name"
                                onChange={(e) => setLName(e.target.value)}
                                sx={{width: '100%'}}
                            />
                        </Grid>

                        <Grid size={20} sx={{ boxSizing: 'border-box', marginLeft: '5%', marginRight: '5%' }}>
                            <AlertTitle>Email</AlertTitle>
                            <TextField
                                required
                                id="outlined-required"
                                label="Email"
                                onChange={(e) => setEmail(e.target.value)}
                                sx={{width: '100%'}}
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
                            <Button variant="contained" onClick={() => 
                                {
                                    create(fName, lName, email, password).then(() => {setPage('login')})
                                    .catch(err => {
                                        var errorText = err.toString().split('\n')[0];
                                        setError(true);
                                        setErrorText(errorText);
                                        console.log(errorText);
                                    });
                                }
                            } 
                            sx={{ margin: '2%', width: '50%' }}>
                                Create Account
                            </Button>
                        <ErrorModal
                            setError={setError}
                            isOpen={error}
                            errorText={errorText}
                        />
                        </Grid>
                    </Grid>
                </Box>
            </Card>
        </>
    );
}