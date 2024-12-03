package D1114;

import java.awt.*;
import javax.swing.*;

public class Frame06 extends JFrame
{
    public Frame06()
    {
        setTitle("Action 이벤트 리스너 예제");
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        Container c = getContentPane();
        c.setLayout(new FlowLayout());
        JButton btn = new JButton("Action");
        btn.addActionListener(new MyActionListener1()); // Action 리스너 달기
        c.add(btn);
        setSize(350, 150);
        setVisible(true);
    }
}
