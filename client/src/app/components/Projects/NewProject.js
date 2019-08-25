import React from 'react';
import project from '../../api/projects';
import GenericButton from '../Common/GenericButton';
import Message from '../Common/Message';

class NewProject extends React.PureComponent{
    
    constructor(props){
        super(props);
        this.state = {
            isNewPanelVisible : false,
            projectName: "",
            isValid : false,
            message : ""
        }
    }

    render(){
        return (
            <div className="col-auto mr-auto">
                <GenericButton 
                    onClick = { this.onAddClick }
                    text = { "Add project" } />
                <Message isValid = { this.state.isValid } message = { this.state.message }/>
                { this.newProjectEntryPanel() }
            </div>
        )
    }

    /**
     * returns the html elements to create the  project entry panel
     */
    newProjectEntryPanel = () => {
        if(this.state.isNewPanelVisible) {
            return(
                <React.Fragment> <br />
                <span>Project Name</span>
                <input type="text" value = { this.state.projectName } onChange = { this.onChange } />
                <GenericButton  
                    onClick = { this.onSaveClick } 
                    text = "Save"/>
                </React.Fragment>
            );
        }
    }

    /**
     * executes on add project button click, to show the new project entry panel
     */
    onAddClick = () => {
        this.setState({
            isNewPanelVisible: true
        });
    }

     /**
     * executes on save button click, initiate the insert api call and hides the panel.
     */
    onSaveClick = () => {
        // Validating the project name
        if(this.state.isValid){
            let data = {Name: this.state.projectName}
            // POST API call to insert project
            project.insert(data).then(response => {
                this.setState({
                    isNewPanelVisible: !response.data,
                    projectName : "",
                    isValid : response.data,
                    message: (response.data === true) ? "" : "Please enter a valid name"
                });
                //Callback to reload the project grid with new project data
                this.props.reloadProjectData();
            });  
        } else {
            // Setting valid state to false and the error message
            this.setState({
                isValid: false,
                message: "Please enter a valid name."
            })
        }
    }

    /**
     * on change handler or project name text box
     */
    onChange = (event) =>{
        let validEntry = (event.target.value !== "");
        this.setState({
            projectName : event.target.value,
            isValid: validEntry,
            message: (validEntry) ? " ": this.state.message
        });
    }
}

export default NewProject;