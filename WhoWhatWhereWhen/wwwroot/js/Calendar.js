let calendarEl = document.getElementById("calendar");

let calendar = new FullCalendar.Calendar(calendarEl, {
    initialView: 'dayGridMonth',
    headerToolbar: {
        left: 'prev,next today',
        center: 'title',
        right: 'dayGridMonth,timeGridWeek,timeGridDay'
    },
    events: [
        {
            title: "Record a video for Marisa",
            start: "2020-11-14"
        },
    ],
});

calendar.render();