window.calendarUtils = {
    setupMoreClick: function (dotnetHelper) {
        // Elimina listeners previos para evitar duplicados
        if (window.__calendarMoreHandler) {
            document.body.removeEventListener('click', window.__calendarMoreHandler, true);
        }

        // Handler delegado
        window.__calendarMoreHandler = function (e) {
            if (e.target && e.target.classList.contains('rz-event-list-btn')) {
                // Busca el atributo 'data-date' o extrae la fecha del día desde el DOM
                let parentCell = e.target.closest('.rz-scheduler-cell, .rz-scheduler-month-cell');
                let dateStr = e.target.getAttribute('data-date'); // Algunas versiones lo tienen
                if (!dateStr && parentCell) {
                    // Busca un span con la fecha visible en la celda (normalmente el número del día)
                    let span = parentCell.querySelector('.rz-scheduler-cell-date, .rz-scheduler-month-cell-date');
                    if (span) {
                        // Construye la fecha basada en el mes/año visible (requiere ajustar si tienes localización)
                        let day = parseInt(span.textContent.trim(), 10);
                        let today = new Date();
                        let year = today.getFullYear();
                        let month = today.getMonth();

                        // Busca el mes/año actual en el calendario (opcional: puedes pasar este dato desde Blazor)
                        // Para precisión total, puedes guardar el mes visible en una variable global al cambiar de mes.

                        let dateObj = new Date(year, month, day);
                        dateStr = dateObj.toISOString().substring(0, 10);
                    }
                }
                // Llama a tu método Blazor solo si tienes la fecha
                if (dateStr) {
                    dotnetHelper.invokeMethodAsync('IrADia', dateStr);
                }
                e.preventDefault();
                e.stopPropagation();
            }
        };

        // Agrega el listener en captura
        document.body.addEventListener('click', window.__calendarMoreHandler, true);
    }
};