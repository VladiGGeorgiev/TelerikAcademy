$(document).ready(function() {
	meetings.initializeCalendar();

	$("#datepicker").datepicker();

	$('#save').click(function() {
		sessionStorage.clear();
		var events = $('#calendar').fullCalendar('clientEvents');
		var i = 0;
		for(i = 0; i < events.length; i += 1){
			sessionStorage.setObject(events[i].title + i, 
				{start: events[i].start, title: events[i].title, className: events[i].className});
		}
	});

	$("#add-button").click(function() {
		var currTitle = $("#title").val();
		var date = $("#datepicker").datepicker( "getDate" );
		var currClass = 'blue';
		if($('#add-deadline:checked').val()) {
			currClass = 'red';
		}

		var currEvent = meetings.initializeEvent(date, currTitle, currClass);
		$('#calendar').fullCalendar('renderEvent', currEvent, true);
	});

	$("#add-temp-button").click(function() {
		var currTitle = $("#temp-title").val();
		var eventClass = 'meeting-event',
			conn = 'meeting-events';
		if($('#add-to-deadline:checked').val()) {
			conn = 'deadline-events';
			eventClass = 'deadline-event';
		}

		$("#" + conn + " p").before("<div class='" + eventClass + " ui-draggable'>" + currTitle + "</div>");
		meetings.initializeExternalEvent("#" + conn + " div." + eventClass);
	});
	
	meetings.loadMeetings();
});