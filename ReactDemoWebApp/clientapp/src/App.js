import React, { Component } from 'react';
import logo from './logo.svg';
import './App.css';
import AccountLayout from './Account/accountlayout';
import UserLayout from './User/userlayout';
import Login from './Account/login';
import UserHome from './User/userhome';
import { HashRouter as Router, Route, Switch } from 'react-router-dom';


class App extends Component {
  render() {
    return (
      <div>
        <Switch>
          {/* <Route exact path="/" layout={AccountLayout} component={AccountLayout} /> */}
          <Route path="/login" layout={AccountLayout} component={Login} />
          <Route path="/home" layout={UserLayout} component={UserHome}></Route>
        </Switch>
      </div>
    );
  }
}

export default App;
