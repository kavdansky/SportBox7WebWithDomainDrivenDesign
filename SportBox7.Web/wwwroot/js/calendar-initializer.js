


(function ($) {
    
    var currentDate; 
    getDateFromCurrentUrl();

    function getDateFromCurrentUrl() {
        let pattern = /\/articles\/date\?year=(\d+)&month=(\d+)&day=(\d+)/;
        let currentUrl = window.location.href;
        let result = currentUrl.match(pattern);
        currentDate = new Date();
        currentDate.setHours(0, 0, 0, 0);
        if (result) {

            currentDate = new Date(result[1], result[2], result[3]);
        }
    }
   
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
        date: currentDate,
    onClickDate: selectDate,
        showYearDropdown: true,
    };

    $('.calendar-wrapper').calendar(defaultConfig);

})(jQuery);


