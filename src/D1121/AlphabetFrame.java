package D1121;

import javax.swing.*;
import java.awt.*;
import java.awt.event.*;

public class AlphabetFrame  extends JFrame 
{
	private JLabel[] labels = new JLabel[26];
	private int count = 0;
	private char alpha = 'A';
	
    private void setLabel(Container c) 
    {
		for(int i=0; i<labels.length; i++) 
        {
			labels[i] = new JLabel(Character.toString(alpha++));
			labels[i].setSize(30, 30);
			
			int x = (int)(Math.random()*300+20);
			int y = (int)(Math.random()*300+20);
			labels[i].setLocation(x, y);
			c.add(labels[i]);
		}
	}
	
	public AlphabetFrame()
    {
		setTitle("A-Z Program");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		Container c = getContentPane();
		c.setLayout(null);
		
		setLabel(c);
		
		for(int i=0; i<labels.length; i++) 
        {
			this.labels[i].addMouseListener(new MouseAdapter() 
            {
				public void mousePressed(MouseEvent e) 
                {
					JLabel la = (JLabel)e.getSource();
                    if (count + (int)'A' == (int)(la.getText().charAt(0)))
                    {
                        la.setSize(0,0);
                        count++;
                    }
                    if(count == 26) 
                    {
                        Frame f = new Frame("Parent");
                        f.setSize(500,500);
                        
                        final JDialog frame = new JDialog(f, "Information", true);
                        frame.setSize(140,90);
                        frame.setLocation(175, 180);
                        frame.setLayout(new FlowLayout());
                        
                        Label msg = new Label("Exit this program", Label.CENTER);
                        Button ok = new Button("OK");
                        
                        ok.addActionListener(new ActionListener() 
                        {
                            @Override
                            public void actionPerformed(ActionEvent arg0) 
                            {
                                System.exit(0);
                            }
                        });
                        frame.add(msg);
                        frame.add(ok);
                        f.setVisible(true);
                        frame.setVisible(true);
					}
				}
			});
		}
		
		setSize(500,500); // 프레임 크기
		setVisible(true); // 프레임 출력
		
		c.setFocusable(true);
		c.requestFocus();
	}
}
