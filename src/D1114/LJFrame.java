package D1114;

import javax.swing.*;
import java.awt.event.*;
import java.awt.*;

public class LJFrame extends JFrame 
{
    private JLabel la = new JLabel("사랑해"); 
    private String en = "Love Java", kr = "사랑해";

    public LJFrame() 
    {
        setTitle("Love Java");
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        Container c = getContentPane();
        c.setLayout(new FlowLayout());
        MyMouseListener listener = new MyMouseListener();
        la.addMouseListener(listener);
        la.addMouseMotionListener(listener); 
        c.add(la);
        setSize(300,200);
        setVisible(true);
    }
        
    class MyMouseListener implements MouseListener, MouseMotionListener 
    {
        public void mousePressed(MouseEvent e) {}
        public void mouseReleased(MouseEvent e) {}
        public void mouseClicked(MouseEvent e) {}
        public void mouseEntered(MouseEvent e)
        {
            la.setText(en);
        }
        public void mouseExited(MouseEvent e) 
        {
            la.setText(kr);
        }
        public void mouseDragged(MouseEvent e) {}
        public void mouseMoved(MouseEvent e) {}
    }
}