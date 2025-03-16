import tkinter as tk
from tkinter import messagebox
import re

# Функція для знаходження всіх вебсайтів з доменом .com
def find_websites():
    text = text_input.get("1.0", "end-1c") # Отримуємо текст з текстового поля
    # Регулярний вираз для знаходження адрес вебсайтів з доменом .com
    pattern = r'[a-zA-Z0-9.-]+\.com\b'
    websites = re.findall(pattern, text) # Пошук всіх вебсайтів за шаблоном
    match_count.set(f"Знайдено {len(websites)} вебсайтів.")
    results_listbox.delete(0, tk.END)  # Очищаємо список результатів
    for website in websites:
        results_listbox.insert(tk.END, website)  # Вставляємо знайдені адреси в список

# Функція для вилучення вибраного вебсайту
def remove_website():
    selected = results_listbox.curselection()  # Отримуємо вибраний елемент
    if selected:
        website_to_remove = results_listbox.get(selected)
        text = text_input.get("1.0", "end-1c")
        updated_text = text.replace(website_to_remove, "")
        text_input.delete("1.0", "end-1c")
        text_input.insert("1.0", updated_text)  # Оновлюємо текст без вибраного вебсайту
        messagebox.showinfo("Інформація", f"Вилучено: {website_to_remove}")
    else:
        messagebox.showwarning("Помилка", "Будь ласка, виберіть вебсайт для вилучення.")

# Функція для заміни вибраного вебсайту
def replace_website():
    selected = results_listbox.curselection()
    new_website = replace_entry.get()  # Отримуємо новий вебсайт для заміни
    if selected and new_website:
        website_to_replace = results_listbox.get(selected)
        text = text_input.get("1.0", "end-1c")
        updated_text = text.replace(website_to_replace, new_website)
        text_input.delete("1.0", "end-1c")
        text_input.insert("1.0", updated_text)  # Оновлюємо текст з заміною
        messagebox.showinfo("Інформація", f"Заміна: {website_to_replace} на {new_website}")
    else:
        messagebox.showwarning("Помилка", "Будь ласка, виберіть вебсайт та введіть нову адресу.")


# Створення основного вікна
window = tk.Tk()
window.title("Вебсайти з доменом .com")

# Поле для введення тексту
text_input_label = tk.Label(window, text="Введіть текст:")
text_input_label.pack()

text_input = tk.Text(window, height=10, width=50)
text_input.pack()

# Кнопка для пошуку вебсайтів
find_button = tk.Button(window, text="Знайти вебсайти", command=find_websites)
find_button.pack()

# Мітка для виведення кількості знайдених вебсайтів
match_count = tk.StringVar()
match_count_label = tk.Label(window, textvariable=match_count)
match_count_label.pack()

# Список для виведення результатів
results_listbox = tk.Listbox(window, height=6, width=50)
results_listbox.pack()

# Кнопка для вилучення вибраного вебсайту
remove_button = tk.Button(window, text="Вилучити вибраний вебсайт", command=remove_website)
remove_button.pack()

# Поле для введення нового вебсайту для заміни
replace_label = tk.Label(window, text="Введіть новий вебсайт для заміни:")
replace_label.pack()

replace_entry = tk.Entry(window, width=50)
replace_entry.pack()

# Кнопка для заміни вибраного вебсайту
replace_button = tk.Button(window, text="Замінити вибраний вебсайт", command=replace_website)
replace_button.pack()

# Запуск головного циклу GUI
window.mainloop()