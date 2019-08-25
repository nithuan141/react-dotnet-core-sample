import React from 'react';

/**
 * Generic table component. You can pass hedear and body data as an array, 
 * this component will build the table structure from that arrays.
 */
class Table extends React.PureComponent {

	render() {
		
		let counter = 0;

		return (
			<table className="table">
				<thead className="thead-dark">
					<TableRow key = "table-header">
						{
							// Iterate the header data and generating header rows
							this.props.headerData.map((item) => {
								return <TableHeader 
											scope="col" 
											value = {item} 
											key = { "table-" + counter++ } />
							})
						}
					</TableRow>
				</thead>
				<tbody>
					{
						// Iterating the body data and genrating tr and tds
						this.props.bodyData.map((item) => {
							return <TableRow 
										id = {item[0]} 
										onClick = {this.rowClick}
										isSelected = {item[0] === this.props.selectedRowId}
										key = { "table-" + counter++ }>
									{
										item.map((data) => {
											return <TableData 
														value={data} 
														key = { "table-" + counter++ }/>
										})
									}
							</TableRow>
						})
					}
				</tbody>
			</table>
		);
	}

	/**
	 * The table row click handler
	 */
	rowClick = (id) => {
		this.props.onRowClick(id)
	}
}

// Table row stateless component , using memo to make it pure
const TableRow = React.memo(function(props) {
	let rowStyle = {};
	if(props.isSelected) {
		rowStyle= {backgroundColor: 'Yellow'}
	}

	//Onclick of a row
	const onRowClick = function() {
		if(props.onClick) { 
			props.onClick(props.id);
		}
	}

	return <tr onClick = {onRowClick}  style = {rowStyle}>{props.children}</tr>
});

//Table header stateless component
const TableHeader = React.memo(function(props) {
	return <th scope={props.scope}>{props.value}</th>
});

// Table data stateless component
const TableData = React.memo(function(props) {
	return <td>{props.value}</td>
});

export default Table;