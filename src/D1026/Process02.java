package D1026;

import java.util.Calendar;
import java.util.Random;

public class Process02 
{
    public void run() throws InterruptedException
    {
        Calendar nowCalendar = Calendar.getInstance();

        while(true)
        {
            nowCalendar = Calendar.getInstance();

            
            if (nowCalendar.get(Calendar.MINUTE) == 0 && new Random().nextInt(100) > 50)
            {
                System.out.println(nowCalendar.get(Calendar.YEAR) +  "-" + nowCalendar.get(Calendar.MONTH) +  "-"+
                    nowCalendar.get(Calendar.DAY_OF_MONTH) +  " " + nowCalendar.get(Calendar.HOUR_OF_DAY) + "시 정각입니다!");
            }
            else 
            {
                System.out.println(nowCalendar.get(Calendar.YEAR) +  "-" + nowCalendar.get(Calendar.MONTH) +  "-"+
                    nowCalendar.get(Calendar.DAY_OF_MONTH) +  " " + nowCalendar.get(Calendar.HOUR_OF_DAY) + ":"+
                    nowCalendar.get(Calendar.MINUTE) +  ":"+ nowCalendar.get(Calendar.SECOND) +  ":"+ nowCalendar.get(Calendar.MILLISECOND));
            }
            
            Thread.sleep(10000);
        }
    }
}
