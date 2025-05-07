from typing import List, Iterable, Callable

from Tools.i18n.pygettext import containsAny


def sort_by_age(people: List[dict]) -> List[dict]:
    return sorted(people, key=lambda person: person['age'])

print(
    sort_by_age(
        [
            {"name": "Alice", "age": 30},
            {"name": "Bob", "age": 25},
            {"name": "Eve", "age": 35},
        ]
    )
)

def filter_long_words(words: List[str]) -> List[str]:
    return [word.strip() for word in words if len(word.strip()) > 3]

print(filter_long_words(["a", "   ", "the", " code", "Python ", "is", "", " fun"]))

def capitalize_words(words: Iterable[str]) -> Iterable[str]:
    return map(lambda word: word.capitalize(), words)

print(list(capitalize_words(["python", "jaAAAva", "c++"])))
print(tuple(capitalize_words(("hello", "world"))))

def validate_password(password: str) -> bool:
    rules: List[Callable[[str], bool]] = [
        has_uppercase,
        has_digit,
        is_long_enough,
        has_special_char,
        no_spaces,
    ]
    return all(rule(password) for rule in rules)

def has_uppercase(password: str) -> bool:
    return any(char.isupper() for char in password)

def has_digit(password: str) -> bool:
    return any(char.isdigit() for char in password)

def is_long_enough(password: str) -> bool:
    return len(password) >= 8

def has_special_char(password: str) -> bool:
    return any(char in '!@#$%^&*()<>?' for char in password)

def no_spaces(password: str) -> str:
    return ' ' not in password

print(validate_password("StrongPass1!"))  # True
print(validate_password("weakpass"))      # False
print(validate_password("NoNumber!"))     # False
print(validate_password("Pass 123!"))     # False