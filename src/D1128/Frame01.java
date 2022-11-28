package D1128;

import javax.swing.*;
import javax.swing.event.MouseInputAdapter;
import java.awt.*;
import java.awt.event.*;
import java.util.ArrayList;

public class Frame01 extends JFrame
{
    private MyPanel panel = new MyPanel();
    public Frame01() 
    {
        setTitle("drawLine 사용 예제");
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setContentPane(panel);
        setSize(400, 400);
        setVisible(true);
    }

    class MyPanel extends JPanel 
    {
        private ArrayList<Point> locatoins;

        public MyPanel()
        {
            this.locatoins = new ArrayList<>();

            addMouseListener(new MouseInputAdapter() {
                public void mousePressed(MouseEvent e)
                {
                    locatoins.add(e.getPoint());
                    draw();
                }
            });
        }
        public void draw()
        {
            panel.repaint();
            paintComponent(panel.getGraphics());
        }
        public void paintComponent(Graphics g) 
        {
            super.paintComponent(g);

            int[] xs = new int[locatoins.size()];
            int[] ys = new int[locatoins.size()];

            for (int i = 0; i < locatoins.size(); i++)
            {
                xs[i] = locatoins.get(i).x;
                ys[i] = locatoins.get(i).y;
            }

            g.setColor(Color.RED); // 빨간색 선택
            for (int i = 0; i < locatoins.size() - 1; i++)
            {
                g.drawString("(" + locatoins.get(i + 1).x + ", " + locatoins.get(i + 1).y + ")",
                    locatoins.get(i + 1).x, locatoins.get(i + 1).y);

                g.drawLine(locatoins.get(i).x, locatoins.get(i).y, 
                    locatoins.get(i + 1).x, locatoins.get(i + 1).y); // 선그리기
            }
        
            g.drawString("(" + locatoins.get(0).x + ", " + locatoins.get(0).y + ")",
            locatoins.get(0).x, locatoins.get(0).y);

            g.drawLine(locatoins.get(0).x, locatoins.get(0).y,
                locatoins.get(locatoins.size() - 1).x,  locatoins.get(locatoins.size() - 1).y);
        }
    }
    
}
