public class ChequeAccount extends Account {
    
    // attributes
    static final String accountInterest = "None";

    // constructors
    public ChequeAccount(String accountType, String accoutInterest, double balance) {
        super(accountType, accoutInterest, balance);
    }

    // getters and setters
    public String getAccountType() {
        return accountType;
    }

    public double getBalance() {
        return accountBalance;
    }

    // method for calculating interest
    @Override
    public void calculateInterest() {
    }

    // method for adding interest    
    @Override
    public void addInterest() {
    }
}