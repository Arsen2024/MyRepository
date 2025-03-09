import random

# Функція для генерації випадкових оцінок
def generate_grades(students=20, subjects=10, min_grade=1, max_grade=12):
    return [[random.randint(min_grade, max_grade) for _ in range(subjects)] for _ in range(students)]

# Функція для обчислення середньої успішності по кожній дисципліні
def calculate_subject_averages(grades):
    subjects = len(grades[0])
    return [sum(grades[i][j] for i in range(len(grades))) / len(grades) for j in range(subjects)]

# Функція для обчислення загальної успішності групи
def calculate_group_average(grades):
    total_sum = sum(sum(student) for student in grades)
    total_count = len(grades) * len(grades[0])
    return total_sum / total_count

# Функція для виводу оцінок та результатів
def print_results(grades):
    students = len(grades)
    subjects = len(grades[0])

    print("Оцінки студентів:")
    print("Студент  | " + "  ".join(f"Дисц-{i + 1}" for i in range(subjects)))
    print("-" * (10 + subjects * 5))

    for i, student in enumerate(grades):
        print(f"{i + 1:^8} | " + "  ".join(f"{grade:^3}" for grade in student))

    subject_averages = calculate_subject_averages(grades)
    group_average = calculate_group_average(grades)

    print("\nСередні оцінки по дисциплінах:")
    print(" | ".join(f"{avg:.2f}" for avg in subject_averages))

    print(f"\nЗагальна середня успішність групи: {group_average:.2f}")

# 🔹 Головний виклик програми
if __name__ == "__main__":
    grades = generate_grades()  # Генеруємо оцінки
    print_results(grades)       # Виводимо результати
