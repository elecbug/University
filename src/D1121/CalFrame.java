package D1121;


import java.awt.*;
import javax.swing.*;

import java.awt.event.*;

public class CalFrame extends JFrame 
{
    private enum Operator { NA, Add, Sub, Mul, Div}
    private JTextField field;
    private JButton[] buttons;

    private String op1, op2;
    private boolean selectOp2;
    private Operator op;
 
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
        for (int i = 0; i < this.buttons.length; i++)
        {
            this.buttons[i].addActionListener(new ButtonClick());
        }

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

        this.op1 = "";
        this.op2 = "";
        this.op = Operator.NA;
        this.selectOp2 = false;
    }

    class ButtonClick implements ActionListener
    {
        private int answer()
        {
            switch(op)
            {
                case Add: return Integer.parseInt(op1) + Integer.parseInt(op2);
                case Sub: return Integer.parseInt(op1) - Integer.parseInt(op2);
                case Mul: return Integer.parseInt(op1) * Integer.parseInt(op2);
                case Div: return Integer.parseInt(op1) / Integer.parseInt(op2);
                default: return 0;
            }
        }

        @Override
        public void actionPerformed(ActionEvent e) 
        {
            JButton b = (JButton)e.getSource();

            switch (b.getText())
            {
                case "+": 
                {
                    if (!selectOp2) 
                    {
                        selectOp2 = true;
                        op = Operator.Add;
                    }
                    else
                    {
                        field.setText(op1);
                        op2 = "";
                        op1 = "" + answer();
                        op = Operator.Add;
                    }
                } break;
                case "-": 
                {
                    if (!selectOp2) 
                    {
                        selectOp2 = true;
                        op = Operator.Sub;
                    }
                    else
                    {
                        field.setText(op1);
                        op2 = "";
                        op1 = "" + answer();
                        op = Operator.Sub;
                    }
                } break;
                case "*": 
                {
                    if (!selectOp2) 
                    {
                        selectOp2 = true;
                        op = Operator.Mul;
                    }
                    else
                    {
                        field.setText(op1);
                        op2 = "";
                        op1 = "" + answer();
                        op = Operator.Mul;
                    }
                } break;
                case "/": 
                {
                    if (!selectOp2) 
                    {
                        selectOp2 = true;
                        op = Operator.Div;
                    }
                    else
                    {
                        field.setText(op1);
                        op2 = "";
                        op1 = "" + answer();
                        op = Operator.Div;
                    }
                } break;
                case "C": 
                {
                    op1 = "";
                    op2 = "";
                    op = Operator.NA;
                } break;
                case "=": 
                {
                    if (selectOp2)
                    {
                        op1 = "" + answer();
                        field.setText(op1);
                    }
                } break;
                default: 
                {
                    int data = Integer.parseInt(b.getText());

                    if (selectOp2) 
                    {
                        op2 += data;
                        field.setText(op2);
                    }
                    else 
                    {
                        op1 += data;
                        field.setText(op1);
                    }
                } break;
            }
        }
    }
}
