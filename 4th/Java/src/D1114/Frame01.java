package D1114;

import java.awt.*;
import javax.swing.*;

public class Frame01 extends JFrame
{
    public Frame01()
    {
        setTitle("Ex01");

        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        Container contentPane = getContentPane();
        contentPane.setBackground(Color.ORANGE);
        contentPane.setLayout(new FlowLayout());
        contentPane.add(new JButton("OK"));
        contentPane.add(new JButton("Cancel"));
        contentPane.add(new JButton("Ignore"));

        setSize(300, 300);
        setVisible(true);
    }
}
