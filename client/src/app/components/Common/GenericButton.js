import React from 'react'

/**
 * A generic component for buttons
 */
const GenericButton = React.memo(function(props){
    
    return(
        <button className = "btn btn-primary" type= "Submit" 
                onClick = {()=>{ if(props.onClick){
                    props.onClick(); 
                }}}> { props.text }</button>
    );
});

export default GenericButton;