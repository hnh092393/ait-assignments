public class ATM {
    public static void main(String[] args) {

        // load data from database
        Database db = new Database();

        // create new thread for loading database
        Thread th = new Thread(db);
        th.start();

        // implement ui
        UI ui = new UI();
        Controller controller = new Controller(db.getUserDataList(), ui);
        ui.setupUI();
    }
}