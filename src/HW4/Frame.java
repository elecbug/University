package HW4;

import javax.swing.*;

import java.awt.*;
import java.awt.event.*;
import java.util.Random;

public class Frame extends JFrame 
{
    private JPanel panel;

    public Frame()
    {
        this.panel = new StartPanel(this);
        
        setTitle("두더지 잡기");
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setContentPane(this.panel);
        setSize(400, 700);
        setVisible(true);
    }

    public void gameStart()
    {
        this.panel = new GamePanel(this);
        setContentPane(this.panel);
    }

    public void viewLog()
    {

    }
}

class Mole extends JLabel
{
    private GamePanel panel;

    public Mole(GamePanel panel)
    {
        this.panel = panel;
        
        ImageIcon icon = new ImageIcon("src/HW4/mole.png");
        Image image = icon.getImage();
        Image newimg = image.getScaledInstance(100, 100,  java.awt.Image.SCALE_SMOOTH);
        icon = new ImageIcon(newimg);


        setLocation(new Point(0,0));
        setIcon(icon);
        setSize(100, 100);
        setVisible(true);
        setAlignmentY(TOP_ALIGNMENT);
        
        addMouseListener(new MouseAdapter() 
        {
            @Override
            public void mousePressed(MouseEvent e)
            {
                panel.increaseGrade();
                setVisible(false);   
            }
        });
    }
}

class GamePanel extends JPanel
{
    private Frame parent;
    private int grade;

    public void increaseGrade()
    {
        this.grade += 100;
    }

    public GamePanel(Frame parent)
    {
        this.parent = parent;
        setLayout(null);
        setSize(parent.getWidth(), parent.getHeight());

        JLabel background = new JLabel(new ImageIcon("src/HW4/fields.png"));
        background.setSize(parent.getWidth(), parent.getHeight());
        add(background);
        setVisible(true);

        add(new Mole(this));
    }
}

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
}
