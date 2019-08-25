import React from 'react';
import ReactDOM from 'react-dom';
import GenericButton from '../app/components/Common/GenericButton';
import Wrapper from '../app/components/Common/StatelessWrapper';

it('verifies the generic button component rendering', () => {
    const mockClick = jest.fn();
    const div = document.createElement('div');
    var dom = ReactDOM.render(<Wrapper><GenericButton text={'test button'} onClick={mockClick}/></Wrapper>, div);
    //The rendered dom should not be null
    expect(dom).not.toBeNull();
});

  