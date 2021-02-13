public abstract class Account {

    // attributes
    protected String accountType;
    protected double accountBalance;
    protected String accountInterest;

    // constructors
    public Account(String accountType, String accountInterest, double balance) {
        this.accountType = accountType;
        this.accountInterest = accountInterest;
        this.accountBalance = balance;
    }

    // method for checking if money is withdrawable
    public boolean isValidAmount(double withdrawalMoney) {
        return (withdrawalMoney % 20 == 0 || withdrawalMoney % 50 == 0 || withdrawalMoney % 100 == 0);
    }

    // method for checking if accountBalance is sufficient
    public boolean isOverBalance(double withdrawalMoney) {
        return withdrawalMoney > accountBalance;
    }

    // method for adjust account balance after withdrawing
    public void withdraw(double withdrawalMoney) {
        accountBalance -= withdrawalMoney;
    }

    // method for adjust account balance after depositing
    public void deposit(double depositedMoney) {
        accountBalance += depositedMoney;
    }

    // method for calculating interest
    public abstract void calculateInterest();

    // method for adding interest    
    public abstract void addInterest();
}