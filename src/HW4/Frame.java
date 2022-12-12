package HW4;

import java.awt.Container;
import java.awt.Dialog.ModalityType;
import java.io.BufferedReader;
import java.io.File;
import java.io.FileReader;
import java.io.IOException;
import java.awt.*;

import javax.swing.*;

public class Frame extends JFrame 
{
    private JPanel panel;
    private UserInfo info;

    public Frame()
    {
        this.panel = new StartPanel(this);

        setTitle("두더지 잡기");
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setContentPane(this.panel);
        setSize(400, 700);
        setVisible(true);
    }

    public void gameStart()
    {
        this.info = new UserInfo(((StartPanel)this.panel).getName());
        this.panel.setVisible(false);
        this.panel = new GamePanel(this, this.info, 5);
        setContentPane(this.panel);
        new Thread((GamePanel)this.panel).start();
    }

    public void restart()
    {
        this.info = new UserInfo(this.info.getName());
        this.panel.setVisible(false);
        this.panel = new GamePanel(this, this.info, 5);
        setContentPane(this.panel);
        new Thread((GamePanel)this.panel).start();
    }

    public void viewLog()
    {
        JDialog modelDialog = new JDialog(this, "View logs", ModalityType.DOCUMENT_MODAL);

        modelDialog.setBounds(132, 132, 300, 900);

        Container dialogContainer = modelDialog.getContentPane();
        dialogContainer.setLayout(new BorderLayout());

        File file = new File("src/HW4/log.txt");
        String str = "";  

        try
        {
            BufferedReader reader = new BufferedReader(new FileReader(file));

            String temp;
            while ((temp = reader.readLine()) != null) 
            {
                str += temp + "\r\n";
            }

            reader.close();  
        } 
        catch (IOException e) 
        {
            e.printStackTrace();
        }

        JTextArea label = new JTextArea(str);
        label.setEditable(false);
        label.setAutoscrolls(true);

        dialogContainer.add(label);

        JPanel panel1 = new JPanel();
        panel1.setLayout(new FlowLayout());

        modelDialog.setVisible(true);
    }

    public void goMain() 
    {
        this.panel.setVisible(false);
        this.panel = new StartPanel(this);

        setContentPane(this.panel);
        setSize(400, 700);
        setVisible(true);
    }

    public void next(int time)
    {
        this.panel.setVisible(false);
        this.panel = new GamePanel(this, this.info, time);
        setContentPane(this.panel);
        new Thread((GamePanel)this.panel).start();
    }
}
