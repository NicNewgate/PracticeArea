const coffees = ["French Roast", "Colombia", "Kona", 1];

console.log(coffees);
console.log(coffees[2]);

console.log(coffees.length)

coffees.length = 5;

console.log(coffees.length)

console.log(coffees);

// smth
const smth = [];
smth[105] = "blabla";
console.log(smth);


const arr = [];
arr[3.4] = "Oranges";
console.log(arr.length); // 0
console.log(arr);

for (let item in arr){
    console.log(item);
};

console.log(Object.hasOwn(arr, 3.4)); // true

// Will print the number of symbols in the string including whitespace.
console.log("Joyo's cat".length); // In this case, 10.

// String interpolation
const name = 'Lev', time = 'today';
console.log(`Hello ${name}, how are you ${time}?`)
