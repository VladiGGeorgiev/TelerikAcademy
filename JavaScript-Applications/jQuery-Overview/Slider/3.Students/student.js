var students = (function(){
	var Student = {
		initialize : function(fname,lname,grade){
			this.fname = fname;
			this.lname = lname;
			this.grade = grade;
		}
	}
	var students = []
	function addStudent(fname,lname,grade){
		var student = {};
		$.extend(student,Student);
		student.initialize(fname,lname,grade);
		students.push(student);
	}

	function renderStudents(container)	{
		var table =	$(document.createElement("table"));
		table.append("<tr><th>First Name</th><th>Last Name</th><th>Grade</th></tr>");
		for (var i = 0; i < students.length; i++) {
			var tableRow = $(document.createElement("tr"));
			tableRow.append('<td>' + students[i].fname + '</td>');
			tableRow.append('<td>' + students[i].lname + '</td>');
			tableRow.append('<td>' + students[i].grade + '</td>');
			table.append(tableRow);
		};

		$(container).append(table);
	}

	return{
		addStudent : addStudent,
		render : renderStudents,
	}
})();