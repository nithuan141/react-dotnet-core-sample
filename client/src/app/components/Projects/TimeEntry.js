import React  from 'react';
import timeSpend from '../../api/work';
import GenericButton from '../Common/GenericButton';
import Message from '../Common/Message';

class TimeEntry extends React.PureComponent{
    constructor(props){
        super(props);
        this.state={
            hoursSpend : "",
            message : "",
            isValid : true
        }
    }

    render(){

        return (
            <div>
                <span> Time Spend</span>
                <input type = "text" value = {this.state.hoursSpend} onChange = {this.onChange}/> 
                <span> (hours) </span> 
                <Message isValid = {this.state.isValid} message = { this.state.message } />
                <GenericButton 
                    onClick = { this.addSpendTime }
                    text = { "Add" }/>
            </div>
        );
    }

    /**
     * Trigger the save on button click
     */
    addSpendTime = () =>{
        let [valid, message] = this.validateTimeEntry();
        if(valid === true) {
            this.saveSPendTime();
        } else {
            // Showing the validation message
            this.setState({
                isValid: valid,
                message: message
            })
        }
    }

    /**
     * Inititaing the save API call and saves the spend time
     */
    saveSPendTime = () => {
        // Initiate the API Call to Add the project time spend
        let data = {UserId : 1, ProjectId: this.props.projectId, HoursSpend: this.state.hoursSpend};
        let that = this;
        timeSpend.add(data).then(response => {
            that.setState({
                message : (response.data === true) ? "Time spend added." : "Invalid data",
                isValid: response.data,
                hoursSpend : ""
            });
            // Callback to reload the  project data table
            that.props.reloadProjectData();
        }).catch(() => {
            that.setState({
                message : "An error occured! Try again.",
                hoursSpend : "",
                isValid: false
            });
        });
    }

    /**
     * Validating the time entry and setting proper message
     */
    validateTimeEntry = () => {
        let message = "";
        let isValid = true;
        
        // Validating the projct and time spend entires
        if(!this.props.projectId) {
            message = "Please select a project";
            isValid = false;
        } else if(this.state.hoursSpend === "" || this.state.hoursSpend <= 0 || this.state.hoursSpend > 24) {
            message = "Please enter a valid time"
            isValid = false;
        }

        return [isValid, message];
    }

    /**
     * Restricting the input on text entry to digit
     */
    onChange = (event) => {
        //regex to restrict the text entry to digits
        var reg = /^\d+$/;
        if(reg.test(event.target.value) === true || event.target.value === "") {     
            this.setState({
                hoursSpend:event.target.value
            });
        }
    }
}

export default TimeEntry;