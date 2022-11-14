package D1114;

import java.awt.*;
import javax.swing.*;

public class Frame02 extends JFrame 
{
    public Frame02()
    {
        setTitle("Ex02");
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        Container c = getContentPane();
        
        c.setLayout(new FlowLayout(FlowLayout.LEFT, 30, 40));
        c.add(new JButton("add"));
        c.add(new JButton("sub"));
        c.add(new JButton("mul"));
        c.add(new JButton("div"));
        c.add(new JButton("Calculate"));

        setSize(300, 200);
        setVisible(true);
    }
}
