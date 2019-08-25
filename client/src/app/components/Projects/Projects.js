import React from 'react';
import Table from '../Common/Table';
import TimeEntry from './TimeEntry';
import projectsApi from '../../api/projects';
import SearchBar from './SearchBar';
import NewProject from './NewProject';
import Invoice from './Invoice';
import work from '../../api/work';
import GenericButton from '../Common/GenericButton';
import sortHelper from '../../utility/sorting/sorthelper';

class Projects extends React.PureComponent {

	// Local variable to holds the project data which is fetching from the API
	projectData = [];
	headerData = ["#", "Project"];
	// Time spend by the selected project
	timeSpend = 0;
	// Invoice amount the selected project
	amount = 0;

	constructor(props){
		super(props);
		//Setting the initial state
		this.state={
			selectedProjectId: null,
			bodyData : [],
			isInvoiceDataVisible: false
		}
	}
	
	render() {
		return (
			<React.Fragment>
				<div className="row">
					<NewProject reloadProjectData = { this.loadProjectData }/>
					<SearchBar onSearch = { this.onSearch } />
					<GenericButton text = {"View Invoice"} onClick = {this.onViewInvoiceClick} />
				</div> <br />
				<TimeEntry 
					projectId = { this.state.selectedProjectId }
					reloadProjectData = { this.loadProjectData }/>
				{ this.invoiceElement() }
				<Table 
					headerData={ this.headerData }
					bodyData = { this.state.bodyData }
					onRowClick = { this.selectProject }
					selectedRowId = { this.state.selectedProjectId }/>
            </React.Fragment>
		);
	}

	componentDidMount(){
		// Fetching and loads the grid with data
		this.loadProjectData();
	}

	/**
	 * Initiate the get api call to get the project data and set the state
	 */
	loadProjectData = () => {
		// Fetching the projects data from API and re-render the component with data
		projectsApi.getAll().then(values => {
			this.projectData = values;
			this.onSearch("", false);
		});		
	}

	/**
	 * hanler to be executed on selecting a project in the grid
	 */
	selectProject = (id)=>{
		this.setState({
			selectedProjectId : id,
			isInvoiceDataVisible: false
		});
	}

	/**
	 * returns the filtered project data based on the search text
	 */
	onSearch = (searchText, isClearSelection = true) => {
		let filteredData  =  [];
		
		// filtering the project data based on the search text entered
		this.projectData.forEach(element => {
			if(searchText === "" || element.name.includes(searchText)) {
				filteredData.push([element.id, element.name]);
			}
		});
		// filteredData = sortHelper.sort(filteredData, 'projectAsc');
		// On Search resetting the data, the invoice panel visibility and the project selection
		this.setState({
			bodyData : filteredData,
			isInvoiceDataVisible : false,
			selectedProjectId: (isClearSelection) ? 0 : this.state.selectedProjectId
		});
	}

	/**
	 * The invoice componet to display the hours and amount
	 */
	invoiceElement(){
		if(this.state.isInvoiceDataVisible) {
			return <Invoice time = { this.timeSpend } amount = { this.amount } />
		}
	}

	/**
	 * Click handler for view invoice button
	 */
	onViewInvoiceClick = () => {
		if(this.state.selectedProjectId > 0) {
			// Fetching the invoice data from API and setting the local variable.
			work.getInvoice(this.state.selectedProjectId).then((response)=>{
				
				if(response) {
					this.timeSpend = response.timeSpend;
					this.amount = response.invoiceAmt;
				}
				
				// Set the state value to show invoice panel 
				this.setState({
					isInvoiceDataVisible: true
				});
			});
		}
	}
}

export default Projects;