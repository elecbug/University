package D1114;

import javax.swing.*;
import java.awt.*;

public class Frame03 extends JFrame
{
    public Frame03()
    {
        setTitle("Ex03");
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);

        Container c = getContentPane();
        c.setLayout(new BorderLayout(30, 20));
        c.add(new JButton("Calculate"), BorderLayout.CENTER);
        c.add(new JButton("add"), BorderLayout.NORTH);
        c.add(new JButton("sub"), BorderLayout.SOUTH);
        c.add(new JButton("mul"), BorderLayout.EAST);
        c.add(new JButton("div"), BorderLayout.WEST);
        
        setSize(300, 200); 
        setVisible(true);
    }
}
