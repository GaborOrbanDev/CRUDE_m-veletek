let viccek

const letöltésBefejeződött = (data) =>{
    console.log("Letöltés befejeződőtt")
    console.table(data)
    viccek = data

    for(let vicc of viccek){
        let viccNode = document.createElement("div")
        viccNode.innerHTML = `<p><b>Question:</b> ${vicc.question}</p><p><b>Answer:</b> ${vicc.answer}</p><hr>`
        document.body.appendChild(viccNode)
    }
}

const letöltés = () => {
    fetch('/jokes.json').then(response => response.json()).then(data => letöltésBefejeződött(data))
}

letöltés()