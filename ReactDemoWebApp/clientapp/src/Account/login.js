import React from 'react';
import { BrowserRouter as Router, Route, Link } from "react-router-dom";

const Login = props => (
    <div>
        <h1>Login Page.</h1>
        <p>
            <Link to={'/Home'}>Home</Link>
        </p>
    </div>
)

export default Login;
