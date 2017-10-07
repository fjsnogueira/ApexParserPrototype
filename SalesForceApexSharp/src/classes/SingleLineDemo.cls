public class SingleLineDemo {
    public void SingleLineIf() {
        Integer i = 5;
        if (i == 1) {
            System.debug('IfOne');
        }
        if (i == 1) {
            System.debug('IfOne');
        } else {
            System.debug('ElseOne');
            System.debug('ElseTwo');
        }
    }
}