package task2;

import java.util.*;

public class ListOperation {
    public static <T> Set<T> transformToUnique(List<T> list)
    {
        return new HashSet<>(list);
    }

    public static <T> Map<T, Integer> getElementCounts(List<T> list) {
        Map<T, Integer> countMap = new HashMap<>();

        for (T element : list) {
            countMap.put(element, countMap.getOrDefault(element, 0) + 1);
        }

        return countMap;
    }
}
