package D1114;

import java.awt.*;
import javax.swing.*;

public class CalFrame extends JFrame 
{
    private JTextField field;
    private JButton[] buttons;
 
    public CalFrame()
    {
        this.field = new JTextField();
        this.buttons = 
        new JButton[] {
            new JButton("C"),
            new JButton("/"),
            new JButton("*"),
            new JButton("="),
            new JButton("7"),
            new JButton("8"),
            new JButton("9"),
            new JButton("+"),
            new JButton("4"),
            new JButton("5"),
            new JButton("6"),
            new JButton("-"),
            new JButton("1"),
            new JButton("2"),
            new JButton("3"),
            new JButton("0"),
        };

        setTitle("Calculator");
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setSize(300, 400);
        setVisible(true);

        Container c = getContentPane();
        c.setLocation(new Point(10,10));
        
        GridLayout grid1 = new GridLayout(2, 1, 10, 10);
        GridLayout grid2 = new GridLayout(4, 4, 10, 10);
        JPanel panel = new JPanel();

        c.setLayout(grid1);

        this.add(this.field);
        this.field.setBorder(BorderFactory.createEmptyBorder(10,10,10,10));
        this.add(panel);
        panel.setBorder(BorderFactory.createEmptyBorder(10,10,10,10));

        panel.setLayout(grid2);

        for (int i = 0; i < 16; i++)
        {
            panel.add(this.buttons[i]);
        }
    }
}
