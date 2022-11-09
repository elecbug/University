package D1109_2;

import java.util.ArrayList;

public class Command 
{
    private ArrayList<String> parts;

    public Command(String fullString)
    {
        this.parts = new ArrayList<>();
        String[] split = fullString.split(" ");

        for (String part : split) 
        {
            this.parts.add(part);
        }
    }

    public String getCommandPart(int index)
    {
        return this.parts.get(index);
    }
}
