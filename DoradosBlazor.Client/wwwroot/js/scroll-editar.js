window.initEditarScroll = function () {
    const fab = document.getElementById("fabEditar");
    const footerBtn = document.getElementById("footerBtnEditar");
    const form = document.querySelector('.modern-form');

    function toggleBtn() {
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

    window.addEventListener("scroll", toggleBtn, { passive: true });
    window.addEventListener("resize", toggleBtn);
    setTimeout(toggleBtn, 400);
}
