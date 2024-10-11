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


function trocarElementos(categoria, btn) {
    // Hide all tab contents
    var tabcontents = document.querySelectorAll('.tabcontent');
    tabcontents.forEach(function (tab) {
        tab.style.display = 'none'; // Hide each tab content
    });

    console.log('Selected category:', categoria);
    // Show the current tab content based on the clicked category
    var currentTab = document.getElementById(categoria);
    if (currentTab) {
        currentTab.style.display = 'block'; // Show the relevant tab content
    } else {
        console.error('No tab content found for category:', categoria); // Log error if not found
    }

    // Remove 'active' class from all buttons (if you use a class to highlight active button)
    var tablinks = document.querySelectorAll('.tablink');
    tablinks.forEach(function (link) {
        link.classList.remove('active');
    });

    // Add 'active' class to the clicked button (if you use a class to highlight active button)
    if (btn) {
        btn.classList.add('active');
    }
}