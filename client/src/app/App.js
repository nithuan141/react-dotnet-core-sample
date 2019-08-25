import React from 'react';
import TimeLoggerCOntainer from './components/TimeLoggerContainer';
import './style.css';
import ErrorBoundary from './components/ErrorBoundary';

class App extends React.Component {
    render() {
        return (
            <React.Fragment>
                <header>
                    <nav className="navbar navbar-expand navbar-dark fixed-top bg-dark">
                        <div className="container">
                            <a className="navbar-brand" href="/">Timelogger</a>
                        </div>
                    </nav>
                </header>
                
                <main>
                    <div className="container">   
                    <ErrorBoundary>                 
                        <TimeLoggerCOntainer />
                    </ErrorBoundary>  
                    </div>
                </main>
            </React.Fragment>
        );
    }
}

export default App;
