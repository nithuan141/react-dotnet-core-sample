import React from 'react';

/**
 * Stateless component for generic messages labels
 * @param {*} props 
 */
const Message = React.memo(function(props) {
    return (
        <span style = { { color: (props.isValid ? 'green' : 'red' )} }> { props.message } </span>
    );
});

export default Message;