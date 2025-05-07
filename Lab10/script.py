from typing import Iterator, Iterable

def fileter_even_numbers(numbs: list) -> list:
    return [num for num in numbs if num % 2 == 0]

print(fileter_even_numbers([1, 2, 3, 4, 5, 6]))

class Countdown:
    def __init__(self, start: int):
        self.current = start if start >= 0 else -1

    def __iter__(self):
        return self

    def __next__(self):
        if self.current < 0:
            raise StopIteration
        value = self.current
        self.current -= 1
        return value

for n in Countdown(5):
    print(n)

def float_range(start: float, stop: float, step:float) -> Iterator[float]:
    if step ==  0:
        raise ValueError("Step must not be zero.")

    current = start
    while (step > 0 and current < stop) or (step < 0 and current > stop):
        yield round(current, 10)
        current += step

print(list(float_range(1.0, 2.0, 0.3)))
print(list(float_range(5.0, 3.0, -0.5)))

def walk_tree(data: dict) -> Iterator[str]:
    for key, value in data.items():
        yield key
        if isinstance(value, dict):
            yield from walk_tree(value)

tree = {"a":
            {"b":
                 {"c": 1}
            },
        "d": 2}

print(list(walk_tree(tree)))