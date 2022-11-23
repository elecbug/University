package Friend;

import javax.swing.*;
import java.awt.event.*;
import java.awt.*;

public class CYJ
{
    public static void main(String[] args)
    {
        new MyFrame();
    }
}

class MyFrame extends JFrame {
	private static JLabel[] jl = new JLabel[26];
	private static int click_Cnt = 0;
	private static char alpha = 'A';
	
	static void setLabel(Container c) {
		for(int i=0; i<jl.length; i++) {
			jl[i] = new JLabel(Character.toString(alpha++));
			jl[i].setSize(30, 30);
			jl[i].setFont(new Font("Arial", Font.PLAIN, 30));
			jl[i].setForeground(Color.PINK);
			
			int x = (int)(Math.random()*300+20);
			int y = (int)(Math.random()*300+20);
			jl[i].setLocation(x, y);
			c.add(jl[i]);
		}
	}
	
	public MyFrame(){
		setTitle("A-Z Program");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		Container c = getContentPane();
		c.setLayout(null);
		
		setLabel(c);
		
		for(int i=0; i<jl.length; i++) {
			jl[i].addMouseListener(new MouseAdapter() {
				public void mousePressed(MouseEvent e) { // mouse를 누른 경우
					JLabel la = (JLabel)e.getSource();
                    la.setSize(0,0);
                    click_Cnt++;
                    if(click_Cnt==26) {
                        Frame f = new Frame("Parent");
                        f.setSize(500,500);
                        
                        final JDialog frame = new JDialog(f, "Information", true);
                        frame.setSize(140,90);
                        frame.setLocation(175, 180);
                        frame.setLayout(new FlowLayout());
                        
                        Label msg = new Label("Exit this program", Label.CENTER);
                        Button ok = new Button("OK");
                        
                        ok.addActionListener(new ActionListener() {
                            @Override
                            public void actionPerformed(ActionEvent arg0) {
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