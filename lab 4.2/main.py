import tkinter as tk
from tkinter import scrolledtext, messagebox
import random
import re

# Файл з вхідними даними
FILE_TF1 = "TF_1.txt"
FILE_TF2 = "TF_2.txt"


# Функція для генерації випадкового тексту
def generate_text_file():
    words = ["hello", "world", "Python", "programming", "AI", "data", "science", "computer", "random", "words"]
    punctuations = [".", ",", "!", "?", ";", ":"]

    with open(FILE_TF1, "w", encoding="utf-8") as f:
        for _ in range(10):  # Генеруємо 10 рядків
            sentence = " ".join(
                random.choice(words) + random.choice(punctuations + [""]) for _ in range(random.randint(5, 10)))
            f.write(sentence + "\n")

    messagebox.showinfo("Файл створено", f"Файл {FILE_TF1} успішно створено!")


# Функція для аналізу тексту
def analyze_text():
    try:
        with open(FILE_TF1, "r", encoding="utf-8") as f:
            text = f.read()

        words = re.findall(r"\b\w+\b", text)  # Знаходимо всі слова
        word_length_count = {}

        for word in words:
            length = len(word)
            word_length_count[length] = word_length_count.get(length, 0) + 1

        # Запис у файл TF_2.txt
        with open(FILE_TF2, "w", encoding="utf-8") as f:
            for length in sorted(word_length_count):
                words_of_length = [w for w in words if len(w) == length]
                f.write(f"{length}-символьні слова: {' '.join(words_of_length)} ({word_length_count[length]})\n")

        messagebox.showinfo("Аналіз завершено", f"Файл {FILE_TF2} оновлено!")

    except FileNotFoundError:
        messagebox.showerror("Помилка", f"Файл {FILE_TF1} не знайдено! Спочатку згенеруйте його.")


# Функція для виводу результатів
def display_results():
    try:
        with open(FILE_TF2, "r", encoding="utf-8") as f:
            text = f.read()

        text_area.delete(1.0, tk.END)  # Очищення поля перед виведенням нового тексту
        text_area.insert(tk.END, text)

    except FileNotFoundError:
        messagebox.showerror("Помилка", f"Файл {FILE_TF2} не знайдено! Спочатку виконайте аналіз.")


# --- Створення GUI ---
root = tk.Tk()
root.title("Аналіз тексту")
root.geometry("500x400")

# Кнопки
btn_generate = tk.Button(root, text="Створити TF_1.txt", command=generate_text_file)
btn_analyze = tk.Button(root, text="Аналізувати TF_1.txt", command=analyze_text)
btn_display = tk.Button(root, text="Показати TF_2.txt", command=display_results)

btn_generate.pack(pady=5)
btn_analyze.pack(pady=5)
btn_display.pack(pady=5)

# Поле для виводу тексту
text_area = scrolledtext.ScrolledText(root, width=60, height=15)
text_area.pack(padx=10, pady=10)

root.mainloop()