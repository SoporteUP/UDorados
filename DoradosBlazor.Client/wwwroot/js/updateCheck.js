window.registrarSWConNotificacion = (dotNetHelper) => {
    if ("serviceWorker" in navigator) {
        navigator.serviceWorker.getRegistration().then(reg => {
            if (reg) {
                reg.onupdatefound = () => {
                    const newWorker = reg.installing;
                    newWorker.onstatechange = () => {
                        if (newWorker.state === "installed" && navigator.serviceWorker.controller) {
                            dotNetHelper.invokeMethodAsync("mostrarNotificacionActualizacion");
                        }
                    };
                };
            }
        });
    }
};

window.forzarRecargaActualizacion = async () => {
    if ("caches" in window) {
        const keys = await caches.keys();
        await Promise.all(keys.map(k => caches.delete(k)));
    }

    localStorage.clear();
    sessionStorage.clear();
    location.reload(true);
};