let currentIndex = 0;
const images = document.querySelectorAll('.carousel-image');
const totalImages = images.length;

function showNextImage() {
    currentIndex = (currentIndex + 1) % totalImages;
    document.querySelector('.carousel').style.transform = `translateX(-${currentIndex * 100}%)`;
}

setInterval(showNextImage, 5000);

function changeImageSize(width, height) {
    images.forEach(image => {
        image.style.width = width;
        image.style.height = height;
    });
}

changeImageSize('1000px', '600px');
