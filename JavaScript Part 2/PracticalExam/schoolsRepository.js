var schoolsRepository = (function  () {
    function save(key, data) {
        localStorage.setItem(key, JSON.stringify(data));
    }

    function load(key) {
        return JSON.parse(localStorage.getItem(key));
    }

    return {
        load: load,
        save: save,
    }
}());

function School(params) {
    this.name = params.name;
    this.location = params.location;
    this.numberOfCourses = params.numberOfCourses;
    this.speciality = params.speciality;
    this.setOfCourses = params.setOfCourses;
};

function Course(params) {
    this.title = params.title;
    this.startDate = params.startDate;
    this.totalStudents = params.totalStudents;
    this.students = params.students;
};

function Student(params) {
    this.firstName = params.firstName;
    this.lastName = params.lastName;
    this.grade = params.grade;
    this.mark = params.mark;
};