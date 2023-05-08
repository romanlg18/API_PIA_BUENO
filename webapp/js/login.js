const Login = document.getElementById("Form_Login")
Login.addEventListener('submit', evento =>{
    evento.preventDefault()
    const User = document.getElementById('User').value;
    const Contra = document.getElementById('Pass').value;

    fetch("https://localhost:7246/api/ClienteControlador/ObtenerCredenciales").then((data) =>{
        return data.json();
    }).then((objectData)=> {
        objectData.map((values)=>{
            if (User == `${values.usuario}` && Contra == `${values.password}`){
                window.location.href = 'http://127.0.0.1:5500/panel.html';
            }else{
                document.getElementById("mensaje").innerHTML = "Contraseña incorrecta";
            }
        })
    })
})

