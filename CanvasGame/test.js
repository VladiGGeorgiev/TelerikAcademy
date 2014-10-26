function Person(name) {
    return {
        name: name,
        toString: function() {
            return "Name: " + this.name;
        }
    }
}

function Student(name, age) {
    var that = new Person(name);
    that.age = age;
    that.toString = function() {
        return  + "; Age:" + that.age;
    }

    return that;
}

var student = new Student("Pesho", 13);
console.log(student.toString());