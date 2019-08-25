class ProjectComparerAsc {

    compare(a, b){
        if(a > b){
            return 1;
        } else if ( a < b){
            return -1;
        }
        return 0;
    }
}

export default ProjectComparerAsc