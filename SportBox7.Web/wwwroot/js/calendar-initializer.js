(function ($) {
    var todayDate = new Date();
    todayDate.setHours(0, 0, 0, 0);

    function selectDate(date) {
        $('.calendar-wrapper').updateCalendarOptions({
            date: date
        });
        let dateObject = new Date(date);
        let day = dateObject.getDate();
        let month = dateObject.getMonth();
        let year = dateObject.getFullYear();
        window.location.href = `/articles/date?year=${year}&month=${month}&day=${day}`;

    }
    var defaultConfig = {
        weekDayLength: 1,
        date: todayDate,
    onClickDate: selectDate,
        showYearDropdown: true,
                        };

$('.calendar-wrapper').calendar(defaultConfig);
})(jQuery);