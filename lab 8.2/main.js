function createSlider(selector, config={}) {
    const container = document.querySelector(selector);
    if (!container) return;
    const {
        images = [],
        duration = 500,
        autoplay = false,
        showArrows = true,
        showDots = true
    } = config;


    let current = 0;
    let interval;
    let isPaused = false;

// Створення елементів
    const slider = document.createElement("div");
    slider.className = "slider";

    const track = document.createElement("div");
    track.className = "slider-track";

    images.forEach(src => {
        const slide = document.createElement("div");
        slide.className = "slide";
        slide.innerHTML = `<img src="${src}" alt="slide">`;
        track.appendChild(slide);
    });

    slider.appendChild(track);

// Стрілки
    if (showArrows) {
        const leftArrow = document.createElement("button");
        leftArrow.className = "slider-arrow left";
        leftArrow.innerHTML = "←";
        leftArrow.onclick = () => moveSlide(-1);

        const rightArrow = document.createElement("button");
        rightArrow.className = "slider-arrow right";
        rightArrow.innerHTML = "→";
        rightArrow.onclick = () => moveSlide(1);

        slider.appendChild(leftArrow);
        slider.appendChild(rightArrow);
    }

// Точки
    let dots = [];
    if (showDots) {
        const dotsContainer = document.createElement("div");
        dotsContainer.className = "slider-dots";

        images.forEach((_, index) => {
            const dot = document.createElement("button");
            dot.onclick = () => goToSlide(index);
            dotsContainer.appendChild(dot);
            dots.push(dot);
        });

        slider.appendChild(dotsContainer);
    }

    container.appendChild(slider);

    function updateSlider() {
        track.style.transform = `translateX(-${current * 100}%)`;
        dots.forEach((dot, index) => {
            dot.classList.toggle("active", index === current);
        });
    }

    function moveSlide(dir) {
        current = (current + dir + images.length) % images.length;
        updateSlider();
    }

    function goToSlide(index) {
        current = index;
        updateSlider();
    }

// Автопрокрутка
    function startAutoplay() {
        if (autoplay) {
            interval = setInterval(() => {
                if (!isPaused) moveSlide(1);
            }, 3000);
        }
    }

    function stopAutoplay() {
        clearInterval(interval);
    }

    slider.addEventListener("mouseenter", () => {
        isPaused = true;
    });
    slider.addEventListener("mouseleave", () => {
        isPaused = false;
    });

// Клавіші
    document.addEventListener("keydown", (e) => {
        if (e.key === "ArrowRight") moveSlide(1);
        else if (e.key === "ArrowLeft") moveSlide(-1);
    });

// Старт
    updateSlider();
    startAutoplay();
}

// Ініціалізація слайдера
createSlider("#slider-container", {
    images: [
        "https://letsenhance.io/static/73136da51c245e80edc6ccfe44888a99/1015f/MainBefore.jpg",
        "https://images.pexels.com/photos/414612/pexels-photo-414612.jpeg?cs=srgb&dl=pexels-souvenirpixels-414612.jpg&fm=jpg",
        "https://media.istockphoto.com/id/1399246824/photo/digital-eye-wave-lines-stock-background.jpg?s=612x612&w=0&k=20&c=1cW5xuLcb6HPDj6CLQQFBvGK5_fJvx9eA2egik-3hAc="
    ],
    duration: 500,
    autoplay: true,
    showArrows: true,
    showDots: true
});