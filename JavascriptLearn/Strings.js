console.log(parseInt("101", 10));

console.log(typeof((+"1.1") + (+"2"))); // 2.2

console.log(typeof +"B");
console.log(+"B");

// NaN kann nicht mit Nan verglichen werden
if (typeof+"B" == typeof(NaN)){
    console.log("true");
}

console.log(typeof("1.1"))
console.log(typeof(1.1))
if ("1.1" == 1.1){
    console.log("'1.1' == 1.1");
}
if ("1" === 1){
    console.log("'1' === 1");
}