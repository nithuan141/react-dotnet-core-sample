import React from 'react';

/**
 * Staeless component for the search bar
 */
const SearchBar  = React.memo(function(props){
        return(
            <div className="col-auto">
                <form className="form-inline my-2 my-lg-0 float-right">
                    <input className="form-control mr-sm-2" type="search" placeholder="Search" aria-label="Search" 
                        onChange = {(event)=>{ props.onSearch(event.target.value); }} />         
                </form>
            </div>
        );
});

export default SearchBar;