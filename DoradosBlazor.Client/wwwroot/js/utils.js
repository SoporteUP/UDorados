window.limpiarCache = async () => {
    if (window.Swal) {
        const result = await Swal.fire({
            title: '¿Actualizar aplicación?',
            text: 'Se limpiará el caché y se recargará la app.',
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#6c63ff',
            cancelButtonColor: '#888',
            confirmButtonText: 'Sí, actualizar',
            cancelButtonText: 'Cancelar'
        });

        if (!result.isConfirmed) return;
    }

    if ('caches' in window) {
        const cacheNames = await caches.keys();
        await Promise.all(cacheNames.map(name => caches.delete(name)));
    }

    localStorage.clear();
    sessionStorage.clear();

    // Espera pequeño para que el usuario vea el mensaje
    setTimeout(() => location.reload(true), 300);
};


window.setupOfflineHandler = () => {
    const alert = document.getElementById("offline-alert");

    const updateStatus = () => {
        if (navigator.onLine) {
            alert.style.display = "none";
        } else {
            alert.style.display = "block";
        }
    };

    window.addEventListener("online", updateStatus);
    window.addEventListener("offline", updateStatus);
    updateStatus();
};

    

