import React from 'react';
import ReactDOM from 'react-dom';
import Project from '../app/components/Projects/Projects';

const div = document.createElement('div');
var dom = ReactDOM.render(<Project />, div);

it('verifies the project component rendering', () => {
    //The component should not be null
    expect(dom).not.toBeNull();
});

it('verifies the invoice data panel is not visible', () => {
    // by default the isInvoiceDataVisible should be false
    expect(dom.state.isInvoiceDataVisible).toBe(false);
});