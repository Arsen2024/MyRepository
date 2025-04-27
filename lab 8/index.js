const gameContainer = document.getElementById("game");
const timerDisplay = document.getElementById("timer");
const movesDisplay = document.getElementById("moves");
const startBtn = document.getElementById("startBtn");
const resetSettingsBtn = document.getElementById("resetSettingsBtn");

let gridRows = 4,
    gridCols = 4,
    difficulty = "easy",
    totalTime = 180,
    timer,
    timeLeft,

    cards = [],
    flipped = [],
    matched = 0,
    moves = 0;

// Список картинок (різні формати файлів дозволені)
const cardImages = [
    'img/plankton.jpg', 'img/Mrs.Puff.png', 'img/Patrick.png', 'img/Spongebob.png',
    'img/spongebob_2.jpg', 'img/spongebob_3.jpeg', 'img/spongebob_4.jpg', 'img/Gary.jpg',
    'img/pineapple_house.jpg', 'img/squidward.jpg', 'img/stone_house.webp', 'img/spongebob_5.webp',
    'img/krusty-krab.jpg', 'img/crabsburger.jpg', 'img/TheChumBucket.webp', 'img/squidward_2.jpg',
    'img/stone_house.webp', 'img/Patrick_house.webp'
];

function getTimeForDifficulty(level) {
    switch (level) {
        case "easy": return 180;
        case "normal": return 120;
        case "hard": return 60;
        default: return 180;
    }
}

function updateInfo() {
    movesDisplay.textContent = `🔄 Ходи: ${moves}`;
}

function updateTimer() {
    const minutes = String(Math.floor(timeLeft / 60)).padStart(2, "0");
    const seconds = String(timeLeft % 60).padStart(2, "0");
    timerDisplay.textContent = `⏱ ${minutes}:${seconds}`;

    if (timeLeft <= 0) {
        clearInterval(timer);
        alert("⏱ Час вичерпано!");
        disableAllCards();
    }
    timeLeft--;
}

function disableAllCards() {
    cards.forEach(card => card.removeEventListener("click", onCardClick));
}

function startTimer() {
    clearInterval(timer);
    timeLeft = totalTime;
    updateTimer();
    timer = setInterval(updateTimer, 1000);
}

function createDeck() {
    const pairCount = (gridRows * gridCols) / 2;
    const selectedImages = cardImages.slice(0, pairCount);
    const deck = [...selectedImages, ...selectedImages]; // подвоюємо картинки для пар
    deck.sort(() => Math.random() - 0.5); // перемішуємо
    return deck;
}

function renderGrid() {
    gameContainer.innerHTML = "";
    gameContainer.style.gridTemplateColumns = `repeat(${gridCols}, 1fr)`;
    cards = [];
    matched = 0;
    moves = 0;
    updateInfo();

    const deck = createDeck();

    deck.forEach(imagePath => {
        const card = document.createElement("div");
        card.className = "card";
        card.dataset.image = imagePath;

        const frontFace = document.createElement("div");
        frontFace.className = "card-front";

        const backFace = document.createElement("div");
        backFace.className = "card-back";

        const img = document.createElement("img");
        img.src = imagePath;
        img.alt = "card image";
        backFace.appendChild(img);

        card.appendChild(frontFace);
        card.appendChild(backFace);

        card.addEventListener("click", () => onCardClick(card));
        gameContainer.appendChild(card);
        cards.push(card);
    });
}

function onCardClick(card) {
    if (flipped.length >= 2 || card.classList.contains("flipped") || card.classList.contains("matched")) return;

    card.classList.add("flipped");
    flipped.push(card);

    if (flipped.length === 2) {
        moves++;
        updateInfo();
        const [first, second] = flipped;

        if (first.dataset.image === second.dataset.image) {
            first.classList.add("matched");
            second.classList.add("matched");
            matched += 1;
            flipped = [];

            if (matched === (gridRows * gridCols) / 2) {
                clearInterval(timer);
                setTimeout(() => {
                    alert(`🎉 Ви виграли! Ходи: ${moves}, Час: ${formatTime(totalTime - timeLeft)}`);
                }, 300);
            }
        } else {
            setTimeout(() => {
                first.classList.remove("flipped");
                second.classList.remove("flipped");
                flipped = [];
            }, 800);
        }
    }
}

function formatTime(seconds) {
    const m = String(Math.floor(seconds / 60)).padStart(2, "0");
    const s = String(seconds % 60).padStart(2, "0");
    return `${m}:${s}`;
}

startBtn.addEventListener("click", () => {
    const size = document.getElementById("gridSize").value.split("x");
    gridRows = parseInt(size[0]);
    gridCols = parseInt(size[1]);
    difficulty = document.getElementById("difficulty").value;
    totalTime = getTimeForDifficulty(difficulty);

    if ((gridRows * gridCols) / 2 > cardImages.length) {
        alert(`Недостатньо картинок для такого розміру! Максимум ${(cardImages.length) * 2} карток.`);
        return;
    }

    renderGrid();
    startTimer();
});

resetSettingsBtn.addEventListener("click", () => {
    document.getElementById("gridSize").value = "4x4";
    document.getElementById("difficulty").value = "easy";
});
