import axios from 'axios';
import config from '../../config';

const client = axios.create({ baseURL: config.BASE_URL });

/**
 * POST Api to add the wor data (hours spend on a project)
 * @param {*} data 
 */
export function add(data) {
    return client.post('/work', data).then(response => response);
}

/**
 * Get API call to fetch the invoice data ( time spend and amount)
 * @param {*} projectId - Id of the project selected to fetch the invoice data. 
 */
export function getInvoice(projectId) {
    return client.get(`/invoice/${projectId}`).then(response => response.data);
}

export default {
    add,
    getInvoice
};
