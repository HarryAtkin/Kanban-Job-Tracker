import { AlertTitle, Button, Grid, IconButton, InputAdornment, TextField } from '@mui/material';
import Card from '@mui/material/Card';
import Box from '@mui/material/Box';
import SignUpPage from './sign-up';
import { useState } from 'react';
import { VisibilityOff, Visibility } from '@mui/icons-material';

export default function LoginPage () {
    
    const [page, setPage] = useState<'login' | 'signup'>('login');
    const [password, setPassword] = useState("");
    const [type, setType] = useState('password');

    if (page === 'signup') return <SignUpPage />;

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
                        <Button variant="contained" href="#contained-buttons" sx={{ margin: '2%', width: '50%' }}>
                            Login
                        </Button>
                        <Button variant="contained" onClick={() => setPage('signup') } sx={{ margin: '2%', width: '50%' }}>
                            Sign-up
                        </Button>
                    </Grid>
                </Grid>
            </Box>
        </Card>
    );
}