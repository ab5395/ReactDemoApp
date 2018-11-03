import 'bootstrap/dist/css/bootstrap.css';
import 'bootstrap/dist/css/bootstrap-theme.css';
import './index.css';
import React from 'react';
import ReactDOM from 'react-dom';
import { BrowserRouter } from 'react-router-dom';
import App from './App';
import { Route } from 'react-router';
import registerServiceWorker from './registerServiceWorker';
import { Login } from './components/Account/login';

const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href');
const rootElement = document.getElementById('root');

ReactDOM.render(
    <BrowserRouter basename={baseUrl}>
        <div>
            <App />
            <Route path='/login' component={Login} />
        </div>
    </BrowserRouter>, rootElement);

registerServiceWorker();
