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


function trocarElementos(cityName, elmnt, cor) {
    // Esconde todos os elementos com class="tabcontent"
    var i, tabcontent, tablinks;
    tabcontent = document.getElementsByClassName("tabcontent");
    for (i = 0; i < tabcontent.length; i++) {
        tabcontent[i].style.display = "none";
    }

    // Mostra o conteúdo da aba específica
    document.getElementById(cityName).style.display = "block";

    // Remove a classe 'active' de todos os títulos h4
    var allH4s = document.querySelectorAll('.nav-item h4');
    allH4s.forEach(h4 => h4.classList.remove('active'));

    // Adiciona a classe 'active' ao título do botão clicado
    var h4 = elmnt.querySelector('h4');
    if (h4) {
        h4.classList.add('active');
    }
}