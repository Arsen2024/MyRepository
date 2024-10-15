package task1;

import java.util.HashMap;
import java.util.Map;

public class RegistryStudent {
        Map<Integer, Student> studentMap;
        public RegistryStudent() {
            studentMap = new HashMap<>();
        }

    // Метод для додавання студента
    public void addStudent(Student student) {
        studentMap.put(student.getId(), student);
        System.out.println("Студент " + student.getName() + " доданий.");
    }

    // Метод для видалення студента за його ID
    public void removeStudent(Integer id) {
        Student removedStudent = studentMap.remove(id);
        if (removedStudent != null) {
            System.out.println("Студента " + removedStudent.getName() + " видалено.");
        } else {
            System.out.println("Студента з ID " + id + " не знайдено.");
        }
    }

    // Метод для пошуку студента за його ID
    public Student findStudent(Integer id) {
        return studentMap.get(id);
    }

    // Метод для відображення всіх студентів
    public void displayAllStudents() {
        if (studentMap.isEmpty()) {
            System.out.println("Реєстр студентів порожній.");
        } else {
            System.out.println("Список всіх студентів:");
            for (Student student : studentMap.values()) {
                System.out.println(student);
            }
        }
    }
}
