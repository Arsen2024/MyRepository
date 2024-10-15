package task3;

public class Box<T> {
    private T item;

    public void put(T item) {
        this.item = item;
        System.out.println("Предмет додано у коробку: " + item);
    }

    public T get() {
        if (item != null) {
            System.out.println("Предмети в коробці: " + item);
        } else {
            System.out.println("Коробка порожня.");
        }
        return item;
    }

    public boolean isEmpty() {
        return item == null;
    }
}

