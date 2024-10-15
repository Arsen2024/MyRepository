package task1;

import java.util.Objects;

public class Student {
    private Integer id;
    private String name;
    private int age;
    private String group;

    public Student(Integer id, String name, int age, String group) {
        this.id = id;
        this.name = name;
        this.age = age;
        this.group = group;
    }

    public Integer getId() {
        return id;
    }

    public String getName() {
        return name;
    }

    public int getAge() {
        return age;
    }

    public String getGroup() {
        return group;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        Student student = (Student) o;
        return age == student.age && Objects.equals(id, student.id) && Objects.equals(name, student.name) && Objects.equals(group, student.group);
    }

    @Override
    public int hashCode() {
        return Objects.hash(id, name, age, group);
    }

    @Override
    public String toString() {
        return "Student{" +
                "id=" + id +
                ", name='" + name + '\'' +
                ", age=" + age +
                ", group='" + group + '\'' +
                '}';
    }
}

