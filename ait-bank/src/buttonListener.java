import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

public class buttonListener implements ActionListener {

    // number on a button
    public char buttonValue;
    public UI ui;
    String buttonInput;

    public buttonListener(char buttonValue, UI ui) {
        this.buttonValue = buttonValue;
        this.ui = ui;
    }

    @Override
    public void actionPerformed(ActionEvent e) {
        buttonInput = String.valueOf(buttonValue);
        ui.updateUI(buttonInput);
    }
}
