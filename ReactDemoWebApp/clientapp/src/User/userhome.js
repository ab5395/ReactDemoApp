import React, { Component } from 'react';
import { BrowserRouter as Router, Route, Link } from "react-router-dom";

class UserHome extends Component {
    render() {
        return (
            <div>
                <h1>User Home</h1>
                <p>
                    <Link to={'/login'}>Login</Link>
                </p>

            </div>
        );
    }
}


export default UserHome;
