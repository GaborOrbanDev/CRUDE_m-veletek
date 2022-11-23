const container = document.querySelector(".container")

const factorial = (n) => {
    if(n==0 || n== 1)
        return 1
    else{
        let result = 1
        for(let i = 1; i<=n; i++){
            result *= i
        }
        return result
    }
}

for(let sor = 0; sor<10; sor++){
    let sorContainer = document.createElement("div")
    sorContainer.classList.add(`sor`)
    for(let oszlop=0;oszlop<=sor;oszlop++){
        let box = document.createElement("div")
        let number = factorial(sor)/(factorial(oszlop)*factorial(sor-oszlop))
        box.innerHTML = number.toString()
        box.style.background = `rgb(${255-number*10}, ${255-number*140}, ${255-number*1.3}`
        box.style.color = "white"
        sorContainer.appendChild(box)
    }
    container.appendChild(sorContainer)
}