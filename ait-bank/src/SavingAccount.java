public class SavingAccount extends Account {
    
    // attributes
    static final String accountInterest = "Daily";
    private final double interestRate = 0.02;
    private double interest;
    private double dailyWithdrawalLimit = 1000;
    private boolean interestAdded = false;

    // constructors
    public SavingAccount(String accountType, String accoutInterest, double balance) {
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

    public void setInterest(double interest) {
        this.interest = interest;
    }

    public boolean isInterestAdded() {
        return interestAdded;
    }

    public void setInterestAdded(boolean interestAdded) {
        this.interestAdded = interestAdded;
    }

    public void setDailyWithdrawalLimit(double dailyWithdrawalLimit) {
        this.dailyWithdrawalLimit = dailyWithdrawalLimit;
    }

    // method for checking if daily limit is reached
    public boolean isOverLimit(double withdrawalMoney) {
        return withdrawalMoney > dailyWithdrawalLimit;
    }

    // method for customize withdrawal limit
    public void setWithdrawalLimit(double limit) {
        dailyWithdrawalLimit = limit;
    }

    // method for calculating interest
    @Override
    public void calculateInterest() {
        interest = accountBalance * interestRate;
    }
    
    // method for adding interest
    @Override
    public void addInterest() {
        accountBalance += interest;
    }
}
