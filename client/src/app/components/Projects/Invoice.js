import React from 'react';

/**
 * Invoice stateless component - to show the amount and hours worked
 */
const Invoice = React.memo(function(props){
    return (
        <div style = {{border:1}}>
            <span>Total Hours Worked :</span><span>{props.time}</span><br></br>
            <span>Total Amount :</span><span>{props.amount}</span>
        </div>
    );
});

export default Invoice;