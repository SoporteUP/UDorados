window.calendarUtils = {
    setupMoreClick: function (dotnetHelper) {
        if (window.__calendarMoreHandler) {
            document.body.removeEventListener('click', window.__calendarMoreHandler, true);
        }
        window.__calendarMoreHandler = function (e) {
            if (e.target && e.target.classList.contains('rz-event-list-btn')) {
                let btn = e.target;
                let leftStr = btn.style.left; // e.g. "85.71428571428572%"
                let leftVal = parseFloat(leftStr);
                let dayIndex = Math.round(leftVal / 14.285714285714286);

                let weekDiv = btn.closest('.rz-week');
                let slots = weekDiv ? weekDiv.querySelectorAll('.rz-slot') : [];
                let slot = slots[dayIndex];
                let dia = null;

                if (slot) {
                    let slotTitle = slot.querySelector('.rz-slot-title');
                    if (slotTitle) {
                        dia = slotTitle.textContent.trim();
                    }
                }
                let year = new Date().getFullYear();
                let month = new Date().getMonth();
                if (window.visibleCalendarYear !== undefined && window.visibleCalendarMonth !== undefined) {
                    year = window.visibleCalendarYear;
                    month = window.visibleCalendarMonth;
                }
                if (dia) {
                    let dateObj = new Date(year, month, parseInt(dia, 10));
                    let dateStr = dateObj.toISOString().substring(0, 10);
                    dotnetHelper.invokeMethodAsync('IrADia', dateStr);
                }
                e.preventDefault();
                e.stopPropagation();
            }
        };
        document.body.addEventListener('click', window.__calendarMoreHandler, true);
    },

    setVisibleMonth: function (year, month) {
        window.visibleCalendarYear = year;
        window.visibleCalendarMonth = month;
    }
};