import { AlertTitle, Button, Grid, IconButton, InputAdornment, TextField } from '@mui/material';
import Card from '@mui/material/Card';
import Box from '@mui/material/Box';
import { useState } from 'react';
import { Visibility, VisibilityOff } from '@mui/icons-material';
import ArrowBackIcon from '@mui/icons-material/ArrowBack';
import LoginPage from './login';
import { create } from '../features/Auth';

export default function SignUpPage () {
    
    const [fName, setFName] = useState("");
    const [lName, setLName] = useState("");
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");

    const [type, setType] = useState('password');
    const [page, setPage] = useState<'login' | 'signup'>('signup');

    if (page === 'login') return <LoginPage />;

    return (
        <Card variant="elevation" sx={{ alignSelf: 'center', width: '50%', height: '80vh', marginTop: '8%', background: '#f9f9f9', alignItems: 'center'}}>
            <Box sx={{ p: 8 }}>
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
                        <Button variant="contained" onClick={() => create(fName, lName, email, password)} sx={{ margin: '2%', width: '50%' }}>
                            Create Account
                        </Button>
                    </Grid>
                </Grid>
            </Box>
        </Card>
    //     <ThemeProvider
    //   theme={{
    //     palette: {
    //       primary: {
    //         main: '#007FFF',
    //         dark: '#0066CC',
    //       },
    //     },
    //   }}
    // >
    //   <Box
    //     sx={{
    //       width: 100,
    //       height: 100,
    //       borderRadius: 1,
    //       bgcolor: 'primary.main',
    //     }}
    //   />
    // </ThemeProvider>

    );
}