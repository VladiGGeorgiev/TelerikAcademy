var meetings = (function() {
	var i = 0;
	
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

	function initializeEvent(date, currTitle, currClassName) {
		
			var eventObject = {
				title: currTitle,
			};
			
			$(this).data('eventObject', eventObject);
			var copiedEventObject = $.extend({}, eventObject);
				
			copiedEventObject.start = date;
			copiedEventObject.className = currClassName;

			return copiedEventObject;
	}

	function loadMeetings() {
		for(i = 0; i < sessionStorage.length; i += 1) {
			var currObject = sessionStorage.getObject(sessionStorage.key(i));
			var currEvent = initializeEvent(new Date(currObject.start), currObject.title, currObject.className);
			$('#calendar').fullCalendar('renderEvent', currEvent, true);
		}
	}

	var initializeCalendar = function() {
		initializeExternalEvent('div.draggable');
		$('#calendar').fullCalendar({
			header: {
				left: 'prev,next today',
				center: 'title',
				right: 'month,agendaWeek,agendaDay'
			},
			editable: true,
			droppable: true, 
			drop: function(date, allDay) {
				var currClass = 'blue'; 
				if($(this).attr('class').indexOf('deadline') != -1) {
					currClass = 'red';
				}

				var originalEventObject = $(this).data('eventObject');
				var copiedEventObject = $.extend({}, originalEventObject);
				
				copiedEventObject.start = date;
				copiedEventObject.allDay = allDay;
				copiedEventObject.className = currClass;

				$('#calendar').fullCalendar('renderEvent', copiedEventObject, true);
				
				if ($('.drop-remove').is(':checked')) {
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