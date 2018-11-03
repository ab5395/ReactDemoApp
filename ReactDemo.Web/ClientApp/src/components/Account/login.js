import React, { Component } from 'react';

export class Login extends Component {
    constructor(props) {
        super(props);

    }


    render() {
        return (
            <div id="LoginForm">
                <div>
                    <h1>login Form</h1>
                    <div >
                        <div >
                            <div >
                                <h2>Admin Login</h2>
                                <p>Please enter your email and password</p>
                            </div>
                            <form id="Login">
                                <div>
                                    <input type="email" id="inputEmail" placeholder="Email Address" />
                                </div>
                                <div>
                                    <input type="password" id="inputPassword" placeholder="Password" />
                                </div>
                                <div >
                                    <a href="reset.html">Forgot password?</a>
                                </div>
                                <button type="submit" >Login</button>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        );
    }
}
