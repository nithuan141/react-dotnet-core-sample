import axios from 'axios';
import config from '../../config';

const client = axios.create({ baseURL: config.BASE_URL });

/**
 * POST Api to logg the client side side error details.
 * @param {*} data 
 */
export function insert(data) {
    return client.post('/logger', data).then(response => response);
}

export default {
  insert
};
