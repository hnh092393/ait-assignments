import javax.swing.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.util.ArrayList;
import java.util.List;
import java.util.Timer;
import java.util.TimerTask;

public class Controller {
    
    // attributes
    private List<User> controllerUserDataList = new ArrayList<>();
    private UI controllerUI;
    private User controllerUser;
    private StringBuilder controllerUserData = new StringBuilder();
    private Account controllerAccount;
    private Double controllerMoneyAmount;

    // constructors
    public Controller(List<User> controllerUserDataList, UI controllerUI) {
        this.controllerUserDataList = controllerUserDataList;
        this.controllerUI = controllerUI;
        this.controllerUI.addEnterButtonListener(new EnterButtonListener());
        this.controllerUI.addWithdrawButtonListener(new WithdrawButtonListener());
        this.controllerUI.addDepositButtonListener(new DepositButtonListener());
        this.controllerUI.addCancelButtonListener(new CancelButtonListener());
        this.controllerUI.addSetLimitButtonListener(new SetLimitListener());
    }

    // method for checking if limit is over for saving and net saver accounts
    private boolean isOverLimit(Account account) {
        
        if (account instanceof SavingAccount) {
            if (((SavingAccount) account).isOverLimit(controllerMoneyAmount)) {
                return true;
            }
        }
        
        if (account instanceof NetSaverAccount) {
            if (((NetSaverAccount) account).isOverLimit(controllerMoneyAmount)) {
                return true;
            }
        }

        return false;
    }

    // method for withdawing money
    private void withdraw(Account account, double withdrawalAmount) {
        if (account.isOverBalance(withdrawalAmount)) {
            controllerUI.setTextUserInfor(controllerUserData.toString() +
                    "\n\n\n                                 Over Balance!");
            controllerUI.clearText();
        } else if (!account.isValidAmount(withdrawalAmount)) {
            controllerUI.setTextUserInfor(controllerUserData.toString() +
                    "\n\n\n                           Not Proper Money Note!\n"
                    + "                  We have $20, $50, $100 notes only");
            controllerUI.clearText();
            removeMessageTimer();

        } else if (isOverLimit(account)) {
            controllerUI.setTextUserInfor(controllerUserData.toString() +
                    "\n\n\n                           Over Limit Widrawal Money!");
            controllerUI.clearText();
            removeMessageTimer();
        } else {
            account.withdraw(withdrawalAmount);
            showUseData();
            controllerUI.setTextUserInfor(controllerUserData.toString() +
                    "\n\n\n                             Withdraw Successfully\n" +
                    "                         You have withdrawn $" + withdrawalAmount);
            removeMessageTimer();
        }
    }

    // method for depositing money
    private void deposit(Account acc, Double depositeMoney) {
        if (!acc.isValidAmount(depositeMoney)) {
            controllerUI.setTextUserInfor(controllerUserData.toString() +
                    "\n\n\n                           Not Proper Money Note!\n"
                    + "                  We accept $20, $50, $100 notes only");
            controllerUI.clearText();
            removeMessageTimer();
        } else {
            acc.deposit(depositeMoney);
            showUseData();
            controllerUI.setTextUserInfor(controllerUserData.toString() +
                    "\n\n\n                             Deposite Successfully!\n" +
                    "                         You have depositted $" + depositeMoney);
            removeMessageTimer();
        }
    }

    // display user information on message text area
    private void showUseData() {
        String accountType = controllerUser.getAccount().accountType;
        String accountName = controllerUser.getId();
        double balance = controllerUser.getAccount().accountBalance;
        String accountInterest = controllerUser.getAccount().accountInterest;
        controllerUserData = new StringBuilder();
        controllerUserData.append("\nAccount Name: " + accountName.toUpperCase() + "\n"
                + "Account Type: " + accountType + "\n"
                + "Account Interest: " + accountInterest + "\n"
                + "Curent Balance: " + String.valueOf(balance) + '\n');
        controllerUI.setTextUserInfor(controllerUserData.toString());
        controllerUI.setTextName("Current session user: " + accountName.toUpperCase());
        controllerUI.clearText();
        controllerUI.setInputOrder(controllerUI.activity);
    }

    // clear message text area after a certain amount of time
    public void removeMessageTimer() {
        Timer timer = new Timer();
        timer.schedule(new TimerTask() {
            @Override
            public void run() {
                controllerUI.setTextUserInfor(controllerUserData.toString() + "");
            }
        }, 1500);
    }

    // implement the Set Limit button
    class SetLimitListener implements ActionListener {

        @Override
        public void actionPerformed(ActionEvent e) {
            controllerUI.setInputOrder(controllerUI.setLimit);
        }
    }

    // implement the Withdraw Button
    class WithdrawButtonListener implements ActionListener {

        @Override
        public void actionPerformed(ActionEvent e) {
            if (controllerUI.getInputOrder().equals(controllerUI.activity)) {
                showUseData();
                controllerUI.setInputOrder(controllerUI.withdraw);
            } else if (controllerUI.getInputOrder().equals(controllerUI.withdraw)) {
                controllerAccount = controllerUser.getAccount();
                try {
                    controllerMoneyAmount = Double.parseDouble(controllerUI.getTextInput());
                    withdraw(controllerAccount, controllerMoneyAmount);
                } catch (NumberFormatException n) {
                    controllerUI.setTextUserInfor(controllerUserData.toString() +
                            "\n\n\n                              Enter Amount Money");
                }
            }
        }
    }

    // implement the Deposit button
    class DepositButtonListener implements ActionListener {

        @Override
        public void actionPerformed(ActionEvent e) {
            if (controllerUI.getInputOrder().equals(controllerUI.activity)) {
                showUseData();
                controllerUI.setInputOrder(controllerUI.deposit);
            } else if (controllerUI.getInputOrder().equals(controllerUI.deposit)) {
                controllerAccount = controllerUser.getAccount();
                try {
                    controllerMoneyAmount = Double.parseDouble(controllerUI.getTextInput());
                    deposit(controllerAccount, controllerMoneyAmount);
                } catch (NumberFormatException n) {
                    controllerUI.setTextUserInfor(controllerUserData.toString() +
                            "\n\n\n                              Enter Amount Money");
                }
            }
        }
    }

    // implement the Enter button
    class EnterButtonListener implements ActionListener {

        @Override
        public void actionPerformed(ActionEvent e) {

            if (controllerUI.getInputOrder().equals(controllerUI.acc)) {
                controllerUI.setInputName(controllerUI.getTextInput());
                controllerUI.clearText();
                controllerUI.setInputOrder(controllerUI.pass);
                controllerUI.textInput.setEditable(false);
                controllerUI.setTextUserInfor("\n\n\n\n\n\n                      Enter password from number button 0-9");
                System.out.println(controllerUI.getInputName());
            } else if (controllerUI.getInputOrder().equals(controllerUI.pass)) {
                controllerUI.setInputPass(controllerUI.getSBString());
                System.out.println(controllerUI.getTextInput());
                checkUser();
            } else if (controllerUI.getInputOrder().equals(controllerUI.activity)) {
                controllerUI.setTextUserInfor(controllerUserData.toString() +
                        "\n\n\n                                Choose an activity");
                controllerUI.clearText();

            } else if (controllerUI.getInputOrder().equals(controllerUI.withdraw)) {
                controllerAccount = controllerUser.getAccount();
                try {
                    controllerMoneyAmount = Double.parseDouble(controllerUI.getTextInput());
                    withdraw(controllerAccount, controllerMoneyAmount);
                } catch (NumberFormatException n) {
                    controllerUI.setTextUserInfor(controllerUserData.toString() +
                            "\n\n\n                              Enter Amount Money");
                }
            } else if (controllerUI.getInputOrder().equals(controllerUI.deposit)) {
                controllerAccount = controllerUser.getAccount();
                try {
                    controllerMoneyAmount = Double.parseDouble(controllerUI.getTextInput());
                    deposit(controllerAccount, controllerMoneyAmount);
                } catch (NumberFormatException n) {
                    controllerUI.setTextUserInfor(controllerUserData.toString() +
                            "\n\n\n                              Enter Amount Money");
                }
            } else if (controllerUI.getInputOrder().equals(controllerUI.setLimit)) {
                String newLimit = controllerUI.getTextInput();
                ((SavingAccount) controllerUser.getAccount()).setDailyWithdrawalLimit(Double.parseDouble(newLimit));
                controllerUI.setTextUserInfor(controllerUserData.toString() +
                        "\n\n\n                             Set Limit Successfully\n" +
                        "                     You have set Withdrawal Limit $" + newLimit);
                controllerUI.clearText();
                controllerUI.setInputOrder(controllerUI.activity);
                removeMessageTimer();
            }
        }

        //check valid user
        private void checkUser() {
            controllerUser = new User();
            controllerUser.setId(controllerUI.getInputName());
            controllerUser.setPassword(controllerUI.getInputPass());
            boolean isUserExist = false;
            for (User u : controllerUserDataList) {
                if (controllerUser.matchedRecord(u)) {
                    isUserExist = true;
                    controllerUser = u;
                }
            }
            if (isUserExist) {
                if (controllerUser.getAccount() instanceof SavingAccount) {
                    
                    // enable set limit button if account type is saving
                    controllerUI.btn_setLimit.setEnabled(true);
                }
                showUseData();
            } else {
                controllerUI.setTextUserInfor("\n\n\n\n\n\n                                  The account is invalid!");
                controllerUI.clearText();
                controllerUI.setInputOrder(controllerUI.acc);
                controllerUI.textInput.requestFocusInWindow();
                controllerUI.textInput.setEditable(true);
            }
        }

    }

    //implement the Cancel button
    class CancelButtonListener implements ActionListener {

        @Override
        public void actionPerformed(ActionEvent e) {
            if (controllerUI.getInputOrder().equals(controllerUI.withdraw) || controllerUI.getInputOrder().equals(controllerUI.deposit) || controllerUI.getInputOrder().equals(controllerUI.setLimit)) {
                controllerUI.clearText();
                showUseData();
                controllerUI.setInputOrder(controllerUI.activity);
                controllerUI.textInput.requestFocusInWindow();
            } else {
                int optionIndex;
                if (controllerUI.getInputOrder().equals(controllerUI.activity)) {
                    
                    // confirm log out action
                    String[] options = {"YES", "NO"};
                    
                    optionIndex = JOptionPane.showOptionDialog(null, "Do you want to log out", "Log out", JOptionPane.YES_NO_OPTION, JOptionPane.INFORMATION_MESSAGE, null, options, options[0]);
                } else
                    optionIndex = 0;

                if (optionIndex == 0) {
                    controllerUI.clearText();
                    controllerUI.welcomeScreen();
                    controllerUI.textInput.setEditable(true);
                    controllerUI.btn_setLimit.setEnabled(false);
                    controllerUI.textInput.requestFocusInWindow();
                }

            }
        }
    }
}