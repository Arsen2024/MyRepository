package task8;

import java.util.ArrayList;
import java.util.List;

public class AnimalShelter {
    private List<Dog> dogs = new ArrayList<>();
    private List<Animal> otherAnimals = new ArrayList<>();

    public void addAnimals(List<? extends Dog> dogsToAdd) {
        dogs.addAll(dogsToAdd);
    }

    public void addOtherAnimals(List<? extends Animal> animalsToAdd) {
        otherAnimals.addAll(animalsToAdd);
    }

    public void printAnimalSounds() {
        System.out.println("Звуки собак у притулку:");
        for (Dog dog : dogs) {
            dog.makeSound();
        }

        System.out.println("\nЗвуки інших тварин у притулку:");
        for (Animal animal : otherAnimals) {
            animal.makeSound();
        }
    }
}
