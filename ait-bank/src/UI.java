import javax.swing.*;
import javax.swing.border.Border;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.io.BufferedReader;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
import java.text.SimpleDateFormat;
import java.util.Date;

public class UI {

    // attributes
    static final String acc = "Account Name:";
    static final String pass = "Password:";
    static final String activity = "Choose an activity!";
    static final String withdraw = "Withdraw Money $";
    static final String deposit = "Deposite Money $";
    static final String setLimit = "Set Limit:";
    public JTextField textInput;
    public Button btn_setLimit = new Button("Set Limit");
    Border border = BorderFactory.createLineBorder(Color.WHITE, 1);
    private JFrame atmFrame;
    private JPanel coveringPan;
    private JPanel btnMidPan;
    private JPanel numberPan;
    private JPanel functionPan;
    private JPanel optionPan;
    private JPanel inputPan;
    private JPanel firstPan;
    private JTextField inputOrder;
    private JTextArea textUserInfor;
    private JTextField textName;
    private JTextField dateAndTime;
    private Button btn_number0;
    private Button btn_number1;
    private Button btn_number2;
    private Button btn_number3;
    private Button btn_number4;
    private Button btn_number5;
    private Button btn_number6;
    private Button btn_number7;
    private Button btn_number8;
    private Button btn_number9;
    private Button btn_dot;
    private Button btn_clear;
    private Button btn_help;
    private Button btn_cancel = new Button("Cancel");
    private Button btn_enter = new Button("Enter");
    private Button btn_withdraw = new Button("Withdraw");
    private Button btn_deposite = new Button("Deposit");
    private Color c = new Color(70, 77, 101);
    Border border2 = BorderFactory.createLineBorder(c, 1);
    private Color textColor = new Color(0, 255, 0);
    private String name = "";
    private StringBuilder sb = new StringBuilder();
    private String inputName;
    private String inputPass;

    public void setupUI() {
        
        // create main JFrame
        atmFrame = new JFrame("Henry's ATM");
        atmFrame.setSize(500, 620);
        atmFrame.setLocationRelativeTo(null);
        atmFrame.setResizable(false);

        setupButton();

        setupPanel();

        atmFrame.setVisible(true);
    }

    private void setupPanel() {
        
        // set box layout for frame
        atmFrame.getContentPane().setLayout(new BoxLayout(atmFrame.getContentPane(), BoxLayout.Y_AXIS));

        // show username
        textName = new JTextField();
        textName.setEnabled(false);
        textName.setBorder(border);
        textName.setDisabledTextColor(Color.WHITE);
        textName.setPreferredSize(new Dimension(310, 50));
        textName.setBackground(c);

        // show current date and time
        dateAndTime = new JTextField();
        dateAndTime.setEnabled(false);
        dateAndTime.setBorder(border);
        dateAndTime.setDisabledTextColor(Color.WHITE);
        dateAndTime.setPreferredSize(new Dimension(190, 50));
        dateAndTime.setBackground(c);

        // create panel for date and time
        firstPan = new JPanel();
        firstPan.setLayout(new BoxLayout(firstPan, BoxLayout.X_AXIS));
        firstPan.add(textName);
        firstPan.add(dateAndTime);

        // text area for messages to users
        textUserInfor = new JTextArea();
        textUserInfor.setEnabled(false);
        textUserInfor.setBackground(Color.WHITE);
        textUserInfor.setDisabledTextColor(Color.BLACK);
        textUserInfor.setFont(new Font("SansSerif", Font.PLAIN, 16));
        textUserInfor.setPreferredSize(new Dimension(500, 260));

        // user actions
        inputOrder = new JTextField();
        inputOrder.setEnabled(false);
        inputOrder.setPreferredSize(new Dimension(210, 60));
        inputOrder.setBorder(border2);
        inputOrder.setDisabledTextColor(Color.WHITE);
        inputOrder.setFont(new Font("SansSerif", Font.BOLD, 20));
        inputOrder.setBackground(c);

        // text input for users
        textInput = new JTextField();
        textInput.setEnabled(true);
        textInput.setBorder(border2);
        textInput.setFont(new Font("SansSerif", Font.PLAIN, 17));
        textInput.setPreferredSize(new Dimension(290, 60));
        textInput.setForeground(Color.WHITE);
        textInput.setBackground(c);
        textInput.requestFocusInWindow();

        // panel for holding user inputs and user actions
        inputPan = new JPanel();
        inputPan.setLayout(new BoxLayout(inputPan, BoxLayout.X_AXIS));
        inputPan.add(inputOrder);
        inputPan.add(textInput);

        // panel for holding input pad buttons
        numberPan = new JPanel(new GridLayout(4, 4));//5 rows, 3 columns
        numberPan.add(btn_number1);
        numberPan.add(btn_number2);
        numberPan.add(btn_number3);
        numberPan.add(btn_number4);
        numberPan.add(btn_number5);
        numberPan.add(btn_number6);
        numberPan.add(btn_number7);
        numberPan.add(btn_number8);
        numberPan.add(btn_number9);
        numberPan.add(btn_number0);
        numberPan.add(btn_dot);
        numberPan.add(btn_clear);

        // panel for holding atm function buttons
        functionPan = new JPanel(new GridLayout(4, 1));
        functionPan.add(btn_withdraw);
        functionPan.add(btn_deposite);
        functionPan.add(btn_setLimit);
        functionPan.add(btn_help);

        // panel for holding number pan and funtion pan
        btnMidPan = new JPanel(new GridLayout(1, 2));
        btnMidPan.setPreferredSize(new Dimension(500, 200));
        btnMidPan.add(numberPan);
        btnMidPan.add(functionPan);

        // panel that holds cancel button and enter button
        optionPan = new JPanel(new GridLayout(1, 2));
        optionPan.setPreferredSize(new Dimension(500, 50));
        optionPan.add(btn_cancel);
        optionPan.add(btn_enter);

        // main panel that holds all panels
        coveringPan = new JPanel();
        coveringPan.setLayout(new BoxLayout(coveringPan, BoxLayout.Y_AXIS));
        coveringPan.setPreferredSize(new Dimension(500, 350));
        coveringPan.add(firstPan);
        coveringPan.add(textUserInfor);
        coveringPan.add(inputPan);
        coveringPan.add(btnMidPan);
        coveringPan.add(optionPan);
        atmFrame.add(coveringPan, BorderLayout.CENTER);

        welcomeScreen();
    }

    // initialize first welcome screen
    public void welcomeScreen() {
        Date today = new Date();
        SimpleDateFormat formatDate = new SimpleDateFormat("EEE, hh:mm a, dd MMM yyyy");
        String date = formatDate.format(today);
        dateAndTime.setText("  " + date);
        textName.setText("Hello" + name);
        textUserInfor.setText("\n\n\n\n\n                                     Welcome to AITBank \n"
                + "                            Enter your account from keyboard");
        inputOrder.setText(acc);
    }

    private void setupButton() {
        
        // create and label number pad buttons
        btn_number0 = new Button("0");
        btn_number1 = new Button("1");
        btn_number2 = new Button("2");
        btn_number3 = new Button("3");
        btn_number4 = new Button("4");
        btn_number5 = new Button("5");
        btn_number6 = new Button("6");
        btn_number7 = new Button("7");
        btn_number8 = new Button("8");
        btn_number9 = new Button("9");
        btn_dot = new Button(".");
        btn_clear = new Button("CLEAR");
        btn_help = new Button("Help");
        btn_setLimit.setEnabled(false);

        btn_number0.addActionListener(new buttonListener('0', this));
        btn_number1.addActionListener(new buttonListener('1', this));
        btn_number2.addActionListener(new buttonListener('2', this));
        btn_number3.addActionListener(new buttonListener('3', this));
        btn_number4.addActionListener(new buttonListener('4', this));
        btn_number5.addActionListener(new buttonListener('5', this));
        btn_number6.addActionListener(new buttonListener('6', this));
        btn_number7.addActionListener(new buttonListener('7', this));
        btn_number8.addActionListener(new buttonListener('8', this));
        btn_number9.addActionListener(new buttonListener('9', this));
        btn_dot.addActionListener(new buttonListener('.', this));

        btn_clear.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                clearText();
            }
        });

        btn_help.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                
                // read userInstruction.txt and show in a text area
                String fileName = "userInstruction.txt";
                String line = null;
                StringBuffer sb = new StringBuffer();
                
                try {
                    FileReader fileReader = new FileReader(fileName);
                    BufferedReader bufferedReader = new BufferedReader(fileReader);
                    while ((line = bufferedReader.readLine()) != null) {
                        sb.append(line + "\n");
                    }
                    JOptionPane.showMessageDialog(null, sb.toString(), "GuideLine", JOptionPane.INFORMATION_MESSAGE);
                    bufferedReader.close();

                } catch (FileNotFoundException ex) {
                    System.out.println(
                            "Unable to open file '" +
                                    fileName + "'");
                } catch (IOException ex) {
                    System.out.println(
                            "Error reading file '"
                                    + fileName + "'");
                }
            }
        });
    }

    // action Listener methods for enter, widthdraw, deposit, and cancel buttons
    public void addEnterButtonListener(ActionListener EnterButtonListener) {
        btn_enter.addActionListener(EnterButtonListener);
    }

    public void addWithdrawButtonListener(ActionListener WithdrawButtonListener) {
        btn_withdraw.addActionListener(WithdrawButtonListener);
    }

    public void addDepositButtonListener(ActionListener DepositButtonListener) {
        btn_deposite.addActionListener(DepositButtonListener);
    }

    public void addCancelButtonListener(ActionListener CancelButtonListenter) {
        btn_cancel.addActionListener(CancelButtonListenter);
    }

    public void addSetLimitButtonListener(ActionListener SetLimitListener) {
        btn_setLimit.addActionListener(SetLimitListener);
    }

    // clear text in user input text field
    public void clearText() {
        textInput.setText("");
        sb.delete(0, sb.length());
    }

    // retrieve value form buttonListener
    void updateUI(String input) {
        sb.append(input);
        if (inputOrder.getText().equals(pass)) {
            String s = "";
            for (int i = 0; i < textInput.toString().length(); i++) {
                s = textInput.getText() + "*";
            }
            textInput.setText(s);
        } else
            textInput.setText(sb.toString());
    }

    // getters and setters
    public String getSBString() {
        return sb.toString();
    }

    public String getInputName() {
        return inputName;
    }

    public void setInputName(String inputName) {
        this.inputName = inputName;
    }

    public String getInputPass() {
        return inputPass;
    }

    public void setInputPass(String inputPass) {
        this.inputPass = inputPass;
    }

    public void setTextUserInfor(String textUserInfor) {
        this.textUserInfor.setText(textUserInfor);
    }

    public void setTextName(String textName) {
        this.textName.setText(textName);
    }

    public String getInputOrder() {
        return inputOrder.getText();
    }

    public void setInputOrder(String inputOrder) {
        this.inputOrder.setText(inputOrder);
    }

    public String getTextInput() {
        return textInput.getText();
    }

    public void setTextInput(String texInput) {
        this.textInput.setText(texInput);
    }
}