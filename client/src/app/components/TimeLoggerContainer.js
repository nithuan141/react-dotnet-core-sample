import React from 'react';
import Projects from './Projects/Projects';
import Login from './Login/Login';

class TimeLoggerContainer extends React.Component {

    constructor () {
        super();
        // Setting the initial state ( initial contaner to be mounted is login)
        this.state = {
            container: 'login'
        };
    }

    /**
     * This is the render function of base container component , 
     * based on the container type state value this component will decide the corresponding child component
     */
	render() {
        switch(this.state.container){
            
            //Login container to load the login page
            case 'login':
                return (<Login containerChange = {this.containerChange}/>);

            //Project container to load the project page
            case 'project':
                return (<Projects containerChange = {this.containerChange}/>);

            // Default container is login page
            default:
                return (<Login containerChange = {this.containerChange}/>);
        }
    }

    /**
     * This will trigger state change and re-render on container change
     */
    containerChange = (type) =>{
        this.setState({
            container : type
        });
    }
}

export default TimeLoggerContainer;
		