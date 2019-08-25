import React from 'react';
import ReactDOM from 'react-dom';
import Table from '../app/components/Common/Table';

it('verifies the generic button component rendering', () => {
    const mockClick = jest.fn();
    const div = document.createElement('div');
    var dom = ReactDOM.render(<Table 
                    headerData={ ['Test','Data'] }
					bodyData = { [[1, 'Test1'],[2, ['Test 2']]] }
					onRowClick = { mockClick }
					selectedRowId = { 1 }/>, div);
    // The rendered dom shpuld not be null
    expect(dom).not.toBeNull();
});

  