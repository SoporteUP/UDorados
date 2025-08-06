window.enviosWhatsappDrag = {
    allowDrop: function () {
        event.preventDefault(); // usa el event global del navegador
        const dropZone = document.querySelector('#envios-whatsapp-col-der');
        if (dropZone) dropZone.classList.add('dragover');
    },
    clearDrop: function () {
        const dropZone = document.querySelector('#envios-whatsapp-col-der');
        if (dropZone) dropZone.classList.remove('dragover');
    }
};