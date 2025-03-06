import * as React from 'react';
import { Box, Container, Grid, Typography, IconButton, Link } from '@mui/material';
import FacebookIcon from '@mui/icons-material/Facebook';
import TwitterIcon from '@mui/icons-material/Twitter';
import InstagramIcon from '@mui/icons-material/Instagram';
import LinkedInIcon from '@mui/icons-material/LinkedIn';
import GitHubIcon from '@mui/icons-material/GitHub';
import './Footer.css'; // Import the CSS file

export default function Footer() {
    return (
        <Box className="footer-container">
            <Container maxWidth="lg">
                <Box className="content-box">
                    <Grid container spacing={4} justifyContent="space-between" alignItems="center">
                        {/* Footer Links */}
                        <Grid item xs={12} sm={6} md={3}>
                            <Typography variant="h6" className="footer-title">
                                About Us
                            </Typography>
                            <Link href="#" color="inherit" className="footer-link">
                                Our Story
                            </Link>
                            <Link href="#" color="inherit" className="footer-link">
                                Team
                            </Link>
                            <Link href="#" color="inherit" className="footer-link">
                                Careers
                            </Link>
                        </Grid>

                        {/* Social Media Links */}
                        <Grid item xs={12} sm={6} md={3}>
                            <Typography variant="h6" className="footer-title">
                                Follow Us
                            </Typography>
                            <Box className="social-icons">
                                <IconButton href="#" color="inherit">
                                    <FacebookIcon />
                                </IconButton>
                                <IconButton href="#" color="inherit">
                                    <TwitterIcon />
                                </IconButton>
                                <IconButton href="#" color="inherit">
                                    <InstagramIcon />
                                </IconButton>
                                <IconButton href="#" color="inherit">
                                    <LinkedInIcon />
                                </IconButton>
                                <IconButton href="#" color="inherit">
                                    <GitHubIcon />
                                </IconButton>
                            </Box>
                        </Grid>
                    </Grid>
                </Box>

                {/* Footer Bottom */}
                <Box mt={5} className="footer-bottom">
                    <Typography variant="body2" color="textSecondary" align="center">
                        {'© '}
                        <Link color="inherit" href="https://yourwebsite.com/">
                            Your Website
                        </Link>{' '}
                        {new Date().getFullYear()}
                        {'.'}
                    </Typography>
                </Box>
            </Container>
        </Box>
    );
}
