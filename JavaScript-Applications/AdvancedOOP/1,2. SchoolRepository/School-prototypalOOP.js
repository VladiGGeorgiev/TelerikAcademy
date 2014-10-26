var Person = {
    init: function(firstName, lastName, age) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
    },
    
    introduce: function() {
        return "Name: " + this.firstName + " " + this.lastName + ", Age: " + this.age;
    },
}

var Student = Person.extend({
    init: function(firstName, lastName, age, grade) {
        this._super = Object.create(this._super);
        this._super.init(firstName, lastName, age);
        this.grade = grade;
    },
    
    introduce: function() {
        return this._super.introduce() + ", Grade: " + this.grade;
    },
});

var Teacher = Person.extend({
    init: function(firstName, lastName, age, faculty) {
        this._super = Object.create(this._super);
        this._super.init(firstName, lastName, age);
        this.faculty = faculty;
    },
    
    introduce: function() {
        return this._super.introduce() + ", Faculty: " + this.faculty;
    },
});
