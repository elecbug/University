package D1114;

import java.awt.*;
import java.awt.event.*;
import javax.swing.*;

public class Frame07 extends JFrame
{
    public Frame07()
    {
        setTitle("Action 이벤트 리스너 예제");
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        Container c = getContentPane();
        c.setLayout(new FlowLayout());
        JButton btn = new JButton("Action");
        btn.addActionListener(new MyActionListener2()); // Action 리스너 달기
        c.add(btn);
        setSize(350, 150);
        setVisible(true);
    }

    public class MyActionListener2 implements ActionListener
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
}
