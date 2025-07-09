window.slideOutCard = (id) => {
    const card = document.querySelector(`.prospecto-id-${id}`);
    if (card) {
        card.classList.add('prospecto-slide-out');
        setTimeout(() => {
            card.classList.remove('prospecto-slide-out');
        }, 300); // coincide con la duración en CSS
    }
};