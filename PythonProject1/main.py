def input_array():
    n = int(input("Введіть кількість елементів масиву: "))
    arr = list(map(int, input("Введіть елементи масиву через пробіл: ").split()))
    if len(arr) != n:
        print("Помилка: кількість введених елементів не співпадає із заявленою!")
        exit(1)
    return arr

def sum_even_indices(arr):
    """Обчислює суму елементів з парними індексами"""
    return sum(arr[i] for i in range(0, len(arr), 2))

def sum_indices_multiple_of_three(arr):
    """Обчислює суму елементів, індекси яких кратні 3"""
    return sum(arr[i] for i in range(0, len(arr), 3))

def main():
    arr = input_array()

    sum_even = sum_even_indices(arr)
    sum_multiple_three = sum_indices_multiple_of_three(arr)
    difference = sum_even - sum_multiple_three

    print(f"Сума елементів з парними індексами: {sum_even}")
    print(f"Сума елементів з індексами, кратними 3: {sum_multiple_three}")
    print(f"Різниця між сумами: {difference}")


if __name__ == "__main__":
    main()