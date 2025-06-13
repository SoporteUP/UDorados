window.initGuardarScroll = function () {
    const fab = document.getElementById("fabGuardar");
    const footerBtn = document.getElementById("footerBtnGuardar");
    const form = document.querySelector('.modern-form');

    function toggleGuardarBtn() {
        if (!fab || !footerBtn || !form) return;
        // Solo en móvil
        if (window.innerWidth >= 768) {
            fab.style.display = "none";
            footerBtn.style.display = "none";
            return;
        }
        const rect = form.getBoundingClientRect();
        const isBottom = (window.innerHeight - rect.bottom) > -80;
        if (isBottom) {
            fab.style.display = "none";
            footerBtn.style.display = "block";
        } else {
            fab.style.display = "block";
            footerBtn.style.display = "none";
        }
    }

    window.addEventListener("scroll", toggleGuardarBtn, { passive: true });
    window.addEventListener("resize", toggleGuardarBtn);
    setTimeout(toggleGuardarBtn, 400);
}
