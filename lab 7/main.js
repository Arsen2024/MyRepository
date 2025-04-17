'use strict';

// Define constants for elements
const gameMenu = document.querySelector('.game-menu');
const gameScreen = document.querySelector('.game-screen');
const winScreen = document.querySelector('.win-screen');
const startGameButton = document.querySelector('.button-start-game');
const restartButton = document.querySelector('.button-restart');
const nextLevelButton = document.querySelector('.button-next-level');
const scorePanel = document.querySelector('.score-panel__score_num');
const levelPanel = document.querySelector('.score-panel__level');
const message = document.querySelector('.message');
const timePanelYou = document.querySelector('.time-panel__you');
const timePanelGunman = document.querySelector('.time-panel__gunman');
const gunman = document.querySelector('.gunman');
const playersPanelYou = document.querySelector('.players-panel__you');
const playersPanelGunman = document.querySelector('.players-panel__gunman');

let score = 0;
let level = 1;
let gunmanTime = 0;
let playerTime = 0;
let gunmanReady = false;
let gameRunning = false;
let shootReady = false;

// Show the game menu and hide the game screen
function startGame() {
    gameMenu.style.display = 'none';
    gameScreen.style.display = 'block';
    startGameButton.disabled = true;
    restartButton.style.display = 'none';
    nextLevelButton.style.display = 'none';

    score = 0;
    level = 1;
    gunmanTime = 0;
    playerTime = 0;
    updateScore();
    updateLevel();
    gameRunning = true;

    startDuel();
}

// Update score and level
function updateScore() {
    scorePanel.textContent = score;
}

function updateLevel() {
    levelPanel.textContent = `Level ${level}`;
}

// Start the duel by setting gunman ready
function startDuel() {
    gunman.style.transition = 'none'; // reset transition
    gunman.classList.remove('shooting');
    gunman.classList.add('ready');
    gunmanReady = true;
    timePanelGunman.textContent = '0.00';
    timePanelYou.textContent = '0.00';

    setTimeout(() => {
        if (gameRunning) {
            shootReady = true;
            gunmanReady = false;
            gunman.classList.remove('ready');
            gunman.classList.add('shooting');
            gunmanTime = (Math.random() * 2 + 1).toFixed(2); // Gunman delay (between 1.00 and 3.00)
            timePanelGunman.textContent = gunmanTime;
            startGunmanShoot();
        }
    }, Math.random() * 3000 + 2000); // Random delay for gunman to shoot (2-5 sec)
}

// Start gunman shoot countdown
function startGunmanShoot() {
    let countDown = gunmanTime * 1000;
    const interval = setInterval(() => {
        countDown -= 100;
        const seconds = (countDown / 1000).toFixed(2);
        timePanelGunman.textContent = seconds;
        if (countDown <= 0) {
            clearInterval(interval);
            gunmanShootsPlayer();
        }
    }, 100);
}

// The gunman shoots
function gunmanShootsPlayer() {
    if (gameRunning) {
        message.textContent = 'You lost!';
        setTimeout(() => {
            endGame();
        }, 1000);
    }
}

// Player shoots
function playerShootsGunman(event) {
    if (!shootReady || !gameRunning) return;
    shootReady = false;
    playerTime = (event.timeStamp / 1000).toFixed(2);
    timePanelYou.textContent = playerTime;

    if (playerTime < gunmanTime) {
        score++;
        message.textContent = 'You won!';
    } else {
        message.textContent = 'You lost!';
    }

    setTimeout(() => {
        if (score < 3) {
            nextLevel();
        } else {
            endGame();
        }
    }, 1000);
}

// Go to the next level
function nextLevel() {
    level++;
    updateLevel();
    setTimeout(() => {
        startDuel();
    }, 1000);
}

// End the game (show win screen)
function endGame() {
    gameRunning = false;
    message.textContent = '';
    gameScreen.style.display = 'none';
    winScreen.style.display = 'block';
    nextLevelButton.style.display = 'none';
    restartButton.style.display = 'block';
}

// Restart the game
function restartGame() {
    winScreen.style.display = 'none';
    gameMenu.style.display = 'block';
    startGameButton.disabled = false;
}

// Event listeners
startGameButton.addEventListener('click', startGame);
restartButton.addEventListener('click', restartGame);
nextLevelButton.addEventListener('click', nextLevel);

// Start player shoot on key press
document.addEventListener('keydown', (event) => {
    if (event.code === 'Space') {
        playerShootsGunman(event);
    }
});
