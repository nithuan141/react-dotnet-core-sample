import React from 'react';
import GenericButton from '../Common/GenericButton'

class Login extends React.PureComponent{
    constructor(props){
        super(props);
        this.state ={
            userName: 'demo',
            password: 'Computer1'
        };
    }

    render(){
        return(
            <div>
                <span>User Name</span>
                <input type="text" value = { this.state.userName } onChange = { this.onUserNameChange } />
                <br/>
                <span>Password</span>
                <input type="password" value = { this.state.password } onChange = { this.onPasswordChange } />
                <br/>
                <GenericButton 
                    text= " Login " 
                    onClick={ this.loginClick } />
            </div>
        )
    }

    /**
     * Clic hander of login button
     */
    loginClick = () =>{
        this.props.containerChange('project');
    }

    /**
     * OnChange handler on typing the user name
     */
    onUserNameChange = (event) =>{
       // parseInt('a');
        this.setState({
            userName: event.target.value
        })
    }

    /**
     * OnChange handler for typing the password
     */
    onPasswordChange = (event) =>{
        this.setState({
            password: event.target.value
        })
    }
}

export default Login