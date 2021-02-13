//import java.sql.Connection;
//import java.sql.DriverManager;
//import java.sql.ResultSet;
//import java.sql.Statement;
import java.util.ArrayList;
import java.util.List;
import java.util.Random;

public class Database implements Runnable {

    private List<Account> bankAccountUser = new ArrayList<>();
    //List of user Infor: ban Account USer + account name and pass word
    private List<User> userDataList = new ArrayList<>();

    @Override
    public void run() {
        bankAccountUser.add(new SavingAccount("Savings Account", SavingAccount.accountInterest, 10000));
        bankAccountUser.add(new NetSaverAccount("Net Saver Account", NetSaverAccount.accountInterest, 10000));
        bankAccountUser.add(new FixedAccount("Fixed Account", FixedAccount.accountInterest, 10000));
        bankAccountUser.add(new ChequeAccount("Cheque Account", ChequeAccount.accountInterest, 10000));
        
        Random random = new Random();
        int i = random.nextInt(3);
        userDataList.add(new User("123", "roy", bankAccountUser.get(i)));

//        Connection conn = null;
//        Statement stm = null;
//        ResultSet result = null;
//        
//        
//        try {
//            // create connection
//            conn = DriverManager.getConnection("jdbc:derby://localhost:1527/MyATM", null, null);
//            
//            // create statement
//            stm = conn.createStatement();
//            
//            // select table
//            result = stm.executeQuery("SELECT * FROM USERS");
//
//            // retrieve row values
//            int i = 0;
//            while (result.next()) {
//                userDataList.add(new User(String.valueOf(result.getInt("pin")), result.getString("id"), bankAccountUser.get(i)));
//                if (i < 3)
//                    i++;
//                else
//                    i = 0;
//                System.out.println(result.getString("id") + " " + String.valueOf(result.getInt("pin")));
//            }
//        } catch (Exception e) {
//            e.printStackTrace();
//        }
    }

    public List<User> getUserDataList() {
        return userDataList;
    }
}   

