import { useState } from "react";
import { TextField, Button, Box, Typography, Modal, Fade, Paper, Avatar, Grid, Link, Backdrop } from "@mui/material";
import LockOutlinedIcon from '@mui/icons-material/LockOutlined';
import { useNavigate } from "react-router-dom";
import { toast, ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

const LoginComponent = ({ onClose, onSignupOpen, onLoginSuccess }) => {
  const [formData, setFormData] = useState({
    email: "",
    password: "",
  });

  const [errors, setErrors] = useState({});
  const [modalOpen, setModalOpen] = useState(false);
  const [modalMessage, setModalMessage] = useState("");
  const navigate = useNavigate();

  const validate = () => {
    let tempErrors = {};
    tempErrors.email = formData.email ? "" : "Email is required.";
    tempErrors.email = /^[^@\s]+@[^@\s]+\.[^@\s]+$/.test(formData.email) ? "" : "Email is not valid.";
    tempErrors.password = formData.password ? "" : "Password is required.";
    setErrors(tempErrors);
    return Object.values(tempErrors).every(x => x === "");
  };

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData({ ...formData, [name]: value });

    if (name === "password") {
      setErrors({
        ...errors,
        password: value ? "" : "Password is required."
      });
    }
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    if (validate()) {
      console.log("Form Data Submitted:", formData);
  
      try {
        // Encode email:password in Base64 for Basic Authentication
        const encodedCredentials = btoa(`${formData.email}:${formData.password}`);
  
        const response = await fetch("http://localhost:5160/api/Login", {
          method: "POST",
          headers: {
            "Authorization": `Basic ${encodedCredentials}`
          }
        });
  
        const result = await response.json();
  
        if (!response.ok) {
          console.log("Error:", result);
          toast.error(result.message);
          return;
        }
  
        console.log("Success:", result);
        toast.success(result.message);
  
        if (result.token) {
          sessionStorage.setItem("token", result.token);
          sessionStorage.setItem("isLoggedIn", "true");
          sessionStorage.setItem("customerEmail", formData.email);
  
          setTimeout(() => {
            onLoginSuccess();
          }, 2000);
        }
      } catch (error) {
        console.error("Error:", error);
        toast.error(`Error: ${error.message || "Network Error"}`);
      }
    }
  };
  
  

  return (
    <Box sx={{ width: 500, p: 2 }}>
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
              Sign in
            </Typography>
            <Box component="form" noValidate onSubmit={handleSubmit} sx={{ mt: 1 }}>
              <TextField
                margin="normal"
                required
                fullWidth
                id="email"
                label="Email Address"
                name="email"
                autoComplete="email"
                autoFocus
                value={formData.email}
                onChange={handleChange}
                error={!!errors.email}
                helperText={errors.email}
              />
              <TextField
                margin="normal"
                required
                fullWidth
                name="password"
                label="Password"
                type="password"
                id="password"
                autoComplete="current-password"
                value={formData.password}
                onChange={handleChange}
                error={!!errors.password}
                helperText={errors.password}
              />
              <Button
                type="submit"
                fullWidth
                variant="contained"
                sx={{ mt: 3, mb: 2, bgcolor: '#7d6df8' }}
              >
                Sign In
              </Button>
              <Grid container>
                <Grid item xs>
                  <Link href="#" variant="body2" sx={{ color: '#7d6df8' }}>
                    Forgot password?
                  </Link>
                </Grid>
                <Grid item>
                  <Link href="#" variant="body2" sx={{ color: '#7d6df8' }} onClick={onSignupOpen}>
                    {"Don't have an account? Sign Up"}
                  </Link>
                </Grid>
              </Grid>
            </Box>
          </Box>
        </Grid>
      </Grid>
    </Box>
  );
};

export default LoginComponent;
