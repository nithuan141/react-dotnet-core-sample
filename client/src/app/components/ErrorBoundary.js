import React from 'react';
import logger from '../api/logger';

class ErrorBoundary extends React.Component {

    constructor(props) {
        super(props);
        this.state = { 
            error: null, 
            errorInfo: null 
        };

        logger.insert({message : "Error message"});
    }
    
    /**
     * Lifecycle event - triggers if any error occures in the component tree
     * @param {*} error 
     * @param {*} errorInfo 
     */
    componentDidCatch(error, errorInfo) {
        if(errorInfo){
            //Initiating the API call to log the error
            logger.insert({message : errorInfo.toString()});
        }
        // Re-render the component with error details
        this.setState({
            error: error,
            errorInfo: errorInfo
        })
        
    }
    
    render() {
        if (this.state.errorInfo) {
            // Hanled message and error stack
            return (
                <div>
                    <h2>Something went wrong. Please try relaoding the App.</h2>
                    <h3>Please contact the administrator if it persist.</h3>
                    <details style={{ whiteSpace: 'pre-wrap' }}>
                    {this.state.error && this.state.error.toString()}
                    <br />
                    {this.state.errorInfo.componentStack}
                    </details>
                </div>
            );
        } 
        
        return this.props.children;
    }  
}
  
export default ErrorBoundary;