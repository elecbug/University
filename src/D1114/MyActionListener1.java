package D1114;

import javax.swing.JButton;
import java.awt.event.*;

public class MyActionListener1 implements ActionListener
{
    public void actionPerformed(ActionEvent e) 
    {
        JButton b = (JButton)e.getSource();
        if(b.getText().equals("Action"))
            b.setText("액션");
        else
            b.setText("Action");
    }
}
