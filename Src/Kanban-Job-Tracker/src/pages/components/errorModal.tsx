import { Box, Modal, Typography } from "@mui/material";

interface ErrorModalProps {
    setError: (error: true | false) => void;
    isOpen: boolean;
    errorText: string;
}




export default function ErrorModal ({setError, isOpen, errorText}: ErrorModalProps) {
    const handleClose = () => setError(false);
    return(
        <Modal
            open={isOpen}
            onClose={handleClose}
            aria-labelledby="modal-modal-title"
            aria-describedby="modal-modal-description"
            >
            <Box sx={{
                position: 'absolute',
                top: '50%',
                left: '50%',
                transform: 'translate(-50%, -50%)',
                width: 400,
                bgcolor: 'background.paper',
                border: '2px solid #000',
                boxShadow: 24,
                p: 4,
            }}>
                <Typography id="modal-modal-title" variant="h6" component="h2" sx={{textAlign: 'center'}}>
                Error
                </Typography>
                <Typography id="modal-modal-description" sx={{ mt: 2 }}>
                {errorText}
                </Typography>
            </Box>
        </Modal>
    )
    
}