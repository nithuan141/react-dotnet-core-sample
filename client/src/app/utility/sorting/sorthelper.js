import comparerFactory from './comparerfactory';

/**
 * Helper class for sorting of an array of any objects
 */
class SortHelper {
    /**
     * returns a sorted list of arrays based on the comparer.
     * @param listToSort - The array to be sorted
     * @param comparer - The name of the comparer, this should be same as the value in comparerList
     */
     static sort(listToSort, comparerName) {
         let comparerObject = comparerFactory.getComparer(comparerName);
 
         if (comparerObject) {
             return listToSort.sort(comparerObject.compare.bind(comparerObject));
         } else {
             /** Throwing an exception of comparer not found */
             throw Error('Comparer not found.');
         }
     }
 }
 
 export default SortHelper;
 