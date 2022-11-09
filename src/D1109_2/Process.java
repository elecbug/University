package D1109_2;

import java.io.File;
import java.util.ArrayList;
import java.util.Scanner;

public class Process 
{
    private String nowDir;

    private final String DIR = "dir", CD = "cd", MKDIR = "mkdir", RMDIR = "rmdir", RENAME = "rename", EXIT = "exit";

    public Process()
    {
        this.nowDir = System.getProperty("user.dir");
    }

    public void run()
    {
        Scanner scanner = new Scanner(System.in);
        boolean roof = true;

        while (roof)
        {
            System.out.print(this.nowDir + ">>");
            Command command = new Command(scanner.nextLine());
            System.out.println();

            switch (command.getCommandPart(0))
            {
                case DIR:
                {
                    File[] directories = new File(this.nowDir).listFiles();

                    for (File file : directories)
                    {
                        System.out.println(file.toString());
                    }

                }
                break;
                case CD:
                {
                    File absolute = new File(command.getCommandPart(1));
                    File subDir = new File(this.nowDir + "\\" + command.getCommandPart(1));

                    if (absolute.toString().equals(".."))
                    {
                        this.nowDir = new File(this.nowDir).getParent();
                    }
                    else if (subDir.isDirectory())
                    {
                        this.nowDir = subDir.toString();
                    }
                    else if (absolute.isDirectory() && absolute.toString().contains(":"))
                    {
                        this.nowDir = absolute.toString();
                    }
                    else
                    {
                        System.out.println("Not found \"" + command.getCommandPart(1) + "\'");
                    }
                }
                break;
                case MKDIR:
                {
                    File file = new File(this.nowDir + "\\" + command.getCommandPart(1));

                    if (!file.mkdirs())
                    {
                        System.out.println("Not created directory");
                    }
                    else
                    {
                        System.out.println("Created \"" + file.toString() + "\"");
                    }
                }
                break;
                case RMDIR:
                {
                    File file = new File(this.nowDir + "\\" + command.getCommandPart(1));

                    ArrayList<File> files = new ArrayList<>();

                    if (!file.exists())
                    {
                        System.out.println("Not deleted directory");
                    }
                    else
                    {
                        reculsiveFile(files, file);

                        System.out.println("You want to delete " + files.size() + " files? y/n");

                        if (scanner.nextLine().equals("y"))
                        {
                            for (int i = files.size() - 1; i >= 0; i--)
                            {
                                files.get(i).delete();
                            }

                            System.out.println("Deleted \"" + file.toString() + "\"");
                        }
                    }
                }
                break;
                case RENAME:
                {
                    File file = new File(this.nowDir + "\\" + command.getCommandPart(1));

                    if (!file.renameTo(new File(this.nowDir + "\\" + command.getCommandPart(2))))
                    {
                        System.out.println("Not renamed");    
                    }
                    else
                    {
                        System.out.println("Renamed \"" + file.toString() + "\"");
                    }
                }
                break;
                case EXIT:
                {
                    roof = false;
                }
                break;
                default:
                {
                    System.out.println("Not defined command");
                }
            }
            System.out.println();
        }

        scanner.close();
    }

    private void reculsiveFile(ArrayList<File> files, File file)
    {
        files.add(file);
        
        if (file.listFiles() != null)
        {
            for (File subFile : file.listFiles())
            {
                reculsiveFile(files, subFile);
            }
        }
    }
}
