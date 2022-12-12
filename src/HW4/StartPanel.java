package HW4;

import java.awt.FlowLayout;
import java.awt.GridLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

import javax.swing.ImageIcon;
import javax.swing.JButton;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.JTextField;

class StartPanel extends JPanel
{
    private Frame parent;
    private JTextField name;
    private JButton start;
    private JButton log;
    private ImageIcon image;

    public StartPanel(Frame parent)
    {
        this.parent = parent;

        setLayout(new FlowLayout());
        this.name = new JTextField();
        this.start = new JButton();
        this.log = new JButton();
        this.image = new ImageIcon("src/HW4/mole.png");

        JLabel label = new JLabel(this.image);
        label.setSize(this.getWidth(), this.getWidth());
        add(label);
        this.parent.pack();
        
        JPanel half = new JPanel();
        half.setSize(this.getWidth(), this.getHeight());
        add (half);
        half.setLayout(new GridLayout(3, 1));

        half.add(this.name);

        half.add(this.start);
        this.start.setText("Game start!");
        
        half.add(this.log);
        this.log.setText("View before games log.");

        this.start.addActionListener(new ActionListener()
        {
            @Override
            public void actionPerformed(ActionEvent e) 
            {
                parent.gameStart();   
            }   
        });

        this.log.addActionListener(new ActionListener()
        {
            @Override
            public void actionPerformed(ActionEvent e) 
            {
                parent.viewLog();  
            }   
        });
    }

    @Override
    public String getName()
    {
        return this.name.getText();
    }
}