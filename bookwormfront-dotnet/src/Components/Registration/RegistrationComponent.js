import { useState, useEffect } from "react";
import { TextField, Button, Box, Typography, Modal, Grid, Fade, Paper, Avatar, Link, Backdrop } from "@mui/material";
import LockOutlinedIcon from '@mui/icons-material/LockOutlined';
import { useNavigate, useLocation } from "react-router-dom";
import { toast, ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';


const RegistrationForm = ({ onClose, onLoginOpen, onSignupSuccess }) => {
  const [formData, setFormData] = useState({
    customeremail: "",
    customername: "",
    customerpassword: "",
    confirmPassword: "",
    dob: "",
    pan: "",
    phonenumber: "",
  });

  const [errors, setErrors] = useState({});
  const [modalOpen, setModalOpen] = useState(false);
  const [modalMessage, setModalMessage] = useState("");
  const [otpModalOpen, setOtpModalOpen] = useState(false);
  const [otp, setOtp] = useState("");
  const [otpMessage, setOtpMessage] = useState('');
  const navigate = useNavigate();
  const location = useLocation();
  const { otpVerified, formData: locationFormData } = location.state || {};

  useEffect(() => {
    if (locationFormData) {
      setFormData(locationFormData);
    }
    if (otpVerified) {
      handleFinalSubmit();
    }
  }, [otpVerified, locationFormData]);

  const validate = () => {
    let tempErrors = {};

    tempErrors.customeremail = formData.customeremail ? "" : "Email is required.";
    tempErrors.customeremail = /^[^@\s]+@[^@\s]+\.[^@\s]+$/.test(formData.customeremail) ? "" : "Email is not valid.";
    tempErrors.customername = formData.customername ? "" : "Name is required.";
    tempErrors.customerpassword = formData.customerpassword.length >= 6 ? "" : "Password must be at least 6 characters.";
    tempErrors.confirmPassword = formData.confirmPassword === formData.customerpassword ? "Password matched" : "Passwords do not match.";

    if (!formData.dob) {
      tempErrors.dob = "Date of Birth is required.";
    } else {
      const dobDate = new Date(formData.dob);
      const today = new Date();
      today.setHours(0, 0, 0, 0); // Reset time to compare only dates

      tempErrors.dob = dobDate < today ? "" : "Date of Birth cannot be in the future.";
    }

    tempErrors.pan = formData.pan ? "" : "PAN is required.";
    tempErrors.phonenumber = formData.phonenumber && /^[0-9]{10}$/.test(formData.phonenumber) ? "" : "Valid phone number is required.";

    setErrors(tempErrors);

    return Object.values(tempErrors).every(x => x === "" || x === "Password matched");
  };

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData({ ...formData, [name]: value });

    if (name === "confirmPassword" || name === "customerpassword") {
      setErrors({
        ...errors,
        confirmPassword: name === "confirmPassword" ? (value === formData.customerpassword ? "Password matched" : "Passwords do not match.") : (formData.confirmPassword === value ? "Password matched" : "Passwords do not match.")
      });
    }

    if (name === "customerpassword") {
      setErrors({
        ...errors,
        customerpassword: value.length >= 6 ? "" : "Password must be at least 6 characters."
      });
    }
  };

  const calculateAge = (dob) => {
    const birthDate = new Date(dob);
    const today = new Date();
    let age = today.getFullYear() - birthDate.getFullYear();
    const monthDifference = today.getMonth() - birthDate.getMonth();
    if (monthDifference < 0 || (monthDifference === 0 && today.getDate() < birthDate.getDate())) {
      age--;
    }
    return age;
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    if (validate()) {
      try {
         const response = await fetch('http://localhost:5160/api/otp/send-otp', {
           method: 'POST',
           headers: {
             'Content-Type': 'application/json',
           },
           body: JSON.stringify({ email: formData.customeremail }),
         });

         if (!response.ok) {
           throw new Error('Network response was not ok');
         }

         const result = await response.json();
         console.log('OTP sent:', result);
         setOtpMessage('OTP sent to your email. Please enter the OTP to complete registration.');
         setOtpModalOpen(true);
       } catch (error) {
         console.error('Error:', error);
         setModalMessage(`Error: ${error.message}`);
         setModalOpen(true);
       }
    }
  };

   const handleOtpSubmit = async (e) => {
     e.preventDefault();
     try {
       const response = await fetch('http://localhost:5160/api/otp/verify-otp', {
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
         setOtpMessage('OTP verified successfully. Registration complete.');
         setTimeout(() => {
           setOtpModalOpen(false);
           handleFinalSubmit();
         }, 2000);
       } else {
         setOtpMessage('Invalid OTP. Please try again.');
       }
     } catch (error) {
       console.error('Error:', error);
       setOtpMessage('OTP verification failed');
     }
   };
  const success = false;
  const handleFinalSubmit = async () => {
    const age = calculateAge(formData.dob);
    const { confirmPassword, ...dataToSend } = formData;
    dataToSend.age = age;

    try {
      const registerResponse = await fetch('http://localhost:5160/api/Customer/register', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(dataToSend),
      });
      const registerResult = await registerResponse.json();
      if (!registerResponse.ok) {
        throw new Error(registerResult.message);
      }

      console.log('Success:', registerResult);
      setModalMessage("User registered successfully");
      //success = true;
    // Close the modal after 2 seconds and navigate to '/'
    setTimeout(() => {
      setModalOpen(false);
      onSignupSuccess();
    }, 2000);

  } catch (error) {
    console.error('Error:', error);
    setModalMessage(`Error: ${error.message}`);
    setModalOpen(true);

    // Close the modal after 2 seconds (only for error messages)
    setTimeout(() => {
      setModalOpen(false);
    }, 2000);
  }
};

  return (
    <Box sx={{ width: 600, p: 2 }}>
    <ToastContainer />
      <Grid container component="main" sx={{ height: '100vh' }}>
        <Grid item xs={12} component={Paper} elevation={6} square>
          <Box
            sx={{
              my: 8,
              mx: 4,
              display: 'flex',
              flexDirection: 'column',
              alignItems: 'center',
            }}
          >
            <Avatar sx={{ m: 1, bgcolor: '#7d6df8' }}>
              <LockOutlinedIcon />
            </Avatar>
            <Typography component="h1" variant="h5" sx={{ color: '#7d6df8' }}>
              Registration Form
            </Typography>
            <Box component="form" noValidate onSubmit={handleSubmit} sx={{ mt: 1 }}>
              <Grid container spacing={2}>
                <Grid item xs={12} sm={6}>
                  <TextField
                    fullWidth
                    label="Email"
                    name="customeremail"
                    value={formData.customeremail}
                    onChange={handleChange}
                    error={!!errors.customeremail}
                    helperText={errors.customeremail}
                    required
                    sx={{ mb: 2 }}
                  />
                </Grid>
                <Grid item xs={12} sm={6}>
                  <TextField
                    fullWidth
                    label="Name"
                    name="customername"
                    value={formData.customername}
                    onChange={handleChange}
                    error={!!errors.customername}
                    helperText={errors.customername}
                    required
                    sx={{ mb: 2 }}
                  />
                </Grid>
                <Grid item xs={12} sm={6}>
                  <TextField
                    fullWidth
                    type="password"
                    label="Password"
                    name="customerpassword"
                    value={formData.customerpassword}
                    onChange={handleChange}
                    error={!!errors.customerpassword}
                    helperText={errors.customerpassword}
                    required
                    sx={{ mb: 2 }}
                  />
                </Grid>
                <Grid item xs={12} sm={6}>
                  <TextField
                    fullWidth
                    type="password"
                    label="Confirm Password"
                    name="confirmPassword"
                    value={formData.confirmPassword}
                    onChange={handleChange}
                    error={!!errors.confirmPassword && errors.confirmPassword !== "Password matched"}
                    helperText={errors.confirmPassword}
                    FormHelperTextProps={{ style: { color: errors.confirmPassword === "Password matched" ? 'green' : 'red' } }}
                    required
                    sx={{ mb: 2 }}
                  />
                </Grid>
                <Grid item xs={12} sm={6}>
                  <TextField
                    fullWidth
                    type="date"
                    name="dob"
                    value={formData.dob}
                    onChange={handleChange}
                    error={!!errors.dob}
                    helperText={errors.dob}
                    required
                    sx={{ mb: 2 }}
                    InputLabelProps={{ shrink: true }}
                  />
                </Grid>
                <Grid item xs={12} sm={6}>
                  <TextField
                    fullWidth
                    label="PAN"
                    name="pan"
                    value={formData.pan}
                    onChange={handleChange}
                    error={!!errors.pan}
                    helperText={errors.pan}
                    required
                    sx={{ mb: 2 }}
                  />
                </Grid>
                <Grid item xs={12} sm={6}>
                  <TextField
                    fullWidth
                    label="Phone Number"
                    name="phonenumber"
                    value={formData.phonenumber}
                    onChange={handleChange}
                    error={!!errors.phonenumber}
                    helperText={errors.phonenumber}
                    required
                    sx={{ mb: 2 }}
                  />
                </Grid>
              </Grid>
              <Button type="submit" variant="contained" color="primary" fullWidth sx={{ mt: 2, bgcolor: '#7d6df8' }}>Register</Button>
              <Grid container justifyContent="flex-end">
                <Grid item>
                  <Link href="#" variant="body2" sx={{ color: '#7d6df8' }} onClick={onLoginOpen}>
                    {"Already have an account? Sign In"}
                  </Link>
                </Grid>
              </Grid>
            </Box>
          </Box>
        </Grid>
      </Grid>
      { <Modal
        open={otpModalOpen}
        onClose={() => setOtpModalOpen(false)}
        closeAfterTransition
        BackdropComponent={Backdrop}
        BackdropProps={{
          timeout: 500,
        }}
        aria-labelledby="otp-modal-title"
        aria-describedby="otp-modal-description"
      >
        <Fade in={otpModalOpen}>
          <Box sx={{ position: 'absolute', top: '50%', left: '50%', transform: 'translate(-50%, -50%)', width: 300, bgcolor: 'background.paper', border: 'none', boxShadow: 24, p: 4, borderRadius: 2 }}>
            <Typography id="otp-modal-title" variant="h6" component="h2">
              OTP Verification
            </Typography>
            <Typography sx={{ mt: 2 }}>
              {otpMessage}
            </Typography>
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
          </Box>
        </Fade>
      </Modal> }

      <Modal
        open={modalOpen}
        onClose={() => setModalOpen(false)}
        closeAfterTransition
        BackdropComponent={Backdrop}
        BackdropProps={{
          timeout: 500,
        }}
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

export default RegistrationForm;
