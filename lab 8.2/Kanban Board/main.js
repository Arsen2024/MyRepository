function allowDrop(event) {
    event.preventDefault();
}

function drag(event) {
    event.dataTransfer.setData("text", event.target.id);
}

function drop(event) {
    event.preventDefault();
    var data = event.dataTransfer.getData("text");
    var draggedElement = document.getElementById(data);
    var targetColumn = event.target;

    document.querySelectorAll(".task").forEach(t => t.classList.remove("drag-over"));

    if (targetColumn.classList.contains("task")) {
        const bounding = targetColumn.getBoundingClientRect();
        const offset = event.clientY - bounding.top;

        // Вставити перед або після залежно від позиції курсора
        if (offset < bounding.height / 2) {
            targetColumn.parentNode.insertBefore(draggedElement, targetColumn);
        } else {
            targetColumn.parentNode.insertBefore(draggedElement, targetColumn.nextSibling);
        }
    } else if (targetColumn.classList.contains("kanban-column")) {
        targetColumn.appendChild(draggedElement);
    }
}

// Додаємо обробники для підсвітки
document.querySelectorAll(".task").forEach(task => {
    task.addEventListener("dragenter", (event) => {
        if (event.target.classList.contains("task")) {
            event.target.classList.add("drag-over");
        }
    });

    task.addEventListener("dragleave", (event) => {
        if (event.target.classList.contains("task")) {
            event.target.classList.remove("drag-over");
        }
    });
});