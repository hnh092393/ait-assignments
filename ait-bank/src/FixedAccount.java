public class FixedAccount extends Account {

    // attributes
    static final String accountInterest = "Period Time";
    private final double interestRate = 0.1;
    private double interest;
    private boolean earlyWithdrawal = false;

    // constructors
    public FixedAccount(String accountType, String accoutInterest, double balance) {
        super(accountType, accoutInterest, balance);
    }

    // getters and setters
    public String getAccountType() {
        return accountType;
    }

    public double getInterestRate() {
        return interestRate;
    }

    public double getInterest() {
        return interest;
    }

    public boolean isEarlyWithdrawal() {
        return earlyWithdrawal;
    }

    // method for calculating interest
    @Override
    public void calculateInterest() {
        if (!earlyWithdrawal)
            interest = accountBalance * interestRate;
        else
            interest = 0;
    }

    // method for adding interest
    @Override
    public void addInterest() {
        accountBalance += interest;
    }
}