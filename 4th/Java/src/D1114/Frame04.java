package D1114;

import javax.swing.*;
import java.awt.*;

public class Frame04 extends JFrame
{
    public Frame04()
    {
        setTitle("Ex04");
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        
        GridLayout grid = new GridLayout(4, 2);
        grid.setVgap(5);

        Container c = getContentPane();
        c.setLayout(grid);
        c.add(new JLabel(" 이름"));
        c.add(new JTextField(""));
        c.add(new JLabel(" 학번"));
        c.add(new JTextField(""));
        c.add(new JLabel(" 학과"));
        c.add(new JTextField(""));
        c.add(new JLabel(" 과목"));
        c.add(new JTextField(""));
        setSize(300, 200);
        setVisible(true);
    }
}
