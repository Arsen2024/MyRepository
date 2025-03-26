import tkinter as tk
from tkinter import scrolledtext


def replace_word():
    text = text_input.get("1.0", tk.END)  # Отримуємо текст із текстового поля
    word_to_replace = word1_entry.get()
    replacement_word = word2_entry.get()

    if word_to_replace and replacement_word:
        new_text = text.replace(word_to_replace, replacement_word)  # Заміна слів
        result_output.delete("1.0", tk.END)
        result_output.insert(tk.END, new_text)

# Створення вікна
root = tk.Tk()
root.title("Замінник слів")

# Поле для введення тексту
tk.Label(root, text="Введіть текст:").pack()
text_input = scrolledtext.ScrolledText(root, width=50, height=10)
text_input.pack()

# Поле для введення першого слова
tk.Label(root, text="Слово для заміни:").pack()
word1_entry = tk.Entry(root)
word1_entry.pack()

# Поле для введення другого слова
tk.Label(root, text="Замінити на:").pack()
word2_entry = tk.Entry(root)
word2_entry.pack()

# Кнопка для заміни
replace_button = tk.Button(root, text="Замінити", command=replace_word)
replace_button.pack()

# Поле для виводу результату
tk.Label(root, text="Результат:").pack()
result_output = scrolledtext.ScrolledText(root, width=50, height=10)
result_output.pack()

root.mainloop()