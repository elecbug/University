package HW4;

import java.awt.Image;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;
import java.util.Random;

import javax.swing.ImageIcon;
import javax.swing.JLabel;

class Mole extends JLabel implements Runnable
{
    private UserInfo _info;
    private int time;

    public Mole(GamePanel parent, UserInfo info, int time)
    {
        ImageIcon icon = new ImageIcon("src/HW4/mole.png");
        Image image = icon.getImage();
        Image newimg = image.getScaledInstance(100, 100,  java.awt.Image.SCALE_SMOOTH);
        icon = new ImageIcon(newimg);

        this._info = info;
        this.time = time;

        parent.add(this, 2, 0);
        setLocation(new Random().nextInt((int)parent.getWidth() -100), new Random().nextInt((int)parent.getHeight() - 100));
        setSize(100, 100);
        setIcon(icon);
        
        addMouseListener(new MouseAdapter() 
        {
            @Override
            public void mousePressed(MouseEvent e)
            {
                parent.setDate();
                _info.increaseGrade();
                setVisible(false);   
            }
        });
    }

    public void run()
    {
        try
        {    
            setVisible(true);
            Thread.sleep(this.time * 1000);
        }
        catch (Exception ex)
        {
            System.out.println(ex);
        }
        finally
        {
            setVisible(false);
        }
    }
}