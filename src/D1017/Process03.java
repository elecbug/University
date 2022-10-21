package D1017;

public class Process03 {
    public void run(){
        Shape donut = new Circle(10);
        donut.redraw();
        System.out.println("면적은 " + donut.getArea());
    }
}
