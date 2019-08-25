import React from 'react';

/**
 * A wrapper component to write the unit test of stateless components
 */
class Wrapper extends React.Component {
    render() { 
      return this.props.children
    }
}

export default Wrapper;