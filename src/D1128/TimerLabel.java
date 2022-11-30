package D1128;

import java.util.Calendar;
import java.util.Random;

import javax.swing.JLabel;
import javax.swing.JPanel;

public class TimerLabel extends Thread
{
    private JPanel panel;
    private JLabel label;

    public TimerLabel(JPanel panel)
    {
        super();
        
        this.panel = panel;
        this.label = new JLabel();
        this.label.setVisible(true);
        this.label.setSize(300, 20);
        this.panel.add(this.label);
    }

    @Override
    public void run()
    {
        int run = 0;

        while (true)
        {
            try
            {
                if (run % 10 == 0)
                {
                    int x = new Random().nextInt(0, this.panel.getWidth());
                    int y = new Random().nextInt(0, this.panel.getHeight());
                    this.label.setLocation(x, y);
                    System.out.println("Set Location: (" + x + ", " + y + ")");
                }
                this.label.setText(Calendar.getInstance().get(Calendar.HOUR_OF_DAY) + ":" + Calendar.getInstance().get(Calendar.MINUTE) 
                    + ":" + Calendar.getInstance().get(Calendar.SECOND));
            
                System.out.println(run);    
                System.out.println("Get Location: (" + this.label.getX() + ", " + this.label.getY() + ")");
                run++;

                Thread.sleep(1000);
            }
            catch (Exception ex)
            {

            }
        }
    }
}