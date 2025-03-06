import { useState } from "react";
import { TextField, Button, Box, Typography, Modal, Fade } from "@mui/material";
import { useNavigate, useLocation } from "react-router-dom";

const OtpForm = () => {
  const [otp, setOtp] = useState("");
  const [modalOpen, setModalOpen] = useState(false);
  const [modalMessage, setModalMessage] = useState("");
  const navigate = useNavigate();
  const location = useLocation();
  const { formData } = location.state;

  const handleOtpSubmit = async (e) => {
    e.preventDefault();
    try {
      const response = await fetch('http://localhost:8080/api/verify-otp', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify({ email: formData.customeremail, otp }),
      });

      if (!response.ok) {
        throw new Error('Network response was not ok');
      }

      const result = await response.json();
      console.log('OTP verification:', result);

      if (result.message === "OTP verified successfully") {
        navigate("/registration", { state: { formData, otpVerified: true } });
      } else {
        setModalMessage(result.message);
        setModalOpen(true);
      }
    } catch (error) {
      console.error('Error:', error);
      setModalMessage(`Error: ${error.message}`);
      setModalOpen(true);
    }
  };

  return (
    <Box sx={{ maxWidth: 600, mx: "auto", p: 3, bgcolor: "white", borderRadius: 2, boxShadow: 3, mt: 4 }}>
      <Typography variant="h5" sx={{ mb: 2, fontWeight: "bold" }}>OTP Verification</Typography>
      <form onSubmit={handleOtpSubmit}>
        <TextField
          fullWidth
          label="OTP"
          name="otp"
          value={otp}
          onChange={(e) => setOtp(e.target.value)}
          required
          sx={{ mt: 2 }}
        />
        <Button type="submit" variant="contained" color="primary" fullWidth sx={{ mt: 2 }}>Verify OTP</Button>
      </form>
      <Modal
        open={modalOpen}
        onClose={() => setModalOpen(false)}
        closeAfterTransition
        aria-labelledby="modal-modal-title"
        aria-describedby="modal-modal-description"
      >
        <Fade in={modalOpen}>
          <Box sx={{ position: 'absolute', top: '50%', left: '50%', transform: 'translate(-50%, -50%)', width: 300, bgcolor: 'background.paper', border: 'none', boxShadow: 24, p: 4, borderRadius: 2 }}>
            <Typography id="modal-modal-title" variant="h6" component="h2">
              {modalMessage}
            </Typography>
          </Box>
        </Fade>
      </Modal>
    </Box>
  );
};

export default OtpForm;
