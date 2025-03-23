// Завдання 1
function processFruitsArray() {
    let fruits = ["яблуко", "банан", "апельсин", "виноград", "манго"];

    // Видаляємо останній елемент
    fruits.pop();
    console.log("1. Оновлений масив після видалення останнього елемента:", fruits);

    // Додаємо "ананас" на початок
    fruits.unshift("ананас");
    console.log("2. Масив після додавання 'ананас' на початок:", fruits);

    // Сортуємо у зворотньому алфавітному порядку
    fruits.sort().reverse();
    console.log("3. Масив у зворотньому алфавітному порядку:", fruits);

    // Знаходимо індекс "яблуко"
    let appleIndex = fruits.indexOf("яблуко");
    console.log("4. Індекс елемента 'яблуко':", appleIndex);
}

// Викликаємо функцію
processFruitsArray();

// Завдання 2
function processColorsArray() {
    let colors = ["червоний", "синій", "зелений", "жовтий", "темно-синій", "блакитний"];

    // Знаходимо найдовший та найкоротший елементи
    let longest = colors.reduce((a, b) => a.length >= b.length ? a : b);
    let shortest = colors.reduce((a, b) => a.length <= b.length ? a : b);
    console.log("1. Найдовший колір:", longest);
    console.log("2. Найкоротший колір:", shortest);

    // Видаляємо всі рядки, крім тих, що містять "синій"
    colors = colors.filter(color => color.includes("синій"));
    console.log("3. Масив після фільтрації:", colors);

    // Об'єднуємо елементи у рядок через кому
    let joinedColors = colors.join(", ");
    console.log("4. Об'єднаний рядок кольорів:", joinedColors);
}

// Викликаємо функцію
processColorsArray();

// Завдання 3
function processEmployeesArray() {
    let employees = [
        { імя: "Іван", вік: 25, посада: "розробник" },
        { імя: "Марія", вік: 30, посада: "дизайнер" },
        { імя: "Петро", вік: 35, посада: "тестувальник" },
        { імя: "Ольга", вік: 28, посада: "розробник" }
    ];

    // Сортуємо за іменами
    employees.sort((a, b) => a.імя.localeCompare(b.імя));
    console.log("1. Відсортований масив працівників:", employees);

    // Знаходимо всіх розробників
    let developers = employees.filter(emp => emp.посада === "розробник");
    console.log("2. Працівники з посадою 'розробник':", developers);

    // Видаляємо працівника за віком (наприклад, старших за 30)
    employees = employees.filter(emp => emp.вік <= 30);
    console.log("3. Масив після видалення працівників старше 30 років:", employees);

    // Додаємо нового працівника
    employees.push({ імя: "Андрій", вік: 26, посада: "аналітик" });
        console.log("4. Оновлений масив працівників:", employees);
    }

// Викликаємо функцію
processEmployeesArray();

// Завдання 4
function processStudentsArray() {
    let students = [
        { імя: "Олексій", вік: 22, курс: 3 },
        { імя: "Наталя", вік: 20, курс: 2 },
        { імя: "Максим", вік: 24, курс: 4 },
        { імя: "Андрій", вік: 19, курс: 1 }
    ];

    // Видаляємо студента з ім’ям "Олексій"
    students = students.filter(student => student.імя !== "Олексій");
    console.log("1. Масив після видалення студента 'Олексій':", students);

    // Додаємо нового студента
    students.push({ імя: "Ольга", вік: 21, курс: 3 });
        console.log("2. Оновлений масив студентів:", students);

        // Сортуємо студентів за віком від найстаршого до наймолодшого
        students.sort((a, b) => b.вік - a.вік);
        console.log("3. Відсортований масив студентів за віком:", students);

        // Знаходимо студента, який навчається на 3-му курсі
        let thirdYearStudent = students.find(student => student.курс === 3);
        console.log("4. Студент 3-го курсу:", thirdYearStudent);
    }

// Викликаємо функцію
processStudentsArray();

// Завдання 5
function processNumbersArray() {
    let numbers = [2, 5, 8, 10, 15];

    // Підносимо кожне число до квадрату
    let squaredNumbers = numbers.map(num => num ** 2);
    console.log("1. Масив чисел у квадраті:", squaredNumbers);

    // Отримуємо лише парні числа
    let evenNumbers = numbers.filter(num => num % 2 === 0);
    console.log("2. Парні числа у масиві:", evenNumbers);

    // Знаходимо суму всіх елементів
    let sum = numbers.reduce((acc, num) => acc + num, 0);
    console.log("3. Сума всіх чисел:", sum);

    // Додаємо новий масив з 5 чисел
    let additionalNumbers = [20, 25, 30, 35, 40];
    numbers = numbers.concat(additionalNumbers);
    console.log("4. Оновлений масив після додавання нових чисел:", numbers);

    // Видаляємо перші 3 елементи
    numbers.splice(0, 3);
    console.log("5. Масив після видалення перших 3 елементів:", numbers);
}

// Викликаємо функцію
processNumbersArray();

// Завдання 6
function libraryManagement() {
    let books = [
        { title: "1984", author: "George Orwell", genre: "Dystopian", pages: 328, isAvailable: true },
        { title: "To Kill a Mockingbird", author: "Harper Lee", genre: "Fiction", pages: 281, isAvailable: true },
        { title: "Moby-Dick", author: "Herman Melville", genre: "Adventure", pages: 635, isAvailable: false }
    ];
    console.log("1. Додавання нової книги до бібліотеки:", books);
    return {
        addBook(title, author, genre, pages) {
            books.push({ title, author, genre, pages, isAvailable: true });
        },

        removeBook(title) {
            books = books.filter(book => book.title !== title);
        },

        findBooksByAuthor(author) {
            return books.filter(book => book.author === author);
        },

        toggleBookAvailability(title, isBorrowed) {
            const book = books.find(book => book.title === title);
            if (book) book.isAvailable = !isBorrowed;
        },

        sortBooksByPages() {
            books.sort((a, b) => a.pages - b.pages);
        },

        getBooksStatistics() {
            const totalBooks = books.length;
            const availableBooks = books.filter(book => book.isAvailable).length;
            const borrowedBooks = totalBooks - availableBooks;
            const averagePages = totalBooks ? books.reduce((sum, book) => sum + book.pages, 0) / totalBooks : 0;
            return { totalBooks, availableBooks, borrowedBooks, averagePages };
        },

        getBooks() {
            return books;
        }
    };
}

// Викликаємо функцію
libraryManagement();

// Завдання 7
function updateStudent() {
    // Створюємо об'єкт зі студентом
    let student = {
        name: "Іван",
        age: 20,
        course: 3
    };

    // Додаємо нову властивість зі списком предметів
    student.subjects = ["Математика", "Інформатика", "Фізика"];

    // Видаляємо властивість "вік"
    delete student.age;

    // Виводимо оновлений об'єкт у консоль
    console.log(student);
}

// Викликаємо функцію
updateStudent();