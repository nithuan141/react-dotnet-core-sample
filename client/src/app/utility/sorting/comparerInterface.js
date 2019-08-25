/**
 * Interface for comparers. This intereface should be implemented in all comparer class across the sytem and define the comparer method.
 */
class ComparerInterface {

    /** Compare method. This should be defined in all comparers. */
    compare(a, b);
}

export default ComparerInterface;