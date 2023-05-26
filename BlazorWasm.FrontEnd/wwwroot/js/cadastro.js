function mostrarSenha() {
    var x = document.getElementById("senha");
    if (x.type === "password") {
        x.type = "text";
    } else {
        x.type = "password";
    }
}

function termos() {
    const termosCheckbox = document.getElementById('termosCheck');
    const cadastroButton = document.getElementById('cadastroBtn');

    termosCheckbox.addEventListener('change', function () {
        cadastroButton.disabled = !this.checked;
    })
}