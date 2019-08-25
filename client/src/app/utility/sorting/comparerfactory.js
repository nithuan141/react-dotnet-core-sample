import comparerList from './comparerlist';
import projectComparerDesc from './projectcomparerdesc';
import projectComparerAsc from './projectcomparerasc'

class ComparerFactory {

    getComparer(type){
        switch(type){
            case comparerList.projectAsc:
                return new projectComparerAsc();
            case comparerList.projectDesc:
                return new projectComparerDesc();
            default:
                throw new Error('Comparer not found:' + type)
        }
    }

}
let comparerFactory = new ComparerFactory();
export default comparerFactory;