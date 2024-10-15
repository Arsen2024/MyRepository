package task6;

import java.util.List;

public abstract class Shape {
    public abstract double getArea();

    public static double calculateTotalArea(List<? extends Shape> shapes) {
        double totalArea = 0;

        for (Shape shape : shapes) {
            totalArea += shape.getArea();
        }

        return totalArea;
    }
}
