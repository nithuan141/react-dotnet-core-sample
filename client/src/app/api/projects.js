import axios from 'axios';
import config from '../../config';

const client = axios.create({ baseURL: config.BASE_URL });

/**
 * API call to fetch a specific project
 */
export function get(id) {
	return client.get(`/projects/${id}`).then(response => response.data);
}

/**
 * API call to fecth all the projects 
 * */
export function getAll() {
	return client.get('/projects').then(response => response.data);
}

/**
 *  API call to insert the project data
 * @param data  - The project data
 */
export function insert(data){
	return client.post('/projects', data).then(response => response).catch(error => error);
}

export default {
	get,
	getAll,
	insert
};
