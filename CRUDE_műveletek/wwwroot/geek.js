let viccek

const letöltésBefejeződött = (data) =>{
    console.log("Letöltés befejeződőtt")
    console.table(data)
    viccek = data
}

const letöltés = () => {
    fetch('/jokes.json').then(response => response.json()).then(data => letöltésBefejeződött(data))
}

letöltés()