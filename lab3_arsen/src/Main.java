import task1.*;
import task2.*;
import task3.*;
import task5.*;
import task6.*;
import task8.*;

import java.util.*;
import static task6.Shape.calculateTotalArea;

public class Main {
    // task4
    public static <T extends Comparable<T>> T findMax(T[] array) {
        if (array == null || array.length == 0) {
            throw new IllegalArgumentException("Масив не може бути порожнім.");
        }

        T max = array[0];

        for (T element : array) {
            if (element.compareTo(max) > 0) {
                max = element;
            }
        }

        return max;
    }

    //task7
    // Метод, що приймає список з lower-bounded wildcard
    public static void addToList(List<? super Integer> list) {
        // Додаємо цілі числа від 1 до 10
        for (int i = 1; i <= 10; i++) {
            list.add(i);  // Додаємо цілі числа до списку
        }
    }

    public static void main(String[] args) {
        RegistryStudent registryStudent = new RegistryStudent();

        Student student1 = new Student(1, "Олена Іваненко", 18, "143-A");
        Student student2 = new Student(2, "Дмитро Петров", 20, "244-B");

        registryStudent.addStudent(student1);
        registryStudent.addStudent(student2);

        registryStudent.displayAllStudents();

        Student foundStudent = registryStudent.findStudent(2);
        System.out.println("Знайдено студента: " + foundStudent);

        registryStudent.removeStudent(2);

        registryStudent.displayAllStudents();

        // task2
        List<String> items = Arrays.asList("apple", "banana", "apple", "orange", "banana", "apple");

        // Отримання унікальних елементів
        Set<String> uniqueElements = ListOperation.transformToUnique(items);
        System.out.println("Унікальні елементи: " + uniqueElements);

        // Підрахунок кількості входжень
        Map<String, Integer> elementCounts = ListOperation.getElementCounts(items);
        System.out.println("Кількість входжень кожного елемента: " + elementCounts);

        // task3
        //Створюємо коробку для цілих чисел
        Box<Integer> integerBox = new Box<>();
        integerBox.put(10);
        System.out.println("Перевірка " + integerBox.isEmpty());

        // Створюємо коробку для рядків
        Box<String> stringBox = new Box<>();
        stringBox.put("Привіт, світ!");
        System.out.println("Перевірка " + stringBox.isEmpty());

        // Створюємо коробку для користувацького об'єкта
        Box<Student> studentBox = new Box<>();
        Student student = new Student(4, "Лариса Іваненко", 20, "240-A");
        studentBox.put(student);
        System.out.println("Перевірка " + studentBox.isEmpty());

        List<Box<?>> boxList = new ArrayList<>();
        boxList.add(integerBox);
        boxList.add(stringBox);
        boxList.add(studentBox);

        for (Box<?> element : boxList) {
            element.get();
        }

        boxList.removeFirst();

        //task4        // Масив цілих чисел
        Integer[] intArray = {3, 5, 7, 2, 8};
        System.out.println("Максимальний елемент у масиві Integer: " + findMax(intArray));

        // Масив дійсних чисел
        Double[] doubleArray = {3.5, 2.1, 9.6, 4.4, 8.0};
        System.out.println("Максимальний елемент у масиві Double: " + findMax(doubleArray));

        // Масив символів
        Character[] charArray = {'a', 'z', 'd', 'm'};
        System.out.println("Максимальний елемент у масиві Character: " + findMax(charArray));

        // Масив рядків
        String[] stringArray = {"apple", "orange", "banana", "pear"};
        System.out.println("Максимальний елемент у масиві String: " + findMax(stringArray));

     //task5   // Приклад використання Pair з Integer і String
        Pair<Integer, String> pair1 = new Pair<>(1, "Привіт");
        System.out.println("Перша пара: " + pair1);

        // Приклад використання Pair з String і List<Integer>
        List<Integer> numbers = Arrays.asList(1, 2, 3, 4);
        Pair<String, List<Integer>> pair2 = new Pair<>("Числа", numbers);
        System.out.println("Друга пара: " + pair2);

        // Порівняння двох пар
        Pair<Integer, String> pair3 = new Pair<>(1, "Привіт");
        boolean areEqual = pair1.equals(pair3);
        System.out.println("Чи однакові перша і третя пари? " + areEqual);

        //task6
        List<Shape> shapes = List.of(
                new Circle(3.0),
                new Rectangle(4.0, 5.0)
        );

        // Обчислюємо загальну площу всіх форм
        double totalArea = calculateTotalArea(shapes);
        System.out.println("Загальна площа всіх форм: " + totalArea);

        //task7
        // Список типу List<Integer>
        List<Integer> integerList = new ArrayList<>();
        addToList(integerList);
        System.out.println("Список Integer: " + integerList);

        // Список типу List<Number>
        List<Number> numberList = new ArrayList<>();
        addToList(numberList);
        System.out.println("Список Number: " + numberList);

        //task8
        Dog dog = new Dog();
        Cat cat = new Cat();
        Labrador labrador = new Labrador();

        List<Dog> dogList = List.of(dog, labrador);
        List<Animal> animalList = List.of(cat);

        AnimalShelter shelter = new AnimalShelter();

        shelter.addAnimals(dogList);
        shelter.addOtherAnimals(animalList);

        shelter.printAnimalSounds();
    }
}
