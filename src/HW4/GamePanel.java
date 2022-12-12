package HW4;

import java.awt.BorderLayout;
import java.awt.Container;
import java.awt.Dialog;
import java.awt.FlowLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.util.Calendar;
import java.util.Date;

import javax.swing.ImageIcon;
import javax.swing.JButton;
import javax.swing.JDialog;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.JTextArea;

class GamePanel extends JPanel implements Runnable
{
    private Date date;
    private Frame parent;
    private UserInfo info;
    private int time;

    public GamePanel(Frame parent, UserInfo info, int time)
    {
        this.parent = parent;
        this.info = info;
        this.time = time;
        
        JLabel background = new JLabel(new ImageIcon("src/HW4/fields.png"));
        background.setSize(parent.getWidth(), parent.getHeight());
        add(background, 0, 0);

        setLayout(null);
        setSize(parent.getWidth(), parent.getHeight());
        setVisible(true);
    }

    public synchronized void setDate()
    {
        this.date = Calendar.getInstance().getTime();
    }

    public void run()
    {
        this.date = Calendar.getInstance().getTime();
        try
        {
            for (int i = 3; i >= 0; i--)
            {
                Thread.sleep(1000);
            }
        }
        catch (Exception ex)
        {
            System.out.println(ex);
        }

        try
        {
            for (int i = 0; i < 10; i++)
            {
                if (Calendar.getInstance().getTime().getTime() - this.date.getTime() > 10000)
                {
                    info.addSum();
                    createModel("10 secs rate...", false);
                    return;
                }
                Mole mole = new Mole(this, this.info, this.time);
                new Thread(mole).start();
                Thread.sleep(2000);
            }
        }
        catch (Exception ex)
        {
            System.out.println(ex);
        }

        if (this.info.getGrade() < 500)
        {
            info.addSum();
            createModel("Game over...", false);
        }
        else
        {
            if (time - 2 > 0)
            {
                info.addSum();
                info.setGrade();
                parent.next(time - 2);
            }
            else
            {
                info.addSum();
                createModel("You win!", true);
            }
        }
    }

    private JDialog createModel(String string, boolean win) 
    {
        JDialog modelDialog = new JDialog(this.parent, string, 
            Dialog.ModalityType.DOCUMENT_MODAL);

        modelDialog.setBounds(132, 132, 300, 200);

        Container dialogContainer = modelDialog.getContentPane();
        dialogContainer.setLayout(new BorderLayout());
        JTextArea label = new JTextArea("Name: " + info.getName() + "\nGrade: " + info.getGrade() 
            + "\nSum of all grades: " + info.getSum());
        label.setEditable(false);

        dialogContainer.add(label);

        JPanel panel1 = new JPanel();
        panel1.setLayout(new FlowLayout());

        JButton okButton = new JButton("Exit");
        okButton.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                modelDialog.setVisible(false);
                parent.goMain();
            }
        });
        JButton reButton = new JButton("Restart");
        reButton.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                modelDialog.setVisible(false);
                parent.restart();
            }
        });

        panel1.add(okButton);
        panel1.add(reButton);
        dialogContainer.add(panel1, BorderLayout.SOUTH);
        
        modelDialog.setVisible(true);

        info.write(win);

        return modelDialog;
    }
}