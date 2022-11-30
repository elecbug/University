package D1128;

import javax.swing.*;

public class Frame02 extends JFrame 
{
    private JPanel panel;

    public Frame02()
    {
        this.panel = new JPanel();
        setTitle("Timer");
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setContentPane(this.panel);
        getContentPane().setLayout(null);
        setSize(400, 400);
        this.panel.setLocation(0, 0);
        this.panel.setSize(this.getSize());
        setVisible(true);

        TimerLabel timer = new TimerLabel(this.panel);
        Thread t = timer;
        t.start();
    }

} 
