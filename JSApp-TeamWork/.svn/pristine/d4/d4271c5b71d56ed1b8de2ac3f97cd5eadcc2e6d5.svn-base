var meetings = (function() {
	function initializeExternalEvent(object) {
		$(object).each(function() {
			
			var eventObject = {
				title: $.trim($(this).text()),
			};
			
			$(this).data('eventObject', eventObject);
			
			$(this).draggable({
				zIndex: 999,
				revert: true,      
				revertDuration: 0  
			});
			
		});
	}

	function initializeEvent(date, currTitle) {
		
			var eventObject = {
				title: currTitle,
			};
			
			$(this).data('eventObject', eventObject);
			var copiedEventObject = $.extend({}, eventObject);
				
			copiedEventObject.start = date;

			return copiedEventObject;
	}

	function loadMeetings() {
		for(i = 0; i < sessionStorage.length; i += 1) {
			var currObject = sessionStorage.getObject(sessionStorage.key(i));
			var currEvent = initializeEvent(new Date(currObject.start), currObject.title);
			$('#calendar').fullCalendar('renderEvent', currEvent, true);
		}
	}

	var initializeCalendar = function() {
		initializeExternalEvent('#external-events div.external-event');
		$('#calendar').fullCalendar({
			header: {
				left: 'prev,next today',
				center: 'title',
				right: 'month,agendaWeek,agendaDay'
			},
			editable: true,
			droppable: true, 
			drop: function(date, allDay) { 
				var originalEventObject = $(this).data('eventObject');
				var copiedEventObject = $.extend({}, originalEventObject);
				
				copiedEventObject.start = date;
				copiedEventObject.allDay = allDay;

				$('#calendar').fullCalendar('renderEvent', copiedEventObject, true);
				
				if ($('#drop-remove').is(':checked')) {
					$(this).remove();
				}

			},
			eventClick: function(event) {
				if(confirm('Are you sure from removing the event?')){
					$('#calendar').fullCalendar('removeEvents', event._id);
				} 
			}
		});
	};

	return {
		initializeCalendar: initializeCalendar,
		initializeEvent: initializeEvent,
		initializeExternalEvent: initializeExternalEvent,
		loadMeetings: loadMeetings
	};
})();

// Maiby in external file.
$(document).ready(function() {
	meetings.initializeCalendar();

	$("#datepicker").datepicker({
		inline: true
	});

	$('#save').click(function() {
		sessionStorage.clear();
		var events = $('#calendar').fullCalendar('clientEvents');
		var i = 0;
		for(i = 0; i < events.length; i += 1){
			sessionStorage.setObject(events[i].title + i, {start: events[i].start, title: events[i].title});
		}
	});

	$("#add-button").click(function() {
		var currTitle = $("#title").val();
		var date = $("#datepicker").datepicker( "getDate" );
		var currEvent = meetings.initializeEvent(date, currTitle);
		$('#calendar').fullCalendar('renderEvent', currEvent, true);
	});

	$("#add-temp-button").click(function() {
		var currTitle = $("#temp-title").val();
		$("#external-events p").before("<div class='external-event ui-draggable'>" + currTitle + "</div>");
		meetings.initializeExternalEvent("#external-events div.external-event");
	});
	
	meetings.loadMeetings();
});