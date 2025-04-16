import tkinter as tk
from tkinter import ttk, messagebox, mainloop
from abc import ABC, abstractmethod

class Employee(ABC):
    def __init__(self, first_name, last_name, age, work_schedule):
        self.first_name = first_name
        self.last_name = last_name
        self.age = age
        self.work_schedule = work_schedule

    def display_info(self):
        return (f"{self.first_name} {self.last_name}, Вік: {self.age}, "
                f"Графік роботи: {self.work_schedule}, "
                f"Тип: {self.get_type()}")

    def get_type(self):
        return self.__class__.__name__

    @abstractmethod
    def calculate_salary(self):
        pass

    @abstractmethod
    def special_method(self):
        pass

class OfficeWorker(Employee):
        def __init__(self, first_name, last_name, age, work_schedule, position):
            super().__init__(first_name, last_name, age, work_schedule)
            self.position = position

        def calculate_salary(self):
            return 15000

        def special_method(self):
            return f"{self.position} виконує офісні завдання."


class Worker(Employee):
    def __init__(self, first_name, last_name, age, work_schedule, hourly_rate, hours_worked):
        super().__init__(first_name, last_name, age, work_schedule)
        self.hourly_rate = hourly_rate
        self.hours_worked = hours_worked

    def calculate_salary(self):
        return self.hourly_rate * self.hours_worked

    def special_method(self):
        return f"Виконав {self.hours_worked} годин роботи "

# Створення списку співробітників
employees = [
    OfficeWorker("Анна", "Петренко", 30, "9:00-18:00", "Бухгалтер"),
    Worker("Іван", "Іваненко", 40, "6:00-15:00", 120, 160),
    Worker("Олег", "Коваленко", 35, "9:00-18:00", 100, 150),
    OfficeWorker("Юлія", "Сидоренко", 28, "10:00-19:00", "Менеджер"),
]

# GUI
root = tk.Tk()
root.title("Співробітники")
root.geometry("700x600")

# Ввідні поля
fields = {}

labels = ["Ім'я", "Прізвище", "Вік", "Графік", "Тип", "Посада / ставка", "Години"]
for i, label in enumerate(labels):
    tk.Label(root, text=label).grid(row=i, column=0, padx=5, pady=5, sticky="e")
    entry = tk.Entry(root)
    entry.grid(row=i, column=1, padx=5, pady=5)
    fields[label] = entry

# Тип співробітника: Combobox
type_combobox = ttk.Combobox(root, values=["Службовець", "Робочий"])
type_combobox.current(0)
type_combobox.grid(row=4, column=1)
fields["Тип"] = type_combobox

# Текстове поле для виводу
output = tk.Text(root, height=15, width=80)
output.grid(row=9, column=0, columnspan=3, padx=5, pady=10)

# Додати співробітника
def add_employee():
    try:
        fn = fields["Ім'я"].get()
        ln = fields["Прізвище"].get()
        age = int(fields["Вік"].get())
        schedule = fields["Графік"].get()
        emp_type = fields["Тип"].get()
        info1 = fields["Посада / ставка"].get()
        info2 = fields["Години"].get()

        if emp_type == "Службовець":
            emp = OfficeWorker(fn, ln, age, schedule, info1)
        else:
            emp = Worker(fn, ln, age, schedule, int(info1), int(info2))

        employees.append(emp)
        messagebox.showinfo("Успішно", "Співробітника додано!")
    except Exception as e:
        messagebox.showerror("Помилка", f"Некоректні дані: {e}")

# Показати всіх
def show_all():
    output.delete(1.0, tk.END)
    for emp in employees:
        output.insert(tk.END, emp.display_info() + "\n")
        output.insert(tk.END, f"Зарплата: {emp.calculate_salary()}\n")
        output.insert(tk.END, f"Особливість: {emp.special_method()}\n")
        output.insert(tk.END, "-"*60 + "\n")

# Пошук за графіком
def search_schedule():
    schedule = fields["Графік"].get()
    output.delete(1.0, tk.END)
    found = False
    for emp in employees:
        if emp.work_schedule == schedule:
            output.insert(tk.END, emp.display_info() + "\n")
            found = True
    if not found:
        output.insert(tk.END, "Нічого не знайдено за цим графіком.\n")

# Кнопки
tk.Button(root, text="Додати співробітника", command=add_employee).grid(row=7, column=0, pady=10)
tk.Button(root, text="Показати всіх", command=show_all).grid(row=7, column=1)
tk.Button(root, text="Пошук за графіком", command=search_schedule).grid(row=8, column=0, columnspan=2)

root.mainloop()