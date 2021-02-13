public class User {
    
    // attributes
    private Account account;
    private SavingAccount savingAccount;
    private NetSaverAccount netSaverAccount;
    private FixedAccount fixedAccount;
    private ChequeAccount chequeAccount;
    private String password;
    private String id;

    // constructors
    public User() {
    }

    public User(String pw, String id, Account account) {
        this.password = pw;
        this.id = id;
        this.account = account;
    }

    User(String valueOf, String string) {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }

    // getters and setters
    public String getId() {
        return id;
    }

    public void setId(String id) {
        this.id = id;
    }

    public Account getAccount() {
        return account;
    }

    public void setAccount(Account account) {
        this.account = account;
    }

    public SavingAccount getSavingAccount() {
        return savingAccount;
    }

    public void setSavingAccount(SavingAccount savingAccount) {
        this.savingAccount = savingAccount;
    }

    public NetSaverAccount getNetSaverAccount() {
        return netSaverAccount;
    }

    public void setNetSaverAccount(NetSaverAccount netSaverAccount) {
        this.netSaverAccount = netSaverAccount;
    }

    public FixedAccount getFixedAccount() {
        return fixedAccount;
    }

    public void setFixedAccount(FixedAccount fixedAccount) {
        this.fixedAccount = fixedAccount;
    }

    public ChequeAccount getChequeAccount() {
        return chequeAccount;
    }

    public void setChequeAccount(ChequeAccount chequeAccount) {
        this.chequeAccount = chequeAccount;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }

    // method for checking if id and pw are matched
    public boolean matchedRecord(User u) {
        return (id.equals(u.id)&&password.equals(u.password));
    }
}
