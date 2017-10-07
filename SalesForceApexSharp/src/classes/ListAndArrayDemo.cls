public with sharing class ListAndArrayDemo {
    public List<String> StringList = new List<String> { 'one', 'two' };
    public Integer[] IntegerArray = new Integer[]{1, 2, 3};
    public Account[] AccountArray = new Account[] {new Account()};

    public void Method() {
        List<String> StringListLocal = new List<String> { 'one', 'two' };
        Integer[] IntegerArrayLocal = new Integer[]{1, 2, 3};
        Account[] AccountArrayLocal = new Account[] {new Account()};
    }
}