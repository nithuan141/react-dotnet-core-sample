import React from 'react';
import ReactDOM from 'react-dom';
import TimeLoggerContainer from '../app/components/TimeLoggerContainer';

it('it verifies the timerlogger container component rendering with default container login', () => {
    const div = document.createElement('div');
    var dom = ReactDOM.render(<TimeLoggerContainer />, div);
    
    //The component should not be null
    expect(dom).not.toBeNull();

    //The defualt state value of container should be logi
    expect(dom.state.container).toBe('login');
});