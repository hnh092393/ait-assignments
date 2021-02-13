public class NetSaverAccount extends Account {

    // attributes
    static final String accountInterest = "Monthly";
    private final double interestRate = 0.05;
    private final double dailyWithdrawalLimit = 500;
    private double interest;
    private boolean interestAdded = false;

    // constructors
    public NetSaverAccount(String accountType, String accoutInterest, double balance) {
        super(accountType, accoutInterest, balance);
    }

    // getters and setters
    public String getAccountType() {
        return accountType;
    }

    public double getBalance() {
        return accountBalance;
    }

    public double getInterestRate() {
        return interestRate;
    }

    public double getInterest() {
        return interest;
    }
    
    public void setInterestAdded(boolean interestAdded) {
        this.interestAdded = interestAdded;
    }
    
    public boolean isInterestAdded() {
        return interestAdded;
    }

    // method for checking if daily limit is reached
    public boolean isOverLimit(double withdrawalMoney) {
        return withdrawalMoney > dailyWithdrawalLimit;
    }

    // method for calculating interest
    @Override
    public void calculateInterest() {
        interest = accountBalance * interestRate;
    }

    // method for adding interest to account balance
    @Override
    public void addInterest() {
        accountBalance += interest;
    }
}