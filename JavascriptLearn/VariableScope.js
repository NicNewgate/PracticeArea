// var - is available everywhere - dont use it! deprecaded
if (true){
    var x = 5
}
console.log(x);

console.log (x === undefined); // false
var x = 3;

// alte schreibwese von funktionen
(function (){
    console.log(x); //undefinded
    var x = "local value";
    console.log(x);
})();

// neue schreibweise von funktionen
(() => {
    var x = "deine mudda";
    console.log(x);
})();

console.log(x);
// const - can be only available in its blockstatement... can be used globally
//if (Math.random() > 0.5){
//    const y = 5
//}
//console.log(y)

// let -


// funktionen und scopes
const person = { 
    name: "anna", 
    greet() { 
        console.log(this.name); 
    } 
} 

person.greet();


// Eine Klasse
class meineKlasse{
    // Konstruktor
    constructor(name, func){
        // an unsere Property wird er Übergebende Name weiter gegebn
        this.name = name;
        this.func = func(this.name); // property-name wird an function "printNameOutClass" übergeben

        this.printNameInClass();
    }

    printNameInClass = () => {
        console.log(this.name + " -> printNameInClass");
    }
};
printNameOutClass = (derName) => {
    console.log(derName + " -> printNameOutClass");
};
let klasse = new meineKlasse("peter", printNameOutClass);

// mr pieps Klasse 
class Person { 
    constructor(name, func) { 
        this.name = name; 
        this.myFunc = func(this.name, this.myInnerFunc); 
    }; 
    myInnerFunc() { 
        console.log("Ich bin die methode - sagte mister pieps ruhig") 
    } 
}; 
const printName = (name, callback) => { 
    console.log(name); 
    callback(); 
}; 
let bla = new Person("pieps", printName);

console.log();

// mr pieps - eine aller aller letzte
class PiepsPerson { 
    constructor(name, func) { 
        this.name = name; 
        func(this.name, this.myInnerFunc.bind(this), this); 
    } 
    undEnde() { 
        console.log("und ich wurde hart am ende ausgeführt"); 
    } 
    myInnerFunc(callback) { 
        console.log("Ich bin die Methode"); 
        callback(); 
    } 
} 
const printDeName = (name, callback, person) => { 
    console.log(name); 
    callback(() => { 
        person.undEnde(); 
    }); 
}; 
new PiepsPerson("Pieps", printDeName);