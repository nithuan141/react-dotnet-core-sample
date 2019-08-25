import React from 'react';
import ReactDOM from 'react-dom';
import App from '../app/App';

it('verifies the app component rendering', () => {
  const div = document.createElement('div');
  var dom = ReactDOM.render(<App />, div);
  //The app componenont rendered dom should not be null
  expect(dom).not.toBeNull()
});